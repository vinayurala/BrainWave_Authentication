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
using WindowsGameSimpleCube1;
using System.IO;

namespace WindowsFormsThreadDemo
{

    public enum Action_t
    {
        NEUTRAL,
        PUSH,
        PULL,
        LIFT,
        DROP,
        LEFT,
        RIGHT,
        ROTATE_LEFT,
        ROTATE_RIGHT,
        ROTATE_CLOCKWISE,
        ROTATE_COUNTER_CLOCKWISE,
        ROTATE_FORWARDS,
        ROTATE_REVERSE,
        DISAPPEAR
    }

    

    //string [] Action_String_t={"NEUTRAL","PUSH","PULL","LIFT","DROP","LEFT","RIGHT","ROTATE_LEFT","ROTATE_RIGHT",        "ROTATE_CLOCKWISE","ROTATE_ANTI_CLOCKWISE","ROTATE_FORWARDS","ROTATE_REVERSE","DISAPPEAR"};


    public partial class TrainingForm : Form
    {
        string[] Action_String_t = { "NEUTRAL", "PUSH", "PULL", "LIFT", "DROP", "LEFT", "RIGHT", "ROTATE_LEFT", "ROTATE_RIGHT", "ROTATE_CLOCKWISE", "ROTATE_COUNTER_CLOCKWISE", "ROTATE_FORWARDS", "ROTATE_REVERSE", "DISAPPEAR" };

        public static TrainingForm trainingFormStaticObject = null;

        bool[] activeActionsFlags = null;
        EmoEngine engine;
        uint userId = 0;
        delegate void d();
        Thread newEngineThread = null;
        Thread newUpdateThread = null;
        bool animateCube = false;
        
        // Cube properties.
        Thread newBoxUpdateThread = null;
        static float DeltaX1;
        static float DeltaY1;
        static bool animateDepth = false;
        static bool moveForward = false;
        static float depth = 10;
        static float angleX = 0f;
        static float angleY = 0f;
        static bool liftCube = false;
        static bool dropCube = false;
        static float height = 0f;
        static bool left = false;
        static bool right = false;
        static bool rotateClockwise = false;
        static bool rotateAntiClockwise = false;
        static float rotateValue = 0f;

        public static bool updateUserProfile = false;
        public static string userProfileNameToBeLoaded = "";
        


        int totalCognitivActiveActions = 0;

        bool IsAborted = false;

        public TrainingForm()
        {
            InitializeComponent();

           
        }

