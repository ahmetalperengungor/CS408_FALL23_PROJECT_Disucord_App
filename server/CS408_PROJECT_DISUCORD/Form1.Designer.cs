namespace CS408_PROJECT_DISUCORD
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
            components = new System.ComponentModel.Container();
            startListening = new Button();
            portTextBox = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            labelPort = new Label();
            activityTextBox = new RichTextBox();
            allUsersTextBox = new RichTextBox();
            spsTextBox = new RichTextBox();
            ifTextBox = new RichTextBox();
            labelActivityLogs = new Label();
            labelAllUsers = new Label();
            labelSPSUsers = new Label();
            labelIFUsers = new Label();
            stopListening = new Button();
            SuspendLayout();
            // 
            // startListening
            // 
            startListening.Location = new Point(52, 142);
            startListening.Name = "startListening";
            startListening.Size = new Size(197, 34);
            startListening.TabIndex = 0;
            startListening.Text = "Start Listening";
            startListening.UseVisualStyleBackColor = true;
            startListening.Click += startListening_Click;
            // 
            // portTextBox
            // 
            portTextBox.Location = new Point(85, 87);
            portTextBox.Name = "portTextBox";
            portTextBox.Size = new Size(125, 31);
            portTextBox.TabIndex = 1;
            portTextBox.TextChanged += port_TextChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // labelPort
            // 
            labelPort.AutoSize = true;
            labelPort.Location = new Point(118, 46);
            labelPort.Name = "labelPort";
            labelPort.Size = new Size(44, 25);
            labelPort.TabIndex = 3;
            labelPort.Text = "Port";
            labelPort.Click += label1_Click;
            // 
            // activityTextBox
            // 
            activityTextBox.Location = new Point(321, 87);
            activityTextBox.Name = "activityTextBox";
            activityTextBox.Size = new Size(428, 624);
            activityTextBox.TabIndex = 4;
            activityTextBox.Text = "";
            // 
            // allUsersTextBox
            // 
            allUsersTextBox.Location = new Point(795, 87);
            allUsersTextBox.Name = "allUsersTextBox";
            allUsersTextBox.Size = new Size(217, 624);
            allUsersTextBox.TabIndex = 5;
            allUsersTextBox.Text = "";
            // 
            // spsTextBox
            // 
            spsTextBox.Location = new Point(1060, 87);
            spsTextBox.Name = "spsTextBox";
            spsTextBox.Size = new Size(217, 624);
            spsTextBox.TabIndex = 6;
            spsTextBox.Text = "";
            // 
            // ifTextBox
            // 
            ifTextBox.Location = new Point(1322, 87);
            ifTextBox.Name = "ifTextBox";
            ifTextBox.Size = new Size(217, 624);
            ifTextBox.TabIndex = 7;
            ifTextBox.Text = "";
            // 
            // labelActivityLogs
            // 
            labelActivityLogs.AutoSize = true;
            labelActivityLogs.Location = new Point(494, 41);
            labelActivityLogs.Name = "labelActivityLogs";
            labelActivityLogs.Size = new Size(113, 25);
            labelActivityLogs.TabIndex = 8;
            labelActivityLogs.Text = "Activity Logs";
            labelActivityLogs.Click += label1_Click_1;
            // 
            // labelAllUsers
            // 
            labelAllUsers.AutoSize = true;
            labelAllUsers.Location = new Point(863, 41);
            labelAllUsers.Name = "labelAllUsers";
            labelAllUsers.Size = new Size(80, 25);
            labelAllUsers.TabIndex = 9;
            labelAllUsers.Text = "All Users";
            // 
            // labelSPSUsers
            // 
            labelSPSUsers.AutoSize = true;
            labelSPSUsers.Location = new Point(1107, 41);
            labelSPSUsers.Name = "labelSPSUsers";
            labelSPSUsers.Size = new Size(125, 25);
            labelSPSUsers.TabIndex = 10;
            labelSPSUsers.Text = "SPS 101 Users";
            // 
            // labelIFUsers
            // 
            labelIFUsers.AutoSize = true;
            labelIFUsers.Location = new Point(1369, 41);
            labelIFUsers.Name = "labelIFUsers";
            labelIFUsers.Size = new Size(109, 25);
            labelIFUsers.TabIndex = 11;
            labelIFUsers.Text = "IF 100 Users";
            // 
            // stopListening
            // 
            stopListening.Enabled = false;
            stopListening.Location = new Point(52, 199);
            stopListening.Name = "stopListening";
            stopListening.Size = new Size(197, 34);
            stopListening.TabIndex = 12;
            stopListening.Text = "Stop Listening";
            stopListening.UseVisualStyleBackColor = true;
            stopListening.Click += stopListening_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1753, 800);
            Controls.Add(stopListening);
            Controls.Add(labelIFUsers);
            Controls.Add(labelSPSUsers);
            Controls.Add(labelAllUsers);
            Controls.Add(labelActivityLogs);
            Controls.Add(ifTextBox);
            Controls.Add(spsTextBox);
            Controls.Add(allUsersTextBox);
            Controls.Add(activityTextBox);
            Controls.Add(labelPort);
            Controls.Add(portTextBox);
            Controls.Add(startListening);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button startListening;
        private TextBox portTextBox;
        private ContextMenuStrip contextMenuStrip1;
        private Label labelPort;
        private RichTextBox activityTextBox;
        private RichTextBox allUsersTextBox;
        private RichTextBox spsTextBox;
        private RichTextBox ifTextBox;
        private Label labelActivityLogs;
        private Label labelAllUsers;
        private Label labelSPSUsers;
        private Label labelIFUsers;
        private Button stopListening;
    }
}