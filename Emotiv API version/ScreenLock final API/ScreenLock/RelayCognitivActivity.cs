using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using System.Threading;


namespace WindowsGameSimpleCube1
{
    class relayCognitivActivity:Microsoft.Xna.Framework.Game
    {

        static float activityPower = 0;
        public float ActitityPower
        {
            get { return activityPower; }
            set { activityPower = value; }
        }

       GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        BasicEffect cubeEffect;

        bool liftCube = false;
        bool dropCube = false;

        public bool rotateClockwise = false;
        public bool rotateAntiClockwise = false;
         public float rotateValue = -1f;

        public bool moveRight=false;
        public bool moveLeft=false;
        public float position = 0f;
        public bool rotateRight = false;
        public bool rotateLeft = false;
        float oldCognitivActivityPower = 0;
        bool activityPowerState = false; //decreasing.


        static float height=0f;
        public float Height
        {
            get { return height; }
            set { height = value; }
        }

        public bool LiftCube
        {
            get { return liftCube; }
            set { liftCube = value; }
        }
        public bool DropCube
        {
            get { return dropCube; }
            set { dropCube = value; }
        }

        bool animateDepth = false;
        public bool AnimateDepth
        {
            get { return animateDepth; }
            set { animateDepth = value; }
        }
        bool moveForward = false;
        public bool MoveForward
        {
            get { return moveForward; }
            set { moveForward = value; }
        }

       public float depth = 10;
        

        float angleY = 0f;

        public float AngleY
        {
            get { return angleY; }
            set { angleY = value; }
        }
        float deltaY = 0f;

        public float DeltaY
        {
            get { return deltaY; }
            set { deltaY = value; }
        }


        float angleX = 0f;

        public float AngleX
        {
            get { return angleX; }
            set { angleX = value; }
        }
        float deltaX = 0f;

        public float DeltaX
        {
            get { return deltaX; }
            set { deltaX = value; }
        }

        

        Matrix worldMatrix;
        Matrix cameraMatrix;
        Matrix projectionMatrix;
        

        BasicShape cube = new BasicShape(new Vector3(2, 2, 2), new Vector3(0, 0, 0));

        public relayCognitivActivity()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
            base.Initialize();
            initializeWorld();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can
            // be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            cube.shapeTexture = Content.Load<Texture2D>("Textures\\Untitled1");
        }
        