        static void RunCube()
        {
            using (Game1 game = new Game1())
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




        void engine_UserAdded(Object sender, EmoEngineEventArgs args)
        {

            lock (this)
            {
                this.Invoke((d)delegate()
                {
                    try
                    {
                       
                        userId = (uint)args.userId;
                       // engine.LoadUserProfile(userId, "Copy of Prakash.emu");
                       // engine.LoadUserProfile(userId, @"profiles\prakashRotate.emu");
                        //engine.LoadUserProfile(userId, @"profiles\prakashFinal1.emu");
                      //  updateUserProfile = true;
                        if (updateUserProfile)
                        {
                            string fileName = userProfileNameToBeLoaded + ".emu";
                            engine.LoadUserProfile(userId, "profiles\\"+userProfileNameToBeLoaded + ".emu");
                            textBox_NewUserName.Text = userProfileNameToBeLoaded;
                            
                        }

                        
                        //bool updateUserProfileFlag = updateUserProfile;

                        //engine.LoadUserProfile(userId, "prakashRotate.emu");
                        uint activeActions = engine.CognitivGetActiveActions(userId);

                       

                        activeActionsFlags = getActionsStatus(activeActions);
                        listBox_ActiveActions.Items.Clear();
                        comboBox_TrainingAction.Items.Clear();

                        // listBox_ActiveActions.Items.Add("NEUTRAL");
                        comboBox_TrainingAction.Items.Add("NEUTRAL");

                        int index = 1;

                        while (index <= 13)
                        {
                            if (index == 4 || index == 5 || index == 6 || index == 9 || index == 10 || index == 13)
                            {
                                index++;
                                continue;
                            }

                            if (activeActionsFlags[index])
                            {
                                string actionDetailsString=Action_String_t[index] + "    " + (((int)(engine.CognitivGetActionSkillRating(userId, getCognitivType(Action_String_t[index])) * 100)))+" % trained";
                                listBox_ActiveActions.Items.Add(actionDetailsString);
                                comboBox_TrainingAction.Items.Add(Action_String_t[index]);
                                totalCognitivActiveActions++;
                            }
                            else
                            {
                                comboBox_Add_New_Action.Items.Add(Action_String_t[index]); // These actions are not active actions for this user.
                            }
                            index++;
                        }
                        comboBox_TrainingAction.SelectedIndex = 0;
                        comboBox_Add_New_Action.SelectedIndex = 0;
                        listBox_ActiveActions.SelectedIndex = 0;

                        if (totalCognitivActiveActions == 4)
                        {
                            button_AddNewAction.Enabled = false;
                            comboBox_Add_New_Action.Enabled = false;
                            //button_DeleteActivity.Enabled = true;

                        }
                        else
                        {
                            button_AddNewAction.Enabled = true;
                            comboBox_Add_New_Action.Enabled = true;
                        }

                        if (totalCognitivActiveActions <= 1)
                        {
                            button_DeleteActivity.Enabled = false;
                        }
                        else
                        {
                            button_DeleteActivity.Enabled = true;
                        }


                       // MessageBox.Show(engine.CognitivGetOverallSkillRating(userId).ToString());
                        textBox_OverallSkillRating.Text = ((int)(engine.CognitivGetOverallSkillRating(userId)*100)).ToString()+"%";


                    }
                    catch
                    {

                    }

                });
            }
            //updateLists();
            
        }

        private EdkDll.EE_CognitivAction_t getCognitivType(string ActionStringType)
        {
            switch (ActionStringType)
            {
                case "NEUTRAL": return EdkDll.EE_CognitivAction_t.COG_NEUTRAL;
                    
                case "PUSH": return EdkDll.EE_CognitivAction_t.COG_PUSH;
                    
                case "PULL": return EdkDll.EE_CognitivAction_t.COG_PULL;
                    
                case "LIFT": return EdkDll.EE_CognitivAction_t.COG_LIFT;
                    
                case "DROP":return EdkDll.EE_CognitivAction_t.COG_DROP;
                    
                case "LEFT": return EdkDll.EE_CognitivAction_t.COG_LEFT;
                    
                case "RIGHT":return EdkDll.EE_CognitivAction_t.COG_RIGHT;
                    
                case "ROTATE_LEFT": return EdkDll.EE_CognitivAction_t.COG_ROTATE_LEFT;
                    
                 case "ROTATE_RIGHT":return EdkDll.EE_CognitivAction_t.COG_ROTATE_RIGHT;
                    
                case "ROTATE_CLOCKWISE": return EdkDll.EE_CognitivAction_t.COG_ROTATE_CLOCKWISE;
                    
                case "ROTATE_ANTI_CLOCKWISE": return EdkDll.EE_CognitivAction_t.COG_ROTATE_COUNTER_CLOCKWISE;
                    
                case "ROTATE_FORWARDS": return EdkDll.EE_CognitivAction_t.COG_ROTATE_FORWARDS;
                    
                case "ROTATE_REVERSE": return EdkDll.EE_CognitivAction_t.COG_ROTATE_REVERSE;
                    
                case "DISAPPEAR": return EdkDll.EE_CognitivAction_t.COG_DISAPPEAR;
                    

            }
            return EdkDll.EE_CognitivAction_t.COG_NEUTRAL;
            
        }

        void engine_CognitivEmoStateUpdated(Object sender, EmoStateUpdatedEventArgs e)
        {
            lock (this)
            {
                this.Invoke((d)delegate()
                {
                    try
                    {
                        if (e.emoState.CognitivIsActive())
                        {
                            progressBar_Cognitiv.Value = (int)(e.emoState.CognitivGetCurrentActionPower()*100);
                            textBox_CognitivCurrentAction.Text = (e.emoState.CognitivGetCurrentAction()).ToString();
                            
                        }
                       
                    }
                    catch
                    {

                    }
                });
            }

        }


        private void DoWork()
        {
            engine = EmoEngine.Instance;
            engine.Connect();
            engine.UserAdded += new EmoEngine.UserAddedEventHandler(engine_UserAdded);
            engine.CognitivEmoStateUpdated += new EmoEngine.CognitivEmoStateUpdatedEventHandler(engine_CognitivEmoStateUpdated);
            

            engine.CognitivTrainingSucceeded += new EmoEngine.CognitivTrainingSucceededEventHandler(engine_CognitivTrainingSucceeded);
            engine.CognitivTrainingFailed += new EmoEngine.CognitivTrainingFailedEventHandler(engine_CognitivTrainingFailed);
            //engine.CognitivTrainingCompleted += new EmoEngine.CognitivTrainingCompletedEventHandler(engine_CognitivTrainingCompleted);

            engine.CognitivSignatureUpdated += new EmoEngine.CognitivSignatureUpdatedEventHandler(engine_CognitivSignatureUpdated);

            
            

            while (!IsAborted)
            {
                engine.ProcessEvents();
            }
        }

        void engine_CognitivSignatureUpdated(object sender, EmoEngineEventArgs e)
        {
            //MessageBox.Show("Cognitiv Signature Updated ");
        }

        //void engine_CognitivTrainingCompleted(object sender, EmoEngineEventArgs e)
        //{
        //    MessageBox.Show("Cognitiv Training Completed");
        //}

        void engine_CognitivTrainingFailed(object sender, EmoEngineEventArgs e)
        {
            if (newBoxUpdateThread != null && newBoxUpdateThread.IsAlive)
            {
                newBoxUpdateThread.Abort();
            }
            
            MessageBox.Show("Cognitiv Training Failed");
            Thread updateLabelThread = new Thread(updateLabel_TrainingMessage);
            updateLabelThread.Start();
        }

        void engine_CognitivTrainingSucceeded(object sender, EmoEngineEventArgs e)
        {
            if (newBoxUpdateThread != null && newBoxUpdateThread.IsAlive)
            {
                newBoxUpdateThread.Abort();
            }

            DialogResult result=MessageBox.Show("Do you want to accept training?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            Thread updateLabelThread = new Thread(updateLabel_TrainingMessage);
            updateLabelThread.Start();
           

          //  if (result.ToString().Equals("No"))
          //  {
          //      engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_REJECT);
          //      return;
          //  }
          //  engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_ACCEPT);
            //  System.Windows.Forms.MessageBox.Show("Training Succeded");
           // engine.CognitivSetTrainingControl(userID, EdkDll.EE_CognitivTrainingControl_t.COG_ACCEPT);
            

            //updateLists();

            lock (this)
            {
                this.Invoke((d)delegate()
                {
                    try
                    {
                        if (result.ToString().Equals("No"))
                        {
                            engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_REJECT);
                            return;
                        }
                        engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_ACCEPT);
                       
                        uint activeActions = engine.CognitivGetActiveActions(userId);

                        activeActionsFlags = getActionsStatus(activeActions);
                        listBox_ActiveActions.Items.Clear();

                        // listBox_ActiveActions.Items.Add("NEUTRAL"+ "    " + (engine.CognitivGetActionSkillRating(userId, getCognitivType(Action_String_t[0])) * 100));

                        int index = 1;
                        while (index <= 13)
                        {
                            if (activeActionsFlags[index])
                            {
                                if (index == 4 || index == 5 || index == 6 || index == 9 || index == 10 || index == 13)
                                {
                                    index++;
                                    continue;
                                }
                               // listBox_ActiveActions.Items.Add(Action_String_t[index] + "    " + (engine.CognitivGetActionSkillRating(userId, getCognitivType(Action_String_t[index])) * 100));
                                string actionDetailsString = Action_String_t[index] + "    " + (((int)(engine.CognitivGetActionSkillRating(userId, getCognitivType(Action_String_t[index])) * 100))) + " % trained";
                                listBox_ActiveActions.Items.Add(actionDetailsString);

                            }
                            index++;
                        }
                        comboBox_TrainingAction.SelectedIndex = 0;
                        textBox_OverallSkillRating.Text = ((int)(engine.CognitivGetOverallSkillRating(userId) * 100)).ToString()+"%";
                    }
                    catch
                    {

                    }
                });
            }




        }

