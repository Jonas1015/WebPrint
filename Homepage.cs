using System;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using Zebra.Sdk.Printer;
using Zebra.Sdk.Comm;
using Zebra.Sdk.Printer.Discovery;

namespace WebPrinting
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }
    }

    class Message
    {
        public string type { get; set; }
        public string message { get; set; }

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

                            byte[] zplData = Encoding.ASCII.GetBytes(this.message);

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
