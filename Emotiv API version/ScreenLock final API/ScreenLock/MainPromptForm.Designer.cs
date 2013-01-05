namespace ScreenLock
{
    partial class MainPromptForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPromptForm));
            this.mainSelectionPanel = new System.Windows.Forms.Panel();
            this.adminOptionsPicture = new System.Windows.Forms.PictureBox();
            this.subCategoryPanel = new System.Windows.Forms.Panel();
            this.button_TrainSystem = new System.Windows.Forms.Button();
            this.lockScreenAgainButton = new System.Windows.Forms.Button();
            this.removeUserLabel = new System.Windows.Forms.Label();
            this.addUserLabel = new System.Windows.Forms.Label();
            this.enableStartupCheckBox = new System.Windows.Forms.CheckBox();
            this.startupSuggestionLabel = new System.Windows.Forms.Label();
            this.removeUserButton = new System.Windows.Forms.Button();
            this.addUserButton = new System.Windows.Forms.Button();
            this.mainSelectionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adminOptionsPicture)).BeginInit();
            this.subCategoryPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSelectionPanel
            // 
            this.mainSelectionPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainSelectionPanel.Controls.Add(this.adminOptionsPicture);
            this.mainSelectionPanel.Location = new System.Drawing.Point(1, -2);
            this.mainSelectionPanel.Name = "mainSelectionPanel";
            this.mainSelectionPanel.Size = new System.Drawing.Size(117, 265);
            this.mainSelectionPanel.TabIndex = 0;
            // 
            // adminOptionsPicture
            // 
            this.adminOptionsPicture.BackgroundImage = global::ScreenLock.Properties.Resources.admin1;
            this.adminOptionsPicture.Location = new System.Drawing.Point(10, 18);
            this.adminOptionsPicture.Name = "adminOptionsPicture";
            this.adminOptionsPicture.Size = new System.Drawing.Size(100, 65);
            this.adminOptionsPicture.TabIndex = 3;
            this.adminOptionsPicture.TabStop = false;
            // 
            // subCategoryPanel
            // 
            this.subCategoryPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.subCategoryPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.subCategoryPanel.Controls.Add(this.button_TrainSystem);
            this.subCategoryPanel.Controls.Add(this.lockScreenAgainButton);
            this.subCategoryPanel.Controls.Add(this.removeUserLabel);
            this.subCategoryPanel.Controls.Add(this.addUserLabel);
            this.subCategoryPanel.Controls.Add(this.enableStartupCheckBox);
            this.subCategoryPanel.Controls.Add(this.startupSuggestionLabel);
            this.subCategoryPanel.Controls.Add(this.removeUserButton);
            this.subCategoryPanel.Controls.Add(this.addUserButton);
            this.subCategoryPanel.Location = new System.Drawing.Point(124, -2);
            this.subCategoryPanel.Name = "subCategoryPanel";
            this.subCategoryPanel.Size = new System.Drawing.Size(449, 256);
            this.subCategoryPanel.TabIndex = 1;
            this.subCategoryPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.subCategoryPanel_Paint);
            // 
            // button_TrainSystem
            // 
            this.button_TrainSystem.Location = new System.Drawing.Point(247, 34);
            this.button_TrainSystem.Name = "button_TrainSystem";
            this.button_TrainSystem.Size = new System.Drawing.Size(150, 23);
            this.button_TrainSystem.TabIndex = 10;
            this.button_TrainSystem.Text = "Train System";
            this.button_TrainSystem.UseVisualStyleBackColor = true;
            this.button_TrainSystem.Click += new System.EventHandler(this.button_TrainSystem_Click);
            // 
            // lockScreenAgainButton
            // 
            this.lockScreenAgainButton.Location = new System.Drawing.Point(35, 34);
            this.lockScreenAgainButton.Name = "lockScreenAgainButton";
            this.lockScreenAgainButton.Size = new System.Drawing.Size(160, 23);
            this.lockScreenAgainButton.TabIndex = 9;
            this.lockScreenAgainButton.Text = "Lock The Screen Again";
            this.lockScreenAgainButton.UseVisualStyleBackColor = true;
            this.lockScreenAgainButton.Click += new System.EventHandler(this.lockScreenAgainButton_Click);
            // 
            // removeUserLabel
            // 
            this.removeUserLabel.AutoSize = true;
            this.removeUserLabel.Location = new System.Drawing.Point(292, 158);
            this.removeUserLabel.Name = "removeUserLabel";
            this.removeUserLabel.Size = new System.Drawing.Size(72, 13);
            this.removeUserLabel.TabIndex = 8;
            this.removeUserLabel.Text = "Remove User";
            // 
            // addUserLabel
            // 
            this.addUserLabel.AutoSize = true;
            this.addUserLabel.Location = new System.Drawing.Point(81, 158);
            this.addUserLabel.Name = "addUserLabel";
            this.addUserLabel.Size = new System.Drawing.Size(51, 13);
            this.addUserLabel.TabIndex = 7;
            this.addUserLabel.Text = "Add User";
            this.addUserLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // enableStartupCheckBox
            // 
            this.enableStartupCheckBox.AutoSize = true;
            this.enableStartupCheckBox.Location = new System.Drawing.Point(370, 231);
            this.enableStartupCheckBox.Name = "enableStartupCheckBox";
            this.enableStartupCheckBox.Size = new System.Drawing.Size(15, 14);
            this.enableStartupCheckBox.TabIndex = 6;
            this.enableStartupCheckBox.UseVisualStyleBackColor = true;
            this.enableStartupCheckBox.CheckedChanged += new System.EventHandler(this.enableStartupCheckBox_CheckedChanged);
            // 
            // startupSuggestionLabel
            // 
            this.startupSuggestionLabel.Location = new System.Drawing.Point(20, 224);
            this.startupSuggestionLabel.Name = "startupSuggestionLabel";
            this.startupSuggestionLabel.Size = new System.Drawing.Size(344, 25);
            this.startupSuggestionLabel.TabIndex = 5;
            this.startupSuggestionLabel.Text = "For better security enable Screen Lock on startup. Click here to enable";
            this.startupSuggestionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // removeUserButton
            // 
            this.removeUserButton.BackgroundImage = global::ScreenLock.Properties.Resources.deleteAccounts;
            this.removeUserButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.removeUserButton.Location = new System.Drawing.Point(247, 82);
            this.removeUserButton.Name = "removeUserButton";
            this.removeUserButton.Size = new System.Drawing.Size(150, 76);
            this.removeUserButton.TabIndex = 2;
            this.removeUserButton.UseVisualStyleBackColor = true;
            this.removeUserButton.Click += new System.EventHandler(this.removeUserButton_Click);
            // 
            // addUserButton
            // 
            this.addUserButton.BackgroundImage = global::ScreenLock.Properties.Resources.addUser;
            this.addUserButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addUserButton.Location = new System.Drawing.Point(32, 82);
            this.addUserButton.Name = "addUserButton";
            this.addUserButton.Size = new System.Drawing.Size(150, 76);
            this.addUserButton.TabIndex = 1;
            this.addUserButton.UseVisualStyleBackColor = true;
            this.addUserButton.Click += new System.EventHandler(this.addUserButton_Click);
            // 
            // MainPromptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 266);
            this.Controls.Add(this.subCategoryPanel);
            this.Controls.Add(this.mainSelectionPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainPromptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Screen Lock software name";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainPromptForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainPromptForm_FormClosing);
            this.mainSelectionPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adminOptionsPicture)).EndInit();
            this.subCategoryPanel.ResumeLayout(false);
            this.subCategoryPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainSelectionPanel;
        private System.Windows.Forms.Panel subCategoryPanel;
        private System.Windows.Forms.Button removeUserButton;
        private System.Windows.Forms.Button addUserButton;
        private System.Windows.Forms.Label startupSuggestionLabel;
        private System.Windows.Forms.PictureBox adminOptionsPicture;
        private System.Windows.Forms.CheckBox enableStartupCheckBox;
        private System.Windows.Forms.Label removeUserLabel;
        private System.Windows.Forms.Label addUserLabel;
        private System.Windows.Forms.Button lockScreenAgainButton;
        private System.Windows.Forms.Button button_TrainSystem;

    }
}