using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;
using Emotiv;
using MatchFeaturesVinayNew1;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using WindowsFormsApplication2;

namespace SignalTrainAndMatch
{
	/// <summary>
	/// Description of TrainingForm.
	/// </summary>
	public partial class TrainingForm : Form
	{
		string activityType;
		string userName;
		string storedFile;
        public static string currentDirectory = null;
		UserAuthentication userAuthObj = new UserAuthentication();
		string currDir = Environment.CurrentDirectory;
		EEG_Logger eeg_loggerObject = new EEG_Logger();
		public TrainingForm()
		{
			InitializeComponent();
		}
		
		void TrainingFormLoad(object sender, EventArgs e)
		{
            trainFormExitButton.Enabled = true;
            trainMathButton.Visible = true;

            if (currentDirectory == null)
            {
                Environment.CurrentDirectory = Environment.CurrentDirectory + "\\profiles";
                currentDirectory = Environment.CurrentDirectory;
            }
          

          this.Show();
		}
		
		void TrainFormExitButtonClick(object sender, EventArgs e)
		{
            hideUserDir();
			this.Close();
		}
		
		void TrainStartButtonClick(object sender, EventArgs e)
		{
            if (userNameTextBox.TextLength == 0)
            {
                MessageBox.Show("No username entered!!");
                return;
            }
            else
            {
                userNameTextBox.Enabled = false;
                //trainFormExitButton.Enabled = false;
            }
			userName = userNameTextBox.Text;
			activityType = "Meditation";
            trainMediButton.Enabled = false;
            storedFile = "outfile.CSV";
            eeg_loggerObject.record(storedFile);
			try{
				userAuthObj.storeNewFeature(userName , storedFile , activityType);
				MessageBox.Show("Training Completed successfully!!");
                mediTrainedlabel.Text = "Completed";
                trainMediButton.Visible = false;
                trainMathButton.Visible = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("There was some error while extracting features");
				MessageBox.Show(ex.Message);
				MessageBox.Show(ex.StackTrace);
                trainMediButton.Enabled = true;
			}
		}

        private void trainMathButton_Click(object sender, EventArgs e)
        {
            userName = userNameTextBox.Text;
            activityType = "Math";
            trainMathButton.Enabled = false;
            storedFile = "outfile.CSV";
            eeg_loggerObject.record(storedFile);
            try
            {
                userAuthObj.storeNewFeature(userName,  storedFile, activityType);
                MessageBox.Show("Training Completed successfully!!");
                mathTrainedLabel.Text = "Completed";
                //trainMathButton.Visible = false;
                //trainReadingButton.Visible = true;
                trainFormExitButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was some error while extracting features");
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
                trainMathButton.Enabled = true;
                
            }
        }

        public void hideUserDir()
        {
            string path = Environment.CurrentDirectory + "\\" + userName;
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            dirInfo.Attributes = FileAttributes.Directory | FileAttributes.Hidden | FileAttributes.System;
        }
	}
}
