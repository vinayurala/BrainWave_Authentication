using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emotiv;
using System.Threading;

namespace WindowsGameSimpleCube1
{
    public partial class AuthenticateForm : Form
    {
        public static AuthenticateForm authenticationFormStaticObject = null;
        EmoEngine engine;
        uint userId = 0;
        bool IsAborted = false;

        static int countNumber=0;
        
        System.Windows.Forms.Timer timer = null;

        System.Windows.Forms.Timer MainTimer = null;
        System.Windows.Forms.Timer MinerTimer = null;

        int totalActiveActions = 0;

        ScreenLock.ScreenLockHelper screenLockHelperObject = new ScreenLock.ScreenLockHelper();

        bool cognitivAction1HandlerDisabled = true;
        bool cognitivAction2HandlerDisabled=true;
        bool cognitivAction3HandlerDisabled = true;
        bool cognitivActionsAuthenticated = false;

        public static float cognitivActivityPower=0f;
        public static Queue<float> cognitivActivityPowerQueue = new Queue<float>();

        static int actionNumber = 0;
        static int differentActionCount = 0;

        static int failedCount=0;

        bool authenticationSuccessfull = false;
        
        /*
         * The following lines of code is for creating cube.
         * 
         * 
         */

        Thread newBoxUpdateThread = null;
        public static float DeltaX1;
        public static float DeltaY1;
        public static bool animateDepth = false;
        public static bool moveForward = false;
        public static float depth = 10;
        public static float angleX = 0f;
        public static float angleY = 0f;
        public static bool liftCube = false;
        public static bool dropCube = false;
        public static float height = 0f;
        public static bool left = false;
        public static bool right = false;
        public static bool rotateClockwise = false;
        public static bool rotateAntiClockwise = false;
        public static bool rotateLeft = false;
        public static bool rotateRight = false;
        public static float rotateValue = 0f;
        ThreadStart newThreadStart = null;

        bool alreadyDisplayed = false;
        



        static void RunCube()
        {
            using (relayCognitivActivity game = new relayCognitivActivity())
            //using (Game1 game=new Game1())
            {
                game.DeltaX = DeltaX1;
                game.DeltaY = DeltaY1;
                game.AngleX = angleX;
                game.AngleY = angleY;
                game.AngleX = 5f;
                game.AnimateDepth = animateDepth;
                game.MoveForward = moveForward;
                game.depth = depth;
                game.LiftCube = liftCube;
                game.DropCube = dropCube;
                game.Height = height;
                game.moveLeft = left;
                game.moveRight = right;
                game.rotateClockwise = rotateClockwise;

                game.rotateAntiClockwise = rotateAntiClockwise;
                game.rotateValue = rotateValue;
                game.position = 0f;
                game.Run();

            }
        }

        /* cube properties ends here */


       
            
        //TimeSpan StartingTime;
        //TimeSpan EndTimer;
        bool matchingGoingOn = false;


        string CurrentAuthenticationAction = null;

        string CurrentCognitivActivity = null;

        Thread authenticateUserThread = null;
        string[] Action_String_t = { "NEUTRAL", "PUSH", "PULL", "LIFT", "DROP", "LEFT", "RIGHT", "ROTATE_LEFT", "ROTATE_RIGHT", "ROTATE_CLOCKWISE", "ROTATE_COUNTER_CLOCKWISE", "ROTATE_FORWARDS", "ROTATE_REVERSE", "DISAPPEAR" };
        List<string> activeActionsList = new List<string>();

        bool[] activeActionsFlag = null;
        uint activeActions = 0;
        public AuthenticateForm()
        {
            InitializeComponent();
        }