        //private void button_startThread_Click(object sender, EventArgs e)
        //{
        //    newEngineThread = new Thread(DoWork);
        //    newEngineThread.Start();

        //    button_Exit.Enabled = true;
           
            
        //}

        private bool[] getActionsStatus(uint activeActions)
        {
            bool[] actionsStatus = new bool[14];  // There can be 14 Active Actions including Neutral.

            // convert trainedActions to binary
            // Then set flags.
            actionsStatus[0] = false;
            int index = 1;
            while (activeActions >= 0 && index<=13)
            {
                activeActions=activeActions >> 1;
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

        private void button1_Click(object sender, EventArgs e)
        {
            // newEngineThread.Join();
            try
            {

                IsAborted = true;

                Thread.Sleep(100);

                if (newEngineThread != null)
                {
                    if (!newEngineThread.IsAlive)
                    {

                        //Application.Exit();
                       // ScreenLock.MainPromptForm.mainPromptFormStaticObject = new ScreenLock.MainPromptForm();
                       // ScreenLock.MainPromptForm.mainPromptFormStaticObject.Show();
                        this.Hide();

                        if (ScreenLock.MainPromptForm.mainPromptFormStaticObject != null)
                        {
                            ScreenLock.MainPromptForm.mainPromptFormStaticObject.Show();
                        }
                        else
                        {
                            ScreenLock.MainPromptForm.mainPromptFormStaticObject = new ScreenLock.MainPromptForm();
                            ScreenLock.MainPromptForm.mainPromptFormStaticObject.Show();
                        }
                    }
                    else
                    {
                        button_Exit.Text = "Please click once again";

                    }
                }
                else
                {
                    //Application.Exit();
                    //ScreenLock.MainPromptForm.mainPromptFormStaticObject = new ScreenLock.MainPromptForm();
                    //ScreenLock.MainPromptForm.mainPromptFormStaticObject.Show();
                    this.Hide();

                    if (ScreenLock.MainPromptForm.mainPromptFormStaticObject != null)
                    {
                        ScreenLock.MainPromptForm.mainPromptFormStaticObject.Show();
                    }
                    else
                    {
                        ScreenLock.MainPromptForm.mainPromptFormStaticObject = new ScreenLock.MainPromptForm();
                        ScreenLock.MainPromptForm.mainPromptFormStaticObject.Show();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
         //   MessageBox.Show(comboBox_TrainingAction.SelectedItem.ToString());
            Thread updateLabelThread = new Thread(updateLabel_TrainingMessage);
            updateLabelThread.Start();

            switch (comboBox_TrainingAction.SelectedItem.ToString())
            {
                case "NEUTRAL":
                                if (animateCube)
                                {
                                    if (newBoxUpdateThread != null && newBoxUpdateThread.IsAlive)
                                    {
                                        newBoxUpdateThread.Abort();
                                    }
                                    DeltaY1 = 0f;
                                    DeltaX1 = 0f;
                                    moveForward = false;
                                    animateDepth = false;
                                    liftCube = false;
                                    dropCube = false;
                                    right = left = false; 
                                    rotateClockwise = rotateAntiClockwise = false;

                                    depth = 20;
                                    ThreadStart newThreadStart = new ThreadStart(RunCube);
                                    newBoxUpdateThread = new Thread(newThreadStart);
                                    newBoxUpdateThread.Start();
                                }
                    
                    
                                engine.CognitivSetTrainingAction(userId, EdkDll.EE_CognitivAction_t.COG_NEUTRAL);
                                engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_START);
                                //MessageBox.Show(comboBox_TrainingAction.SelectedItem.ToString());
                                break;
                case "PUSH":
                                if (animateCube)
                                {
                                    //angleX = 30f;

                                    if (newBoxUpdateThread != null && newBoxUpdateThread.IsAlive)
                                    {
                                        newBoxUpdateThread.Abort();
                                    }
                                    DeltaY1 = 0f;
                                    DeltaX1 = 0f;
                                    moveForward = false;
                                    animateDepth = true;
                                    liftCube = false;
                                    dropCube = false;
                                    right = left = false;
                                    depth = 5;
                                    rotateClockwise = rotateAntiClockwise = false;
                                    ThreadStart newThreadStart = new ThreadStart(RunCube);

                                    newBoxUpdateThread = new Thread(newThreadStart);
                                    newBoxUpdateThread.Start();
                                }
                                engine.CognitivSetTrainingAction(userId, EdkDll.EE_CognitivAction_t.COG_PUSH);
                                engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_START);
                                break;
                case "PULL":
                                if (animateCube)
                                {
                                    if (newBoxUpdateThread != null && newBoxUpdateThread.IsAlive)
                                    {
                                        newBoxUpdateThread.Abort();
                                    }
                                    DeltaY1 = 0f;
                                    DeltaX1 = 0f;
                                    angleX = 5f;
                                    moveForward = true;
                                    animateDepth = true;
                                    liftCube = false;
                                    dropCube = false;
                                    right = left = false;
                                    depth = 40;
                                    rotateClockwise = rotateAntiClockwise = false;
                                    ThreadStart newThreadStart = new ThreadStart(RunCube);
                                    newBoxUpdateThread = new Thread(newThreadStart);
                                    newBoxUpdateThread.Start();
                                }
                    
                    
                    
                                engine.CognitivSetTrainingAction(userId, EdkDll.EE_CognitivAction_t.COG_PULL);
                                engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_START);
                                break;

                case "LIFT":

                                if (animateCube)
                                {
                                    liftCube = true;
                                    dropCube = false;
                                    if (newBoxUpdateThread != null && newBoxUpdateThread.IsAlive)
                                    {
                                        newBoxUpdateThread.Abort();
                                    }
                                    DeltaY1 = 0f;
                                    DeltaX1 = 0f;
                                    angleX = -10f;
                                    moveForward = false ;
                                    animateDepth = false;
                                    right = left = false;
                                    height = 0f;
                                    depth = 40;
                                    rotateClockwise = rotateAntiClockwise = false;
                                    ThreadStart newThreadStart = new ThreadStart(RunCube);
                                    newBoxUpdateThread = new Thread(newThreadStart);
                                    newBoxUpdateThread.Start();
                                }


                                //engine.CognitivSetActiveActions(userId, (uint)10);
                                engine.CognitivSetTrainingAction(userId, EdkDll.EE_CognitivAction_t.COG_LIFT);
                                engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_START);
                                break;


                case "DROP":

                                if (animateCube)
                                {
                                    liftCube = false;
                                    dropCube = true;
                                    if (newBoxUpdateThread != null && newBoxUpdateThread.IsAlive)
                                    {
                                        newBoxUpdateThread.Abort();
                                    }
                                    DeltaY1 = 0f;
                                    DeltaX1 = 0f;
                                    angleX = -10f;
                                    moveForward = false;
                                    animateDepth = false;
                                    right = left = false;
                                    height = -10f;
                                    rotateClockwise = rotateAntiClockwise = false;
                                    ThreadStart newThreadStart = new ThreadStart(RunCube);
                                    newBoxUpdateThread = new Thread(newThreadStart);
                                    newBoxUpdateThread.Start();
                                }
                    engine.CognitivSetTrainingAction(userId, EdkDll.EE_CognitivAction_t.COG_DROP);
                                engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_START);
                                break;
            
                case "LEFT":
                                if (animateCube)
                                {
                                    liftCube = false;
                                    dropCube = false;
                                    if (newBoxUpdateThread != null && newBoxUpdateThread.IsAlive)
                                    {
                                        newBoxUpdateThread.Abort();
                                    }
                                    DeltaY1 = 0f;
                                    DeltaX1 = 0f;
                                    
                                    moveForward = false;
                                    animateDepth = false;
                                    left = true;
                                    right = false;
                                    rotateClockwise = rotateAntiClockwise = false;
                                    ThreadStart newThreadStart = new ThreadStart(RunCube);
                                    newBoxUpdateThread = new Thread(newThreadStart);
                                    newBoxUpdateThread.Start();
                                }
                                
                                engine.CognitivSetTrainingAction(userId, EdkDll.EE_CognitivAction_t.COG_LEFT);
                                engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_START);
                                break;

                case "RIGHT": if (animateCube)
                                {
                                    liftCube = false;
                                    dropCube = false;
                                    if (newBoxUpdateThread != null && newBoxUpdateThread.IsAlive)
                                    {
                                        newBoxUpdateThread.Abort();
                                    }
                                    DeltaY1 = 0f;
                                    DeltaX1 = 0f;

                                    moveForward = false;
                                    animateDepth = false;
                                    left = false;
                                    right = true;
                                    rotateClockwise = rotateAntiClockwise = false;
                                    ThreadStart newThreadStart = new ThreadStart(RunCube);
                                    newBoxUpdateThread = new Thread(newThreadStart);
                                    newBoxUpdateThread.Start();
                                }

                                
                    engine.CognitivSetTrainingAction(userId, EdkDll.EE_CognitivAction_t.COG_RIGHT);
                                engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_START);
                                break;
              