        protected override void Update(GameTime gameTime)
        {
            if (AuthenticateForm.cognitivActivityPowerQueue.Count > 0)
                activityPower = AuthenticateForm.cognitivActivityPowerQueue.Dequeue();
            else
                activityPower = oldCognitivActivityPower;
            if (activityPower > oldCognitivActivityPower)
            {
                activityPowerState = true;
            }
            else
                activityPowerState = false;
            oldCognitivActivityPower = activityPower;

            //DeltaX = AuthenticateForm.DeltaX1;
            //DeltaY = AuthenticateForm.DeltaY1;
            //AngleX = AuthenticateForm.angleX;
            //AngleY = AuthenticateForm.angleY;

            AnimateDepth = AuthenticateForm.animateDepth;
            MoveForward = AuthenticateForm.moveForward;
            //depth = AuthenticateForm.depth;
            LiftCube = AuthenticateForm.liftCube;
            DropCube = AuthenticateForm.dropCube;
            //Height = AuthenticateForm.height;
            moveLeft = AuthenticateForm.left;
            moveRight = AuthenticateForm.right;
            rotateClockwise = AuthenticateForm.rotateClockwise;
            rotateRight = AuthenticateForm.rotateRight;
            rotateLeft = AuthenticateForm.rotateLeft;

            rotateAntiClockwise = AuthenticateForm.rotateAntiClockwise;
            //rotateValue = AuthenticateForm.rotateValue;
            


            // Allows the game to exit
            //int count = 5;
            if (animateDepth && !moveForward)
            {

                depth = 10 + activityPower * 35;
                cameraMatrix = Matrix.CreateLookAt(
                    new Vector3(0, depth, 20), new Vector3(0, 1, 0), new Vector3(0, 1, 0));

               //if(activityPowerState)
               //    angleX = angleX + (float)((266 * 0.15) * ActitityPower);
               //else
               //    angleX = angleX - (float)((266 * 0.15) * ActitityPower);
               // //deltaX = -0.15f;
                //if (depth >= 45)
                //{
                //    depth = 45;
                //    deltaX = 0f;
                //}


            }
            else if (animateDepth && moveForward)
            {

                depth = 30 - activityPower * 20;
                cameraMatrix = Matrix.CreateLookAt(
                    new Vector3(0, depth, 20), new Vector3(0, 1, 0), new Vector3(0, 1, 0));
                // deltaX = 20f;
                //if (depth <= 10)
                //{
                //    deltaX = 0f;
                //    depth = 10f;
                //}
            }

            else if (liftCube)
            {
                height = -activityPower * 20;
                cameraMatrix = Matrix.CreateLookAt(
                    new Vector3(0, 20, 20), new Vector3(0, height, 0), new Vector3(0, 1, 0));
                if (height <= -20)
                {
                    height = -20;
                }
            }
            else if (dropCube)
            {
                height = -5 + activityPower * 15;
                cameraMatrix = Matrix.CreateLookAt(
                    new Vector3(0, 20, 20), new Vector3(0, height, 0), new Vector3(0, 1, 0));
                if (height >= 10)
                {
                    height = 10;
                }
            }

            else if (moveRight)
            {
                position = -activityPower * 8;
                cameraMatrix = Matrix.CreateLookAt(
                    new Vector3(0, 20, 20), new Vector3(position, 0, 0), new Vector3(0, 1, 0));
                //if (position <= -8)
                //    position = -8;
            }
            else if (moveLeft)
            {
                position = 8 * activityPower;
                cameraMatrix = Matrix.CreateLookAt(
                    new Vector3(0, 20, 20), new Vector3(position, 0, 0), new Vector3(0, 1, 0));
                if (position >= 8)
                    position = 8;
            }
            else if (rotateAntiClockwise)
            {
                rotateValue = -1 + (activityPower * 2);
                cameraMatrix = Matrix.CreateLookAt(
                    new Vector3(0, 20, 20), new Vector3(0, 0, 0), new Vector3(rotateValue, 1, 0));
                if (rotateValue >= 1)
                {
                    rotateValue = -1f;
                }
            }
            else if (rotateClockwise)
            {
                rotateValue = 1 - (activityPower * 2);
                cameraMatrix = Matrix.CreateLookAt(
                    new Vector3(0, 20, 20), new Vector3(0, 0, 0), new Vector3(rotateValue, 1, 0));
                if (rotateValue <= -1)
                {
                    rotateValue = 1f;
                }
            }
            else if (rotateLeft)
            {
                angleY -= (activityPower*4f);
                angleX += deltaX;
            }
            else if (rotateRight)
            {
                angleY -= DeltaY;
                angleX += (activityPower*4f);
            }





            cubeEffect.View = cameraMatrix;


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            

            base.Update(gameTime);
               
            
        }

        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.White);

            cubeEffect.Begin();

            worldMatrix = Matrix.CreateRotationY(MathHelper.ToRadians(angleY)) *
                Matrix.CreateRotationX(MathHelper.ToRadians(angleX));   // angle
            cubeEffect.World = worldMatrix;

            foreach (EffectPass pass in cubeEffect.CurrentTechnique.Passes)
            {
                pass.Begin();

                cubeEffect.Texture = cube.shapeTexture;

                cube.RenderShape(GraphicsDevice);

                pass.End();
            }

            cubeEffect.End();

            base.Draw(gameTime);
        }
        public void initializeWorld()
        {
           
            cameraMatrix = Matrix.CreateLookAt(
                    new Vector3(0,10, 20), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
               
            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
                Window.ClientBounds.Width / Window.ClientBounds.Height, 1.0f, 50.0f);
            float tilt = MathHelper.ToRadians(22.5f);
            worldMatrix = Matrix.CreateRotationX(tilt) * Matrix.CreateRotationY(tilt);

            cubeEffect = new BasicEffect(GraphicsDevice, null);
            cubeEffect.World = worldMatrix;
            cubeEffect.View = cameraMatrix;
            cubeEffect.Projection = projectionMatrix;
            cubeEffect.TextureEnabled = true;
        }
    }
}
