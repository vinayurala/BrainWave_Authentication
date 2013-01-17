namespace ScreenLock
{
    partial class AccountUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountUpdate));
            this.mainSelectionPanel = new System.Windows.Forms.Panel();
            this.accountNamepictureBox = new System.Windows.Forms.PictureBox();
            this.adminOptionButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.newNameTextBox = new System.Windows.Forms.TextBox();
            this.confirmNewNameTextBox = new System.Windows.Forms.TextBox();
            this.updateUserNameButton = new System.Windows.Forms.Button();
            this.newNameLabel = new System.Windows.Forms.Label();
            this.confirmNewNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mainSelectionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSelectionPanel
            // 
            this.mainSelectionPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainSelectionPanel.Controls.Add(this.accountNamepictureBox);
            this.mainSelectionPanel.Controls.Add(this.adminOptionButton);
            this.mainSelectionPanel.Controls.Add(this.helpButton);
            this.mainSelectionPanel.Location = new System.Drawing.Point(1, 0);
            this.mainSelectionPanel.Name = "mainSelectionPanel";
            this.mainSelectionPanel.Size = new System.Drawing.Size(117, 265);
            this.mainSelectionPanel.TabIndex = 1;
            // 
            // accountNamepictureBox
            // 
            this.accountNamepictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.accountNamepictureBox.Location = new System.Drawing.Point(20, 95);
            this.accountNamepictureBox.Name = "accountNamepictureBox";
            this.accountNamepictureBox.Size = new System.Drawing.Size(75, 60);
            this.accountNamepictureBox.TabIndex = 4;
            this.accountNamepictureBox.TabStop = false;
            // 
            // adminOptionButton
            // 
            this.adminOptionButton.BackgroundImage = global::ScreenLock.Properties.Resources.admin1;
            this.adminOptionButton.Location = new System.Drawing.Point(9, 10);
            this.adminOptionButton.Name = "adminOptionButton";
            this.adminOptionButton.Size = new System.Drawing.Size(101, 68);
            this.adminOptionButton.TabIndex = 3;
            this.adminOptionButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.adminOptionButton.UseVisualStyleBackColor = true;
            this.adminOptionButton.Click += new System.EventHandler(this.adminOptionButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(20, 185);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(75, 60);
            this.helpButton.TabIndex = 2;
            this.helpButton.Text = "Get online help";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // newNameTextBox
            // 
            this.newNameTextBox.Location = new System.Drawing.Point(249, 24);
            this.newNameTextBox.Name = "newNameTextBox";
            this.newNameTextBox.Size = new System.Drawing.Size(142, 20);
            this.newNameTextBox.TabIndex = 2;
            // 
            // confirmNewNameTextBox
            // 
            this.confirmNewNameTextBox.Location = new System.Drawing.Point(249, 64);
            this.confirmNewNameTextBox.Name = "confirmNewNameTextBox";
            this.confirmNewNameTextBox.Size = new System.Drawing.Size(142, 20);
            this.confirmNewNameTextBox.TabIndex = 3;
            // 
            // updateUserNameButton
            // 
            this.updateUserNameButton.Location = new System.Drawing.Point(279, 97);
            this.updateUserNameButton.Name = "updateUserNameButton";
            this.updateUserNameButton.Size = new System.Drawing.Size(75, 23);
            this.updateUserNameButton.TabIndex = 4;
            this.updateUserNameButton.Text = "Update";
            this.updateUserNameButton.UseVisualStyleBackColor = true;
            this.updateUserNameButton.Click += new System.EventHandler(this.updateUserNameButton_Click);
            // 
            // newNameLabel
            // 
            this.newNameLabel.AutoSize = true;
            this.newNameLabel.Location = new System.Drawing.Point(147, 27);
            this.newNameLabel.Name = "newNameLabel";
            this.newNameLabel.Size = new System.Drawing.Size(81, 13);
            this.newNameLabel.TabIndex = 5;
            this.newNameLabel.Text = "newNameLabel";
            // 
            // confirmNewNameLabel
            // 
            this.confirmNewNameLabel.AutoSize = true;
            this.confirmNewNameLabel.Location = new System.Drawing.Point(130, 67);
            this.confirmNewNameLabel.Name = "confirmNewNameLabel";
            this.confirmNewNameLabel.Size = new System.Drawing.Size(98, 13);
            this.confirmNewNameLabel.TabIndex = 6;
            this.confirmNewNameLabel.Text = "Confirm New Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "We can certainly add some more details later";
            // 
            // AccountUpdate
            // 
            this.AcceptButton = this.updateUserNameButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 268);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.confirmNewNameLabel);
            this.Controls.Add(this.newNameLabel);
            this.Controls.Add(this.updateUserNameButton);
            this.Controls.Add(this.confirmNewNameTextBox);
            this.Controls.Add(this.newNameTextBox);
            this.Controls.Add(this.mainSelectionPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AccountUpdate";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AccountUpdateForm_Closing);
            this.mainSelectionPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainSelectionPanel;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.PictureBox accountNamepictureBox;
        private System.Windows.Forms.Button adminOptionButton;
        private System.Windows.Forms.TextBox newNameTextBox;
        private System.Windows.Forms.TextBox confirmNewNameTextBox;
        private System.Windows.Forms.Button updateUserNameButton;
        private System.Windows.Forms.Label newNameLabel;
        private System.Windows.Forms.Label confirmNewNameLabel;
        private System.Windows.Forms.Label label1;
    }
}