                case "ROTATE_LEFT":

                                if (animateCube)
                                {
                                    if (newBoxUpdateThread != null && newBoxUpdateThread.IsAlive)
                                    {
                                        newBoxUpdateThread.Abort();
                                    }
                                    angleX = -50f;
                                    DeltaY1 = 2f;
                                    DeltaX1 = 0f;
                                    animateDepth = false;
                                    liftCube = false;
                                    dropCube = false;
                                    right = left = false;
                                    rotateClockwise = rotateAntiClockwise = false;
                                    ThreadStart newThreadStart = new ThreadStart(RunCube);
                                    newBoxUpdateThread = new Thread(newThreadStart);
                                    newBoxUpdateThread.Start();
                                }
                                engine.CognitivSetTrainingAction(userId, EdkDll.EE_CognitivAction_t.COG_ROTATE_LEFT);
                                engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_START);
                                break;
            
                case "ROTATE_RIGHT":
                                if (animateCube)
                                {
                                    if (newBoxUpdateThread != null && newBoxUpdateThread.IsAlive)
                                    {
                                        newBoxUpdateThread.Abort();
                                    }
                                    DeltaY1 = -2f;
                                    DeltaX1 = 0f;
                                    animateDepth = false;
                                    liftCube = false;
                                    dropCube = false;
                                    right = left = false;
                                    rotateClockwise = rotateAntiClockwise = false;
                                    ThreadStart newThreadStart = new ThreadStart(RunCube);
                                    newBoxUpdateThread = new Thread(newThreadStart);
                                    newBoxUpdateThread.Start();
                                }
                    
