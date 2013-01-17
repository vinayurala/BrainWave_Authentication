using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using WindowsGameSimpleCube1;

namespace ScreenLock
{
    public partial class LoginForm : Form
    {
        public static string userName;
        public static LoginForm loginFormStaticObject = null;
        ScreenLockHelper screenLockObj = new ScreenLockHelper();
        public static bool ClosingTheAppFlag = false;

        /// <summary>
        /// Constructor of the username prompt.
        /// Associate an event handler if the form loses its focus.
        /// Also create a new object of backGroundScreen class
        /// and display.
        /// </summary>    
        public LoginForm()
        {
            InitializeComponent();
            loginFormStaticObject = this;
        }


        /// <summary>
        /// Methods to be called and work that has to be done while
        /// loading this form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.userNameTextbox.Focus();
            try
                {
                screenLockObj.enableHook(this, e);
                
                this.ActiveControl = userNameTextbox;
                int winCount = screenLockObj.countWindows();
                winCount = winCount - 1; // I am assuming that user is not interested in
                                         // counting this process.
                if (winCount == 0)
                {
                    this.programCountMessageLabel.Text = " No program is running ";
                }
                else if (winCount == 1)
                {
                    this.programCountMessageLabel.Text = " One program is running ";
                }
                else
                {
                    this.programCountMessageLabel.Text = winCount + " programs are running";
                }
            }
        catch (Exception ex)
            {

            }
            
        }







