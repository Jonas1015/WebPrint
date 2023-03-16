﻿using System;
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

                    manualStart.Visible = false;
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
                        Description = "Connected"
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
                            string zplCommands = GetZPLCommands();

                            zplCommands = zplCommands.Replace("{{SampleID}}", messageObject.Message.SampleID);
                            zplCommands = zplCommands.Replace("{{Department}}", messageObject.Message.Department);
                            zplCommands = zplCommands.Replace("{{Tests}}", messageObject.Message.Tests);
                            zplCommands = zplCommands.Replace("{{Storage}}", messageObject.Message.Storage);
                            zplCommands = zplCommands.Replace("{{PatientNames}}", messageObject.Message.PatientNames);

                            PrintMessage(zplCommands);
                            Console.WriteLine(zplCommands);
                            string successMessage = JsonSerializer.Serialize(new SocketMessage
                            {
                                Type = "Success",
                                Description = "Print job is completed"
                            });
                            socket.Send(successMessage);
                        }
                        catch (Exception ex)
                        {
                            string exceptionMessage = JsonSerializer.Serialize(new SocketMessage
                            {
                                Type = "Error",
                                Description = $"{ex.Message}"
                            });
                            socket.Send(exceptionMessage);
                        }
                    }
                    else
                    {
                        string unsupportedMessage = JsonSerializer.Serialize(new SocketMessage
                        {
                            Type = "unsupported",
                            Description = $"{messageObject.Type} type of message is unsupported."
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
            DataTable dataTable2 = new DataTable();
            dataAdapter.Fill(dataTable);
            dataTable2.Columns.Add("S/N");
            dataTable2.Columns.Add("Printer Name");
            dataTable2.Columns.Add("ZPL Command"); 
            dataTable2.Columns.Add("In Use");

            int count = 1;
            foreach (DataRow row in dataTable.Rows)
            {
                DataRow newRow = dataTable2.NewRow();
                newRow["S/N"] = count;
                newRow["Printer Name"] = row["printerModel"];
                newRow["ZPL Command"] = row["zplCommands"];
                string useThis = "No";
                if (row["useThis"].ToString() == "1") useThis = "Yes";
                newRow["In Use"] = useThis;
                dataTable2.Rows.Add(newRow);
                count++;
            }
            this.printersSettings.DataSource = dataTable2;

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
                    if (autostartValue)
                    {
                        StartServer();
                        manualStart.Visible = false;
                    }
                    else manualStart.Visible = true;
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
                SQLiteConnection connection = new SQLiteConnection(this.dbConnectionString);
                connection.Open();

                string printer = this.printers.SelectedItem.ToString();
                int useThisPrinter = 0;
                string zplCommands = this.zplCommands.Text;
                if (this.useThisPrinter.Checked) useThisPrinter = 1;

                string existingPrinter = $"SELECT * FROM PrinterSettings WHERE printerModel='{printer}';";

                SQLiteCommand existingPrinterCommand = new SQLiteCommand(existingPrinter, connection);
                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(existingPrinterCommand);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                if(dataTable.Rows.Count == 0)
                {
                    string query = $"INSERT INTO PrinterSettings Values (NULL ,'{printer}','{zplCommands}',{useThisPrinter});";

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
                if (dataTable.Rows.Count == 1)
                {
                    string query = $"UPDATE PrinterSettings SET printerModel='{printer}', zplCommands='{zplCommands}', useThis={useThisPrinter} WHERE id={dataTable.Rows[0]["id"]};";

                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    var response = command.ExecuteNonQuery();
                    if (response > 0)
                    {
                        MessageBox.Show("Printer settings updated successfully");
                    }
                    else
                    {
                        MessageBox.Show("Couldn't update data into the database.");
                    }
                }
                if (dataTable.Rows.Count > 1)
                {
                    MessageBox.Show("Couldn't update data into the database because more than 1 records was found from the database.");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occured while trying to save printer settings. Error: {ex.Message}");
            }
        }

        private void EditPrinterSettings_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.printersSettings.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow = this.printersSettings.SelectedRows[0];

                    // Get the data from the selected row
                    string printerName = selectedRow.Cells["Printer Name"].Value.ToString();
                    string zplCommands = selectedRow.Cells["ZPL Command"].Value.ToString();
                    bool useThis = false;
                    if (selectedRow.Cells["In Use"].Value.ToString() == "Yes") useThis = true;

                    this.printers.Text = printerName;
                    this.zplCommands.Text = zplCommands;
                    this.useThisPrinter.Checked = useThis;
                    this.homePageTabControl.SelectedTab = this.settingsPage;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Couldn't edit. Error: {ex.Message}");
            }
        }

        private void ReloadPrintersList_Click(object sender, EventArgs e)
        {
            try
            {
                LoadAvailablePrinters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Couldn't reload printers list. Error: {ex.Message}");
            }
        }

        private void DeletePrinterSettings_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection connection = new SQLiteConnection(this.dbConnectionString);
                connection.Open();

                if (this.printersSettings.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow = this.printersSettings.SelectedRows[0];

                    // Get the data from the selected row
                    string printerName = selectedRow.Cells["Printer Name"].Value.ToString();

                    string deletePrinter = $"DELETE FROM PrinterSettings WHERE printerModel='{printerName}';";

                    SQLiteCommand deletePrinterCommand = new SQLiteCommand(deletePrinter, connection);
                    var response = deletePrinterCommand.ExecuteNonQuery();

                    if(response > 0)
                    {
                        MessageBox.Show($"{printerName} settings deleted successfully.");
                        LoadAvailablePrinters();
                    } else
                    {
                        MessageBox.Show($"{printerName} settings could not be deleted.");
                    }


                }


                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occured while trying to save printer settings. Error: {ex.Message}");
            }
        }

        private string GetZPLCommands()
        {
            try
            {
                SQLiteConnection connection = new SQLiteConnection(this.dbConnectionString);
                connection.Open();

                string query = $"SELECT zplCommands FROM PrinterSettings WHERE useThis=1;";

                SQLiteCommand selectQuery = new SQLiteCommand(query, connection);

                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(selectQuery);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                return dataTable.Rows[0]["zplCommands"].ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Couldn't load saved zpl commands to be used. Error: {ex.Message}");
                return "";
            }
            
        }

        private void PrintMessage(string message)
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

                            byte[] zplData = Encoding.ASCII.GetBytes(message);

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

        private void ManualStart_Click(object sender, EventArgs e)
        {
            this.StartServer();
        }
    }

    public class SocketMessage
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public IncomingMessage Message { get; set; }
    }

    public class IncomingMessage
    {
        public string SampleID { get; set; }
        public string Tests { get; set; }
        public string PatientNames { get; set; }
        public string Storage { get; set; }
        public string Department { get; set; }
    }
}