                                engine.CognitivSetTrainingAction(userId, EdkDll.EE_CognitivAction_t.COG_ROTATE_RIGHT);
                                engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_START);
                                break;
             
                case "ROTATE_CLOCKWISE":

                                if (animateCube)
                                {
                                    if (newBoxUpdateThread != null && newBoxUpdateThread.IsAlive)
                                    {
                                        newBoxUpdateThread.Abort();
                                    }
                                    DeltaY1 = 0f;
                                    DeltaX1 = 0f;
                                    animateDepth = false;
                                    liftCube = false;
                                    dropCube = false;
                                    right = left = false;
                                    rotateAntiClockwise = false;
                                    rotateClockwise = true;
                                    rotateValue = -1f;
                                    ThreadStart newThreadStart = new ThreadStart(RunCube);
                                    newBoxUpdateThread = new Thread(newThreadStart);
                                    newBoxUpdateThread.Start();
                                }
                    
                                engine.CognitivSetTrainingAction(userId, EdkDll.EE_CognitivAction_t.COG_ROTATE_CLOCKWISE);
                                engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_START);
                                break;
              
                case "ROTATE_COUNTER_CLOCKWISE":


                                if (animateCube)
                                {
                                    if (newBoxUpdateThread != null && newBoxUpdateThread.IsAlive)
                                    {
                                        newBoxUpdateThread.Abort();
                                    }
                                    DeltaY1 = 0f;
                                    DeltaX1 = 0f;
                                    animateDepth = false;
                                    liftCube = false;
                                    dropCube = false;
                                    right = left = false;
                                    rotateAntiClockwise = true;
                                    rotateClockwise = false;
                                    rotateValue = 1f;
                                    ThreadStart newThreadStart = new ThreadStart(RunCube);
                                    newBoxUpdateThread = new Thread(newThreadStart);
                                    newBoxUpdateThread.Start();
                                }
                                engine.CognitivSetTrainingAction(userId, EdkDll.EE_CognitivAction_t.COG_ROTATE_COUNTER_CLOCKWISE);
                                engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_START);
                                break;
               
                case "ROTATE_FORWARDS":
                                if (animateCube)
                                {
                                    if (newBoxUpdateThread != null && newBoxUpdateThread.IsAlive)
                                    {
                                        newBoxUpdateThread.Abort();
                                    }
                                    animateDepth = false;
                                    DeltaY1 = 0f;
                                    DeltaX1 = 2f;
                                    liftCube = false;
                                    dropCube = false;
                                    moveForward = false;
                                    right = left = false;
                                    rotateClockwise = rotateAntiClockwise = false;
                                    ThreadStart newThreadStart = new ThreadStart(RunCube);
                                    newBoxUpdateThread = new Thread(newThreadStart);
                                    newBoxUpdateThread.Start();
                                }
                    engine.CognitivSetTrainingAction(userId, EdkDll.EE_CognitivAction_t.COG_ROTATE_FORWARDS);
                                engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_START);
                                break;
               
                case "ROTATE_REVERSE":
                                if (animateCube)
                                {
                                    if (newBoxUpdateThread != null && newBoxUpdateThread.IsAlive)
                                    {
                                        newBoxUpdateThread.Abort();
                                    }
                                    animateDepth = false;
                                    DeltaY1 = 0f;
                                    DeltaX1 = -2f;
                                    moveForward = false;
                                    liftCube = false;
                                    right = left = false;
                                    dropCube = false;
                                    rotateClockwise = rotateAntiClockwise = false;
                                    ThreadStart newThreadStart = new ThreadStart(RunCube);
                                    newBoxUpdateThread = new Thread(newThreadStart);
                                    newBoxUpdateThread.Start();
                                } 
                                engine.CognitivSetTrainingAction(userId, EdkDll.EE_CognitivAction_t.COG_ROTATE_REVERSE);
                                engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_START);
                                break;
               
                case "DISAPPEAR":
                    
                    
                    
                    
                    
                                engine.CognitivSetTrainingAction(userId, EdkDll.EE_CognitivAction_t.COG_DISAPPEAR);
                                engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_START);

                                break;
                               
                
            }
        }

        private void FormClosedHandlerFunction(object sender, FormClosedEventArgs e)
        {
            IsAborted = true;

            if (newEngineThread != null)
            {
                while (newEngineThread.IsAlive)
                {
                    Thread.Sleep(30);
                }
            }

            Application.Exit();
        }

        

        private void MainForm_Load(object sender, EventArgs e)
        {
            newEngineThread = new Thread(DoWork);
            newEngineThread.Start();

            button_Exit.Enabled = true;
           
            ////comboBox_TrainingAction.SelectedIndex = 0;
            //MessageBox.Show(Enum.Format(typeof(EE_CognitivAction_Tt),EE_CognitivAction_Tt.COG_DISAPPEAR,"D").ToString());
            //MessageBox.Show(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_LIFT, "D").ToString());

            //uint num1=uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_LIFT, "D"));
            //uint num2 = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_DISAPPEAR, "D"));
            //MessageBox.Show((num1|num2).ToString());
           
        }

        public enum EE_CognitivAction_Tt
        {
            COG_NEUTRAL = 0x0001,
            COG_PUSH = 0x0002,
            COG_PULL = 0x0004,
            COG_LIFT = 0x0008,
            COG_DROP = 0x0010,
            COG_LEFT = 0x0020,
            COG_RIGHT = 0x0040,
            COG_ROTATE_LEFT = 0x0080,
            COG_ROTATE_RIGHT = 0x0100,
            COG_ROTATE_CLOCKWISE = 0x0200,
            COG_ROTATE_COUNTER_CLOCKWISE = 0x0400,
            COG_ROTATE_FORWARDS = 0x0800,
            COG_ROTATE_REVERSE = 0x1000,
            COG_DISAPPEAR = 0x2000

        } ;

        private void button_AddNewAction_Click(object sender, EventArgs e)
        {
            uint activeActions = 0;
            uint newActiveActions = 0;
            uint newActiveAction;

            activeActions = engine.CognitivGetActiveActions(userId);
            //MessageBox.Show(comboBox_Add_New_Action.SelectedItem.ToString());
            if (totalCognitivActiveActions < 4)
            {
                totalCognitivActiveActions++;
                switch (comboBox_Add_New_Action.SelectedItem.ToString())
                {
                    case "NEUTRAL":
                        newActiveAction = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_NEUTRAL, "D"));
                        newActiveActions = activeActions | newActiveAction;
                        engine.CognitivSetActiveActions(userId, newActiveActions);

                        break;
                    case "PUSH": newActiveAction = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_PUSH, "D"));
                        newActiveActions = activeActions | newActiveAction;
                        engine.CognitivSetActiveActions(userId, newActiveActions);
                        break;
                    case "PULL": newActiveAction = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_PULL, "D"));
                        newActiveActions = activeActions | newActiveAction;
                        engine.CognitivSetActiveActions(userId, newActiveActions);
                        break;

                    case "LIFT":
                        newActiveAction = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_LIFT, "D"));
                        newActiveActions = activeActions | newActiveAction;
                        engine.CognitivSetActiveActions(userId, newActiveActions);
                        break;


                    case "DROP": newActiveAction = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_DROP, "D"));
                        newActiveActions = activeActions | newActiveAction;
                        engine.CognitivSetActiveActions(userId, newActiveActions);
                        break;

                    case "LEFT": newActiveAction = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_LEFT, "D"));
                        newActiveActions = activeActions | newActiveAction;
                        engine.CognitivSetActiveActions(userId, newActiveActions);
                        break;

                    case "RIGHT": newActiveAction = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_RIGHT, "D"));
                        newActiveActions = activeActions | newActiveAction;
                        engine.CognitivSetActiveActions(userId, newActiveActions);
                        break;

                    case "ROTATE_LEFT": newActiveAction = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_ROTATE_LEFT, "D"));
                        newActiveActions = activeActions | newActiveAction;
                        engine.CognitivSetActiveActions(userId, newActiveActions);
                        break;

                    case "ROTATE_RIGHT": newActiveAction = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_ROTATE_RIGHT, "D"));
                        newActiveActions = activeActions | newActiveAction;
                        engine.CognitivSetActiveActions(userId, newActiveActions);
                        break;

                    case "ROTATE_CLOCKWISE": newActiveAction = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_ROTATE_CLOCKWISE, "D"));
                        newActiveActions = activeActions | newActiveAction;
                        engine.CognitivSetActiveActions(userId, newActiveActions);
                        break;

                    case "ROTATE_COUNTER_CLOCKWISE": newActiveAction = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_ROTATE_COUNTER_CLOCKWISE, "D"));
                        newActiveActions = activeActions | newActiveAction;
                        engine.CognitivSetActiveActions(userId, newActiveActions);
                        break;

                    case "ROTATE_FORWARDS": newActiveAction = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_ROTATE_FORWARDS, "D"));
                        newActiveActions = activeActions | newActiveAction;
                        engine.CognitivSetActiveActions(userId, newActiveActions);
                        break;

                    case "ROTATE_REVERSE": newActiveAction = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_ROTATE_REVERSE, "D"));
                        newActiveActions = activeActions | newActiveAction;
                        engine.CognitivSetActiveActions(userId, newActiveActions);
                        break;

                    case "DISAPPEAR": newActiveAction = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_DISAPPEAR, "D"));
                        newActiveActions = activeActions | newActiveAction;
                        engine.CognitivSetActiveActions(userId, newActiveActions);
                        break;


                }
            }
            else
            {
                MessageBox.Show("You can have maximum of 4 trained Actions");
                return;
            }

            newUpdateThread = new Thread(updatelist);
            newUpdateThread.Start();

           



        }

        /// <summary>
        ///  Update Trained list, Training list and inactive actions lists.
        /// </summary>
        public void updatelist()
        {

            lock (this)
            {
                this.Invoke((d)delegate()
                {
                    try
                    {
                        textBox_OverallSkillRating.Text = ((int)(engine.CognitivGetOverallSkillRating(userId) * 100)).ToString()+"%";
                        
                       // textBox_OverallSkillRating.Text = "heel";

                        if (totalCognitivActiveActions == 4)
                        {
                            button_AddNewAction.Enabled = false;
                            comboBox_Add_New_Action.Enabled = false;
                            //button_DeleteActivity.Enabled = true;
                           
                        }else                       
                        {
                            button_AddNewAction.Enabled = true;
                            comboBox_Add_New_Action.Enabled = true;
                        }

                        if (totalCognitivActiveActions <= 1)
                        {
                            button_DeleteActivity.Enabled = false;
                        }
                        else
                        {
                            button_DeleteActivity.Enabled = true;
                        }
                        uint activeActions = engine.CognitivGetActiveActions(userId);

                        //MessageBox.Show(activeActions.ToString());

                        activeActionsFlags = getActionsStatus(activeActions);
                        listBox_ActiveActions.Items.Clear();
                        comboBox_TrainingAction.Items.Clear();
                        comboBox_Add_New_Action.Items.Clear();

                        // listBox_ActiveActions.Items.Add("NEUTRAL");
                        comboBox_TrainingAction.Items.Add("NEUTRAL");

                        int index = 1;

                        while (index <= 13)
                        {
                            if (index == 4 || index == 5 || index == 6 || index == 9 || index == 10 || index == 13)
                            {
                                index++;
                                continue;
                            }

                            if (activeActionsFlags[index])
                            {
                                
                              //  listBox_ActiveActions.Items.Add(Action_String_t[index] + "    " + (engine.CognitivGetActionSkillRating(userId, getCognitivType(Action_String_t[index])) * 100));
                                string actionDetailsString = Action_String_t[index] + "    " + (((int)(engine.CognitivGetActionSkillRating(userId, getCognitivType(Action_String_t[index])) * 100))) + " % trained";
                                listBox_ActiveActions.Items.Add(actionDetailsString);
                                comboBox_TrainingAction.Items.Add(Action_String_t[index]);

                            }
                            else
                            {
                                comboBox_Add_New_Action.Items.Add(Action_String_t[index]); // These actions are not active actions for this user.
                            }
                            index++;
                        }
                        comboBox_TrainingAction.SelectedIndex = 0;
                        comboBox_Add_New_Action.SelectedIndex = 0;




                    }
                    catch
                    {

                    }

                });
            }
        }

        private void button_SaveUserProfile_Click(object sender, EventArgs e)
        {


            if (textBox_NewUserName.Text.Length <= 5)
            {
                MessageBox.Show("User name must contain atleast 5 characters");
                return;

            }
            else
            {
                bool uniqueFlag = true;
                DialogResult result = System.Windows.Forms.DialogResult.No;
                DirectoryInfo dInfo = new DirectoryInfo("profiles");
                FileInfo[] fInfos = dInfo.GetFiles();
                foreach (FileInfo finfo in fInfos)
                {
                    if (finfo.Name.Equals(textBox_NewUserName.Text + ".emu"))
                    {
                        uniqueFlag = false;
                    }
                }
                if (!uniqueFlag)
                {
                    result = MessageBox.Show("User name exists! Do you want to overwrite the file?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                    if (result.ToString().Equals("Yes"))
                    {
                        engine.EE_SaveUserProfile(userId, "profiles\\"+textBox_NewUserName.Text + ".emu");
                    }
                }
                else
                {
                    engine.EE_SaveUserProfile(userId, "profiles\\"+textBox_NewUserName.Text + ".emu");
                }
            }
                
        }

        private void listBox_ActiveActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_DeleteActivity.Enabled = true;
        }

        private void button_DeleteActivity_Click(object sender, EventArgs e)
        {

            if (totalCognitivActiveActions <= 1)
            {
                MessageBox.Show("Sorry at least one activity should be trained");
            }

            string selectedAction = listBox_ActiveActions.SelectedItem.ToString();

            string[] values = selectedAction.Split(' ');

          DialogResult result= MessageBox.Show("Do you want to delete "+values[0], "INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            uint actionToBeDeleted;
            uint newActiveActions;
            uint activeActions=engine.CognitivGetActiveActions(userId);
          //MessageBox.Show((result.ToString().Equals( "Yes")).ToString());
          //MessageBox.Show(result.ToString());
          
          //MessageBox.Show(values[0]);
          if (result.ToString().Equals("Yes"))
          {
                totalCognitivActiveActions--;
                switch (values[0])
                {
                    case "NEUTRAL":
                        actionToBeDeleted = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_NEUTRAL, "D"));
                        newActiveActions = activeActions ^ actionToBeDeleted;
                        engine.CognitivSetActiveActions(userId, newActiveActions);

                        break;
                    case "PUSH": actionToBeDeleted = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_PUSH, "D"));
                        newActiveActions = activeActions ^ actionToBeDeleted;
                        engine.CognitivSetActiveActions(userId, newActiveActions);
                        break;
                    case "PULL": actionToBeDeleted = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_PULL, "D"));
                        newActiveActions = activeActions ^ actionToBeDeleted;
                        engine.CognitivSetActiveActions(userId, newActiveActions);
                        break;

                    case "LIFT":
                        actionToBeDeleted = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_LIFT, "D"));
                        newActiveActions = activeActions ^ actionToBeDeleted;
                        engine.CognitivSetActiveActions(userId, newActiveActions);
                        break;


                    case "DROP": actionToBeDeleted = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_DROP, "D"));
                        newActiveActions = activeActions ^ actionToBeDeleted;
                        engine.CognitivSetActiveActions(userId, newActiveActions);
                        break;

                    case "LEFT": actionToBeDeleted = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_LEFT, "D"));
                        newActiveActions = activeActions ^ actionToBeDeleted;
                        engine.CognitivSetActiveActions(userId, newActiveActions);
                        break;

                    case "RIGHT": actionToBeDeleted = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_RIGHT, "D"));
                        newActiveActions = activeActions ^ actionToBeDeleted;
                        engine.CognitivSetActiveActions(userId, newActiveActions);
                        break;

                    case "ROTATE_LEFT": actionToBeDeleted = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_ROTATE_LEFT, "D"));
                        newActiveActions = activeActions ^ actionToBeDeleted;
                        engine.CognitivSetActiveActions(userId, newActiveActions);
                        break;

                    case "ROTATE_RIGHT": actionToBeDeleted = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_ROTATE_RIGHT, "D"));
                        newActiveActions = activeActions ^ actionToBeDeleted;
                        engine.CognitivSetActiveActions(userId, newActiveActions);
                        break;

                    case "ROTATE_CLOCKWISE": actionToBeDeleted = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_ROTATE_CLOCKWISE, "D"));
                        newActiveActions = activeActions ^ actionToBeDeleted;
                        engine.CognitivSetActiveActions(userId, newActiveActions);
                        break;

                    case "ROTATE_COUNTER_CLOCKWISE": actionToBeDeleted = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_ROTATE_COUNTER_CLOCKWISE, "D"));
                        newActiveActions = activeActions ^ actionToBeDeleted;
                        engine.CognitivSetActiveActions(userId, newActiveActions);
                        break;

                    case "ROTATE_FORWARDS": actionToBeDeleted = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_ROTATE_FORWARDS, "D"));
                        newActiveActions = activeActions ^ actionToBeDeleted;
                        engine.CognitivSetActiveActions(userId, newActiveActions);
                        break;

                    case "ROTATE_REVERSE": actionToBeDeleted = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_ROTATE_REVERSE, "D"));
                        newActiveActions = activeActions ^ actionToBeDeleted;
                        engine.CognitivSetActiveActions(userId, newActiveActions);
                        break;

                    case "DISAPPEAR": actionToBeDeleted = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_DISAPPEAR, "D"));
                        newActiveActions = activeActions ^ actionToBeDeleted;
                        engine.CognitivSetActiveActions(userId, newActiveActions);
                        break;
                }

             
                Thread newUpdateListThread1 = new Thread(updatelist);
                newUpdateListThread1.Start();

          }



            

        }

        void updateLabel_TrainingMessage()
        {
            lock (this)
            {
                this.Invoke((d)delegate()
                {
                    try
                    {
                        if (label_TrainingMessage.Text.Equals(""))
                        {
                            label_TrainingMessage.Text = "Training is going on.. please wait..";
                            button_StartTraining.Enabled = false;
                        }
                        else
                        {
                            label_TrainingMessage.Text = "";
                            button_StartTraining.Enabled = true;
                        }
                    }
                    catch
                    {

                    }

                });
            }
        }

        //private void button1_Click_1(object sender, EventArgs e)
        //{
        //    newEngineThread.Abort();
        //}

        private void button_EraseTraining_Click(object sender, EventArgs e)
        {
            string activityName = comboBox_TrainingAction.SelectedItem.ToString();
            DialogResult result = MessageBox.Show("Do you want to erase training details of " + activityName + " activity? ", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            uint actionToBeErased, pTrainedActionsOut;

            //EdkDll.EE_CognitivGetTrainedSignatureActions(userId,out pTrainedActionsOut);
            //MessageBox.Show(pTrainedActionsOut.ToString());
            
            if (result.ToString().Equals("Yes"))
            {
                //MessageBox.Show("true");
                switch (activityName)
                {
                    case "NEUTRAL":
                        actionToBeErased = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_NEUTRAL, "D"));
                        engine.CognitivSetTrainingAction(userId, EdkDll.EE_CognitivAction_t.COG_NEUTRAL);
                        engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_ERASE);
                        // EdkDll.EE_CognitivGetTrainedSignatureActions(userId,out pTrainedActionsOut);
                        //MessageBox.Show(pTrainedActionsOut.ToString());
                        break;
                    case "PUSH":
                        actionToBeErased = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_PUSH, "D"));
                        engine.CognitivSetTrainingAction(userId, EdkDll.EE_CognitivAction_t.COG_PUSH);
                        engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_ERASE);
                        // EdkDll.EE_CognitivGetTrainedSignatureActions(userId,out pTrainedActionsOut);
                        //MessageBox.Show(pTrainedActionsOut.ToString());



                        break;
                    case "PULL": actionToBeErased = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_PULL, "D"));
                        engine.CognitivSetTrainingAction(userId, EdkDll.EE_CognitivAction_t.COG_PULL);
                        engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_ERASE);
                        break;

                    case "LIFT":
                        actionToBeErased = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_LIFT, "D"));
                        engine.CognitivSetTrainingAction(userId, EdkDll.EE_CognitivAction_t.COG_LIFT);
                        engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_ERASE);
                        break;


                    case "DROP": actionToBeErased = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_DROP, "D"));
                        engine.CognitivSetTrainingAction(userId, EdkDll.EE_CognitivAction_t.COG_DROP);
                        engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_ERASE);
                        break;

                    case "LEFT": actionToBeErased = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_LEFT, "D"));
                        engine.CognitivSetTrainingAction(userId, EdkDll.EE_CognitivAction_t.COG_LEFT);
                        engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_ERASE);
                        break;

                    case "RIGHT": actionToBeErased = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_RIGHT, "D"));
                        engine.CognitivSetTrainingAction(userId, EdkDll.EE_CognitivAction_t.COG_RIGHT);
                        engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_ERASE);
                        break;

                    case "ROTATE_LEFT": actionToBeErased = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_ROTATE_LEFT, "D"));
                        engine.CognitivSetTrainingAction(userId, EdkDll.EE_CognitivAction_t.COG_ROTATE_LEFT);
                        engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_ERASE);
                        break;

                    case "ROTATE_RIGHT": actionToBeErased = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_ROTATE_RIGHT, "D"));
                        engine.CognitivSetTrainingAction(userId, EdkDll.EE_CognitivAction_t.COG_ROTATE_RIGHT);
                        engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_ERASE);
                        break;

                    case "ROTATE_CLOCKWISE": actionToBeErased = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_ROTATE_CLOCKWISE, "D"));
                        engine.CognitivSetTrainingAction(userId, EdkDll.EE_CognitivAction_t.COG_ROTATE_CLOCKWISE);
                        engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_ERASE);
                        break;

                    case "ROTATE_COUNTER_CLOCKWISE": actionToBeErased = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_ROTATE_COUNTER_CLOCKWISE, "D"));
                        engine.CognitivSetTrainingAction(userId, EdkDll.EE_CognitivAction_t.COG_ROTATE_COUNTER_CLOCKWISE);
                        engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_ERASE);
                        break;

                    case "ROTATE_FORWARDS": actionToBeErased = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_ROTATE_FORWARDS, "D"));
                        engine.CognitivSetTrainingAction(userId, EdkDll.EE_CognitivAction_t.COG_ROTATE_FORWARDS);
                        engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_ERASE);
                        break;

                    case "ROTATE_REVERSE": actionToBeErased = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_ROTATE_REVERSE, "D"));
                        engine.CognitivSetTrainingAction(userId, EdkDll.EE_CognitivAction_t.COG_ROTATE_REVERSE);
                        engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_ERASE);
                        break;

                    case "DISAPPEAR": actionToBeErased = uint.Parse(Enum.Format(typeof(EE_CognitivAction_Tt), EE_CognitivAction_Tt.COG_DISAPPEAR, "D"));
                        engine.CognitivSetTrainingAction(userId, EdkDll.EE_CognitivAction_t.COG_DISAPPEAR);
                        engine.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_ERASE);
                        break;
                }
                Thread newUpdateListThread1 = new Thread(updatelist);
                newUpdateListThread1.Start();

            }
        }

        private void checkBox_AnimateCube_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_AnimateCube.Checked)
            {
                animateCube = true;
            }
            else
            {
                animateCube = false;
            }
        }

        private void textBox_TrainedActions_TextChanged(object sender, EventArgs e)
        {

        }

     
    }


   



}
