namespace SignalTrainAndMatch
{
    partial class MatchForm
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
            this.activityTypeLabel = new System.Windows.Forms.Label();
            this.mediMatchButton = new System.Windows.Forms.Button();
            this.mediMatchLabel = new System.Windows.Forms.Label();
            this.mathMatchLabel = new System.Windows.Forms.Label();
            this.matchMediLabel = new System.Windows.Forms.Label();
            this.matchMathLabel = new System.Windows.Forms.Label();
            this.mathMatchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // activityTypeLabel
            // 
            this.activityTypeLabel.AutoSize = true;
            this.activityTypeLabel.Location = new System.Drawing.Point(123, 32);
            this.activityTypeLabel.Name = "activityTypeLabel";
            this.activityTypeLabel.Size = new System.Drawing.Size(231, 13);
            this.activityTypeLabel.TabIndex = 1;
            this.activityTypeLabel.Text = "Perform following activities to unlock the screen";
            this.activityTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mediMatchButton
            // 
            this.mediMatchButton.Location = new System.Drawing.Point(151, 65);
            this.mediMatchButton.Name = "mediMatchButton";
            this.mediMatchButton.Size = new System.Drawing.Size(176, 23);
            this.mediMatchButton.TabIndex = 4;
            this.mediMatchButton.Text = "Authenticate Meditation";
            this.mediMatchButton.UseVisualStyleBackColor = true;
            this.mediMatchButton.Click += new System.EventHandler(this.signalMatchButton_Click);
            // 
            // mediMatchLabel
            // 
            this.mediMatchLabel.AutoSize = true;
            this.mediMatchLabel.Location = new System.Drawing.Point(32, 70);
            this.mediMatchLabel.Name = "mediMatchLabel";
            this.mediMatchLabel.Size = new System.Drawing.Size(56, 13);
            this.mediMatchLabel.TabIndex = 6;
            this.mediMatchLabel.Text = "Meditation";
            this.mediMatchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mathMatchLabel
            // 
            this.mathMatchLabel.AutoSize = true;
            this.mathMatchLabel.Location = new System.Drawing.Point(32, 112);
            this.mathMatchLabel.Name = "mathMatchLabel";
            this.mathMatchLabel.Size = new System.Drawing.Size(31, 13);
            this.mathMatchLabel.TabIndex = 7;
            this.mathMatchLabel.Text = "Math";
            // 
            // matchMediLabel
            // 
            this.matchMediLabel.AutoSize = true;
            this.matchMediLabel.Location = new System.Drawing.Point(370, 70);
            this.matchMediLabel.Name = "matchMediLabel";
            this.matchMediLabel.Size = new System.Drawing.Size(92, 13);
            this.matchMediLabel.TabIndex = 9;
            this.matchMediLabel.Text = "Not authenticated";
            // 
            // matchMathLabel
            // 
            this.matchMathLabel.AutoSize = true;
            this.matchMathLabel.Location = new System.Drawing.Point(370, 112);
            this.matchMathLabel.Name = "matchMathLabel";
            this.matchMathLabel.Size = new System.Drawing.Size(92, 13);
            this.matchMathLabel.TabIndex = 10;
            this.matchMathLabel.Text = "Not authenticated";
            // 
            // mathMatchButton
            // 
            this.mathMatchButton.Location = new System.Drawing.Point(151, 107);
            this.mathMatchButton.Name = "mathMatchButton";
            this.mathMatchButton.Size = new System.Drawing.Size(176, 23);
            this.mathMatchButton.TabIndex = 12;
            this.mathMatchButton.Text = "Authenticate Math";
            this.mathMatchButton.UseVisualStyleBackColor = true;
            this.mathMatchButton.Click += new System.EventHandler(this.mathMatchButton_Click);
            // 
            // MatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 176);
            this.ControlBox = false;
            this.Controls.Add(this.mathMatchButton);
            this.Controls.Add(this.matchMathLabel);
            this.Controls.Add(this.matchMediLabel);
            this.Controls.Add(this.mathMatchLabel);
            this.Controls.Add(this.mediMatchLabel);
            this.Controls.Add(this.mediMatchButton);
            this.Controls.Add(this.activityTypeLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MatchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MatchForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MatchForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MatchForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label activityTypeLabel;
        private System.Windows.Forms.Button mediMatchButton;
        private System.Windows.Forms.Label mediMatchLabel;
        private System.Windows.Forms.Label mathMatchLabel;
        private System.Windows.Forms.Label matchMediLabel;
        private System.Windows.Forms.Label matchMathLabel;
        private System.Windows.Forms.Button mathMatchButton;
    }
}