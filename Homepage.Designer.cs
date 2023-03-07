using Fleck;
using System;
using System.Windows.Forms;
using System.Text.Json;
using System.Text;

namespace WebPrinting
{
    partial class Homepage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loadPrinters = new System.Windows.Forms.TabPage();
            this.printButton = new System.Windows.Forms.Button();
            this.printersList = new System.Windows.Forms.ListBox();
            this.reloadPrinters = new System.Windows.Forms.Label();
            this.setupTab = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loadPrinters
            // 
            this.loadPrinters.Location = new System.Drawing.Point(0, 0);
            this.loadPrinters.Name = "loadPrinters";
            this.loadPrinters.Size = new System.Drawing.Size(200, 100);
            this.loadPrinters.TabIndex = 0;
            // 
            // printButton
            // 
            this.printButton.Location = new System.Drawing.Point(0, 0);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(75, 23);
            this.printButton.TabIndex = 0;
            // 
            // printersList
            // 
            this.printersList.Location = new System.Drawing.Point(0, 0);
            this.printersList.Name = "printersList";
            this.printersList.Size = new System.Drawing.Size(120, 96);
            this.printersList.TabIndex = 0;
            // 
            // reloadPrinters
            // 
            this.reloadPrinters.Location = new System.Drawing.Point(0, 0);
            this.reloadPrinters.Name = "reloadPrinters";
            this.reloadPrinters.Size = new System.Drawing.Size(100, 23);
            this.reloadPrinters.TabIndex = 0;
            // 
            // setupTab
            // 
            this.setupTab.Location = new System.Drawing.Point(0, 0);
            this.setupTab.Name = "setupTab";
            this.setupTab.Size = new System.Drawing.Size(200, 100);
            this.setupTab.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(139, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(522, 56);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome to Printing Module.";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(209, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(360, 38);
            this.label2.TabIndex = 3;
            this.label2.Text = "Minimize this window and continue to work";
            // 
            // Homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Homepage";
            this.Text = "Homepage";
            this.ResumeLayout(false);

            //
            //Initiate Socket server as soon as the application is run
            //
            
            var server = new WebSocketServer("ws://127.0.0.1:4444");
            server.RestartAfterListenError = true;
            server.Start(socket =>
            {
                socket.OnOpen = () => 
                {
                    string welcomeMessage = JsonSerializer.Serialize(new Message
                    {
                        type = "welcome",
                        message = "Connected"
                    });
                    socket.Send(welcomeMessage);
                };
                socket.OnClose = () => Console.WriteLine("Client disconnected");
                socket.OnMessage = (message) =>
                {
                    Message messageObject = JsonSerializer.Deserialize<Message>(message);
                    if (messageObject.type.ToLower() == "print")
                    {
                        try
                        {
                            messageObject.PrintMessage();
                            string successMessage = JsonSerializer.Serialize(new Message
                            {
                                type = "Success",
                                message = "Print job is completed"
                            });
                            socket.Send(successMessage);
                        }
                        catch (Exception ex)
                        {
                            string exceptionMessage = JsonSerializer.Serialize(new Message
                            {
                                type = "Error",
                                message = $"{ex.Message}"
                            });
                            socket.Send(exceptionMessage);
                        }
                    } 
                    else
                    {
                        messageObject.PrintMessage();
                        string unsupportedMessage = JsonSerializer.Serialize(new Message
                        {
                            type = "unsupported",
                            message = $"{messageObject.type} type of message is unsupported."
                        });
                        socket.Send(unsupportedMessage);
                    }
                };
            });

        }

        #endregion
        private TabPage loadPrinters;
        private TabPage setupTab;
        private ListBox printersList;
        private Label reloadPrinters;
        private Button itemButton;
        private Button printButton;
        private string selectedPrinter;
        private Label label1;
        private Label label2;
    }
}