        /// <summary>
        /// Method to unlock the screen. At present this method only
        /// checks for null user input. Once we get the headset and the
        /// MATLAB part is completed, we can call the MATLAB function
        /// from this method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnlockButton_Click(object sender, EventArgs e)
            {

                userName=this.userNameTextbox.Text;
            string userNameFile=userName+".emu";

                bool flag = false;  // I use this to skip last two lines 
                                   // when authentication is successful.
                if (this.userNameTextbox.TextLength == 0)
                {
                    MessageBox.Show("No username entered!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    LoginForm loginFormObj = new LoginForm();
                    BackgroundScreen.loginFormReload(loginFormObj);
                    return;
                }

                try
                    {
                        try
                        {
                            DirectoryInfo dInfo = new DirectoryInfo("profiles");
                            FileInfo[] fInfos = dInfo.GetFiles();
                            
                            foreach (FileInfo fInfo in fInfos)
                            {
                                if (userNameFile.Equals(fInfo.Name))
                                {
                                    flag = true;
                                   // screenLockObj.removeFromStartup();
                                    this.Close();
                                    // screenLockHelperObj.maximizeWindow();
                                    // screenLockHelperObj.releaseHook();

                                    // this.Hide();

                                    //if (WindowsGameSimpleCube1.AuthenticateForm.authenticationFormStaticObject != null)
                                    //{
                                    //    WindowsGameSimpleCube1.AuthenticateForm.authenticationFormStaticObject.Show();
                                    //}
                                    //else
                                    //{
                                        WindowsGameSimpleCube1.AuthenticateForm.authenticationFormStaticObject = new WindowsGameSimpleCube1.AuthenticateForm();
                                        WindowsGameSimpleCube1.AuthenticateForm.authenticationFormStaticObject.Show();
                                    //}

                                   
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.StackTrace);
                            MessageBox.Show("Exception Username: " + userName + " is invalid! ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                            LoginForm loginFormObj = new LoginForm();
                            BackgroundScreen.loginFormReload(loginFormObj);
                            flag = true;
                            
                        }

                        if (!flag)
                        {
                            MessageBox.Show("Username: " + userName + " is invalid! ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                            LoginForm loginFormObj = new LoginForm();
                            BackgroundScreen.loginFormReload(loginFormObj);

                        }

/*
                        flag = true; 
                    if (this.userNameTextbox.TextLength == 0)
                        {
                        MessageBox.Show("No username entered!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        }
                    else if(userName!=null && userName.Equals("administrator") /* && brainwaves are matched * / ) 
                    {
                            screenLockObj.removeFromStartup();
                            this.Close();
                           // screenLockHelperObj.maximizeWindow();
                           // screenLockHelperObj.releaseHook();

                           // this.Hide();

                            if (ScreenLock.MainPromptForm.mainPromptFormStaticObject != null)
                            {
                                ScreenLock.MainPromptForm.mainPromptFormStaticObject.Show();
                            }
                            else
                            {
                                ScreenLock.MainPromptForm.mainPromptFormStaticObject = new MainPromptForm();
                                ScreenLock.MainPromptForm.mainPromptFormStaticObject.Show();
                            }

                            flag = false;
                        
                    } /* else if( brainwaves are matched) {
                       * 
                       *      start another form for common user 
                       *      
                       * }
                       * /                    
                    else
                        {            
                            MessageBox.Show("Username: " + userName + " is invalid! ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }

                    //userNamePrompt unp = new userNamePrompt();
                    //backGroundScreen.unpReload(unp);

                    /*  Here we are creating one more window without releasing 
                     * previously created objects. 
                     * * /
                    if (flag)
                    {
                        LoginForm loginFormObj = new LoginForm();
                        BackgroundScreen.loginFormReload(loginFormObj);
                    }
                    */

                    }
                catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
            }


        /// <summary>
        /// This button is necessary only for now, that is to unlock
        /// the screen without recording any brain waves.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitButton_Click(object sender, EventArgs e)
            {

           // this.Close();
            try
                {
                screenLockObj.removeFromStartup();
                screenLockObj.maximizeWindow();
                screenLockObj.releaseHook();
                }
            catch (Exception ex)
                {
                    
                }
            
            //Process screenLockPromptProcess = new Process();
            try
                {
                //screenLockPromptProcess.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
                //screenLockPromptProcess.StartInfo.FileName = "Screen Lock Prompt";
                //screenLockPromptProcess.Start();
                    ClosingTheAppFlag = true;

                Application.Exit();
                }
            catch (Exception ex)
                {
                MessageBox.Show(Environment.CurrentDirectory);
                MessageBox.Show(ex.Message);
                Application.Exit();
                }





            }


        /// <summary>
        /// Method to send restart signal and reboot the system.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RestartButton_Click(object sender, EventArgs e)
            {
                //Process.Start("shutdown", " /r /t 00");        
            }



        /// <summary>
        /// Method to send the shut down signal and shut down the system.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShutdownButton_Click(object sender, EventArgs e)
            {
              //  Process.Start("shutdown", " /s /t 00");
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginForm_FormClosing(object sender, EventArgs e)
            {
                if (!ClosingTheAppFlag)
                {
                    BackgroundScreen.reloadHook(screenLockObj);
                }
            }

       
        }











    /// <summary>
    /// Description of screenLockHelper.
    /// As the name suggests, this is a helper class, which is used
    /// to block all special key combinations, hide windows etc. thereby
    /// giving an essence of 'screen lock' to the user.
    /// </summary>
    internal sealed class ScreenLockHelper
    {
        const int SW_HIDE = 0;
        const int SW_SHOW = 1;
        const int MIN_ALL = 419;
        const int MIN_ALL_UNDO = 416;
        const int WM_COMMAND = 0x0111;
        const int WH_KEYBOARD_LL = 13;
        const int WM_CLOSE = 0x0010;
        int intLLKey;
        int winCount = 0;

        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string lpszClassName, string lpszWindowName);
        [DllImport("user32.dll")]
        static extern int ShowWindow(IntPtr windowHandle, int nCmdShow);
        [DllImport("user32.dll", EntryPoint = "SetWindowsHookExA", CharSet = CharSet.Ansi)]
        static extern int SetWindowsHookEx(int idHook, LowLevelKeyboardProcDelegate lpfn, int hMod, int dwThreadId);
        [DllImport("user32.dll")]
        static extern int UnhookWindowsHookEx(int hHook);
        [DllImport("user32.dll", EntryPoint = "CallNextHookEx", CharSet = CharSet.Ansi)]
        static extern int CallNextHookEx(int hHook, int nCode, int wParam, ref KBDLLHOOKSTRUCT lParam);
        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, IntPtr Msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Delegate to call the private "LowLevelKeyboardProc" method.
        /// </summary>
        private delegate int LowLevelKeyboardProcDelegate(int nCode, int wParam, ref KBDLLHOOKSTRUCT lParam);

        /// <summary>
        /// 
        /// </summary>
        private struct KBDLLHOOKSTRUCT
        {
            public int vkCode;
            int scanCode;
            public int flags;
            int time;
            int dwExtraInfo;
        }

        static LowLevelKeyboardProcDelegate LLkeyboardStaticObject = new LowLevelKeyboardProcDelegate(new ScreenLockHelper().LowLevelKeyboardProc);


        /// <summary>
        /// A private function which is used as callback function to the
        /// delegate "LowLevelKeyboardProcDelegate".
        /// This is low level Windows programming. So I haven't understood
        /// this method completely.
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        private int LowLevelKeyboardProc(int nCode, int wParam, ref KBDLLHOOKSTRUCT lParam)
        {
            bool blnEat = false;

            switch (wParam)
            {
                case 256:
                case 257:
                case 260:
                case 261:
                    //Alt+Tab, Alt+Esc, Ctrl+Esc, Windows Key
                    if (((lParam.vkCode == 9) && (lParam.flags == 32)) ||
                        ((lParam.vkCode == 27) && (lParam.flags == 32)) || ((lParam.vkCode ==
                                                                             27) && (lParam.flags == 0)) || ((lParam.vkCode == 91) && (lParam.flags
                                                                                  == 1)) || ((lParam.vkCode == 92) && (lParam.flags == 1)) || ((true) &&
                                                                                     (lParam.flags == 32)))
                    {
                        blnEat = true;
                    }
                    break;
            }

            if (blnEat)
                return 1;
            else return CallNextHookEx(0, nCode, wParam, ref lParam);
        }

        /// <summary>
        /// Establish or create a keyboard hook to trap Alt+Esc , Ctrl+Esc ,
        /// Alt+F4 , Alt+Tab and Windows key combinations.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyboardHook(object sender, EventArgs e)
        {
            intLLKey =
                SetWindowsHookEx(
                    WH_KEYBOARD_LL,
                // new LowLevelKeyboardProcDelegate(LowLevelKeyboardProc),
                    LLkeyboardStaticObject,
                    System.Runtime.InteropServices.Marshal.GetHINSTANCE(
                        System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0]).ToInt32(), 0);
        }

        /// <summary>
        /// A private function which releases the keybord hook established
        /// previously.
        /// </summary>
        private void ReleaseKeyboardHook()
        {
            intLLKey = UnhookWindowsHookEx(intLLKey);
        }

        /// <summary>
        /// This function minimizes all open windows except the screen lock
        /// app window. It also hides the taskbar. Another alternative to
        /// provide this functionality is by killing "explorer.exe".
        /// This function also minimizes the task manager window.
        /// Any later attempts to create a task window manager will
        /// only result in creating a new instance of the minimized
        /// window. Hence "Ctrl+Alt+Del" won't bother us in the future.
        /// </summary>
        public void minimizeWindow()
        {
            IntPtr windowHandle = FindWindow("Shell_TrayWnd", "");
            // Hide the taskbar
            ShowWindow(windowHandle, SW_HIDE);
            // Minimize all active windows except this process
            SendMessage(windowHandle, (IntPtr)WM_COMMAND, (IntPtr)MIN_ALL, IntPtr.Zero);
            Process p = new Process();
            p.StartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.System);
            p.StartInfo.FileName = "taskmgr.exe";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();
        }

        /// <summary>
        /// This function is used to maximize all windows minimized,
        /// previously. It also closes the task manager window instances
        /// which were also minimized.
        /// </summary>
        public void maximizeWindow()
        {
            IntPtr taskManager = FindWindow("#32770", "Windows Task Manager");
            SendMessage(taskManager, (IntPtr)WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            IntPtr windowHandle = FindWindow("Shell_TrayWnd", "");
            // Unhide the taskbar
            ShowWindow(windowHandle, SW_SHOW);
            // Maximize all windows minimized previously
            SendMessage((IntPtr)windowHandle, (IntPtr)WM_COMMAND, (IntPtr)MIN_ALL_UNDO, IntPtr.Zero);
        }

        /// <summary>
        /// A public helper function which exposes the functionality
        /// of the private function "KeyboardHook".
        /// </summary>
        public void enableHook(object sender, EventArgs e)
        {
            KeyboardHook(sender, e);
        }

        /// <summary>
        /// A public helper function which exposes the functionality
        /// of the private function "ReleaseKeyboardHook".
        /// </summary>
        public void releaseHook()
        {
            ReleaseKeyboardHook();
        }

        /// <summary>
        /// This function is used to add this executable to the
        /// list of start-up items in Windows Registry.
        /// </summary>
        public void addtoStartup()
        {
            string procName = Process.GetCurrentProcess().ProcessName;
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            rkApp.SetValue(procName, Application.ExecutablePath.ToString());
        }

        /// <summary>
        /// This function is used to remove this executable from the
        /// list of start-up items in Windows Registry.
        /// </summary>
        public void removeFromStartup()
        {
            string procName = Process.GetCurrentProcess().ProcessName;
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            rkApp.DeleteValue(procName);
        }

        /// <summary>
        /// This function is used to count the number of open windows.
        /// It does so by enumerating the window handles for each
        /// processes that are currently running.
        /// </summary>
        /// <returns>Number of open windows(integer)</returns>
        public int countWindows()
        {
            foreach (Process p in Process.GetProcesses())
            {
                if (p.MainWindowHandle != IntPtr.Zero)
                    winCount++;
            }
            return winCount;
        }

        /// <summary>
        /// This method is used to find out any open task manager
        /// process and kill it before loading the userNamePrompt
        /// form.
        /// </summary>
        public void killtaskmgr()
        {
            Process[] runProc = Process.GetProcesses();
            foreach (Process curProc in runProc)
            {
                if (curProc.ProcessName.StartsWith("taskmgr"))
                    curProc.Kill();
            }
        }
    }










    ///// <summary>
    ///// Description of screenLockHelper.
    ///// As the name suggests, this is a helper class, which is used
    ///// to block all special key combinations, hide windows etc. thereby
    ///// giving an essence of 'screen lock' to the user.
    ///// </summary>
    //internal sealed class ScreenLockHelper
    //    {
    //    const int SW_HIDE = 0;
    //    const int SW_SHOW = 1;
    //    const int MIN_ALL = 419;
    //    const int MIN_ALL_UNDO = 416;
    //    const int WM_COMMAND = 0x0111;
    //    const int WH_KEYBOARD_LL = 13;
    //    const int WM_CLOSE = 0x0010;
    //    int intLLKey;
    //    int winCount = 0;

    //    [DllImport("user32.dll")]
    //    static extern IntPtr FindWindow(string lpszClassName, string lpszWindowName);
    //    [DllImport("user32.dll")]
    //    static extern int ShowWindow(IntPtr windowHandle, int nCmdShow);
    //    [DllImport("user32.dll", EntryPoint = "SetWindowsHookExA", CharSet = CharSet.Ansi)]
    //    static extern int SetWindowsHookEx(int idHook, LowLevelKeyboardProcDelegate lpfn, int hMod, int dwThreadId);
    //    [DllImport("user32.dll")]
    //    static extern int UnhookWindowsHookEx(int hHook);
    //    [DllImport("user32.dll", EntryPoint = "CallNextHookEx", CharSet = CharSet.Ansi)]
    //    static extern int CallNextHookEx(int hHook, int nCode, int wParam, ref KBDLLHOOKSTRUCT lParam);
    //    [DllImport("user32.dll")]
    //    static extern int SendMessage(IntPtr hWnd, IntPtr Msg, IntPtr wParam, IntPtr lParam);

    //    /// <summary>
    //    /// Delegate to call the private "LowLevelKeyboardProc" method.
    //    /// </summary>
    //    private delegate int LowLevelKeyboardProcDelegate(int nCode, int wParam, ref KBDLLHOOKSTRUCT lParam);

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    private struct KBDLLHOOKSTRUCT
    //        {
    //            public int vkCode;
    //            public Keys key;
    //            int scanCode;
    //            public int flags;
    //            int time;
    //            int dwExtraInfo;
    //        }



    //    static LowLevelKeyboardProcDelegate LLKeyboardDelegateStaticObject = new LowLevelKeyboardProcDelegate(new ScreenLockHelper().LowLevelKeyboardProc);






    //    /// <summary>
    //    /// A private function which is used as callback function to the
    //    /// delegate "LowLevelKeyboardProcDelegate".
    //    /// This is low level Windows programming. So I haven't understood
    //    /// this method completely.
    //    /// </summary>
    //    /// <param name="nCode"></param>
    //    /// <param name="wParam"></param>
    //    /// <param name="lParam"></param>
    //    /// <returns></returns>
    //    private int LowLevelKeyboardProc(int nCode, int wParam, ref KBDLLHOOKSTRUCT lParam)
    //        {
    //        bool blnEat = false;

    //        switch (wParam)
    //            {
    //            case 256:
    //            case 257:
    //            case 260:
    //            case 261:
    //                //Alt+Tab, Alt+Esc, Ctrl+Esc, Windows Key
    //                if (((lParam.vkCode == 9) && (lParam.flags == 32)) ||
    //                    ((lParam.vkCode == 27) && (lParam.flags == 32)) || ((lParam.vkCode ==
    //                                                                         27) && (lParam.flags == 0)) || ((lParam.vkCode == 91) && (lParam.flags
    //                                                                              == 1)) || ((lParam.vkCode == 92) && (lParam.flags == 1)) || ((true) &&
    //                                                                                 (lParam.flags == 32)))
    //                    {
    //                    blnEat = true;
    //                    }
    //                break;
    //            }

    //        if (blnEat)
    //            return 1;
    //        else if ((lParam.key == Keys.LWin) || (lParam.key == Keys.RWin))
    //            return 1;
    //        else
    //        {
    //            try {
    //                return CallNextHookEx(0, nCode, wParam, ref lParam);
             
    //            }
    //            catch (Exception ex)
    //            {
    //                return 1;
    //            }
    //        }
    //        }

    //    /// <summary>
    //    /// Establish or create a keyboard hook to trap Alt+Esc , Ctrl+Esc ,
    //    /// Alt+F4 , Alt+Tab and Windows key combinations.
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="e"></param>
    //    private void KeyboardHook(object sender, EventArgs e)
    //        {
    //        intLLKey =
    //            SetWindowsHookEx(
    //                WH_KEYBOARD_LL,
    //               // new LowLevelKeyboardProcDelegate(LowLevelKeyboardProc),
    //               LLKeyboardDelegateStaticObject,  // I added this static object reference here
    //                System.Runtime.InteropServices.Marshal.GetHINSTANCE(
    //                    System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0]).ToInt32(), 0);
    //        }

    //    /// <summary>
    //    /// A private function which releases the keybord hook established
    //    /// previously.
    //    /// </summary>
    //    private void ReleaseKeyboardHook()
    //        {
    //        intLLKey = UnhookWindowsHookEx(intLLKey);
    //        }


    //    /// <summary>
    //    /// This function minimizes all open windows except the screen lock
    //    /// app window. It also hides the taskbar. Another alternative to
    //    /// provide this functionality is by killing "explorer.exe".
    //    /// This function also minimizes the task manager window.
    //    /// Any later attempts to create a task window manager will
    //    /// only result in creating a new instance of the minimized
    //    /// window. Hence "Ctrl+Alt+Del" won't bother us in the future.
    //    /// </summary>
    //    public void minimizeWindow()
    //        {
    //        IntPtr windowHandle = FindWindow("Shell_TrayWnd", "");
    //        // Hide the taskbar
    //        ShowWindow(windowHandle, SW_HIDE);
    //        // Minimize all active windows except this process
    //        SendMessage(windowHandle, (IntPtr)WM_COMMAND, (IntPtr)MIN_ALL, IntPtr.Zero);

    //        }

    //    /// <summary>
    //    /// This function is used to maximize all windows minimized,
    //    /// previously. It also closes the task manager window instances
    //    /// which were also minimized.
    //    /// </summary>
    //    public void maximizeWindow()
    //        {
    //        IntPtr taskManager = FindWindow("#32770", "Windows Task Manager");
    //        SendMessage(taskManager, (IntPtr)WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
    //        IntPtr windowHandle = FindWindow("Shell_TrayWnd", "");
    //        // Unhide the taskbar
    //        ShowWindow(windowHandle, SW_SHOW);
    //        // Maximize all windows minimized previously
    //        SendMessage((IntPtr)windowHandle, (IntPtr)WM_COMMAND, (IntPtr)MIN_ALL_UNDO, IntPtr.Zero);
    //        }

    //    /// <summary>
    //    /// A public helper function which exposes the functionality
    //    /// of the private function "KeyboardHook".
    //    /// </summary>
    //    public void enableHook(object sender, EventArgs e)
    //        {
    //        KeyboardHook(sender, e);
    //        }

    //    /// <summary>
    //    /// A public helper function which exposes the functionality
    //    /// of the private function "ReleaseKeyboardHook".
    //    /// </summary>
    //    public void releaseHook()
    //        {
    //        ReleaseKeyboardHook();
    //        }

    //    /// <summary>
    //    /// This function is used to add this executable to the
    //    /// list of start-up items in Windows Registry.
    //    /// </summary>
    //    public void addtoStartup()
    //        {
    //        string procName = Process.GetCurrentProcess().ProcessName;
    //        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
    //        rkApp.SetValue(procName, Application.ExecutablePath.ToString());
    //        }

    //    /// <summary>
    //    /// This function is used to remove this executable from the
    //    /// list of start-up items in Windows Registry.
    //    /// </summary>
    //    public void removeFromStartup()
    //        {
    //        string procName = Process.GetCurrentProcess().ProcessName;
    //        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
    //        rkApp.DeleteValue(procName);
    //        }

    //    /// <summary>
    //    /// This function is used to count the number of open windows.
    //    /// It does so by enumerating the window handles for each
    //    /// processes that are currently running.
    //    /// </summary>
    //    /// <returns>Number of open windows(integer)</returns>
    //    public int countWindows()
    //        {
    //        foreach (Process p in Process.GetProcesses())
    //            {
    //            if (p.MainWindowHandle != IntPtr.Zero)
    //                winCount++;
    //            }
    //        return --winCount;
    //        }

    //    /// <summary>
    //    /// This method is used to find out any open task manager
    //    /// process and kill it before loading the userNamePrompt
    //    /// form.
    //    /// </summary>
    //    public void killtaskmgr()
    //        {
    //        Process[] runProc = Process.GetProcesses();
    //        foreach (Process curProc in runProc)
    //            {
    //            if (curProc.ProcessName.StartsWith("taskmgr"))
    //                curProc.Kill();
    //            }
    //        Process p = new Process();
    //        p.StartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.System);
    //        p.StartInfo.FileName = "taskmgr.exe";
    //        p.StartInfo.CreateNoWindow = true;
    //        p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
    //        p.Start();
    //        }
    //    }
    
   







}
