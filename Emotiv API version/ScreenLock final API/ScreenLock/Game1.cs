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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
       public static int countNumber = 0;

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

        public Game1()
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
            countNumber++;
            // Allows the game to exit
            //int count = 5;
            if(animateDepth && !moveForward)
            {
                
                depth = depth + 0.15f;
                cameraMatrix = Matrix.CreateLookAt(
                    new Vector3(0, depth, 20), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
                deltaX = -0.15f;
                if (depth >= 45)
                {
                    depth = 45;
                    deltaX = 0f;
                }
                
                
            }
            else if (animateDepth && moveForward)
            {
                
                depth = depth - 0.15f;
                cameraMatrix = Matrix.CreateLookAt(
                    new Vector3(0, depth, 20), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
               //// deltaX = 20f;
                if (depth <= 10)
                {
                    deltaX = 0f;
                    depth = 10f;
                }
            }

            else if (liftCube)
            {
                height = height - 0.1f;
                cameraMatrix = Matrix.CreateLookAt(
                    new Vector3(0, 20, 20), new Vector3(0, height, 0), new Vector3(0, 1, 0));
                if (height <= -20)
                {
                    height = -20;
                }
            }
            else if (dropCube)
            {
                height = height + 0.05f;
                cameraMatrix = Matrix.CreateLookAt(
                    new Vector3(0, 20, 20), new Vector3(0, height, 0), new Vector3(0, 1, 0));
                if (height >= 10)
                {
                    height = 10;
                }
            }

            else if (moveRight)
            {
                position -= 0.05f;
                cameraMatrix = Matrix.CreateLookAt(
                    new Vector3(0, 20, 20), new Vector3(position, 0, 0), new Vector3(0, 1, 0));
                if (position <= -8)
                    position = -8;
            }
            else if (moveLeft)
            {
                position += 0.05f;
                cameraMatrix = Matrix.CreateLookAt(
                    new Vector3(0, 20, 20), new Vector3(position, 0, 0), new Vector3(0, 1, 0));
                if (position >= 8)
                    position = 8;
            }
            else if (rotateAntiClockwise)
            {
                rotateValue += 0.005f;
                cameraMatrix = Matrix.CreateLookAt(
                    new Vector3(0, 20, 20), new Vector3(0, 0, 0), new Vector3(rotateValue, 1, 0));
                if (rotateValue >= 1)
                {
                    rotateValue = -1f;
                }
            }
            else if (rotateClockwise)
            {
                rotateValue -= 0.005f;
                cameraMatrix = Matrix.CreateLookAt(
                    new Vector3(0, 20, 20), new Vector3(0, 0, 0), new Vector3(rotateValue, 1, 0));
                if (rotateValue <= -1)
                {
                    rotateValue = 1f;
                }
            }
            

                cubeEffect.View = cameraMatrix;
            
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            angleY -= DeltaY;
            angleX += deltaX;

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
