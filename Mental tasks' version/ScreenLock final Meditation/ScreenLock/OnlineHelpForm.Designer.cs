namespace ScreenLock
{
    partial class OnlineHelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnlineHelpForm));
            this.mainSelectionPanel = new System.Windows.Forms.Panel();
            this.onlineHelpPictureBox = new System.Windows.Forms.PictureBox();
            this.adminOptionsButton = new System.Windows.Forms.Button();
            this.accountNameButton = new System.Windows.Forms.Button();
            this.onlineHelpPanel = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.goBackToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.goForwardToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addressBarToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.goButton = new System.Windows.Forms.ToolStripButton();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.onlineHelpBrowser = new System.Windows.Forms.WebBrowser();
            this.mainSelectionPanel.SuspendLayout();
            this.onlineHelpPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSelectionPanel
            // 
            this.mainSelectionPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainSelectionPanel.Controls.Add(this.onlineHelpPictureBox);
            this.mainSelectionPanel.Controls.Add(this.adminOptionsButton);
            this.mainSelectionPanel.Controls.Add(this.accountNameButton);
            this.mainSelectionPanel.Location = new System.Drawing.Point(2, 1);
            this.mainSelectionPanel.Name = "mainSelectionPanel";
            this.mainSelectionPanel.Size = new System.Drawing.Size(117, 265);
            this.mainSelectionPanel.TabIndex = 1;
            // 
            // onlineHelpPictureBox
            // 
            this.onlineHelpPictureBox.Location = new System.Drawing.Point(10, 192);
            this.onlineHelpPictureBox.Name = "onlineHelpPictureBox";
            this.onlineHelpPictureBox.Size = new System.Drawing.Size(100, 50);
            this.onlineHelpPictureBox.TabIndex = 4;
            this.onlineHelpPictureBox.TabStop = false;
            // 
            // adminOptionsButton
            // 
            this.adminOptionsButton.BackgroundImage = global::ScreenLock.Properties.Resources.admin1;
            this.adminOptionsButton.Location = new System.Drawing.Point(10, 9);
            this.adminOptionsButton.Name = "adminOptionsButton";
            this.adminOptionsButton.Size = new System.Drawing.Size(100, 67);
            this.adminOptionsButton.TabIndex = 3;
            this.adminOptionsButton.UseVisualStyleBackColor = true;
            this.adminOptionsButton.Click += new System.EventHandler(this.adminOptionsButton_Click);
            // 
            // accountNameButton
            // 
            this.accountNameButton.Location = new System.Drawing.Point(20, 99);
            this.accountNameButton.Name = "accountNameButton";
            this.accountNameButton.Size = new System.Drawing.Size(75, 60);
            this.accountNameButton.TabIndex = 1;
            this.accountNameButton.Text = "Change  My Account Name";
            this.accountNameButton.UseVisualStyleBackColor = true;
            this.accountNameButton.Click += new System.EventHandler(this.accountNameButton_Click);
            // 
            // onlineHelpPanel
            // 
            this.onlineHelpPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.onlineHelpPanel.Controls.Add(this.toolStrip1);
            this.onlineHelpPanel.Controls.Add(this.onlineHelpBrowser);
            this.onlineHelpPanel.Location = new System.Drawing.Point(125, 1);
            this.onlineHelpPanel.Name = "onlineHelpPanel";
            this.onlineHelpPanel.Size = new System.Drawing.Size(1145, 800);
            this.onlineHelpPanel.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripButton,
            this.printToolStripButton,
            this.toolStripSeparator,
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.toolStripSeparator1,
            this.goBackToolStripButton,
            this.goForwardToolStripButton,
            this.toolStripSeparator2,
            this.addressBarToolStripTextBox,
            this.goButton,
            this.helpToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1141, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printToolStripButton.Text = "&Print";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // cutToolStripButton
            // 
            this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
            this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripButton.Name = "cutToolStripButton";
            this.cutToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.cutToolStripButton.Text = "C&ut";
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.copyToolStripButton.Text = "&Copy";
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.pasteToolStripButton.Text = "&Paste";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // goBackToolStripButton
            // 
            this.goBackToolStripButton.BackgroundImage = global::ScreenLock.Properties.Resources.leftArrow;
            this.goBackToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.goBackToolStripButton.Image = global::ScreenLock.Properties.Resources.leftArrow;
            this.goBackToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.goBackToolStripButton.Name = "goBackToolStripButton";
            this.goBackToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.goBackToolStripButton.Text = "toolStripButton1";
            // 
            // goForwardToolStripButton
            // 
            this.goForwardToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.goForwardToolStripButton.Image = global::ScreenLock.Properties.Resources.rightArrow;
            this.goForwardToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.goForwardToolStripButton.Name = "goForwardToolStripButton";
            this.goForwardToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.goForwardToolStripButton.Text = "toolStripButton2";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // addressBarToolStripTextBox
            // 
            this.addressBarToolStripTextBox.Name = "addressBarToolStripTextBox";
            this.addressBarToolStripTextBox.Size = new System.Drawing.Size(170, 25);
            this.addressBarToolStripTextBox.Text = "http://www.google.co.in";
            // 
            // goButton
            // 
            this.goButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.goButton.Image = global::ScreenLock.Properties.Resources.goButton;
            this.goButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(23, 22);
            this.goButton.Text = "toolStripButton3";
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "He&lp";
            // 
            // onlineHelpBrowser
            // 
            this.onlineHelpBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.onlineHelpBrowser.Location = new System.Drawing.Point(0, 0);
            this.onlineHelpBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.onlineHelpBrowser.Name = "onlineHelpBrowser";
            this.onlineHelpBrowser.Size = new System.Drawing.Size(1141, 796);
            this.onlineHelpBrowser.TabIndex = 0;
            this.onlineHelpBrowser.Url = new System.Uri("http://www.google.co.in", System.UriKind.Absolute);
            // 
            // OnlineHelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 766);
            this.Controls.Add(this.onlineHelpPanel);
            this.Controls.Add(this.mainSelectionPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OnlineHelpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OnlineHelpForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnlineHelpForm_FormClosing);
            this.Load += new System.EventHandler(this.OnlineHelpForm_Load);
            this.mainSelectionPanel.ResumeLayout(false);
            this.onlineHelpPanel.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

      

        #endregion

        private System.Windows.Forms.Panel mainSelectionPanel;
        private System.Windows.Forms.Button accountNameButton;
        private System.Windows.Forms.Button adminOptionsButton;
        private System.Windows.Forms.Panel onlineHelpPanel;
        private System.Windows.Forms.PictureBox onlineHelpPictureBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton cutToolStripButton;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton goBackToolStripButton;
        private System.Windows.Forms.ToolStripButton goForwardToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox addressBarToolStripTextBox;
        private System.Windows.Forms.ToolStripButton goButton;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.WebBrowser onlineHelpBrowser;
    }
}