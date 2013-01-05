namespace WindowsGameSimpleCube1
{
    partial class AuthenticateForm
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
            this.label_UserId = new System.Windows.Forms.Label();
            this.textBox_Username = new System.Windows.Forms.TextBox();
            this.button_Unlock = new System.Windows.Forms.Button();
            this.label_Action1 = new System.Windows.Forms.Label();
            this.label_Action2 = new System.Windows.Forms.Label();
            this.label_Action3 = new System.Windows.Forms.Label();
            this.label_Action1State = new System.Windows.Forms.Label();
            this.label_Action2State = new System.Windows.Forms.Label();
            this.label_Action3State = new System.Windows.Forms.Label();
            this.button_AuthenticateAction1 = new System.Windows.Forms.Button();
            this.button_AuthenticateAction2 = new System.Windows.Forms.Button();
            this.button_AuthenticateAction3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar_CognitivActivity = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label_ActionPower = new System.Windows.Forms.Label();
            this.label_CurrentAction = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_UserId
            // 
            this.label_UserId.AutoSize = true;
            this.label_UserId.Location = new System.Drawing.Point(154, 16);
            this.label_UserId.Name = "label_UserId";
            this.label_UserId.Size = new System.Drawing.Size(55, 13);
            this.label_UserId.TabIndex = 0;
            this.label_UserId.Text = "Username";
            // 
            // textBox_Username
            // 
            this.textBox_Username.Location = new System.Drawing.Point(225, 13);
            this.textBox_Username.Name = "textBox_Username";
            this.textBox_Username.Size = new System.Drawing.Size(185, 20);
            this.textBox_Username.TabIndex = 1;
            // 
            // button_Unlock
            // 
            this.button_Unlock.Location = new System.Drawing.Point(447, 12);
            this.button_Unlock.Name = "button_Unlock";
            this.button_Unlock.Size = new System.Drawing.Size(151, 23);
            this.button_Unlock.TabIndex = 2;
            this.button_Unlock.Text = "Unlock";
            this.button_Unlock.UseVisualStyleBackColor = true;
            this.button_Unlock.Click += new System.EventHandler(this.button_Unlock_Click);
            // 
            // label_Action1
            // 
            this.label_Action1.AutoSize = true;
            this.label_Action1.Location = new System.Drawing.Point(244, 62);
            this.label_Action1.Name = "label_Action1";
            this.label_Action1.Size = new System.Drawing.Size(43, 13);
            this.label_Action1.TabIndex = 3;
            this.label_Action1.Text = "Action1";
            this.label_Action1.Visible = false;
            // 
            // label_Action2
            // 
            this.label_Action2.AutoSize = true;
            this.label_Action2.Location = new System.Drawing.Point(244, 98);
            this.label_Action2.Name = "label_Action2";
            this.label_Action2.Size = new System.Drawing.Size(43, 13);
            this.label_Action2.TabIndex = 4;
            this.label_Action2.Text = "Action2";
            this.label_Action2.Visible = false;
            // 
            // label_Action3
            // 
            this.label_Action3.AutoSize = true;
            this.label_Action3.Location = new System.Drawing.Point(244, 132);
            this.label_Action3.Name = "label_Action3";
            this.label_Action3.Size = new System.Drawing.Size(43, 13);
            this.label_Action3.TabIndex = 5;
            this.label_Action3.Text = "Action3";
            this.label_Action3.Visible = false;
            // 
            // label_Action1State
            // 
            this.label_Action1State.AutoSize = true;
            this.label_Action1State.Location = new System.Drawing.Point(478, 62);
            this.label_Action1State.Name = "label_Action1State";
            this.label_Action1State.Size = new System.Drawing.Size(93, 13);
            this.label_Action1State.TabIndex = 7;
            this.label_Action1State.Text = "Not Authenticated";
            this.label_Action1State.Visible = false;
            // 
            // label_Action2State
            // 
            this.label_Action2State.AutoSize = true;
            this.label_Action2State.Location = new System.Drawing.Point(478, 98);
            this.label_Action2State.Name = "label_Action2State";
            this.label_Action2State.Size = new System.Drawing.Size(93, 13);
            this.label_Action2State.TabIndex = 8;
            this.label_Action2State.Text = "Not Authenticated";
            this.label_Action2State.Visible = false;
            // 
            // label_Action3State
            // 
            this.label_Action3State.AutoSize = true;
            this.label_Action3State.Location = new System.Drawing.Point(478, 132);
            this.label_Action3State.Name = "label_Action3State";
            this.label_Action3State.Size = new System.Drawing.Size(93, 13);
            this.label_Action3State.TabIndex = 9;
            this.label_Action3State.Text = "Not Authenticated";
            this.label_Action3State.Visible = false;
            // 
            // button_AuthenticateAction1
            // 
            this.button_AuthenticateAction1.Location = new System.Drawing.Point(676, 62);
            this.button_AuthenticateAction1.Name = "button_AuthenticateAction1";
            this.button_AuthenticateAction1.Size = new System.Drawing.Size(75, 23);
            this.button_AuthenticateAction1.TabIndex = 10;
            this.button_AuthenticateAction1.Text = "Authenticate";
            this.button_AuthenticateAction1.UseVisualStyleBackColor = true;
            this.button_AuthenticateAction1.Visible = false;
            this.button_AuthenticateAction1.Click += new System.EventHandler(this.button_AuthenticateAction1_Click);
            // 
            // button_AuthenticateAction2
            // 
            this.button_AuthenticateAction2.Location = new System.Drawing.Point(676, 98);
            this.button_AuthenticateAction2.Name = "button_AuthenticateAction2";
            this.button_AuthenticateAction2.Size = new System.Drawing.Size(75, 23);
            this.button_AuthenticateAction2.TabIndex = 11;
            this.button_AuthenticateAction2.Text = "Authenticate";
            this.button_AuthenticateAction2.UseVisualStyleBackColor = true;
            this.button_AuthenticateAction2.Visible = false;
            this.button_AuthenticateAction2.Click += new System.EventHandler(this.button_AuthenticateAction2_Click);
            // 
            // button_AuthenticateAction3
            // 
            this.button_AuthenticateAction3.Location = new System.Drawing.Point(676, 132);
            this.button_AuthenticateAction3.Name = "button_AuthenticateAction3";
            this.button_AuthenticateAction3.Size = new System.Drawing.Size(75, 23);
            this.button_AuthenticateAction3.TabIndex = 12;
            this.button_AuthenticateAction3.Text = "Authenticate";
            this.button_AuthenticateAction3.UseVisualStyleBackColor = true;
            this.button_AuthenticateAction3.Visible = false;
            this.button_AuthenticateAction3.Click += new System.EventHandler(this.button_AuthenticateAction3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(252, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(482, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(707, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar_CognitivActivity
            // 
            this.progressBar_CognitivActivity.Location = new System.Drawing.Point(13, 165);
            this.progressBar_CognitivActivity.Name = "progressBar_CognitivActivity";
            this.progressBar_CognitivActivity.Size = new System.Drawing.Size(212, 23);
            this.progressBar_CognitivActivity.TabIndex = 17;
            this.progressBar_CognitivActivity.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            // 
            // label_ActionPower
            // 
            this.label_ActionPower.AutoSize = true;
            this.label_ActionPower.Location = new System.Drawing.Point(13, 146);
            this.label_ActionPower.Name = "label_ActionPower";
            this.label_ActionPower.Size = new System.Drawing.Size(70, 13);
            this.label_ActionPower.TabIndex = 19;
            this.label_ActionPower.Text = "Action Power";
            this.label_ActionPower.Visible = false;
            // 
            // label_CurrentAction
            // 
            this.label_CurrentAction.AutoSize = true;
            this.label_CurrentAction.Location = new System.Drawing.Point(103, 146);
            this.label_CurrentAction.Name = "label_CurrentAction";
            this.label_CurrentAction.Size = new System.Drawing.Size(74, 13);
            this.label_CurrentAction.TabIndex = 20;
            this.label_CurrentAction.Text = "Current Action";
            this.label_CurrentAction.Visible = false;
            // 
            // AuthenticateForm
            // 
            this.AcceptButton = this.button_Unlock;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 200);
            this.Controls.Add(this.label_CurrentAction);
            this.Controls.Add(this.label_ActionPower);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressBar_CognitivActivity);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_AuthenticateAction3);
            this.Controls.Add(this.button_AuthenticateAction2);
            this.Controls.Add(this.button_AuthenticateAction1);
            this.Controls.Add(this.label_Action3State);
            this.Controls.Add(this.label_Action2State);
            this.Controls.Add(this.label_Action1State);
            this.Controls.Add(this.label_Action3);
            this.Controls.Add(this.label_Action2);
            this.Controls.Add(this.label_Action1);
            this.Controls.Add(this.button_Unlock);
            this.Controls.Add(this.textBox_Username);
            this.Controls.Add(this.label_UserId);
            this.Name = "AuthenticateForm";
            this.Text = "AuthenticateForm";
            this.Load += new System.EventHandler(this.AuthenticateForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AuthenticateForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_UserId;
        private System.Windows.Forms.TextBox textBox_Username;
        private System.Windows.Forms.Button button_Unlock;
        private System.Windows.Forms.Label label_Action1;
        private System.Windows.Forms.Label label_Action2;
        private System.Windows.Forms.Label label_Action3;
        private System.Windows.Forms.Label label_Action1State;
        private System.Windows.Forms.Label label_Action2State;
        private System.Windows.Forms.Label label_Action3State;
        private System.Windows.Forms.Button button_AuthenticateAction1;
        private System.Windows.Forms.Button button_AuthenticateAction2;
        private System.Windows.Forms.Button button_AuthenticateAction3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar_CognitivActivity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_ActionPower;
        private System.Windows.Forms.Label label_CurrentAction;
    }
}