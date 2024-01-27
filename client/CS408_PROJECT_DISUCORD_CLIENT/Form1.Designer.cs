namespace CS408_PROJECT_DISUCORD_CLIENT
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            usernameTextBox = new TextBox();
            addressTextBox = new TextBox();
            portTextBox = new TextBox();
            usernameLabel = new Label();
            addressLabel = new Label();
            portLabel = new Label();
            connectButton = new Button();
            activityTextBox = new RichTextBox();
            spsTextBox = new RichTextBox();
            ifTextBox = new RichTextBox();
            activityLogLabel = new Label();
            SPSLabel = new Label();
            IFLabel = new Label();
            disconnectButton = new Button();
            spsConnectButton = new Button();
            spsDisconnectButton = new Button();
            ifConnectButton = new Button();
            ifDisconnectButton = new Button();
            spsMessageTextBox = new RichTextBox();
            ifMessageTextBox = new RichTextBox();
            spsMessageSendButton = new Button();
            ifMessageSendButton = new Button();
            SuspendLayout();
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(192, 75);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(150, 31);
            usernameTextBox.TabIndex = 0;
            usernameTextBox.TextChanged += usernameTextBox_TextChanged;
            // 
            // addressTextBox
            // 
            addressTextBox.Location = new Point(192, 130);
            addressTextBox.Name = "addressTextBox";
            addressTextBox.Size = new Size(150, 31);
            addressTextBox.TabIndex = 1;
            // 
            // portTextBox
            // 
            portTextBox.Location = new Point(192, 189);
            portTextBox.Name = "portTextBox";
            portTextBox.Size = new Size(150, 31);
            portTextBox.TabIndex = 2;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(80, 78);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(91, 25);
            usernameLabel.TabIndex = 3;
            usernameLabel.Text = "Username";
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new Point(80, 130);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new Size(97, 25);
            addressLabel.TabIndex = 4;
            addressLabel.Text = "IP Address";
            // 
            // portLabel
            // 
            portLabel.AutoSize = true;
            portLabel.Location = new Point(80, 192);
            portLabel.Name = "portLabel";
            portLabel.Size = new Size(114, 25);
            portLabel.TabIndex = 5;
            portLabel.Text = "Port Number";
            // 
            // connectButton
            // 
            connectButton.Location = new Point(80, 249);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(112, 34);
            connectButton.TabIndex = 6;
            connectButton.Text = "Connect";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // activityTextBox
            // 
            activityTextBox.Location = new Point(496, 75);
            activityTextBox.Name = "activityTextBox";
            activityTextBox.Size = new Size(380, 759);
            activityTextBox.TabIndex = 7;
            activityTextBox.Text = "";
            // 
            // spsTextBox
            // 
            spsTextBox.Location = new Point(897, 137);
            spsTextBox.Name = "spsTextBox";
            spsTextBox.Size = new Size(380, 631);
            spsTextBox.TabIndex = 8;
            spsTextBox.Text = "";
            // 
            // ifTextBox
            // 
            ifTextBox.Location = new Point(1309, 137);
            ifTextBox.Name = "ifTextBox";
            ifTextBox.Size = new Size(380, 631);
            ifTextBox.TabIndex = 9;
            ifTextBox.Text = "";
            // 
            // activityLogLabel
            // 
            activityLogLabel.AutoSize = true;
            activityLogLabel.Location = new Point(657, 26);
            activityLogLabel.Name = "activityLogLabel";
            activityLogLabel.Size = new Size(82, 25);
            activityLogLabel.TabIndex = 10;
            activityLogLabel.Text = "Activities";
            // 
            // SPSLabel
            // 
            SPSLabel.AutoSize = true;
            SPSLabel.Location = new Point(1023, 31);
            SPSLabel.Name = "SPSLabel";
            SPSLabel.Size = new Size(145, 25);
            SPSLabel.TabIndex = 11;
            SPSLabel.Text = "SPS 101 Channel";
            // 
            // IFLabel
            // 
            IFLabel.AutoSize = true;
            IFLabel.Location = new Point(1467, 31);
            IFLabel.Name = "IFLabel";
            IFLabel.Size = new Size(129, 25);
            IFLabel.TabIndex = 12;
            IFLabel.Text = "IF 100 Channel";
            // 
            // disconnectButton
            // 
            disconnectButton.Enabled = false;
            disconnectButton.Location = new Point(230, 249);
            disconnectButton.Name = "disconnectButton";
            disconnectButton.Size = new Size(112, 34);
            disconnectButton.TabIndex = 13;
            disconnectButton.Text = "Disconnect";
            disconnectButton.UseVisualStyleBackColor = true;
            disconnectButton.Click += disconnectButton_Click;
            // 
            // spsConnectButton
            // 
            spsConnectButton.Enabled = false;
            spsConnectButton.Location = new Point(929, 78);
            spsConnectButton.Name = "spsConnectButton";
            spsConnectButton.Size = new Size(112, 34);
            spsConnectButton.TabIndex = 14;
            spsConnectButton.Text = "Connect";
            spsConnectButton.UseVisualStyleBackColor = true;
            spsConnectButton.Click += spsConnectButton_Click;
            // 
            // spsDisconnectButton
            // 
            spsDisconnectButton.Enabled = false;
            spsDisconnectButton.Location = new Point(1114, 78);
            spsDisconnectButton.Name = "spsDisconnectButton";
            spsDisconnectButton.Size = new Size(112, 34);
            spsDisconnectButton.TabIndex = 15;
            spsDisconnectButton.Text = "Disconnect";
            spsDisconnectButton.UseVisualStyleBackColor = true;
            spsDisconnectButton.Click += spsDisconnectButton_Click;
            // 
            // ifConnectButton
            // 
            ifConnectButton.Enabled = false;
            ifConnectButton.Location = new Point(1352, 78);
            ifConnectButton.Name = "ifConnectButton";
            ifConnectButton.Size = new Size(112, 34);
            ifConnectButton.TabIndex = 16;
            ifConnectButton.Text = "Connect";
            ifConnectButton.UseVisualStyleBackColor = true;
            ifConnectButton.Click += ifConnectButton_Click;
            // 
            // ifDisconnectButton
            // 
            ifDisconnectButton.Enabled = false;
            ifDisconnectButton.Location = new Point(1539, 76);
            ifDisconnectButton.Name = "ifDisconnectButton";
            ifDisconnectButton.Size = new Size(112, 34);
            ifDisconnectButton.TabIndex = 17;
            ifDisconnectButton.Text = "Disconnect";
            ifDisconnectButton.UseVisualStyleBackColor = true;
            ifDisconnectButton.Click += ifDisconnectButton_Click;
            // 
            // spsMessageTextBox
            // 
            spsMessageTextBox.Enabled = false;
            spsMessageTextBox.Location = new Point(897, 774);
            spsMessageTextBox.Name = "spsMessageTextBox";
            spsMessageTextBox.Size = new Size(299, 36);
            spsMessageTextBox.TabIndex = 18;
            spsMessageTextBox.Text = "";
            spsMessageTextBox.TextChanged += spsMessageTextBox_TextChanged;
            // 
            // ifMessageTextBox
            // 
            ifMessageTextBox.Enabled = false;
            ifMessageTextBox.Location = new Point(1309, 774);
            ifMessageTextBox.Name = "ifMessageTextBox";
            ifMessageTextBox.Size = new Size(299, 36);
            ifMessageTextBox.TabIndex = 19;
            ifMessageTextBox.Text = "";
            ifMessageTextBox.TextChanged += ifMessageTextBox_TextChanged;
            // 
            // spsMessageSendButton
            // 
            spsMessageSendButton.Enabled = false;
            spsMessageSendButton.Location = new Point(1216, 774);
            spsMessageSendButton.Name = "spsMessageSendButton";
            spsMessageSendButton.Size = new Size(61, 34);
            spsMessageSendButton.TabIndex = 20;
            spsMessageSendButton.Text = "Send";
            spsMessageSendButton.UseVisualStyleBackColor = true;
            spsMessageSendButton.Click += spsMessageSendButton_Click;
            // 
            // ifMessageSendButton
            // 
            ifMessageSendButton.Enabled = false;
            ifMessageSendButton.Location = new Point(1628, 772);
            ifMessageSendButton.Name = "ifMessageSendButton";
            ifMessageSendButton.Size = new Size(61, 34);
            ifMessageSendButton.TabIndex = 21;
            ifMessageSendButton.Text = "Send";
            ifMessageSendButton.UseVisualStyleBackColor = true;
            ifMessageSendButton.Click += ifMessageSendButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1862, 846);
            Controls.Add(ifMessageSendButton);
            Controls.Add(spsMessageSendButton);
            Controls.Add(ifMessageTextBox);
            Controls.Add(spsMessageTextBox);
            Controls.Add(ifDisconnectButton);
            Controls.Add(ifConnectButton);
            Controls.Add(spsDisconnectButton);
            Controls.Add(spsConnectButton);
            Controls.Add(disconnectButton);
            Controls.Add(IFLabel);
            Controls.Add(SPSLabel);
            Controls.Add(activityLogLabel);
            Controls.Add(ifTextBox);
            Controls.Add(spsTextBox);
            Controls.Add(activityTextBox);
            Controls.Add(connectButton);
            Controls.Add(portLabel);
            Controls.Add(addressLabel);
            Controls.Add(usernameLabel);
            Controls.Add(portTextBox);
            Controls.Add(addressTextBox);
            Controls.Add(usernameTextBox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox usernameTextBox;
        private TextBox addressTextBox;
        private TextBox portTextBox;
        private Label usernameLabel;
        private Label addressLabel;
        private Label portLabel;
        private Button connectButton;
        private RichTextBox activityTextBox;
        private RichTextBox spsTextBox;
        private RichTextBox ifTextBox;
        private Label activityLogLabel;
        private Label SPSLabel;
        private Label IFLabel;
        private Button disconnectButton;
        private Button spsConnectButton;
        private Button spsDisconnectButton;
        private Button ifConnectButton;
        private Button ifDisconnectButton;
        private RichTextBox spsMessageTextBox;
        private RichTextBox ifMessageTextBox;
        private Button spsMessageSendButton;
        private Button ifMessageSendButton;
    }
}