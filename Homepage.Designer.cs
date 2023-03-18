using Fleck;
using System;
using System.Windows.Forms;
using System.Text;
using System.Configuration;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Homepage));
            this.printButton = new System.Windows.Forms.Button();
            this.printersList = new System.Windows.Forms.ListBox();
            this.reloadPrinters = new System.Windows.Forms.Label();
            this.setupTab = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.homePageTabControl = new System.Windows.Forms.TabControl();
            this.welcomePage = new System.Windows.Forms.TabPage();
            this.manualStart = new System.Windows.Forms.Button();
            this.printersListPage = new System.Windows.Forms.TabPage();
            this.deletePrinterSettings = new System.Windows.Forms.Button();
            this.editPrinterSettings = new System.Windows.Forms.Button();
            this.reloadPrintersList = new System.Windows.Forms.Button();
            this.printersSettings = new System.Windows.Forms.DataGridView();
            this.settingsPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.testZPL = new System.Windows.Forms.Button();
            this.savePrintersSettingsButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.zplCommands = new System.Windows.Forms.TextBox();
            this.printerSelectionLabel = new System.Windows.Forms.Label();
            this.useThisPrinter = new System.Windows.Forms.CheckBox();
            this.printers = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.port = new System.Windows.Forms.TextBox();
            this.ipAddress = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.savePrintServerSettingsButton = new System.Windows.Forms.Button();
            this.addressLabel = new System.Windows.Forms.Label();
            this.printServerAutoStart = new System.Windows.Forms.CheckBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.homePageTabControl.SuspendLayout();
            this.welcomePage.SuspendLayout();
            this.printersListPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.printersSettings)).BeginInit();
            this.settingsPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.printersList.Size = new System.Drawing.Size(120, 95);
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
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(30, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 207);
            this.label1.TabIndex = 2;
            this.label1.Text = "DHIS2 LAB ZEBRA PRINT MODULE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Print Server";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseDoubleClick);
            // 
            // homePageTabControl
            // 
            this.homePageTabControl.Controls.Add(this.welcomePage);
            this.homePageTabControl.Controls.Add(this.printersListPage);
            this.homePageTabControl.Controls.Add(this.settingsPage);
            this.homePageTabControl.Location = new System.Drawing.Point(13, 13);
            this.homePageTabControl.Name = "homePageTabControl";
            this.homePageTabControl.SelectedIndex = 0;
            this.homePageTabControl.Size = new System.Drawing.Size(783, 434);
            this.homePageTabControl.TabIndex = 4;
            // 
            // welcomePage
            // 
            this.welcomePage.BackgroundImage = global::WebPrinting.Properties.Resources.PrintServer;
            this.welcomePage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.welcomePage.Controls.Add(this.manualStart);
            this.welcomePage.Controls.Add(this.label1);
            this.welcomePage.Location = new System.Drawing.Point(4, 22);
            this.welcomePage.Name = "welcomePage";
            this.welcomePage.Padding = new System.Windows.Forms.Padding(3);
            this.welcomePage.Size = new System.Drawing.Size(775, 408);
            this.welcomePage.TabIndex = 0;
            this.welcomePage.Text = "Welcome";
            this.welcomePage.UseVisualStyleBackColor = true;
            // 
            // manualStart
            // 
            this.manualStart.BackColor = System.Drawing.Color.Gainsboro;
            this.manualStart.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.manualStart.FlatAppearance.BorderSize = 40;
            this.manualStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manualStart.Location = new System.Drawing.Point(62, 307);
            this.manualStart.Name = "manualStart";
            this.manualStart.Size = new System.Drawing.Size(157, 38);
            this.manualStart.TabIndex = 3;
            this.manualStart.Text = "Start Print Server";
            this.manualStart.UseVisualStyleBackColor = false;
            this.manualStart.Click += new System.EventHandler(this.ManualStart_Click);
            // 
            // printersListPage
            // 
            this.printersListPage.Controls.Add(this.deletePrinterSettings);
            this.printersListPage.Controls.Add(this.editPrinterSettings);
            this.printersListPage.Controls.Add(this.reloadPrintersList);
            this.printersListPage.Controls.Add(this.printersSettings);
            this.printersListPage.Location = new System.Drawing.Point(4, 22);
            this.printersListPage.Name = "printersListPage";
            this.printersListPage.Size = new System.Drawing.Size(775, 408);
            this.printersListPage.TabIndex = 2;
            this.printersListPage.Text = "Printers List";
            this.printersListPage.UseVisualStyleBackColor = true;
            // 
            // deletePrinterSettings
            // 
            this.deletePrinterSettings.Location = new System.Drawing.Point(671, 149);
            this.deletePrinterSettings.Name = "deletePrinterSettings";
            this.deletePrinterSettings.Size = new System.Drawing.Size(91, 36);
            this.deletePrinterSettings.TabIndex = 3;
            this.deletePrinterSettings.Text = "Delete";
            this.deletePrinterSettings.UseVisualStyleBackColor = true;
            this.deletePrinterSettings.Click += new System.EventHandler(this.DeletePrinterSettings_Click);
            // 
            // editPrinterSettings
            // 
            this.editPrinterSettings.Location = new System.Drawing.Point(671, 77);
            this.editPrinterSettings.Name = "editPrinterSettings";
            this.editPrinterSettings.Size = new System.Drawing.Size(91, 36);
            this.editPrinterSettings.TabIndex = 2;
            this.editPrinterSettings.Text = "Edit";
            this.editPrinterSettings.UseVisualStyleBackColor = true;
            this.editPrinterSettings.Click += new System.EventHandler(this.EditPrinterSettings_Click);
            // 
            // reloadPrintersList
            // 
            this.reloadPrintersList.Location = new System.Drawing.Point(671, 13);
            this.reloadPrintersList.Name = "reloadPrintersList";
            this.reloadPrintersList.Size = new System.Drawing.Size(91, 36);
            this.reloadPrintersList.TabIndex = 1;
            this.reloadPrintersList.Text = "Reload";
            this.reloadPrintersList.UseVisualStyleBackColor = true;
            this.reloadPrintersList.Click += new System.EventHandler(this.ReloadPrintersList_Click);
            // 
            // printersSettings
            // 
            this.printersSettings.AllowDrop = true;
            this.printersSettings.AllowUserToAddRows = false;
            this.printersSettings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.printersSettings.BackgroundColor = System.Drawing.Color.White;
            this.printersSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.printersSettings.Dock = System.Windows.Forms.DockStyle.Left;
            this.printersSettings.Location = new System.Drawing.Point(0, 0);
            this.printersSettings.Name = "printersSettings";
            this.printersSettings.ReadOnly = true;
            this.printersSettings.Size = new System.Drawing.Size(653, 408);
            this.printersSettings.TabIndex = 0;
            // 
            // settingsPage
            // 
            this.settingsPage.Controls.Add(this.groupBox2);
            this.settingsPage.Controls.Add(this.groupBox1);
            this.settingsPage.Location = new System.Drawing.Point(4, 22);
            this.settingsPage.Name = "settingsPage";
            this.settingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.settingsPage.Size = new System.Drawing.Size(775, 408);
            this.settingsPage.TabIndex = 1;
            this.settingsPage.Text = "Settings";
            this.settingsPage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.testZPL);
            this.groupBox2.Controls.Add(this.savePrintersSettingsButton);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.zplCommands);
            this.groupBox2.Controls.Add(this.printerSelectionLabel);
            this.groupBox2.Controls.Add(this.useThisPrinter);
            this.groupBox2.Controls.Add(this.printers);
            this.groupBox2.Location = new System.Drawing.Point(6, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(763, 294);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Printer Settings";
            // 
            // testZPL
            // 
            this.testZPL.Location = new System.Drawing.Point(531, 237);
            this.testZPL.Name = "testZPL";
            this.testZPL.Size = new System.Drawing.Size(98, 35);
            this.testZPL.TabIndex = 14;
            this.testZPL.Text = "Test ZPL";
            this.testZPL.UseVisualStyleBackColor = true;
            this.testZPL.Click += new System.EventHandler(this.TestZPL_Click);
            // 
            // savePrintersSettingsButton
            // 
            this.savePrintersSettingsButton.Location = new System.Drawing.Point(646, 237);
            this.savePrintersSettingsButton.Name = "savePrintersSettingsButton";
            this.savePrintersSettingsButton.Size = new System.Drawing.Size(107, 35);
            this.savePrintersSettingsButton.TabIndex = 11;
            this.savePrintersSettingsButton.Text = "Save ";
            this.savePrintersSettingsButton.UseVisualStyleBackColor = true;
            this.savePrintersSettingsButton.Click += new System.EventHandler(this.SavePrintersSettingsButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "ZPL Commands";
            // 
            // zplCommands
            // 
            this.zplCommands.Location = new System.Drawing.Point(107, 83);
            this.zplCommands.Multiline = true;
            this.zplCommands.Name = "zplCommands";
            this.zplCommands.Size = new System.Drawing.Size(375, 189);
            this.zplCommands.TabIndex = 13;
            // 
            // printerSelectionLabel
            // 
            this.printerSelectionLabel.AutoSize = true;
            this.printerSelectionLabel.Location = new System.Drawing.Point(12, 41);
            this.printerSelectionLabel.Name = "printerSelectionLabel";
            this.printerSelectionLabel.Size = new System.Drawing.Size(68, 13);
            this.printerSelectionLabel.TabIndex = 8;
            this.printerSelectionLabel.Text = "Printer Name";
            // 
            // useThisPrinter
            // 
            this.useThisPrinter.AutoSize = true;
            this.useThisPrinter.Location = new System.Drawing.Point(531, 41);
            this.useThisPrinter.Name = "useThisPrinter";
            this.useThisPrinter.Size = new System.Drawing.Size(135, 17);
            this.useThisPrinter.TabIndex = 5;
            this.useThisPrinter.Text = "Use this printer settings";
            this.useThisPrinter.UseVisualStyleBackColor = true;
            // 
            // printers
            // 
            this.printers.FormattingEnabled = true;
            this.printers.Location = new System.Drawing.Point(107, 41);
            this.printers.Name = "printers";
            this.printers.Size = new System.Drawing.Size(375, 21);
            this.printers.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.port);
            this.groupBox1.Controls.Add(this.ipAddress);
            this.groupBox1.Controls.Add(this.portLabel);
            this.groupBox1.Controls.Add(this.savePrintServerSettingsButton);
            this.groupBox1.Controls.Add(this.addressLabel);
            this.groupBox1.Controls.Add(this.printServerAutoStart);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(763, 96);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Print Server Settings";
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(408, 57);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(75, 20);
            this.port.TabIndex = 18;
            // 
            // ipAddress
            // 
            this.ipAddress.Location = new System.Drawing.Point(108, 57);
            this.ipAddress.Name = "ipAddress";
            this.ipAddress.Size = new System.Drawing.Size(190, 20);
            this.ipAddress.TabIndex = 17;
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(376, 57);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(26, 13);
            this.portLabel.TabIndex = 16;
            this.portLabel.Text = "Port";
            // 
            // savePrintServerSettingsButton
            // 
            this.savePrintServerSettingsButton.Location = new System.Drawing.Point(646, 47);
            this.savePrintServerSettingsButton.Name = "savePrintServerSettingsButton";
            this.savePrintServerSettingsButton.Size = new System.Drawing.Size(107, 33);
            this.savePrintServerSettingsButton.TabIndex = 2;
            this.savePrintServerSettingsButton.Text = "Save ";
            this.savePrintServerSettingsButton.UseVisualStyleBackColor = true;
            this.savePrintServerSettingsButton.Click += new System.EventHandler(this.SavePrintServerSettingsButton_Click);
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(12, 57);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(58, 13);
            this.addressLabel.TabIndex = 15;
            this.addressLabel.Text = "IP Address";
            // 
            // printServerAutoStart
            // 
            this.printServerAutoStart.AutoSize = true;
            this.printServerAutoStart.Location = new System.Drawing.Point(15, 19);
            this.printServerAutoStart.Name = "printServerAutoStart";
            this.printServerAutoStart.Size = new System.Drawing.Size(131, 17);
            this.printServerAutoStart.TabIndex = 1;
            this.printServerAutoStart.Text = "Print Server Auto Start";
            this.printServerAutoStart.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.homePageTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Homepage";
            this.Text = "Print Server";
            this.Load += new System.EventHandler(this.Homepage_Load);
            this.homePageTabControl.ResumeLayout(false);
            this.welcomePage.ResumeLayout(false);
            this.printersListPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.printersSettings)).EndInit();
            this.settingsPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private TabPage setupTab;
        private ListBox printersList;
        private Label reloadPrinters;
        private Button printButton;
        private Label label1;
        private NotifyIcon notifyIcon1;
        private TabControl homePageTabControl;
        private TabPage welcomePage;
        private TabPage settingsPage;
        private CheckBox useThisPrinter;
        private Button savePrintServerSettingsButton;
        private CheckBox printServerAutoStart;
        private Label printerSelectionLabel;
        private ComboBox printers;
        private Button savePrintersSettingsButton;
        private Label label5;
        private TabPage printersListPage;
        private string dbConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        private TextBox zplCommands;
        private DataGridView printersSettings;
        private Button deletePrinterSettings;
        private Button editPrinterSettings;
        private Button reloadPrintersList;
        private Button manualStart;
        private Button testZPL;
        private GroupBox groupBox1;
        private Label portLabel;
        private Label addressLabel;
        private TextBox port;
        private TextBox ipAddress;
        private GroupBox groupBox2;
        private ImageList imageList1;
    }
}

