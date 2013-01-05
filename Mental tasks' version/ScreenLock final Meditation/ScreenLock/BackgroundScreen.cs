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
    public partial class BackgroundScreen : Form
    {
        LoginForm loginFormObj = new LoginForm();
        ScreenLockHelper screenLockHelperObj = new ScreenLockHelper();
        static LoginForm loginFormStatic = null;
		static ScreenLockHelper screenLockHelperStatic = null;
		public static BackgroundScreen backgroundScreenStatic = null;
		/// <summary>
		/// Constructor for the backGroundScreen class.
		/// </summary>
		
        public BackgroundScreen()
        {
            InitializeComponent();
            backgroundScreenStatic = this;
        }


        // <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundScreen_Load(object sender, EventArgs e)
        {
            
            Environment.CurrentDirectory = @"C:\Documents and Settings\Administrator\Desktop\vinay\ScreenLock\ScreenLock\bin\Debug\profiles";
            this.SetTopLevel(true);
            try
                {
            //    screenLockHelperObj.enableHook(this, new EventArgs());
                screenLockHelperObj.killtaskmgr();
                screenLockHelperObj.addtoStartup();
                screenLockHelperObj.minimizeWindow();
                
                }
            catch (Exception ex)
                {
                    
                }
            screenLockHelperObj.enableHook(backgroundScreenStatic, new EventArgs());
            backgroundScreenStatic.BringToFront();
            loginFormStatic = loginFormObj;
            loginFormStatic.Show();
            loginFormStatic.BringToFront();
           
           // reloadHook(screenLockHelperObj);
            //int i = 20;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginFormObject"></param>
        internal static void loginFormReload(LoginForm loginFormObject)
        {
            /* Hey first you need to free the object reference before 
             * calling Garbage Collector */

            loginFormStatic = null; // Now it's eligible for garbage collection.

            GC.Collect();
            GC.WaitForPendingFinalizers();
            loginFormStatic = loginFormObject;
            loginFormStatic.Show();
           // loginFormStatic.Focus();
            
            loginFormStatic.Activate();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="slh"></param>
        internal static void reloadHook(ScreenLockHelper slh)
            {
                try
                    {
                    screenLockHelperStatic = slh;
                    screenLockHelperStatic.minimizeWindow();
                    screenLockHelperStatic.releaseHook();
                    screenLockHelperStatic.enableHook(backgroundScreenStatic, new EventArgs());
                    }
                catch (Exception e)
                    {
                    }
            }

    }
}
