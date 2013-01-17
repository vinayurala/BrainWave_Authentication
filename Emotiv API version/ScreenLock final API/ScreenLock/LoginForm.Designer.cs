namespace ScreenLock
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            this.unlockLabel = new System.Windows.Forms.Label();
            this.restartLabel = new System.Windows.Forms.Label();
            this.shutdownLabel = new System.Windows.Forms.Label();
            this.messageLabel = new System.Windows.Forms.Label();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.userNameTextbox = new System.Windows.Forms.TextBox();
            this.programCountMessageLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.windowsLogo = new System.Windows.Forms.PictureBox();
            this.ShutdownButton = new System.Windows.Forms.Button();
            this.RestartButton = new System.Windows.Forms.Button();
            this.unlockButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.windowsLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // unlockLabel
            // 
            this.unlockLabel.AutoSize = true;
            this.unlockLabel.Location = new System.Drawing.Point(101, 158);
            this.unlockLabel.Name = "unlockLabel";
            this.unlockLabel.Size = new System.Drawing.Size(41, 13);
            this.unlockLabel.TabIndex = 6;
            this.unlockLabel.Text = "Unlock";
            // 
            // restartLabel
            // 
            this.restartLabel.AutoSize = true;
            this.restartLabel.Location = new System.Drawing.Point(211, 158);
            this.restartLabel.Name = "restartLabel";
            this.restartLabel.Size = new System.Drawing.Size(41, 13);
            this.restartLabel.TabIndex = 7;
            this.restartLabel.Text = "Restart";
            // 
            // shutdownLabel
            // 
            this.shutdownLabel.AutoSize = true;
            this.shutdownLabel.Location = new System.Drawing.Point(318, 158);
            this.shutdownLabel.Name = "shutdownLabel";
            this.shutdownLabel.Size = new System.Drawing.Size(55, 13);
            this.shutdownLabel.TabIndex = 8;
            this.shutdownLabel.Text = "Shutdown";
            // 
            // messageLabel
            // 
            this.messageLabel.Location = new System.Drawing.Point(102, 15);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(305, 37);
            this.messageLabel.TabIndex = 9;
            this.messageLabel.Text = "                    Your Screen has been locked.                                E" +
                "nter your username  and feedin your Brain Waves to unlock";
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(56, 63);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(55, 13);
            this.userNameLabel.TabIndex = 10;
            this.userNameLabel.Text = "Username";
            // 
            // userNameTextbox
            // 
            this.userNameTextbox.Location = new System.Drawing.Point(137, 60);
            this.userNameTextbox.MaxLength = 32;
            this.userNameTextbox.Name = "userNameTextbox";
            this.userNameTextbox.Size = new System.Drawing.Size(216, 20);
            this.userNameTextbox.TabIndex = 11;
            // 
            // programCountMessageLabel
            // 
            this.programCountMessageLabel.AutoSize = true;
            this.programCountMessageLabel.Location = new System.Drawing.Point(147, 234);
            this.programCountMessageLabel.Name = "programCountMessageLabel";
            this.programCountMessageLabel.Size = new System.Drawing.Size(0, 13);
            this.programCountMessageLabel.TabIndex = 13;
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(352, 234);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 25);
            this.exitButton.TabIndex = 14;
            this.exitButton.Text = "Exit";
            this.exitButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // windowsLogo
            // 
            this.windowsLogo.BackgroundImage = global::ScreenLock.Properties.Resources.windows_icon;
            this.windowsLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.windowsLogo.Location = new System.Drawing.Point(44, 204);
            this.windowsLogo.Name = "windowsLogo";
            this.windowsLogo.Size = new System.Drawing.Size(67, 55);
            this.windowsLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.windowsLogo.TabIndex = 12;
            this.windowsLogo.TabStop = false;
            // 
            // ShutdownButton
            // 
            this.ShutdownButton.BackgroundImage = global::ScreenLock.Properties.Resources.shut_down_logo;
            this.ShutdownButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ShutdownButton.Location = new System.Drawing.Point(320, 108);
            this.ShutdownButton.Name = "ShutdownButton";
            this.ShutdownButton.Size = new System.Drawing.Size(51, 47);
            this.ShutdownButton.TabIndex = 5;
            this.ShutdownButton.UseVisualStyleBackColor = true;
            this.ShutdownButton.Click += new System.EventHandler(this.ShutdownButton_Click);
            // 
            // RestartButton
            // 
            this.RestartButton.BackgroundImage = global::ScreenLock.Properties.Resources.Windows_Restart_icon;
            this.RestartButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RestartButton.Location = new System.Drawing.Point(207, 108);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(51, 47);
            this.RestartButton.TabIndex = 4;
            this.RestartButton.UseVisualStyleBackColor = true;
            this.RestartButton.Click += new System.EventHandler(this.RestartButton_Click);
            // 
            // unlockButton
            // 
            this.unlockButton.BackgroundImage = global::ScreenLock.Properties.Resources.Unlock;
            this.unlockButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.unlockButton.Location = new System.Drawing.Point(96, 108);
            this.unlockButton.Name = "unlockButton";
            this.unlockButton.Size = new System.Drawing.Size(51, 47);
            this.unlockButton.TabIndex = 3;
            this.unlockButton.UseVisualStyleBackColor = true;
            this.unlockButton.Click += new System.EventHandler(this.UnlockButton_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.unlockButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(461, 262);
            this.ControlBox = false;
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.programCountMessageLabel);
            this.Controls.Add(this.windowsLogo);
            this.Controls.Add(this.userNameTextbox);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.shutdownLabel);
            this.Controls.Add(this.restartLabel);
            this.Controls.Add(this.unlockLabel);
            this.Controls.Add(this.ShutdownButton);
            this.Controls.Add(this.RestartButton);
            this.Controls.Add(this.unlockButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.windowsLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button unlockButton;
        private System.Windows.Forms.Button RestartButton;
        private System.Windows.Forms.Button ShutdownButton;
        private System.Windows.Forms.Label unlockLabel;
        private System.Windows.Forms.Label restartLabel;
        private System.Windows.Forms.Label shutdownLabel;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.TextBox userNameTextbox;
        private System.Windows.Forms.PictureBox windowsLogo;
        private System.Windows.Forms.Label programCountMessageLabel;
        private System.Windows.Forms.Button exitButton;

    }
}

