// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


namespace Bodoconsult.App.WinForms.AppStarter.Forms
{
    sealed partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            MsgServerIsListeningOnPort = new Label();
            MsgHowToShutdownServer = new Label();
            LogWindow = new RichTextBox();
            AppTitle = new Label();
            MsgServerProcessId = new Label();
            Logo = new PictureBox();
            AppHeader = new Label();
            AppLine = new Label();
            ((System.ComponentModel.ISupportInitialize)Logo).BeginInit();
            SuspendLayout();
            // 
            // MsgServerIsListeningOnPort
            // 
            MsgServerIsListeningOnPort.AutoSize = true;
            MsgServerIsListeningOnPort.Font = new Font("Segoe UI", 12F);
            MsgServerIsListeningOnPort.Location = new Point(17, 177);
            MsgServerIsListeningOnPort.Margin = new Padding(4, 0, 4, 0);
            MsgServerIsListeningOnPort.Name = "MsgServerIsListeningOnPort";
            MsgServerIsListeningOnPort.Size = new Size(313, 32);
            MsgServerIsListeningOnPort.TabIndex = 0;
            MsgServerIsListeningOnPort.Text = "MsgServerIsListeningOnPort";
            // 
            // MsgHowToShutdownServer
            // 
            MsgHowToShutdownServer.AutoSize = true;
            MsgHowToShutdownServer.Font = new Font("Segoe UI", 12F);
            MsgHowToShutdownServer.Location = new Point(17, 287);
            MsgHowToShutdownServer.Margin = new Padding(4, 0, 4, 0);
            MsgHowToShutdownServer.Name = "MsgHowToShutdownServer";
            MsgHowToShutdownServer.Size = new Size(308, 32);
            MsgHowToShutdownServer.TabIndex = 1;
            MsgHowToShutdownServer.Text = "MsgHowToShutdownServer";
            // 
            // LogWindow
            // 
            LogWindow.Font = new Font("Segoe UI", 9.75F);
            LogWindow.Location = new Point(17, 343);
            LogWindow.Margin = new Padding(4, 5, 4, 5);
            LogWindow.Name = "LogWindow";
            LogWindow.Size = new Size(1488, 537);
            LogWindow.TabIndex = 2;
            LogWindow.Text = "";
            LogWindow.KeyPress += LogWindow_KeyPress;
            // 
            // AppTitle
            // 
            AppTitle.BackColor = Color.White;
            AppTitle.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
            AppTitle.ForeColor = Color.Black;
            AppTitle.Location = new Point(561, 45);
            AppTitle.Margin = new Padding(4, 0, 4, 0);
            AppTitle.Name = "AppTitle";
            AppTitle.Size = new Size(567, 108);
            AppTitle.TabIndex = 3;
            AppTitle.Text = "StSys server app";
            AppTitle.MouseDoubleClick += AppTitle_MouseDoubleClick;
            // 
            // MsgServerProcessId
            // 
            MsgServerProcessId.AutoSize = true;
            MsgServerProcessId.Font = new Font("Segoe UI", 12F);
            MsgServerProcessId.Location = new Point(17, 235);
            MsgServerProcessId.Margin = new Padding(4, 0, 4, 0);
            MsgServerProcessId.Name = "MsgServerProcessId";
            MsgServerProcessId.Size = new Size(226, 32);
            MsgServerProcessId.TabIndex = 4;
            MsgServerProcessId.Text = "MsgServerProcessId";
            // 
            // Logo
            // 
            Logo.BackColor = Color.Transparent;
            Logo.BackgroundImageLayout = ImageLayout.Zoom;
            Logo.Location = new Point(-6, -5);
            Logo.Margin = new Padding(4, 5, 4, 5);
            Logo.Name = "Logo";
            Logo.Size = new Size(486, 143);
            Logo.SizeMode = PictureBoxSizeMode.Zoom;
            Logo.TabIndex = 5;
            Logo.TabStop = false;
            // 
            // AppHeader
            // 
            AppHeader.BackColor = Color.White;
            AppHeader.ForeColor = SystemColors.ControlText;
            AppHeader.ImageAlign = ContentAlignment.BottomLeft;
            AppHeader.Location = new Point(-6, -5);
            AppHeader.Margin = new Padding(4, 0, 4, 0);
            AppHeader.Name = "AppHeader";
            AppHeader.Size = new Size(1533, 165);
            AppHeader.TabIndex = 6;
            AppHeader.Text = "   ";
            // 
            // AppLine
            // 
            AppLine.BackColor = Color.White;
            AppLine.ForeColor = SystemColors.ControlText;
            AppLine.ImageAlign = ContentAlignment.BottomLeft;
            AppLine.Location = new Point(-6, 153);
            AppLine.Margin = new Padding(4, 0, 4, 0);
            AppLine.Name = "AppLine";
            AppLine.Size = new Size(1533, 8);
            AppLine.TabIndex = 7;
            AppLine.Text = "   ";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1524, 903);
            Controls.Add(AppLine);
            Controls.Add(Logo);
            Controls.Add(MsgServerProcessId);
            Controls.Add(AppTitle);
            Controls.Add(LogWindow);
            Controls.Add(MsgHowToShutdownServer);
            Controls.Add(MsgServerIsListeningOnPort);
            Controls.Add(AppHeader);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "MainWindow";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainWindow";
            WindowState = FormWindowState.Maximized;
            FormClosing += MainWindow_FormClosing;
            KeyPress += MainWindow_KeyPress;
            Resize += MainWindow_Resize;
            ((System.ComponentModel.ISupportInitialize)Logo).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MsgServerIsListeningOnPort;
        private System.Windows.Forms.Label MsgHowToShutdownServer;
        private System.Windows.Forms.RichTextBox LogWindow;
        private System.Windows.Forms.Label AppTitle;
        private System.Windows.Forms.Label MsgServerProcessId;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Label AppHeader;
        private System.Windows.Forms.Label AppLine;
    }
}