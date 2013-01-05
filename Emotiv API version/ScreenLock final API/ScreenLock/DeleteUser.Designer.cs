namespace ScreenLock
{
    partial class DeleteUser
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
            this.listBox_UserName = new System.Windows.Forms.ListBox();
            this.button_DeleteUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox_UserName
            // 
            this.listBox_UserName.FormattingEnabled = true;
            this.listBox_UserName.Location = new System.Drawing.Point(108, 56);
            this.listBox_UserName.Name = "listBox_UserName";
            this.listBox_UserName.Size = new System.Drawing.Size(238, 95);
            this.listBox_UserName.TabIndex = 0;
            // 
            // button_DeleteUser
            // 
            this.button_DeleteUser.Location = new System.Drawing.Point(405, 94);
            this.button_DeleteUser.Name = "button_DeleteUser";
            this.button_DeleteUser.Size = new System.Drawing.Size(75, 23);
            this.button_DeleteUser.TabIndex = 1;
            this.button_DeleteUser.Text = "Delete User";
            this.button_DeleteUser.UseVisualStyleBackColor = true;
            this.button_DeleteUser.Click += new System.EventHandler(this.button_DeleteUser_Click);
            // 
            // DeleteUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 266);
            this.Controls.Add(this.button_DeleteUser);
            this.Controls.Add(this.listBox_UserName);
            this.Name = "DeleteUser";
            this.Text = "DeleteUser";
            this.Load += new System.EventHandler(this.DeleteUser_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_UserName;
        private System.Windows.Forms.Button button_DeleteUser;
    }
}