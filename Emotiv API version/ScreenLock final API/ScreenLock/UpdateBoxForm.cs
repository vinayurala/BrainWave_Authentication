using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsGameSimpleCube1
{
    public partial class UpdateBoxForm : Form
    {
        static float DeltaX1;
        static float DeltaY1;
        Thread newGameThread = null;

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
       

        public UpdateBoxForm()
        {
            InitializeComponent();
        }

        private void UpdateBoxForm_Load(object sender, EventArgs e)
        {
            
        }

        static void RunGame()
        {
            using (Game1 game = new Game1())
            {
                game.DeltaX = DeltaX1;
                game.DeltaY = DeltaY1;
                game.AngleX = -20f;
                game.Run();
                
            }
        }
        //private void button_RotateRight_Click(object sender, EventArgs e)
        //{
        //    //if (newGameThread != null && newGameThread.IsAlive)
        //    //{
        //    //    newGameThread.Abort();
        //    //}

        //    if (newGameThread != null && newGameThread.IsAlive)
        //    {
        //        newGameThread.Abort();
        //    }
        //    DeltaY1 -= 2f;
        //    ThreadStart newThreadStart = new ThreadStart(RunGame);
        //    Thread newGameThread = new Thread(newThreadStart);
        //    newGameThread.Start();

        //}

        private void button_RotateLeft_Click(object sender, EventArgs e)
        {
            if (newGameThread != null && newGameThread.IsAlive)
            {
                newGameThread.Abort();
            }
            DeltaY1 = 2f;
            DeltaX1 = 0f;
            ThreadStart newThreadStart = new ThreadStart(RunGame);
            newGameThread = new Thread(newThreadStart);
            newGameThread.Start();

        }

        private void button_RotateRight_Click(object sender, EventArgs e)
        {
            if (newGameThread != null && newGameThread.IsAlive)
            {
                newGameThread.Abort();
            }
            DeltaY1 = -4f;
            DeltaX1 = 0f;
            ThreadStart newThreadStart = new ThreadStart(RunGame);
            newGameThread = new Thread(newThreadStart);
            newGameThread.Start();
        }

        private void button_RotateForward_Click(object sender, EventArgs e)
        {
            if (newGameThread != null && newGameThread.IsAlive)
            {
                newGameThread.Abort();
            }
            DeltaY1 = 0f;
            DeltaX1 = 2f;
            ThreadStart newThreadStart = new ThreadStart(RunGame);
            newGameThread = new Thread(newThreadStart);
            newGameThread.Start();

        }

        private void button_RotateBackward_Click(object sender, EventArgs e)
        {
            if (newGameThread != null && newGameThread.IsAlive)
            {
                newGameThread.Abort();
            }
            DeltaY1 = 0f;
            DeltaX1 = -2f;
            ThreadStart newThreadStart = new ThreadStart(RunGame);
            newGameThread = new Thread(newThreadStart);
            newGameThread.Start();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            Game1.countNumber = 0;
            timer.Enabled = true;

        }

        void timer_Tick(object sender, EventArgs e)
        {
            label1.Text = Game1.countNumber.ToString();
            Game1.countNumber = 0;

        }

        
    }
}
