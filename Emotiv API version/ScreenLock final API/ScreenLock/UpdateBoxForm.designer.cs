namespace WindowsGameSimpleCube1
{
    partial class UpdateBoxForm
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
            this.button_RotateLeft = new System.Windows.Forms.Button();
            this.button_RotateRight = new System.Windows.Forms.Button();
            this.button_RotateForward = new System.Windows.Forms.Button();
            this.button_RotateBackward = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_RotateLeft
            // 
            this.button_RotateLeft.Location = new System.Drawing.Point(182, 44);
            this.button_RotateLeft.Name = "button_RotateLeft";
            this.button_RotateLeft.Size = new System.Drawing.Size(75, 23);
            this.button_RotateLeft.TabIndex = 0;
            this.button_RotateLeft.Text = "Rotate Left";
            this.button_RotateLeft.UseVisualStyleBackColor = true;
            this.button_RotateLeft.Click += new System.EventHandler(this.button_RotateLeft_Click);
            // 
            // button_RotateRight
            // 
            this.button_RotateRight.Location = new System.Drawing.Point(563, 43);
            this.button_RotateRight.Name = "button_RotateRight";
            this.button_RotateRight.Size = new System.Drawing.Size(75, 23);
            this.button_RotateRight.TabIndex = 1;
            this.button_RotateRight.Text = "Rotate Right";
            this.button_RotateRight.UseVisualStyleBackColor = true;
            this.button_RotateRight.Click += new System.EventHandler(this.button_RotateRight_Click);
            // 
            // button_RotateForward
            // 
            this.button_RotateForward.Location = new System.Drawing.Point(168, 131);
            this.button_RotateForward.Name = "button_RotateForward";
            this.button_RotateForward.Size = new System.Drawing.Size(99, 23);
            this.button_RotateForward.TabIndex = 2;
            this.button_RotateForward.Text = "Rotate Forward";
            this.button_RotateForward.UseVisualStyleBackColor = true;
            this.button_RotateForward.Click += new System.EventHandler(this.button_RotateForward_Click);
            // 
            // button_RotateBackward
            // 
            this.button_RotateBackward.Location = new System.Drawing.Point(546, 131);
            this.button_RotateBackward.Name = "button_RotateBackward";
            this.button_RotateBackward.Size = new System.Drawing.Size(109, 23);
            this.button_RotateBackward.TabIndex = 3;
            this.button_RotateBackward.Text = "Rotate Backward";
            this.button_RotateBackward.UseVisualStyleBackColor = true;
            this.button_RotateBackward.Click += new System.EventHandler(this.button_RotateBackward_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(356, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(485, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UpdateBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 262);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_RotateBackward);
            this.Controls.Add(this.button_RotateForward);
            this.Controls.Add(this.button_RotateRight);
            this.Controls.Add(this.button_RotateLeft);
            this.Name = "UpdateBoxForm";
            this.Text = "UpdateBoxForm";
            this.Load += new System.EventHandler(this.UpdateBoxForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_RotateLeft;
        private System.Windows.Forms.Button button_RotateRight;
        private System.Windows.Forms.Button button_RotateForward;
        private System.Windows.Forms.Button button_RotateBackward;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}