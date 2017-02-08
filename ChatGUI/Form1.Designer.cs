namespace ChatGUI
{
    partial class MainForm
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
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNetwork = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNetworkConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNetworkDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.PicBox = new System.Windows.Forms.PictureBox();
            this.SendMessageBoxGroup = new System.Windows.Forms.GroupBox();
            this.SendMessageBoxClear = new System.Windows.Forms.Button();
            this.SendMessageBoxButton = new System.Windows.Forms.Button();
            this.SendMessageBox = new System.Windows.Forms.TextBox();
            this.ConversationBoxGroup = new System.Windows.Forms.GroupBox();
            this.ConversationBox = new System.Windows.Forms.TextBox();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).BeginInit();
            this.SendMessageBoxGroup.SuspendLayout();
            this.ConversationBoxGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.MenuNetwork,
            this.MenuHelp});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(815, 28);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "Menu";
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFileExit});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(44, 24);
            this.MenuFile.Text = "File";
            // 
            // MenuFileExit
            // 
            this.MenuFileExit.Name = "MenuFileExit";
            this.MenuFileExit.Size = new System.Drawing.Size(108, 26);
            this.MenuFileExit.Text = "Exit";
            this.MenuFileExit.Click += new System.EventHandler(this.MenuFileExit_Click);
            // 
            // MenuNetwork
            // 
            this.MenuNetwork.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuNetworkConnect,
            this.MenuNetworkDisconnect});
            this.MenuNetwork.Name = "MenuNetwork";
            this.MenuNetwork.Size = new System.Drawing.Size(77, 24);
            this.MenuNetwork.Text = "Network";
            // 
            // MenuNetworkConnect
            // 
            this.MenuNetworkConnect.Name = "MenuNetworkConnect";
            this.MenuNetworkConnect.Size = new System.Drawing.Size(157, 26);
            this.MenuNetworkConnect.Text = "Connect";
            this.MenuNetworkConnect.Click += new System.EventHandler(this.MenuNetworkConnect_Click);
            // 
            // MenuNetworkDisconnect
            // 
            this.MenuNetworkDisconnect.Name = "MenuNetworkDisconnect";
            this.MenuNetworkDisconnect.Size = new System.Drawing.Size(157, 26);
            this.MenuNetworkDisconnect.Text = "Disconnect";
            this.MenuNetworkDisconnect.Click += new System.EventHandler(this.MenuNetworkDisconnect_Click);
            // 
            // MenuHelp
            // 
            this.MenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuHelpAbout});
            this.MenuHelp.Name = "MenuHelp";
            this.MenuHelp.Size = new System.Drawing.Size(53, 24);
            this.MenuHelp.Text = "Help";
            // 
            // MenuHelpAbout
            // 
            this.MenuHelpAbout.Name = "MenuHelpAbout";
            this.MenuHelpAbout.Size = new System.Drawing.Size(125, 26);
            this.MenuHelpAbout.Text = "About";
            this.MenuHelpAbout.Click += new System.EventHandler(this.MenuHelpAbout_Click);
            // 
            // PicBox
            // 
            this.PicBox.BackColor = System.Drawing.Color.Black;
            this.PicBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.PicBox.Location = new System.Drawing.Point(0, 28);
            this.PicBox.Name = "PicBox";
            this.PicBox.Size = new System.Drawing.Size(815, 50);
            this.PicBox.TabIndex = 1;
            this.PicBox.TabStop = false;
            // 
            // SendMessageBoxGroup
            // 
            this.SendMessageBoxGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SendMessageBoxGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SendMessageBoxGroup.Controls.Add(this.SendMessageBoxClear);
            this.SendMessageBoxGroup.Controls.Add(this.SendMessageBoxButton);
            this.SendMessageBoxGroup.Controls.Add(this.SendMessageBox);
            this.SendMessageBoxGroup.Location = new System.Drawing.Point(13, 89);
            this.SendMessageBoxGroup.Name = "SendMessageBoxGroup";
            this.SendMessageBoxGroup.Size = new System.Drawing.Size(790, 47);
            this.SendMessageBoxGroup.TabIndex = 2;
            this.SendMessageBoxGroup.TabStop = false;
            this.SendMessageBoxGroup.Text = "Type Your Message Here:";
            // 
            // SendMessageBoxClear
            // 
            this.SendMessageBoxClear.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SendMessageBoxClear.AutoSize = true;
            this.SendMessageBoxClear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SendMessageBoxClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.SendMessageBoxClear.Location = new System.Drawing.Point(733, 14);
            this.SendMessageBoxClear.Name = "SendMessageBoxClear";
            this.SendMessageBoxClear.Size = new System.Drawing.Size(51, 27);
            this.SendMessageBoxClear.TabIndex = 2;
            this.SendMessageBoxClear.Text = "Clear";
            this.SendMessageBoxClear.UseVisualStyleBackColor = true;
            this.SendMessageBoxClear.Click += new System.EventHandler(this.SendMessageBoxClear_Click);
            // 
            // SendMessageBoxButton
            // 
            this.SendMessageBoxButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SendMessageBoxButton.AutoSize = true;
            this.SendMessageBoxButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SendMessageBoxButton.Location = new System.Drawing.Point(676, 14);
            this.SendMessageBoxButton.Name = "SendMessageBoxButton";
            this.SendMessageBoxButton.Size = new System.Drawing.Size(51, 27);
            this.SendMessageBoxButton.TabIndex = 1;
            this.SendMessageBoxButton.Text = "Send";
            this.SendMessageBoxButton.UseVisualStyleBackColor = true;
            this.SendMessageBoxButton.Click += new System.EventHandler(this.SendMessageBoxButton_Click);
            // 
            // SendMessageBox
            // 
            this.SendMessageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SendMessageBox.Location = new System.Drawing.Point(7, 22);
            this.SendMessageBox.Name = "SendMessageBox";
            this.SendMessageBox.Size = new System.Drawing.Size(663, 22);
            this.SendMessageBox.TabIndex = 0;
            // 
            // ConversationBoxGroup
            // 
            this.ConversationBoxGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConversationBoxGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ConversationBoxGroup.Controls.Add(this.ConversationBox);
            this.ConversationBoxGroup.Location = new System.Drawing.Point(13, 138);
            this.ConversationBoxGroup.MinimumSize = new System.Drawing.Size(200, 100);
            this.ConversationBoxGroup.Name = "ConversationBoxGroup";
            this.ConversationBoxGroup.Size = new System.Drawing.Size(790, 235);
            this.ConversationBoxGroup.TabIndex = 3;
            this.ConversationBoxGroup.TabStop = false;
            this.ConversationBoxGroup.Text = "Conversation:";
            // 
            // ConversationBox
            // 
            this.ConversationBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConversationBox.BackColor = System.Drawing.Color.White;
            this.ConversationBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ConversationBox.Location = new System.Drawing.Point(7, 22);
            this.ConversationBox.MinimumSize = new System.Drawing.Size(100, 5);
            this.ConversationBox.Multiline = true;
            this.ConversationBox.Name = "ConversationBox";
            this.ConversationBox.ReadOnly = true;
            this.ConversationBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ConversationBox.Size = new System.Drawing.Size(777, 207);
            this.ConversationBox.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AcceptButton = this.SendMessageBoxButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.SendMessageBoxClear;
            this.ClientSize = new System.Drawing.Size(815, 385);
            this.Controls.Add(this.ConversationBoxGroup);
            this.Controls.Add(this.SendMessageBoxGroup);
            this.Controls.Add(this.PicBox);
            this.Controls.Add(this.Menu);
            this.MainMenuStrip = this.Menu;
            this.MinimumSize = new System.Drawing.Size(350, 350);
            this.Name = "MainForm";
            this.Text = "Network Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClosing_Click);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).EndInit();
            this.SendMessageBoxGroup.ResumeLayout(false);
            this.SendMessageBoxGroup.PerformLayout();
            this.ConversationBoxGroup.ResumeLayout(false);
            this.ConversationBoxGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem MenuFileExit;
        private System.Windows.Forms.ToolStripMenuItem MenuNetwork;
        private System.Windows.Forms.ToolStripMenuItem MenuNetworkConnect;
        private System.Windows.Forms.ToolStripMenuItem MenuNetworkDisconnect;
        private System.Windows.Forms.ToolStripMenuItem MenuHelp;
        private System.Windows.Forms.ToolStripMenuItem MenuHelpAbout;
        private System.Windows.Forms.PictureBox PicBox;
        private System.Windows.Forms.GroupBox SendMessageBoxGroup;
        private System.Windows.Forms.GroupBox ConversationBoxGroup;
        private System.Windows.Forms.Button SendMessageBoxButton;
        private System.Windows.Forms.TextBox SendMessageBox;
        private System.Windows.Forms.TextBox ConversationBox;
        private System.Windows.Forms.Button SendMessageBoxClear;
    }
}

