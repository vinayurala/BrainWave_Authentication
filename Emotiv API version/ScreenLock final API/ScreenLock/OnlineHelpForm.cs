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
    public partial class OnlineHelpForm : Form
    {

        public static OnlineHelpForm onlineHelpStaticObject = null;
        private static ScreenLockHelper screenLockHelperStaticObject = new ScreenLockHelper();
        public OnlineHelpForm()
        {
            InitializeComponent();
        }

        private void adminOptionsButton_Click(object sender, EventArgs e)
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

        private void accountNameButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            if (ScreenLock.AccountUpdate.accountUpdateStaticObject != null)
            {
                ScreenLock.AccountUpdate.accountUpdateStaticObject.Show();
            }
            else
            {
                ScreenLock.AccountUpdate.accountUpdateStaticObject =new  AccountUpdate();
                ScreenLock.AccountUpdate.accountUpdateStaticObject.Show();
            }
        }

        public void OnlineHelpForm_FormClosing(object sender, EventArgs e)
        {
            screenLockHelperStaticObject.maximizeWindow();
            screenLockHelperStaticObject.releaseHook();
            Application.Exit();
        }

        private void OnlineHelpForm_Load(object sender, EventArgs e)
        {
            this.SetTopLevel(true);
        }

        private void onlineHelpBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
