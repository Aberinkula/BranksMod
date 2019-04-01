namespace BranksMod
{
    partial class MainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.MStrip = new System.Windows.Forms.MenuStrip();
            this.FileMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFolderMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckUpdatesMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.ReinstallMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.UninstallMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.TroubleshootingMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.RLLbl = new System.Windows.Forms.Label();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.ProcessTmr = new System.Windows.Forms.Timer(this.components);
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenTrayBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitTrayBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.InjectionTmr = new System.Windows.Forms.Timer(this.components);
            this.InjectBtn = new System.Windows.Forms.PictureBox();
            this.StatusImg = new System.Windows.Forms.PictureBox();
            this.RLImg = new System.Windows.Forms.PictureBox();
            this.MStrip.SuspendLayout();
            this.TrayMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InjectBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RLImg)).BeginInit();
            this.SuspendLayout();
            // 
            // MStrip
            // 
            this.MStrip.BackColor = System.Drawing.Color.White;
            this.MStrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuBtn,
            this.SettingsMenuBtn,
            this.TroubleshootingMenuBtn});
            this.MStrip.Location = new System.Drawing.Point(0, 0);
            this.MStrip.Name = "MStrip";
            this.MStrip.Size = new System.Drawing.Size(309, 24);
            this.MStrip.TabIndex = 0;
            this.MStrip.Text = "MStrip";
            // 
            // FileMenuBtn
            // 
            this.FileMenuBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFolderMenuBtn,
            this.CheckUpdatesMenuBtn,
            this.ReinstallMenuBtn,
            this.UninstallMenuBtn,
            this.ExitMenuBtn});
            this.FileMenuBtn.Image = global::BranksMod.Properties.Resources.Menu;
            this.FileMenuBtn.Name = "FileMenuBtn";
            this.FileMenuBtn.Size = new System.Drawing.Size(67, 20);
            this.FileMenuBtn.Text = "Menu";
            // 
            // OpenFolderMenuBtn
            // 
            this.OpenFolderMenuBtn.ForeColor = System.Drawing.Color.Black;
            this.OpenFolderMenuBtn.Image = global::BranksMod.Properties.Resources.Open;
            this.OpenFolderMenuBtn.Name = "OpenFolderMenuBtn";
            this.OpenFolderMenuBtn.Size = new System.Drawing.Size(210, 22);
            this.OpenFolderMenuBtn.Text = "Open BakkesMod Folder";
            this.OpenFolderMenuBtn.Click += new System.EventHandler(this.OpenFolderMenuBtn_Click);
            // 
            // CheckUpdatesMenuBtn
            // 
            this.CheckUpdatesMenuBtn.ForeColor = System.Drawing.Color.Black;
            this.CheckUpdatesMenuBtn.Image = global::BranksMod.Properties.Resources.Update;
            this.CheckUpdatesMenuBtn.Name = "CheckUpdatesMenuBtn";
            this.CheckUpdatesMenuBtn.Size = new System.Drawing.Size(210, 22);
            this.CheckUpdatesMenuBtn.Text = "Check for Updates";
            this.CheckUpdatesMenuBtn.Click += new System.EventHandler(this.CheckUpdatesMenuBtn_Click);
            // 
            // ReinstallMenuBtn
            // 
            this.ReinstallMenuBtn.ForeColor = System.Drawing.Color.Black;
            this.ReinstallMenuBtn.Image = global::BranksMod.Properties.Resources.Reinstall;
            this.ReinstallMenuBtn.Name = "ReinstallMenuBtn";
            this.ReinstallMenuBtn.Size = new System.Drawing.Size(210, 22);
            this.ReinstallMenuBtn.Text = "Reinstall";
            this.ReinstallMenuBtn.Click += new System.EventHandler(this.ReinstallMenuBtn_Click);
            // 
            // UninstallMenuBtn
            // 
            this.UninstallMenuBtn.ForeColor = System.Drawing.Color.Black;
            this.UninstallMenuBtn.Image = global::BranksMod.Properties.Resources.Uninstall;
            this.UninstallMenuBtn.Name = "UninstallMenuBtn";
            this.UninstallMenuBtn.Size = new System.Drawing.Size(210, 22);
            this.UninstallMenuBtn.Text = "Uninstall";
            this.UninstallMenuBtn.Click += new System.EventHandler(this.UninstallMenuBtn_Click);
            // 
            // ExitMenuBtn
            // 
            this.ExitMenuBtn.ForeColor = System.Drawing.Color.Black;
            this.ExitMenuBtn.Image = global::BranksMod.Properties.Resources.Exit;
            this.ExitMenuBtn.Name = "ExitMenuBtn";
            this.ExitMenuBtn.Size = new System.Drawing.Size(210, 22);
            this.ExitMenuBtn.Text = "Exit";
            this.ExitMenuBtn.Click += new System.EventHandler(this.ExitMenuBtn_Click);
            // 
            // SettingsMenuBtn
            // 
            this.SettingsMenuBtn.Image = global::BranksMod.Properties.Resources.Settings;
            this.SettingsMenuBtn.Name = "SettingsMenuBtn";
            this.SettingsMenuBtn.Size = new System.Drawing.Size(79, 20);
            this.SettingsMenuBtn.Text = "Settings";
            this.SettingsMenuBtn.Click += new System.EventHandler(this.SettingsMenuBtn_Click);
            // 
            // TroubleshootingMenuBtn
            // 
            this.TroubleshootingMenuBtn.Image = global::BranksMod.Properties.Resources.Help;
            this.TroubleshootingMenuBtn.Name = "TroubleshootingMenuBtn";
            this.TroubleshootingMenuBtn.Size = new System.Drawing.Size(124, 20);
            this.TroubleshootingMenuBtn.Text = "Troubleshooting";
            this.TroubleshootingMenuBtn.Click += new System.EventHandler(this.TroubleshootingMenuBtn_Click);
            // 
            // RLLbl
            // 
            this.RLLbl.BackColor = System.Drawing.Color.Transparent;
            this.RLLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RLLbl.ForeColor = System.Drawing.Color.Black;
            this.RLLbl.Location = new System.Drawing.Point(43, 36);
            this.RLLbl.Name = "RLLbl";
            this.RLLbl.Size = new System.Drawing.Size(254, 25);
            this.RLLbl.TabIndex = 1;
            this.RLLbl.Text = "Rocket League is not running.";
            this.RLLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusLbl
            // 
            this.StatusLbl.BackColor = System.Drawing.Color.Transparent;
            this.StatusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLbl.ForeColor = System.Drawing.Color.Black;
            this.StatusLbl.Location = new System.Drawing.Point(43, 67);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(254, 25);
            this.StatusLbl.TabIndex = 2;
            this.StatusLbl.Text = "Status: Uninjected.";
            this.StatusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProcessTmr
            // 
            this.ProcessTmr.Tick += new System.EventHandler(this.ProcessTmr_Tick);
            // 
            // TrayIcon
            // 
            this.TrayIcon.ContextMenuStrip = this.TrayMenuStrip;
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "BranksMod";
            this.TrayIcon.DoubleClick += new System.EventHandler(this.TrayIcon_DoubleClick);
            // 
            // TrayMenuStrip
            // 
            this.TrayMenuStrip.BackColor = System.Drawing.Color.White;
            this.TrayMenuStrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrayMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenTrayBtn,
            this.ExitTrayBtn});
            this.TrayMenuStrip.Name = "TrayMenuStrip";
            this.TrayMenuStrip.Size = new System.Drawing.Size(171, 48);
            // 
            // OpenTrayBtn
            // 
            this.OpenTrayBtn.Name = "OpenTrayBtn";
            this.OpenTrayBtn.Size = new System.Drawing.Size(170, 22);
            this.OpenTrayBtn.Text = "Open BranksMod";
            this.OpenTrayBtn.Click += new System.EventHandler(this.OpenTrayBtn_Click);
            // 
            // ExitTrayBtn
            // 
            this.ExitTrayBtn.Name = "ExitTrayBtn";
            this.ExitTrayBtn.Size = new System.Drawing.Size(170, 22);
            this.ExitTrayBtn.Text = "Exit BranksMod";
            this.ExitTrayBtn.Click += new System.EventHandler(this.ExitTrayBtn_Click);
            // 
            // InjectionTmr
            // 
            this.InjectionTmr.Interval = 2500;
            this.InjectionTmr.Tick += new System.EventHandler(this.InjectionTmr_Tick);
            // 
            // InjectBtn
            // 
            this.InjectBtn.BackColor = System.Drawing.Color.Transparent;
            this.InjectBtn.BackgroundImage = global::BranksMod.Properties.Resources.Inject;
            this.InjectBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.InjectBtn.Location = new System.Drawing.Point(272, 67);
            this.InjectBtn.Name = "InjectBtn";
            this.InjectBtn.Size = new System.Drawing.Size(25, 25);
            this.InjectBtn.TabIndex = 6;
            this.InjectBtn.TabStop = false;
            this.InjectBtn.Visible = false;
            this.InjectBtn.Click += new System.EventHandler(this.InjectBtn_Click);
            // 
            // StatusImg
            // 
            this.StatusImg.BackColor = System.Drawing.Color.Transparent;
            this.StatusImg.BackgroundImage = global::BranksMod.Properties.Resources.Status;
            this.StatusImg.Location = new System.Drawing.Point(12, 67);
            this.StatusImg.Name = "StatusImg";
            this.StatusImg.Size = new System.Drawing.Size(25, 25);
            this.StatusImg.TabIndex = 5;
            this.StatusImg.TabStop = false;
            // 
            // RLImg
            // 
            this.RLImg.BackColor = System.Drawing.Color.Transparent;
            this.RLImg.BackgroundImage = global::BranksMod.Properties.Resources.RL;
            this.RLImg.Location = new System.Drawing.Point(12, 36);
            this.RLImg.Name = "RLImg";
            this.RLImg.Size = new System.Drawing.Size(25, 25);
            this.RLImg.TabIndex = 4;
            this.RLImg.TabStop = false;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(309, 106);
            this.Controls.Add(this.InjectBtn);
            this.Controls.Add(this.StatusImg);
            this.Controls.Add(this.RLImg);
            this.Controls.Add(this.StatusLbl);
            this.Controls.Add(this.RLLbl);
            this.Controls.Add(this.MStrip);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MStrip;
            this.MaximizeBox = false;
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BranksMod";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.Resize += new System.EventHandler(this.MainFrm_Resize);
            this.MStrip.ResumeLayout(false);
            this.MStrip.PerformLayout();
            this.TrayMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InjectBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RLImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MStrip;
        private System.Windows.Forms.ToolStripMenuItem FileMenuBtn;
        private System.Windows.Forms.ToolStripMenuItem OpenFolderMenuBtn;
        private System.Windows.Forms.ToolStripMenuItem CheckUpdatesMenuBtn;
        private System.Windows.Forms.ToolStripMenuItem ReinstallMenuBtn;
        private System.Windows.Forms.ToolStripMenuItem UninstallMenuBtn;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuBtn;
        private System.Windows.Forms.ToolStripMenuItem SettingsMenuBtn;
        private System.Windows.Forms.ToolStripMenuItem TroubleshootingMenuBtn;
        internal System.Windows.Forms.Label RLLbl;
        internal System.Windows.Forms.Label StatusLbl;
        private System.Windows.Forms.Timer ProcessTmr;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.OpenFileDialog FileDialog;
        private System.Windows.Forms.ContextMenuStrip TrayMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem OpenTrayBtn;
        private System.Windows.Forms.ToolStripMenuItem ExitTrayBtn;
        private System.Windows.Forms.Timer InjectionTmr;
        private System.Windows.Forms.PictureBox RLImg;
        private System.Windows.Forms.PictureBox StatusImg;
        private System.Windows.Forms.PictureBox InjectBtn;
    }
}