using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ScreenLock
{
    public partial class AccountUpdate : Form
    {

       public static AccountUpdate accountUpdateStaticObject;// = new AccountUpdate();

       ScreenLockHelper screenLockObj = new ScreenLockHelper();

        public AccountUpdate()
        {
            InitializeComponent();
           // accountUpdateStaticObject = this;
        }

        private void adminOptionButton_Click(object sender, EventArgs e)
        {
            this.Hide();

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

        private void AccountUpdateForm_Closing(object sender, EventArgs e)
        {
            screenLockObj.releaseHook();
            screenLockObj.maximizeWindow();

            Application.Exit();
        }

        private void updateUserNameButton_Click(object sender, EventArgs e)
        {
            if ((confirmNewNameTextBox.Text.Length>0)&&(newNameTextBox.Text).Equals(confirmNewNameTextBox.Text))
            {
                //MessageBox.Show("Both are equal ! this is for testing purpose", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                /* Now write code to update the Database */
                string oldDir = Environment.CurrentDirectory + "\\" + newNameTextBox.Text;
                if(!(Directory.Exists(oldDir)))
                {
                    MessageBox.Show("Username not found!!");
                    return;
                }
                string newDir = Environment.CurrentDirectory + "\\" + confirmNewNameTextBox.Text;
                Directory.Move(oldDir, newDir);
                MessageBox.Show("Username updated!!");
            }
            else
            {
                MessageBox.Show("Both names must match!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
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

        private void AccountUpdate_Load(object sender, EventArgs e)
        {

        }

    }
}
