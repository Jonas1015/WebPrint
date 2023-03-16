using System;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using Zebra.Sdk.Printer;
using Zebra.Sdk.Comm;
using Zebra.Sdk.Printer.Discovery;
using Fleck;
using System.Text.Json;
using System.Data.SQLite;
using System.Data;
using System.Drawing.Printing;

namespace WebPrinting
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void Homepage_Load(object sender, EventArgs e)
        {
            try
            {
                string query = $"SELECT * FROM GeneralSettings;";

                SQLiteConnection connection = new SQLiteConnection(this.dbConnectionString);
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                LoadPrinters();
                LoadAvailablePrinters();
                if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["autoStart"].ToString() == "1")
                {
                    this.printServerAutoStart.Checked = true;
                    //Hide window
                    this.WindowState = FormWindowState.Minimized;
                    //
                    // Initiate Socket server as soon as the application is run
                    //
                    this.StartServer();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occured when starting an application. Error: {ex.Message}");
            }
        }

        private void StartServer()
        {
            WebSocketServer server = new WebSocketServer("ws://127.0.0.1:4444")
            {
                RestartAfterListenError = true
            };
            server.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    string welcomeMessage = JsonSerializer.Serialize(new SocketMessage
                    {
                        Type = "welcome",
                        Message = "Connected"
                    });
                    socket.Send(welcomeMessage);
                    Console.WriteLine("Client connected");
                };
                socket.OnClose = () => Console.WriteLine("Client disconnected");
                socket.OnMessage = (message) =>
                {
                    SocketMessage messageObject = JsonSerializer.Deserialize<SocketMessage>(message);
                    if (messageObject.Type.ToLower() == "print")
                    {
                        try
                        {
                            messageObject.PrintMessage();
                            string successMessage = JsonSerializer.Serialize(new SocketMessage
                            {
                                Type = "Success",
                                Message = "Print job is completed"
                            });
                            socket.Send(successMessage);
                        }
                        catch (Exception ex)
                        {
                            string exceptionMessage = JsonSerializer.Serialize(new SocketMessage
                            {
                                Type = "Error",
                                Message = $"{ex.Message}"
                            });
                            socket.Send(exceptionMessage);
                        }
                    }
                    else
                    {
                        messageObject.PrintMessage();
                        string unsupportedMessage = JsonSerializer.Serialize(new SocketMessage
                        {
                            Type = "unsupported",
                            Message = $"{messageObject.Type} type of message is unsupported."
                        });
                        socket.Send(unsupportedMessage);
                    }
                };
            });
        }

        private void LoadPrinters()
        {

            // Get all installed printers
            PrinterSettings.StringCollection printers = PrinterSettings.InstalledPrinters;

            // Loop through each printer and output its name
            foreach (string printer in printers)
            {
               this.printers.Items.Add(printer);
            }

        }

        private void LoadAvailablePrinters()
        {
            string query = $"SELECT * FROM PrinterSettings;";

            SQLiteConnection connection = new SQLiteConnection(this.dbConnectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(query, connection);
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            this.printersSettings.DataSource = dataTable;

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Visible = false;
            }
            else
            {
                base.OnFormClosing(e);
            }
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;

        }

        private void SavePrintServerSettingsButton_Click(object sender, EventArgs e)
        {
            try
            {
                var autostartValue = this.printServerAutoStart.Checked;
                int autoStart = 0;
                if (autostartValue)
                {
                    autoStart = 1;
                }

                string query = $"UPDATE GeneralSettings set autoStart={autoStart} WHERE id=1;";
                SQLiteConnection connection = new SQLiteConnection(this.dbConnectionString);
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                var response = command.ExecuteNonQuery();
                if (response > 0)
                {
                    this.printServerAutoStart.Checked = autostartValue;
                    MessageBox.Show("Saved successfully");
                }
                else
                {
                    MessageBox.Show("Couldn't save data into the database.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Encountered an error when trying to save. Error: {ex.Message}");
            }
        }

        private void SavePrintersSettingsButton_Click(object sender, EventArgs e)
        {
            try
            {
                string printer = this.printers.SelectedItem.ToString();
                int useThisPrinter = 0;
                string zplCommands = this.zplCommands.Text;
                if (this.useThisPrinter.Checked) useThisPrinter = 1;

                string query = $"INSERT INTO PrinterSettings Values (NULL ,'{printer}','{zplCommands}',{useThisPrinter});";
                SQLiteConnection connection = new SQLiteConnection(this.dbConnectionString);
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                var response = command.ExecuteNonQuery();
                if (response > 0)
                {
                    MessageBox.Show("Printer settings saved successfully");
                }
                else
                {
                    MessageBox.Show("Couldn't save data into the database.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occured while trying to save printer settings. Error: {ex.Message}");
            }
        }
    }

    public class SocketMessage
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public void PrintMessage()
        {
            foreach (DiscoveredUsbPrinter usbPrinter in UsbDiscoverer.GetZebraUsbPrinters(new ZebraPrinterFilter()))
            {
                Connection conn = usbPrinter.GetConnection();
                if (conn != null)
                {
                    try
                    {
                        conn.Open();
                        if (conn.Connected)
                        {
                            ZebraPrinter printer = ZebraPrinterFactory.GetInstance(conn);

                            byte[] zplData = Encoding.ASCII.GetBytes(this.Message);

                            conn.Write(zplData);
                            conn.Close();
                            break;

                        }
                        else
                        {
                            conn.Close();
                            continue;
                        }

                    }
                    catch (ConnectionException ex)
                    {
                        // Handle exception
                        MessageBox.Show($"Print error: {ex.StackTrace}");
                        continue;
                    }
                    finally { conn.Close(); }
                }
                else
                {
                    MessageBox.Show("No printer connection");
                    continue;
                }

            }

        }
    }

}
