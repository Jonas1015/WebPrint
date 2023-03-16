using Fleck;
using System;
using System.Windows.Forms;
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
            this.zplCommands = new System.Windows.Forms.TextBox();
            this.printers = new System.Windows.Forms.ComboBox();
            this.savePrintersSettingsButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.useThisPrinter = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.savePrintServerSettingsButton = new System.Windows.Forms.Button();
            this.printServerAutoStart = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.homePageTabControl.SuspendLayout();
            this.welcomePage.SuspendLayout();
            this.printersListPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.printersSettings)).BeginInit();
            this.settingsPage.SuspendLayout();
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
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(131, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(522, 56);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome to Printing Module.";
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
            this.manualStart.Location = new System.Drawing.Point(283, 344);
            this.manualStart.Name = "manualStart";
            this.manualStart.Size = new System.Drawing.Size(157, 38);
            this.manualStart.TabIndex = 3;
            this.manualStart.Text = "Start Print Server";
            this.manualStart.UseVisualStyleBackColor = true;
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
            this.settingsPage.Controls.Add(this.zplCommands);
            this.settingsPage.Controls.Add(this.printers);
            this.settingsPage.Controls.Add(this.savePrintersSettingsButton);
            this.settingsPage.Controls.Add(this.label5);
            this.settingsPage.Controls.Add(this.label6);
            this.settingsPage.Controls.Add(this.useThisPrinter);
            this.settingsPage.Controls.Add(this.label4);
            this.settingsPage.Controls.Add(this.savePrintServerSettingsButton);
            this.settingsPage.Controls.Add(this.printServerAutoStart);
            this.settingsPage.Controls.Add(this.label3);
            this.settingsPage.Location = new System.Drawing.Point(4, 22);
            this.settingsPage.Name = "settingsPage";
            this.settingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.settingsPage.Size = new System.Drawing.Size(775, 408);
            this.settingsPage.TabIndex = 1;
            this.settingsPage.Text = "Settings";
            this.settingsPage.UseVisualStyleBackColor = true;
            // 
            // zplCommands
            // 
            this.zplCommands.Location = new System.Drawing.Point(114, 173);
            this.zplCommands.Multiline = true;
            this.zplCommands.Name = "zplCommands";
            this.zplCommands.Size = new System.Drawing.Size(375, 189);
            this.zplCommands.TabIndex = 13;
            // 
            // printers
            // 
            this.printers.FormattingEnabled = true;
            this.printers.Location = new System.Drawing.Point(114, 132);
            this.printers.Name = "printers";
            this.printers.Size = new System.Drawing.Size(375, 21);
            this.printers.TabIndex = 12;
            // 
            // savePrintersSettingsButton
            // 
            this.savePrintersSettingsButton.Location = new System.Drawing.Point(614, 321);
            this.savePrintersSettingsButton.Name = "savePrintersSettingsButton";
            this.savePrintersSettingsButton.Size = new System.Drawing.Size(107, 41);
            this.savePrintersSettingsButton.TabIndex = 11;
            this.savePrintersSettingsButton.Text = "Save ";
            this.savePrintersSettingsButton.UseVisualStyleBackColor = true;
            this.savePrintersSettingsButton.Click += new System.EventHandler(this.SavePrintersSettingsButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "ZPL Commands";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Printer Name";
            // 
            // useThisPrinter
            // 
            this.useThisPrinter.AutoSize = true;
            this.useThisPrinter.Location = new System.Drawing.Point(586, 132);
            this.useThisPrinter.Name = "useThisPrinter";
            this.useThisPrinter.Size = new System.Drawing.Size(135, 17);
            this.useThisPrinter.TabIndex = 5;
            this.useThisPrinter.Text = "Use this printer settings";
            this.useThisPrinter.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Printers Settings";
            // 
            // savePrintServerSettingsButton
            // 
            this.savePrintServerSettingsButton.Location = new System.Drawing.Point(325, 40);
            this.savePrintServerSettingsButton.Name = "savePrintServerSettingsButton";
            this.savePrintServerSettingsButton.Size = new System.Drawing.Size(75, 23);
            this.savePrintServerSettingsButton.TabIndex = 2;
            this.savePrintServerSettingsButton.Text = "Save ";
            this.savePrintServerSettingsButton.UseVisualStyleBackColor = true;
            this.savePrintServerSettingsButton.Click += new System.EventHandler(this.SavePrintServerSettingsButton_Click);
            // 
            // printServerAutoStart
            // 
            this.printServerAutoStart.AutoSize = true;
            this.printServerAutoStart.Location = new System.Drawing.Point(21, 44);
            this.printServerAutoStart.Name = "printServerAutoStart";
            this.printServerAutoStart.Size = new System.Drawing.Size(131, 17);
            this.printServerAutoStart.TabIndex = 1;
            this.printServerAutoStart.Text = "Print Server Auto Start";
            this.printServerAutoStart.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label3.Location = new System.Drawing.Point(18, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Print Server Settings";
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
            this.settingsPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private TabPage setupTab;
        private ListBox printersList;
        private Label reloadPrinters;
        private Button itemButton;
        private Button printButton;
        private string selectedPrinter;
        private Label label1;
        private NotifyIcon notifyIcon1;
        private TabControl homePageTabControl;
        private TabPage welcomePage;
        private TabPage settingsPage;
        private CheckBox useThisPrinter;
        private Label label4;
        private Button savePrintServerSettingsButton;
        private CheckBox printServerAutoStart;
        private Label label3;
        private Label label6;
        private ComboBox printers;
        private Button savePrintersSettingsButton;
        private Label label5;
        private TabPage printersListPage;
        private string dbConnectionString = "Data Source=WebPrintServerDB.db;Version=3;";
        private TextBox zplCommands;
        private DataGridView printersSettings;
        private Button deletePrinterSettings;
        private Button editPrinterSettings;
        private Button reloadPrintersList;
        private Button manualStart;
    }
}

