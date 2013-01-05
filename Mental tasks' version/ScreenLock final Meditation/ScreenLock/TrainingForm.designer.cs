/*
 * Created by SharpDevelop.
 * User: Vinay K Urala
 * Date: 5/6/2010
 * Time: 4:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SignalTrainAndMatch
{
	partial class TrainingForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.userNameLabel = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.activityTypeLabel = new System.Windows.Forms.Label();
            this.trainMediButton = new System.Windows.Forms.Button();
            this.trainFormExitButton = new System.Windows.Forms.Button();
            this.trainMathButton = new System.Windows.Forms.Button();
            this.trainMediLabel = new System.Windows.Forms.Label();
            this.trainMathLabel = new System.Windows.Forms.Label();
            this.mediTrainedlabel = new System.Windows.Forms.Label();
            this.mathTrainedLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // userNameLabel
            // 
            this.userNameLabel.Location = new System.Drawing.Point(27, 31);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(111, 23);
            this.userNameLabel.TabIndex = 0;
            this.userNameLabel.Text = "Enter New Username";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(164, 28);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(180, 20);
            this.userNameTextBox.TabIndex = 1;
            this.userNameTextBox.TextChanged += new System.EventHandler(this.userNameTextBox_TextChanged);
            // 
            // activityTypeLabel
            // 
            this.activityTypeLabel.Location = new System.Drawing.Point(27, 69);
            this.activityTypeLabel.Name = "activityTypeLabel";
            this.activityTypeLabel.Size = new System.Drawing.Size(100, 23);
            this.activityTypeLabel.TabIndex = 3;
            this.activityTypeLabel.Text = "Activity Type ";
            this.activityTypeLabel.Click += new System.EventHandler(this.ActivityTypeLabelClick);
            // 
            // trainMediButton
            // 
            this.trainMediButton.Location = new System.Drawing.Point(164, 112);
            this.trainMediButton.Name = "trainMediButton";
            this.trainMediButton.Size = new System.Drawing.Size(120, 25);
            this.trainMediButton.TabIndex = 4;
            this.trainMediButton.Text = "Train Meditation";
            this.trainMediButton.UseVisualStyleBackColor = true;
            this.trainMediButton.Click += new System.EventHandler(this.TrainStartButtonClick);
            // 
            // trainFormExitButton
            // 
            this.trainFormExitButton.Location = new System.Drawing.Point(365, 25);
            this.trainFormExitButton.Name = "trainFormExitButton";
            this.trainFormExitButton.Size = new System.Drawing.Size(75, 25);
            this.trainFormExitButton.TabIndex = 5;
            this.trainFormExitButton.Text = "Done";
            this.trainFormExitButton.UseVisualStyleBackColor = true;
            this.trainFormExitButton.Click += new System.EventHandler(this.TrainFormExitButtonClick);
            // 
            // trainMathButton
            // 
            this.trainMathButton.Location = new System.Drawing.Point(164, 176);
            this.trainMathButton.Name = "trainMathButton";
            this.trainMathButton.Size = new System.Drawing.Size(120, 23);
            this.trainMathButton.TabIndex = 6;
            this.trainMathButton.Text = "Train Math";
            this.trainMathButton.UseVisualStyleBackColor = true;
            this.trainMathButton.Click += new System.EventHandler(this.trainMathButton_Click);
            // 
            // trainMediLabel
            // 
            this.trainMediLabel.AutoSize = true;
            this.trainMediLabel.Location = new System.Drawing.Point(27, 118);
            this.trainMediLabel.Name = "trainMediLabel";
            this.trainMediLabel.Size = new System.Drawing.Size(56, 13);
            this.trainMediLabel.TabIndex = 8;
            this.trainMediLabel.Text = "Meditation";
            // 
            // trainMathLabel
            // 
            this.trainMathLabel.AutoSize = true;
            this.trainMathLabel.Location = new System.Drawing.Point(27, 181);
            this.trainMathLabel.Name = "trainMathLabel";
            this.trainMathLabel.Size = new System.Drawing.Size(31, 13);
            this.trainMathLabel.TabIndex = 9;
            this.trainMathLabel.Text = "Math";
            // 
            // mediTrainedlabel
            // 
            this.mediTrainedlabel.AutoSize = true;
            this.mediTrainedlabel.Location = new System.Drawing.Point(348, 118);
            this.mediTrainedlabel.Name = "mediTrainedlabel";
            this.mediTrainedlabel.Size = new System.Drawing.Size(76, 13);
            this.mediTrainedlabel.TabIndex = 11;
            this.mediTrainedlabel.Text = "Not completed";
            // 
            // mathTrainedLabel
            // 
            this.mathTrainedLabel.AutoSize = true;
            this.mathTrainedLabel.Location = new System.Drawing.Point(348, 181);
            this.mathTrainedLabel.Name = "mathTrainedLabel";
            this.mathTrainedLabel.Size = new System.Drawing.Size(77, 13);
            this.mathTrainedLabel.TabIndex = 12;
            this.mathTrainedLabel.Text = "Not Completed";
            // 
            // TrainingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 227);
            this.ControlBox = false;
            this.Controls.Add(this.mathTrainedLabel);
            this.Controls.Add(this.mediTrainedlabel);
            this.Controls.Add(this.trainMathLabel);
            this.Controls.Add(this.trainMediLabel);
            this.Controls.Add(this.trainMathButton);
            this.Controls.Add(this.trainFormExitButton);
            this.Controls.Add(this.trainMediButton);
            this.Controls.Add(this.activityTypeLabel);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.userNameLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TrainingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TrainingForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.TrainingFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.Button trainMediButton;
        private System.Windows.Forms.Button trainFormExitButton;
		private System.Windows.Forms.TextBox userNameTextBox;
		private System.Windows.Forms.Label activityTypeLabel;
		private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Button trainMathButton;
        private System.Windows.Forms.Label trainMediLabel;
        private System.Windows.Forms.Label trainMathLabel;
        private System.Windows.Forms.Label mediTrainedlabel;
        private System.Windows.Forms.Label mathTrainedLabel;
	}
}
