namespace WindowsFormsThreadDemo
{
    partial class TrainingForm
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
            this.progressBar_Cognitiv = new System.Windows.Forms.ProgressBar();
            this.button_Exit = new System.Windows.Forms.Button();
            this.textBox_CognitivCurrentAction = new System.Windows.Forms.TextBox();
            this.button_StartTraining = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_Add_New_Action = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox_TrainingAction = new System.Windows.Forms.ComboBox();
            this.listBox_ActiveActions = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button_AddNewAction = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_OverallSkillRating = new System.Windows.Forms.TextBox();
            this.button_SaveUserProfile = new System.Windows.Forms.Button();
            this.button_DeleteActivity = new System.Windows.Forms.Button();
            this.label_TrainingMessage = new System.Windows.Forms.Label();
            this.button_EraseTraining = new System.Windows.Forms.Button();
            this.checkBox_AnimateCube = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_NewUserName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // progressBar_Cognitiv
            // 
            this.progressBar_Cognitiv.Location = new System.Drawing.Point(92, 88);
            this.progressBar_Cognitiv.Name = "progressBar_Cognitiv";
            this.progressBar_Cognitiv.Size = new System.Drawing.Size(406, 23);
            this.progressBar_Cognitiv.TabIndex = 1;
            // 
            // button_Exit
            // 
            this.button_Exit.Location = new System.Drawing.Point(435, 479);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(166, 23);
            this.button_Exit.TabIndex = 3;
            this.button_Exit.Text = "Exit";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_CognitivCurrentAction
            // 
            this.textBox_CognitivCurrentAction.Location = new System.Drawing.Point(92, 62);
            this.textBox_CognitivCurrentAction.Name = "textBox_CognitivCurrentAction";
            this.textBox_CognitivCurrentAction.Size = new System.Drawing.Size(149, 20);
            this.textBox_CognitivCurrentAction.TabIndex = 5;
            // 
            // button_StartTraining
            // 
            this.button_StartTraining.Location = new System.Drawing.Point(88, 414);
            this.button_StartTraining.Name = "button_StartTraining";
            this.button_StartTraining.Size = new System.Drawing.Size(121, 23);
            this.button_StartTraining.TabIndex = 9;
            this.button_StartTraining.Text = "Start Training";
            this.button_StartTraining.UseVisualStyleBackColor = true;
            this.button_StartTraining.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(76, 383);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "Training Action";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Current Action";
            // 
            // comboBox_Add_New_Action
            // 
            this.comboBox_Add_New_Action.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Add_New_Action.FormattingEnabled = true;
            this.comboBox_Add_New_Action.Location = new System.Drawing.Point(123, 307);
            this.comboBox_Add_New_Action.Name = "comboBox_Add_New_Action";
            this.comboBox_Add_New_Action.Size = new System.Drawing.Size(177, 21);
            this.comboBox_Add_New_Action.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 310);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Add New Action";
            // 
            // comboBox_TrainingAction
            // 
            this.comboBox_TrainingAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TrainingAction.Location = new System.Drawing.Point(160, 381);
            this.comboBox_TrainingAction.Name = "comboBox_TrainingAction";
            this.comboBox_TrainingAction.Size = new System.Drawing.Size(191, 21);
            this.comboBox_TrainingAction.TabIndex = 21;
            // 
            // listBox_ActiveActions
            // 
            this.listBox_ActiveActions.FormattingEnabled = true;
            this.listBox_ActiveActions.Location = new System.Drawing.Point(118, 154);
            this.listBox_ActiveActions.Name = "listBox_ActiveActions";
            this.listBox_ActiveActions.Size = new System.Drawing.Size(261, 95);
            this.listBox_ActiveActions.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 157);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Active Actions";
            // 
            // button_AddNewAction
            // 
            this.button_AddNewAction.Location = new System.Drawing.Point(325, 306);
            this.button_AddNewAction.Name = "button_AddNewAction";
            this.button_AddNewAction.Size = new System.Drawing.Size(115, 23);
            this.button_AddNewAction.TabIndex = 25;
            this.button_AddNewAction.Text = "Add New Action";
            this.button_AddNewAction.UseVisualStyleBackColor = true;
            this.button_AddNewAction.Click += new System.EventHandler(this.button_AddNewAction_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 254);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Overall Skill Rating";
            // 
            // textBox_OverallSkillRating
            // 
            this.textBox_OverallSkillRating.Enabled = false;
            this.textBox_OverallSkillRating.Location = new System.Drawing.Point(118, 251);
            this.textBox_OverallSkillRating.Name = "textBox_OverallSkillRating";
            this.textBox_OverallSkillRating.Size = new System.Drawing.Size(118, 20);
            this.textBox_OverallSkillRating.TabIndex = 27;
            // 
            // button_SaveUserProfile
            // 
            this.button_SaveUserProfile.Location = new System.Drawing.Point(399, 13);
            this.button_SaveUserProfile.Name = "button_SaveUserProfile";
            this.button_SaveUserProfile.Size = new System.Drawing.Size(114, 23);
            this.button_SaveUserProfile.TabIndex = 28;
            this.button_SaveUserProfile.Text = "Save User Profile";
            this.button_SaveUserProfile.UseVisualStyleBackColor = true;
            this.button_SaveUserProfile.Click += new System.EventHandler(this.button_SaveUserProfile_Click);
            // 
            // button_DeleteActivity
            // 
            this.button_DeleteActivity.Enabled = false;
            this.button_DeleteActivity.Location = new System.Drawing.Point(385, 157);
            this.button_DeleteActivity.Name = "button_DeleteActivity";
            this.button_DeleteActivity.Size = new System.Drawing.Size(93, 23);
            this.button_DeleteActivity.TabIndex = 29;
            this.button_DeleteActivity.Text = "Delete Activity";
            this.button_DeleteActivity.UseVisualStyleBackColor = true;
            this.button_DeleteActivity.Click += new System.EventHandler(this.button_DeleteActivity_Click);
            // 
            // label_TrainingMessage
            // 
            this.label_TrainingMessage.Location = new System.Drawing.Point(103, 436);
            this.label_TrainingMessage.Name = "label_TrainingMessage";
            this.label_TrainingMessage.Size = new System.Drawing.Size(332, 23);
            this.label_TrainingMessage.TabIndex = 30;
            // 
            // button_EraseTraining
            // 
            this.button_EraseTraining.Location = new System.Drawing.Point(261, 414);
            this.button_EraseTraining.Name = "button_EraseTraining";
            this.button_EraseTraining.Size = new System.Drawing.Size(121, 23);
            this.button_EraseTraining.TabIndex = 32;
            this.button_EraseTraining.Text = "Erase Training";
            this.button_EraseTraining.UseVisualStyleBackColor = true;
            this.button_EraseTraining.Click += new System.EventHandler(this.button_EraseTraining_Click);
            // 
            // checkBox_AnimateCube
            // 
            this.checkBox_AnimateCube.AutoSize = true;
            this.checkBox_AnimateCube.Location = new System.Drawing.Point(359, 384);
            this.checkBox_AnimateCube.Name = "checkBox_AnimateCube";
            this.checkBox_AnimateCube.Size = new System.Drawing.Size(91, 17);
            this.checkBox_AnimateCube.TabIndex = 33;
            this.checkBox_AnimateCube.Text = "Animate cube";
            this.checkBox_AnimateCube.UseVisualStyleBackColor = true;
            this.checkBox_AnimateCube.CheckedChanged += new System.EventHandler(this.checkBox_AnimateCube_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "New userName";
            // 
            // textBox_NewUserName
            // 
            this.textBox_NewUserName.Location = new System.Drawing.Point(206, 15);
            this.textBox_NewUserName.Name = "textBox_NewUserName";
            this.textBox_NewUserName.Size = new System.Drawing.Size(162, 20);
            this.textBox_NewUserName.TabIndex = 35;
            // 
            // TrainingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 501);
            this.ControlBox = false;
            this.Controls.Add(this.textBox_NewUserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_AnimateCube);
            this.Controls.Add(this.button_EraseTraining);
            this.Controls.Add(this.label_TrainingMessage);
            this.Controls.Add(this.button_DeleteActivity);
            this.Controls.Add(this.button_SaveUserProfile);
            this.Controls.Add(this.textBox_OverallSkillRating);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button_AddNewAction);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.listBox_ActiveActions);
            this.Controls.Add(this.comboBox_TrainingAction);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox_Add_New_Action);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_StartTraining);
            this.Controls.Add(this.textBox_CognitivCurrentAction);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.progressBar_Cognitiv);
            this.Name = "TrainingForm";
            this.Text = "Main Form";
            this.TopMost = false;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormClosedHandlerFunction);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar_Cognitiv;

        //public System.Windows.Forms.ProgressBar ProgressBar_Cognitiv
        //{
        //    get { return progressBar_Cognitiv; }
        //    set { progressBar_Cognitiv = value; }
        //}
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.TextBox textBox_CognitivCurrentAction;
        private System.Windows.Forms.Button button_StartTraining;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_Add_New_Action;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox_TrainingAction;
        private System.Windows.Forms.ListBox listBox_ActiveActions;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button_AddNewAction;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_OverallSkillRating;
        private System.Windows.Forms.Button button_SaveUserProfile;
        private System.Windows.Forms.Button button_DeleteActivity;
        private System.Windows.Forms.Label label_TrainingMessage;
        private System.Windows.Forms.Button button_EraseTraining;
        private System.Windows.Forms.CheckBox checkBox_AnimateCube;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_NewUserName;

        //public System.Windows.Forms.ProgressBar ProgressBar_Expressiv
        //{
        //    get { return progressBar_Expressiv; }
        //    set { progressBar_Expressiv = value; }
        //}
    }
}

