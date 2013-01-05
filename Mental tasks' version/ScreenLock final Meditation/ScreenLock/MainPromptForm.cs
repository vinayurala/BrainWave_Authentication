using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScreenLock
{
    public partial class MainPromptForm : Form
    {
        static bool RunAtStartup = false;

        // public static MainPromptForm mainPromptFormStaticObject= new MainPromptForm();

        
        public static MainPromptForm mainPromptFormStaticObject = null;// new MainPromptForm();
        ScreenLockHelper screenLockObj = new ScreenLockHelper();

        public MainPromptForm()
        {
            InitializeComponent();
           // mainPromptFormStaticObject = this;
        }

       

        private void MainPromptForm_Load(object sender, EventArgs e)
        {
            this.SetTopLevel(true);
            //Environment.CurrentDirectory = "profiles";

            // First write logic to retrive this data from database or a flat file
            // Then enable or disable enableStartupCheckBock
            // here I am assuming it as true.

            if (!RunAtStartup)
            {
                //screenLockHelperObj.addtoStartup();
                enableStartupCheckBox.Checked = false;
             
            }
            else
            {
                enableStartupCheckBox.Checked = true;
             
            }
            
        }

        private void MainPromptForm_Closing(object sender, EventArgs e)
        {
           // MessageBox.Show(" Application is closing now ", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
            screenLockObj.releaseHook();
            screenLockObj.maximizeWindow();

            Application.Exit();
        }

        private void enableStartupButton_Click(object sender, EventArgs e)
        {
            screenLockObj.addtoStartup();
            MessageBox.Show(" Successfully added to startup ", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
           // startupSuggestionLabel.Text= " Application is set to run on startup
        }

        private void enableStartupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            
                if (enableStartupCheckBox.Checked == true)
                {
                    screenLockObj.addtoStartup();
                    RunAtStartup = true;
                }
                else
                {
                    screenLockObj.removeFromStartup();
                    RunAtStartup = false;
                    
                }
            
        }

        private void accountNameButton_Click(object sender, EventArgs e)
        {

            this.Hide();


            //this.Close();
            //GC.Collect();
            //GC.WaitForPendingFinalizers();
            if (ScreenLock.AccountUpdate.accountUpdateStaticObject != null)
            {
                ScreenLock.AccountUpdate.accountUpdateStaticObject.Show();
            }
            else
            {

                ScreenLock.AccountUpdate.accountUpdateStaticObject = new AccountUpdate();
                ScreenLock.AccountUpdate.accountUpdateStaticObject.Show();
            }
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            // I know codes to invoke browser window inside the application.
            // So we can write codes to provide onlike help using Browser Objects in this application.
            // This will make our project look some professionally sophisticated project.
            //   - Prakash Yaji.


            this.Hide();
            if (ScreenLock.OnlineHelpForm.onlineHelpStaticObject != null)
            {
                ScreenLock.OnlineHelpForm.onlineHelpStaticObject.Show();
            }
            else
            {
                ScreenLock.OnlineHelpForm.onlineHelpStaticObject = new OnlineHelpForm();
                ScreenLock.OnlineHelpForm.onlineHelpStaticObject.Show();
            }

        }

        private void lockScreenAgainButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            
  //              ScreenLock.LoginForm.loginFormStaticObject = new LoginForm();
  //              ScreenLock.LoginForm.loginFormStaticObject.Show();

            Application.Restart();

            //BackgroundScreen back = ScreenLock.BackgroundScreen.backgroundScreenStatic;

            //ScreenLock.BackgroundScreen.backgroundScreenStatic = new BackgroundScreen();
            
            //if (back != null)
            //{
            //    back.Close();
            //}
                
            //ScreenLock.BackgroundScreen.backgroundScreenStatic.Show();
            
            
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            SignalTrainAndMatch.TrainingForm trainingFormObj = new SignalTrainAndMatch.TrainingForm();
            trainingFormObj.Show();
        }

        private void removeUserButton_Click(object sender, EventArgs e)
        {
            ScreenLock.DeleteUserForm deleteFormObj = new DeleteUserForm();
            deleteFormObj.Show();
        }

        private void MainPromptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            screenLockObj.maximizeWindow();
            screenLockObj.releaseHook();
            
            Application.Exit();
        }

    }
}