        private void button_Unlock_Click(object sender, EventArgs e)
        {
            if(button_Unlock.Text.Equals("Unlock")){
            
                IsAborted = false;
                //button_Unlock.Enabled = false;
                button_Unlock.Text="Use different username";
                textBox_Username.Enabled = false;
                authenticateUserThread = new Thread(doWork);
                authenticateUserThread.Start();
            
            }
            else{
                if (!cognitivAction1HandlerDisabled)
                {
                    engine.CognitivEmoStateUpdated -= new EmoEngine.CognitivEmoStateUpdatedEventHandler(engine_CognitivEmoStateUpdatedForAction1);
                    cognitivAction1HandlerDisabled = true;
                }
                if (!cognitivAction2HandlerDisabled)
                {
                    engine.CognitivEmoStateUpdated -= new EmoEngine.CognitivEmoStateUpdatedEventHandler(engine_CognitivEmoStateUpdatedForAction2);
                    cognitivAction2HandlerDisabled = true;
                }
                if (!cognitivAction3HandlerDisabled)
                {
                    engine.CognitivEmoStateUpdated -= new EmoEngine.CognitivEmoStateUpdatedEventHandler(engine_CognitivEmoStateUpdatedForAction3);
                    cognitivAction3HandlerDisabled = true;
                }
                actionNumber = 0;
                IsAborted = true;
                label_Action1.Text = "";
                label_Action1State.Text = "";
                label_Action2.Text = "";
                label_Action2State.Text = "";
                label_Action3.Text = "";
                label_Action3State.Text = "";
                label_Action1.Text = "";
                label_Action1State.Text = "";
                label_Action2.Text = "";
                label_Action2State.Text = "";
                label_Action3.Text = "";
                label_Action3State.Text = "";
                activeActions = 0;
                activeActionsFlag = null;
                activeActionsList.Clear();
                if (MainTimer != null)
                {
                    MainTimer.Enabled = false;
                }
                if (MinerTimer != null)
                {
                    MinerTimer.Enabled = false;
                }
                if (timer != null)
                {
                    timer.Enabled = false;
                }
                label_ActionPower.Visible = false;
                label_CurrentAction.Visible = false;
                progressBar_CognitivActivity.Visible = false;
                button_AuthenticateAction1.Visible = button_AuthenticateAction2.Visible = button_AuthenticateAction3.Visible = false;
                
                
                activeActionsList = new List<string>();
                button_AuthenticateAction1.Visible = false;
                button_AuthenticateAction2.Visible = false;
                button_AuthenticateAction3.Visible = false;
                if (engine != null)
                {
                    engine.Disconnect();
                    engine = null;
                }
                textBox_Username.Text = "";
                button_Unlock.Text="Unlock";
                textBox_Username.Enabled = true;
                button_Unlock.Enabled = true;
                if (authenticateUserThread != null)
                {
                    authenticateUserThread.Abort();
                }
            }
            
            //doWork();

        }


        void doWork()
        {
            engine = EmoEngine.Instance;
            engine.Connect();

            engine.UserAdded += new EmoEngine.UserAddedEventHandler(engine_UserAdded);
            while (!IsAborted)
            {
                engine.ProcessEvents();
            }
            
        }
        delegate void d();

