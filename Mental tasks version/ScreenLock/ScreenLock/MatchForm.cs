using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using MatchFeaturesVinayNew1;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using System.Collections;
using Emotiv;
using WindowsFormsApplication2;
using ScreenLock;


namespace SignalTrainAndMatch
{
    public partial class MatchForm : Form
    {
        string activityType;
        string userName;
        string storedFile;
        MWArray res;
        string authParam;
        bool authenticationSuccess = false;

        System.Array ans = new double[1];
        UserAuthentication userAuthenticateObj = new UserAuthentication();
        ScreenLockHelper screenLockObj = new ScreenLockHelper();
        //static ScreenLock.LoginForm loginFormObj = new ScreenLock.LoginForm();
        EEG_Logger eeg_loggerObject = new EEG_Logger();
        public MatchForm()
        {
            InitializeComponent();
        }

        private void MatchForm_Load(object sender, EventArgs e)
        {
            //formCloseButton.Enabled = false;
            //mathMatchButton.Visible = false;
           // Environment.CurrentDirectory = Environment.CurrentDirectory + "\\profiles";

            userName = ScreenLock.LoginForm.userNameString;
        }

        private void formCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void signalMatchButton_Click(object sender, EventArgs e)
        {
            //userName = ScreenLock.LoginForm.loginFormStaticObject.userNameString.Text;
           // userName = ScreenLock.LoginForm.userNameString;
            activityType = "Meditation";
           // string path = "profiles\\" + userName;//Environment.CurrentDirectory + "\\profiles\\" + userName;
            string path = userName;
            if (!(Directory.Exists(path)))
            {
                MessageBox.Show("User name \"" + userName + "\" not found!!");
                return;
            }
            //else
            //{
            //    //userNameTextBox.Enabled = false;
            //}
            string temp = activityType+"Activity.txt";
          //  string filePath = Environment.CurrentDirectory + "\\profiles\\" + userName + "\\" + temp;
            string filePath = userName + "\\" + temp;
            if (!(File.Exists(filePath)))
            {
                MessageBox.Show("\"" + activityType + "\" activity not trained!!Train the activity before matching");
                return;
            }
            mediMatchButton.Enabled = false;
            storedFile = "outfile.CSV";
            eeg_loggerObject.record(storedFile);
            try
            {
                res = userAuthenticateObj.matchFeatures(userName, storedFile, activityType);
                ans = ((MWNumericArray)res).ToVector(MWArrayComponent.Real);
                authParam = ans.GetValue(0).ToString();
                if (authParam.Equals("1"))
                {
                    mediMatchButton.Visible = false;
                    mathMatchButton.Visible = true;
                    matchMediLabel.Text = "Authenticated";
                    //formCloseButton.Enabled = true;
                }
                else
                {
                    authParam = null;
                    MessageBox.Show("Authentication Failure!!", "FAILURE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mediMatchButton.Enabled = true;
                    mathMatchButton.Visible = false;
                    //readingMatchButton.Visible = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was some error while matching the features!!");
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
                mediMatchButton.Visible = true;
            }
            finally
            {
                mediMatchButton.Visible = true;
                //mathMatchButton.Visible = true;
            }
        }

        private void mathMatchButton_Click(object sender, EventArgs e)
        {
            activityType = "Math";
          //  string path = Environment.CurrentDirectory + "\\profiles\\" + userName;
            string path = userName;
            string temp = activityType + "Activity.txt";
           // string filePath = Environment.CurrentDirectory + "\\profiles\\" + userName + "\\" + temp;
            string filePath = userName + "\\" + temp;
            if (!(File.Exists(filePath)))
            {
                MessageBox.Show("\"" + activityType + "\" activity not trained!!Train the activity before matching");
                return;
            }
            storedFile =  "outfile.CSV";
            mathMatchButton.Enabled = false;
            eeg_loggerObject.record(storedFile);
            try
            {
                res = userAuthenticateObj.matchFeatures(userName, storedFile, activityType);
                ans = ((MWNumericArray)res).ToVector(MWArrayComponent.Real);
                authParam = ans.GetValue(0).ToString();
                if (authParam.Equals("1"))
                {
                    mathMatchButton.Visible = false;
                    //readingMatchButton.Visible = true;
                    MessageBox.Show("Authentication Success");
                    //formCloseButton.Enabled = true;
                    authenticationSuccess = true;
                    this.Close();
                    //ScreenLock.AccountUpdate accUpdateFormObj = new ScreenLock.AccountUpdate();
                    //accUpdateFormObj.Show();
                    if (ScreenLock.MainPromptForm.mainPromptFormStaticObject != null)
                    {
                        ScreenLock.MainPromptForm.mainPromptFormStaticObject.Show();
                    }
                    else
                    {
                        ScreenLock.MainPromptForm.mainPromptFormStaticObject = new MainPromptForm();
                        ScreenLock.MainPromptForm.mainPromptFormStaticObject.Show();
                    }
                }
                else
                {
                    authParam = null;
                    MessageBox.Show("Authentication Failure!!", "FAILURE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mediMatchButton.Visible = false;
                    mathMatchButton.Enabled = true;
                    //formCloseButton.Enabled = true;
                    //readingMatchButton.Visible = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was some error while matching the features!!");
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
                mathMatchButton.Visible = true;
            }
        }

        private void MatchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!authenticationSuccess)
            {
                LoginForm loginFormObj = new LoginForm();
                BackgroundScreen.loginFormReload(loginFormObj);
                this.Hide();
                Application.Restart();
                //if (ScreenLock.LoginForm.loginFormStaticObject != null)
                //{
                //    ScreenLock.LoginForm.loginFormStaticObject.Show();
                //}
            }

        }

        

    }
}
