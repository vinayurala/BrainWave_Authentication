namespace ScreenLock
{
    partial class DeleteUserForm
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
            this.userNameListComboBox = new System.Windows.Forms.ComboBox();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.deleteUserButton = new System.Windows.Forms.Button();
            this.formCloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userNameListComboBox
            // 
            this.userNameListComboBox.FormattingEnabled = true;
            this.userNameListComboBox.Items.AddRange(new object[] {
            "None"});
            this.userNameListComboBox.Location = new System.Drawing.Point(193, 34);
            this.userNameListComboBox.Name = "userNameListComboBox";
            this.userNameListComboBox.Size = new System.Drawing.Size(200, 21);
            this.userNameListComboBox.TabIndex = 0;
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(81, 37);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(60, 13);
            this.userNameLabel.TabIndex = 1;
            this.userNameLabel.Text = "User Name";
            // 
            // deleteUserButton
            // 
            this.deleteUserButton.Location = new System.Drawing.Point(193, 93);
            this.deleteUserButton.Name = "deleteUserButton";
            this.deleteUserButton.Size = new System.Drawing.Size(75, 23);
            this.deleteUserButton.TabIndex = 2;
            this.deleteUserButton.Text = "Delete";
            this.deleteUserButton.UseVisualStyleBackColor = true;
            this.deleteUserButton.Click += new System.EventHandler(this.deleteUserButton_Click);
            // 
            // formCloseButton
            // 
            this.formCloseButton.Location = new System.Drawing.Point(318, 93);
            this.formCloseButton.Name = "formCloseButton";
            this.formCloseButton.Size = new System.Drawing.Size(75, 23);
            this.formCloseButton.TabIndex = 3;
            this.formCloseButton.Text = "Exit";
            this.formCloseButton.UseVisualStyleBackColor = true;
            this.formCloseButton.Click += new System.EventHandler(this.formCloseButton_Click);
            // 
            // DeleteUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 160);
            this.ControlBox = false;
            this.Controls.Add(this.formCloseButton);
            this.Controls.Add(this.deleteUserButton);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.userNameListComboBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeleteUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeleteUserForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.DeleteUserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox userNameListComboBox;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Button deleteUserButton;
        private System.Windows.Forms.Button formCloseButton;
    }
}