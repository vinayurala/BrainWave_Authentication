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

        public static string userName = null;

        
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

        //private void MainPromptForm_Closing(object sender, EventArgs e)
        //{
        //   // MessageBox.Show(" Application is closing now ", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        //    screenLockObj.releaseHook();
        //    screenLockObj.maximizeWindow();

        //   // Application.Exit();
        //}

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


            ScreenLock.BackgroundScreen.backgroundScreenStatic = new BackgroundScreen();
            ScreenLock.BackgroundScreen.backgroundScreenStatic.Show();
            
            
        }

        private void subCategoryPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainPromptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(ScreenLock.BackgroundScreen.backgroundScreenStatic!=null)
                ScreenLock.BackgroundScreen.backgroundScreenStatic.Hide();
            Application.Exit();
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            WindowsFormsThreadDemo.TrainingForm.trainingFormStaticObject = new WindowsFormsThreadDemo.TrainingForm();
            WindowsFormsThreadDemo.TrainingForm.updateUserProfile = false;
            WindowsFormsThreadDemo.TrainingForm.userProfileNameToBeLoaded = "";
            WindowsFormsThreadDemo.TrainingForm.trainingFormStaticObject.Show();
            //this.Hide();
            this.TopMost = false;
        }

        private void removeUserButton_Click(object sender, EventArgs e)
        {
            ScreenLock.DeleteUser deleteUser = new DeleteUser();
            deleteUser.Show();
        }

        private void button_TrainSystem_Click(object sender, EventArgs e)
        {
            this.Hide();
            WindowsFormsThreadDemo.TrainingForm.trainingFormStaticObject = new WindowsFormsThreadDemo.TrainingForm();
            WindowsFormsThreadDemo.TrainingForm.updateUserProfile = true;
            WindowsFormsThreadDemo.TrainingForm.userProfileNameToBeLoaded = userName;
            WindowsFormsThreadDemo.TrainingForm.trainingFormStaticObject.Show();
            //WindowsFormsThreadDemo.TrainingForm.updateUserProfile = true;
            //WindowsFormsThreadDemo.TrainingForm.userProfileNameToBeLoaded = userName;
            //this.Hide();
            this.TopMost = false;
        }

    }
}