        void engine_UserAdded(object sender, EmoEngineEventArgs e)
        {
            engine.UserAdded-=new EmoEngine.UserAddedEventHandler(engine_UserAdded);
            //MessageBox.Show("user added");
            int index = 0;
            try
            {

                //Profile profile = new Profile();
                engine.LoadUserProfile(userId, "profiles\\"+textBox_Username.Text + ".emu");
                activeActions = engine.CognitivGetActiveActions(userId);
                //engine.SetUserProfile(userId, profile);

                activeActionsFlag = getActionsStatus(activeActions);
                foreach (string s in Action_String_t)
                {
                    if (activeActionsFlag[index])
                    {
                        activeActionsList.Add(s);
                    }
                    index++;
                }

                totalActiveActions = activeActionsList.Count;

                //try
                //{
                //    lock (this)
                //    {
                //        this.Invoke((d)delegate()
                //        {
                //            label_Action1.Text = "PUSH";
                //            label_Action2.Text = "PUSH";
                //            label_Action3.Text = "PUSH";
                //            label_Action1.Visible =label_Action2.Visible=label_Action3.Visible= true;
                //            label_Action1State.Text = label_Action2State.Text = label_Action3State.Text = "Not Authenticated";
                //            label_Action1State.Visible = label_Action2State.Visible = label_Action3State.Visible = true;
                //            button_AuthenticateAction1.Visible = true;
                //        });
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Error in manipulation");
                //}
                
                //MessageBox.Show(activeActionsList.FindLastIndex.ToString());
                lock (this)
                {
                    this.Invoke((d)delegate()
                    {
                        index = 0;
                        foreach (string s in activeActionsList)
                        {
                            if (index == 0)
                            {
                                label_Action1.Text = s;
                                label_Action1.Visible = true;
                                label_Action1State.Text = "Not Authenticated";
                                label_Action1State.Visible = true;
                                button_AuthenticateAction1.Visible = true;
                                index++;
                            }
                            else if (index == 1)
                            {
                                label_Action2.Text = s;
                                label_Action2.Visible = true;
                                label_Action2State.Text = "Not Authenticated";
                                label_Action2State.Visible = true;
                                index++;
                            }
                            else if (index == 2)
                            {
                                label_Action3.Text = s;
                                label_Action3.Visible = true;
                                label_Action3State.Text = "Not Authenticated";
                                label_Action3State.Visible = true;
                                index++;
                            }
                            else
                                break;
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("User name is wrong");
                IsAborted = true;
                this.authenticateUserThread.Abort();
                
            }
            //engine.LoadUserProfile(userId, "Prakash.emu");
            
            

        }
        private bool[] getActionsStatus(uint activeActions)
        {
            bool[] actionsStatus = new bool[14];  // There can be 14 Active Actions including Neutral.

            // convert trainedActions to binary
            // Then set flags.
            actionsStatus[0] = false;
            int index = 1;
            while (activeActions >= 0 && index <= 13)
            {
                activeActions = activeActions >> 1;
                if ((activeActions % 2) == 1)
                {
                    actionsStatus[index] = true;
                }
                else
                {
                    actionsStatus[index] = false;
                }
                index++;
            }


            return actionsStatus;

        }

        private void button_AuthenticateAction1_Click(object sender, EventArgs e)
        {
            actionNumber = 1;
            label1.Text = "";
            label2.Text = "";
            label_Action1State.Text = "Not Authenticated";
            label3.Text = "";
            differentActionCount = 0;

            
            CurrentAuthenticationAction = label_Action1.Text;
            

            timer = new System.Windows.Forms.Timer();
            timer.Enabled = true;
            timer.Interval = 30000;
            timer.Tick += new EventHandler(timer_Tick);
            
            MinerTimer = new System.Windows.Forms.Timer();
            MinerTimer.Interval = 200;
            MinerTimer.Enabled = false;
            MinerTimer.Tick += new EventHandler(MinerTimer_Tick);

            MainTimer = new System.Windows.Forms.Timer();
            MainTimer.Enabled = false;
            MainTimer.Interval = 3000;
            MainTimer.Tick += new EventHandler(MainTimer_Tick);
            failedCount = 0;
            cognitivAction1HandlerDisabled = false;
            engine.CognitivEmoStateUpdated += new EmoEngine.CognitivEmoStateUpdatedEventHandler(engine_CognitivEmoStateUpdatedForAction1);
            CurrentCognitivActivity = "COG_NEUTRAL";
            cognitivActivityPower = 0.0f;
            animateCube();
            newThreadStart = new ThreadStart(RunCube);
            newBoxUpdateThread = new Thread(newThreadStart);
            newBoxUpdateThread.Start();
            label_ActionPower.Visible = true;
            label_CurrentAction.Visible = true;
            progressBar_CognitivActivity.Visible = true;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            
            lock (this)
            {
                this.Invoke((d)delegate()
                {
                    if (newBoxUpdateThread != null && newBoxUpdateThread.IsAlive)
                    {
                        newBoxUpdateThread.Abort();
                    }
                    matchingGoingOn = false;
                    if (!cognitivAction1HandlerDisabled)
                    {
                        engine.CognitivEmoStateUpdated -= new EmoEngine.CognitivEmoStateUpdatedEventHandler(engine_CognitivEmoStateUpdatedForAction1);
                        cognitivAction1HandlerDisabled = true;
                    }
                    if (!cognitivAction2HandlerDisabled)
                    {
                        engine.CognitivEmoStateUpdated -= new EmoEngine.CognitivEmoStateUpdatedEventHandler(engine_CognitivEmoStateUpdatedForAction2);
                        cognitivAction2HandlerDisabled = true;
                    }
                    if (!cognitivAction3HandlerDisabled)
                    {
                        engine.CognitivEmoStateUpdated -= new EmoEngine.CognitivEmoStateUpdatedEventHandler(engine_CognitivEmoStateUpdatedForAction3);
                        cognitivAction3HandlerDisabled = true;
                    }
                    MainTimer.Enabled = false;
                    MinerTimer.Enabled = false;
                    timer.Enabled = false;

                    label_ActionPower.Visible = false;
                    label_CurrentAction.Visible = false;
                    progressBar_CognitivActivity.Visible = false;

                    MessageBox.Show("Time out!");
                });
            }
            
            

        }
        
        

        void engine_CognitivEmoStateUpdatedForAction1(object sender, EmoStateUpdatedEventArgs e)
        {
            CurrentCognitivActivity = e.emoState.CognitivGetCurrentAction().ToString();
            cognitivActivityPower = e.emoState.CognitivGetCurrentActionPower();
            cognitivActivityPowerQueue.Enqueue(cognitivActivityPower);
            animateCube();

            lock (this)
            {
                this.Invoke((d)delegate()
                {
                    progressBar_CognitivActivity.Value=(int)(cognitivActivityPower*100);
                    label_CurrentAction.Text = CurrentCognitivActivity;
                });
            }

            if (e.emoState.CognitivGetCurrentAction() == convertStringToAction(label_Action1.Text))
            {
               // MessageBox.Show(((int)(e.emoState.CognitivGetCurrentActionPower()*100)).ToString());
                //((int)(e.emoState.CognitivGetCurrentActionPower()*100)).ToString();


                lock (this)
                {
                    
                    this.Invoke((d)delegate()
                    {

                        if (((int)(e.emoState.CognitivGetCurrentActionPower() * 100)) >= 60)
                        {
                            //MessageBox.Show(((int)(e.emoState.CognitivGetCurrentActionPower() * 100)).ToString());
                            
                            label1.Text = "Matching going on... : "+((int)(e.emoState.CognitivGetCurrentActionPower() * 100)).ToString();
                            if (!matchingGoingOn)
                            {

                                //MainTimer.Enabled = true;

                                matchingGoingOn = true;
                                //MessageBox.Show("Cognitiv started");

                            }

                            MainTimer.Enabled = true;

                            MinerTimer.Enabled = false;


                        }
                        else
                        {
                            if (((int)e.emoState.CognitivGetCurrentActionPower() * 100) < 10 && MinerTimer == null)
                            {
                                MinerTimer.Enabled = true;



                            }
                        }
                    });
                }
                
            }
            else if (matchingGoingOn)
            {
                //MessageBox.Show("Thinking different");
                lock (this)
                {
                    this.Invoke((d)delegate()
                    {
                        MinerTimer.Enabled = true;
                        label3.Text = "Different action while " + label_Action1.Text;
                    });
                }
            }
            else
            {
                lock (this)
                {
                    this.Invoke((d)delegate()
                    {
                        differentActionCount++;

                        label3.Text = "Different Aciton! " + differentActionCount.ToString()+" "+e.emoState.CognitivGetCurrentAction().ToString();
                    });
                }
            }

        }

        void MinerTimer_Tick(object sender, EventArgs e)
        {
            lock (this)
            {
                this.Invoke((d)delegate()
                {
                    failedCount++;
                    label2.Text = "Failed count : " + failedCount.ToString();
                    matchingGoingOn = false;
                    if (MainTimer != null)
                    {
                        MainTimer.Enabled = false;

                    }
                    MinerTimer.Enabled = false;
                });
            }
            
            //MessageBox.Show("Oh!!");
        }

        void MainTimer_Tick(object sender, EventArgs e)
        {
            
            lock (this)
            {
                this.Invoke((d)delegate()
                {
                    if (newBoxUpdateThread != null && newBoxUpdateThread.IsAlive)
                    {
                        newBoxUpdateThread.Abort();
                    }
                    matchingGoingOn = false;
                    if (!cognitivAction1HandlerDisabled)
                    {
                        engine.CognitivEmoStateUpdated -= new EmoEngine.CognitivEmoStateUpdatedEventHandler(engine_CognitivEmoStateUpdatedForAction1);
                        cognitivAction1HandlerDisabled = true;
                    }
                    if (!cognitivAction2HandlerDisabled)
                    {
                        engine.CognitivEmoStateUpdated -= new EmoEngine.CognitivEmoStateUpdatedEventHandler(engine_CognitivEmoStateUpdatedForAction2);
                        cognitivAction2HandlerDisabled = true;
                    }
                    if (!cognitivAction3HandlerDisabled)
                    {
                        engine.CognitivEmoStateUpdated -= new EmoEngine.CognitivEmoStateUpdatedEventHandler(engine_CognitivEmoStateUpdatedForAction3);
                        cognitivAction3HandlerDisabled = true;
                    }
                    if (MinerTimer != null)
                        MinerTimer.Enabled = false;
                    MainTimer.Enabled = false;
                    timer.Enabled = false;

                    

                   
                });
            }
            label_ActionPower.Visible = false;
            label_CurrentAction.Visible = false;
            progressBar_CognitivActivity.Visible = false;

            if (actionNumber == totalActiveActions)
            {
                MessageBox.Show("Completely authenticated");
                // Write logic to unlock the screen.
                //if (ScreenLock.MainPromptForm.mainPromptFormStaticObject != null)
                //{
                //    ScreenLock.MainPromptForm.mainPromptFormStaticObject.Show();
                //}
                //else
                //{
                authenticationSuccessfull = true;

                screenLockHelperObject.releaseHook();
                screenLockHelperObject.maximizeWindow();
                this.Hide();


                if (!cognitivAction1HandlerDisabled)
                {
                    engine.CognitivEmoStateUpdated -= new EmoEngine.CognitivEmoStateUpdatedEventHandler(engine_CognitivEmoStateUpdatedForAction1);
                    cognitivAction1HandlerDisabled = true;
                }
                if (!cognitivAction2HandlerDisabled)
                {
                    engine.CognitivEmoStateUpdated -= new EmoEngine.CognitivEmoStateUpdatedEventHandler(engine_CognitivEmoStateUpdatedForAction2);
                    cognitivAction2HandlerDisabled = true;
                }
                if (!cognitivAction3HandlerDisabled)
                {
                    engine.CognitivEmoStateUpdated -= new EmoEngine.CognitivEmoStateUpdatedEventHandler(engine_CognitivEmoStateUpdatedForAction3);
                    cognitivAction3HandlerDisabled = true;
                }
                actionNumber = 0;
                IsAborted = true;

                if (MainTimer != null)
                {
                    MainTimer.Enabled = false;
                }
                if (MinerTimer != null)
                {
                    MinerTimer.Enabled = false;
                }
                if (timer != null)
                {
                    timer.Enabled = false;
                }

                if (engine != null)
                {
                    engine.Disconnect();
                    engine = null;
                }




                ScreenLock.BackgroundScreen.backgroundScreenStatic.Hide();


                ScreenLock.MainPromptForm.mainPromptFormStaticObject = new ScreenLock.MainPromptForm();
                ScreenLock.MainPromptForm.userName = textBox_Username.Text;
                ScreenLock.MainPromptForm.mainPromptFormStaticObject.Show();
                //}
                return;
            }

            if (actionNumber == 1)
            {
                label_Action1State.Text = "Authenticated";
                button_AuthenticateAction1.Visible = false;
                button_AuthenticateAction2.Enabled = true;
                button_AuthenticateAction2.Visible = true;
            }
            else if (actionNumber == 2)
            {
                label_Action2State.Text = "Authenticated";
                button_AuthenticateAction2.Visible = false;
                button_AuthenticateAction3.Enabled = true;
                button_AuthenticateAction3.Visible = true;
            }
            else if (actionNumber == 3)
            {
                label_Action3State.Text = "Authenticated";
                button_AuthenticateAction3.Visible = false;
                button_AuthenticateAction3.Enabled = false;
                cognitivActionsAuthenticated = true;
                // MessageBox.Show("Completely authenticated");
            }
        }

        EdkDll.EE_CognitivAction_t convertStringToAction(string actionString)
        {
            switch (actionString)
            {
                case "NEUTRAL":
                    return EdkDll.EE_CognitivAction_t.COG_NEUTRAL;
                    
                case "PUSH":
                   return EdkDll.EE_CognitivAction_t.COG_PUSH;
                case "PULL":
                   return EdkDll.EE_CognitivAction_t.COG_PULL;
                case "LIFT":
                   return EdkDll.EE_CognitivAction_t.COG_LIFT;
                case "DROP":
                   return EdkDll.EE_CognitivAction_t.COG_DROP;

                case "LEFT":
                   return EdkDll.EE_CognitivAction_t.COG_LEFT;
                case "RIGHT":
                   return EdkDll.EE_CognitivAction_t.COG_RIGHT;

                case "ROTATE_LEFT":
                   return EdkDll.EE_CognitivAction_t.COG_ROTATE_LEFT;
                case "ROTATE_RIGHT":
                    return EdkDll.EE_CognitivAction_t.COG_ROTATE_RIGHT;
                case "ROTATE_CLOCKWISE":
                    return EdkDll.EE_CognitivAction_t.COG_ROTATE_CLOCKWISE;
                case "ROTATE_COUNTER_CLOCKWISE":
                    return EdkDll.EE_CognitivAction_t.COG_ROTATE_COUNTER_CLOCKWISE;

                case "ROTATE_FORWARDS":
                    return EdkDll.EE_CognitivAction_t.COG_ROTATE_FORWARDS;
                case "ROTATE_REVERSE":
                    return EdkDll.EE_CognitivAction_t.COG_ROTATE_REVERSE;
                case "DISAPPEAR":
                    return EdkDll.EE_CognitivAction_t.COG_DISAPPEAR;
            }
            return EdkDll.EE_CognitivAction_t.COG_NEUTRAL;
        }

        private void button_AuthenticateAction2_Click(object sender, EventArgs e)
        {
            actionNumber = 2;
            label1.Text = "";
            label2.Text = "";
            label_Action2State.Text = "Not Authenticated";
            label3.Text = "";
            differentActionCount = 0;


            CurrentAuthenticationAction = label_Action2.Text;
            
            timer = new System.Windows.Forms.Timer();
            timer.Enabled = true;
            timer.Interval = 30000;
            timer.Tick += new EventHandler(timer_Tick);

            MinerTimer = new System.Windows.Forms.Timer();
            MinerTimer.Interval = 200;
            MinerTimer.Enabled = false;
            MinerTimer.Tick += new EventHandler(MinerTimer_Tick);

            MainTimer = new System.Windows.Forms.Timer();
            MainTimer.Enabled = false;
            MainTimer.Interval = 3000;
            MainTimer.Tick += new EventHandler(MainTimer_Tick);
            failedCount = 0;
            cognitivAction2HandlerDisabled = false;
           // engine.CognitivEmoStateUpdated += new EmoEngine.CognitivEmoStateUpdatedEventHandler(engine_CognitivEmoStateUpdatedForAction1);
            engine.CognitivEmoStateUpdated += new EmoEngine.CognitivEmoStateUpdatedEventHandler(engine_CognitivEmoStateUpdatedForAction2);

            CurrentCognitivActivity = "COG_NEUTRAL";
            cognitivActivityPower = 0.0f;
            animateCube();
            newThreadStart = new ThreadStart(RunCube);
            newBoxUpdateThread = new Thread(newThreadStart);
            newBoxUpdateThread.Start();
            label_ActionPower.Visible = true;
            label_CurrentAction.Visible = true;
            progressBar_CognitivActivity.Visible = true;
            
        
        }

        void engine_CognitivEmoStateUpdatedForAction2(object sender, EmoStateUpdatedEventArgs e)
        {

            CurrentCognitivActivity = e.emoState.CognitivGetCurrentAction().ToString();
            cognitivActivityPower = e.emoState.CognitivGetCurrentActionPower();
            cognitivActivityPowerQueue.Enqueue(cognitivActivityPower);
            animateCube();

            lock (this)
            {
                this.Invoke((d)delegate()
                {
                    progressBar_CognitivActivity.Value = (int)(cognitivActivityPower * 100);
                    label_CurrentAction.Text = CurrentCognitivActivity;
                });
            }

            if (e.emoState.CognitivGetCurrentAction() == convertStringToAction(label_Action2.Text))
            {
                
                lock (this)
                {

                    this.Invoke((d)delegate()
                    {

                        if (((int)(e.emoState.CognitivGetCurrentActionPower() * 100)) >= 50)
                        {
                            //MessageBox.Show(((int)(e.emoState.CognitivGetCurrentActionPower() * 100)).ToString());

                            label1.Text = "Matching going on... : " + ((int)(e.emoState.CognitivGetCurrentActionPower() * 100)).ToString();
                            if (!matchingGoingOn)
                            {

                                //MainTimer.Enabled = true;

                                matchingGoingOn = true;
                                //MessageBox.Show("Cognitiv started");

                            }

                            MainTimer.Enabled = true;

                            MinerTimer.Enabled = false;


                        }
                        else
                        {
                            if (((int)e.emoState.CognitivGetCurrentActionPower() * 100) < 10 && MinerTimer == null)
                            {
                                MinerTimer.Enabled = true;



                            }
                        }
                    });
                }

            }
            else if (matchingGoingOn)
            {
                //MessageBox.Show("Thinking different");
                lock (this)
                {
                    this.Invoke((d)delegate()
                    {
                        MinerTimer.Enabled = true;
                        label3.Text = "Different action while " + label_Action2.Text;
                    });
                }
            }
            else
            {
                lock (this)
                {
                    this.Invoke((d)delegate()
                    {
                        differentActionCount++;

                        label3.Text = "Different Aciton! " + differentActionCount.ToString();
                    });
                }
            }
        }

        private void button_AuthenticateAction3_Click(object sender, EventArgs e)
        {
            
            actionNumber = 3;
            label1.Text = "";
            label2.Text = "";
            label_Action3State.Text = "Not Authenticated";
            label3.Text = "";
            differentActionCount = 0;


            CurrentAuthenticationAction = label_Action3.Text;
            
            timer = new System.Windows.Forms.Timer();
            timer.Enabled = true;
            timer.Interval = 30000;
            timer.Tick += new EventHandler(timer_Tick);

            MinerTimer = new System.Windows.Forms.Timer();
            MinerTimer.Interval = 200;
            MinerTimer.Enabled = false;
            MinerTimer.Tick += new EventHandler(MinerTimer_Tick);

            MainTimer = new System.Windows.Forms.Timer();
            MainTimer.Enabled = false;
            MainTimer.Interval = 3000;
            MainTimer.Tick += new EventHandler(MainTimer_Tick);
            failedCount = 0;
            cognitivAction3HandlerDisabled = false;
            engine.CognitivEmoStateUpdated += new EmoEngine.CognitivEmoStateUpdatedEventHandler(engine_CognitivEmoStateUpdatedForAction3);

            CurrentCognitivActivity = "COG_NEUTRAL";
            cognitivActivityPower = 0.0f;
            animateCube();
            newThreadStart = new ThreadStart(RunCube);
            newBoxUpdateThread = new Thread(newThreadStart);
            newBoxUpdateThread.Start();

            label_ActionPower.Visible = true;
            label_CurrentAction.Visible = true;
            progressBar_CognitivActivity.Visible = true;
        }

        void engine_CognitivEmoStateUpdatedForAction3(object sender, EmoStateUpdatedEventArgs e)
        {

            CurrentCognitivActivity = e.emoState.CognitivGetCurrentAction().ToString();
            cognitivActivityPower = e.emoState.CognitivGetCurrentActionPower();
            cognitivActivityPowerQueue.Enqueue(cognitivActivityPower);
            animateCube();
            lock (this)
            {
                this.Invoke((d)delegate()
                {
                    progressBar_CognitivActivity.Value = (int)(cognitivActivityPower * 100);
                    label_CurrentAction.Text = CurrentCognitivActivity;
                });
            }
            if (e.emoState.CognitivGetCurrentAction() == convertStringToAction(label_Action3.Text))
            {

                lock (this)
                {

                    this.Invoke((d)delegate()
                    {

                        if (((int)(e.emoState.CognitivGetCurrentActionPower() * 100)) >= 70)
                        {
                            //MessageBox.Show(((int)(e.emoState.CognitivGetCurrentActionPower() * 100)).ToString());

                            label1.Text = "Matching going on... : " + ((int)(e.emoState.CognitivGetCurrentActionPower() * 100)).ToString();
                            if (!matchingGoingOn)
                            {

                                //MainTimer.Enabled = true;

                                matchingGoingOn = true;
                                //MessageBox.Show("Cognitiv started");

                            }

                            MainTimer.Enabled = true;

                            MinerTimer.Enabled = false;


                        }
                        else
                        {
                            if (((int)e.emoState.CognitivGetCurrentActionPower() * 100) < 20 && MinerTimer == null)
                            {
                                MinerTimer.Enabled = true;



                            }
                        }
                    });
                }

            }
            else if (matchingGoingOn)
            {
                //MessageBox.Show("Thinking different");
                lock (this)
                {
                    this.Invoke((d)delegate()
                    {
                        MinerTimer.Enabled = true;
                        label3.Text = "Different action while " + label_Action3.Text;
                    });
                }
            }
            else
            {
                lock (this)
                {
                    this.Invoke((d)delegate()
                    {
                        differentActionCount++;

                        label3.Text = "Different Aciton! " + differentActionCount.ToString();
                    });
                }
            }
        }

        void animateCube()
        {
            
            switch (CurrentCognitivActivity)
            {
                case "COG_NEUTRAL":
                    

                        
                        DeltaY1 = 0f;
                        DeltaX1 = 0f;
                        moveForward = false;
                        animateDepth = false;
                        liftCube = false;
                        dropCube = false;
                        right = left = false;
                        rotateLeft = rotateRight = false;
                        rotateClockwise = rotateAntiClockwise = false;

                        depth = 20;
                        
                        
                        
                    
                    break;
                case "COG_PUSH":
                        DeltaY1 = 0f;
                        DeltaX1 = 0f;
                        moveForward = false;
                        animateDepth = true;
                        liftCube = false;
                        dropCube = false;
                        right = left = false;
                        rotateLeft = rotateRight = false;
                        depth = 5;
                        rotateClockwise = rotateAntiClockwise = false;
                        
                    
                    break;
                case "COG_PULL":
                        DeltaY1 = 0f;
                        DeltaX1 = 0f;
                        angleX = 5f;
                        moveForward = true;
                        animateDepth = true;
                        liftCube = false;
                        dropCube = false;
                        right = left = false;
                        rotateLeft = rotateRight = false;
                        depth = 40;
                        rotateClockwise = rotateAntiClockwise = false;
                        
                         break;

                case "COG_LIFT":

                        liftCube = true;
                        dropCube = false;
                        
                        DeltaY1 = 0f;
                        DeltaX1 = 0f;
                        angleX = -10f;
                        moveForward = false;
                        animateDepth = false;
                        right = left = false;
                        rotateLeft = rotateRight = false;
                        height = 0f;
                        depth = 40;
                        rotateClockwise = rotateAntiClockwise = false;
                        
                     break;


                case "COG_DROP":
                        liftCube = false;
                        dropCube = true;
                        
                        DeltaY1 = 0f;
                        DeltaX1 = 0f;
                        angleX = -10f;
                        moveForward = false;
                        animateDepth = false;
                        right = left = false;
                        rotateLeft = rotateRight = false;
                        height = -10f;
                        rotateClockwise = rotateAntiClockwise = false;
                       
                    break;

                case "COG_LEFT":
                        liftCube = false;
                        dropCube = false;
                        
                        DeltaY1 = 0f;
                        DeltaX1 = 0f;

                        moveForward = false;
                        animateDepth = false;
                        rotateLeft = rotateRight = false;
                        left = true;
                        right = false;
                        rotateClockwise = rotateAntiClockwise = false;
                        
                     break;

                case "COG_RIGHT":
                        liftCube = false;
                        dropCube = false;
                        
                        DeltaY1 = 0f;
                        DeltaX1 = 0f;

                        moveForward = false;
                        animateDepth = false;
                        rotateLeft = rotateRight = false;
                        left = false;
                        right = true;
                        rotateClockwise = rotateAntiClockwise = false;
                        break;

                case "COG_ROTATE_LEFT":
                     
                        angleX = -50f;
                        DeltaY1 = 2f;
                        DeltaX1 = 0f;
                        animateDepth = false;
                        liftCube = false;
                        dropCube = false;
                        right = left = false;
                        
                        rotateLeft = true;
                        
                        rotateRight = false;
                        rotateClockwise = rotateAntiClockwise = false;
                        
                   break;

                case "COG_ROTATE_RIGHT":
                        rotateLeft = false;
                        rotateRight = true;
                        DeltaY1 = -2f;
                        DeltaX1 = 0f;
                        animateDepth = false;
                        liftCube = false;
                        dropCube = false;
                        right = left = false;
                        rotateClockwise = rotateAntiClockwise = false;
                        
                   break;

                case "COG_ROTATE_CLOCKWISE":

                        
                        DeltaY1 = 0f;
                        DeltaX1 = 0f;
                        animateDepth = false;
                        liftCube = false;
                        dropCube = false;
                        right = left = false;
                        rotateAntiClockwise = false;
                        rotateClockwise = true;
                        rotateLeft = rotateRight = false;
                        rotateValue = -1f;
                        
                   break;

                case "COG_ROTATE_COUNTER_CLOCKWISE":
                        DeltaY1 = 0f;
                        DeltaX1 = 0f;
                        animateDepth = false;
                        liftCube = false;
                        dropCube = false;
                        right = left = false;
                        rotateAntiClockwise = true;
                        rotateClockwise = false;
                        rotateLeft = rotateRight = false;
                        rotateValue = 1f;
                        
                        break;
                case "COG_ROTATE_FORWARDS":
                        animateDepth = false;
                        DeltaY1 = 0f;
                        DeltaX1 = 2f;
                        liftCube = false;
                        dropCube = false;
                        moveForward = false;
                        right = left = false;
                        rotateLeft = rotateRight = false;
                        rotateClockwise = rotateAntiClockwise = false;
                        
                       break;

                case "COG_ROTATE_REVERSE":
                        animateDepth = false;
                        DeltaY1 = 0f;
                        DeltaX1 = -2f;
                        moveForward = false;
                        liftCube = false;
                        right = left = false;
                        dropCube = false;
                        rotateLeft = rotateRight = false;
                        rotateClockwise = rotateAntiClockwise = false;
                        //newThreadStart = new ThreadStart(RunCube);
                        //newBoxUpdateThread = new Thread(newThreadStart);
                        //newBoxUpdateThread.Start();
                        break;

                case "COG_DISAPPEAR":
                    break;


            }
        }


        // following methods are just for testing.
        private void button1_Click(object sender, EventArgs e)
        {
            //if (!alreadyDisplayed)
            //{
            //    if (newBoxUpdateThread != null && newBoxUpdateThread.IsAlive)
            //    {
            //        newBoxUpdateThread.Abort();
            //    }
            //    DeltaY1 = 0f;
            //    DeltaX1 = 0f;
            //    moveForward = false;
            //    animateDepth = false;
            //    liftCube = true;
            //    dropCube = false;
            //    right = left = false;
            //    depth = 5;
            //    height = 0;
            //    rotateClockwise = rotateAntiClockwise = false;

            //    cognitivActivityPower = 0.3f;
            //    ThreadStart newThreadStart = new ThreadStart(RunCube);

            //    newBoxUpdateThread = new Thread(newThreadStart);
            //    newBoxUpdateThread.Start();
            //    alreadyDisplayed = true;
            //}
            //else
            //{
            //    cognitivActivityPower =1f;
            //}
            lock (this)
            {
                this.Invoke((d)delegate()
                {
                    engine.CognitivEmoStateUpdated += new EmoEngine.CognitivEmoStateUpdatedEventHandler(engine_CognitivEmoStateUpdated);
                    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                    timer.Interval = 1000;
                    timer.Tick += new EventHandler(timer_Tick1);
                    timer.Enabled = true;
                });
            }
            //CurrentCognitivActivity = "COG_ROTATE_LEFT";
            //angleX = -50f;
            //DeltaY1 = 2f;
            //DeltaX1 = 0f;
            //animateDepth = false;
            //liftCube = false;
            //dropCube = false;
            //right = left = false;
            //rotateLeft = true;
            //rotateRight = false;
            //rotateClockwise = rotateAntiClockwise = false;
            //ThreadStart newThreadStart = new ThreadStart(RunCube);
            //newBoxUpdateThread = new Thread(newThreadStart);
            //newBoxUpdateThread.Start();
        }

        private void AuthenticateForm_Load(object sender, EventArgs e)
        {
            textBox_Username.Text = ScreenLock.LoginForm.userName;
            authenticationSuccessfull = false;

            
        }

        void engine_CognitivEmoStateUpdated(object sender, EmoStateUpdatedEventArgs e)
        {
            lock (this)
            {
                this.Invoke((d)delegate()
                {
                    countNumber++;
                });
            }
        }

        void timer_Tick1(object ob, EventArgs args)
        {
            lock (this)
            {
                this.Invoke((d)delegate()
                {
                    label4.Text = countNumber.ToString();
                    countNumber = 0;
                });
            } 
        }

        private void AuthenticateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!authenticationSuccessfull)
            {
                ScreenLock.LoginForm loginFormObj = new ScreenLock.LoginForm();
                ScreenLock.BackgroundScreen.loginFormReload(loginFormObj);
            }
        }

    }
}
