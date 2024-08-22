using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.CodeDom;
using System.Drawing.Text;

namespace MonoGameTest
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private double rval;
        private double gval;
        private double bval;
        private int colorcount;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            //added this to setup
            _graphics.PreferredBackBufferWidth = 1920;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 1080;   // set this value to the desired height of your window
            _graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            rval = 0;
            gval = 0;
            bval = 0;
            colorcount = 0;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // TODO: Add your update logic here

            //mouse control*******************************************
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                rval += 5;
                if (rval > 255)
                    rval = 0;
            }
            if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                gval += 5;
                if (gval > 255)
                    gval = 0;
            }
            if (Mouse.GetState().MiddleButton == ButtonState.Pressed)
            {
                bval += 5;
                if (bval > 255)
                    bval = 0;
            }
            //**********************************************************
            //Gamepad control.......
            //**********************************************************
            if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
            {
                rval += 5;
                if (rval > 255)
                    rval = 0;
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed)
            {
                gval += 5;
                if (gval > 255)
                    gval = 0;
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed)
            {
                bval += 5;
                if (bval > 255)
                    bval = 0;
            }
            //**************************************************************

            //*****a quck exercise to change the bg colour over time********//
            //*****Link this to delta time exercise*************************//
            //colorcount++;
            //if (colorcount >= 10)
            //{
            //    colorcount = 0;
            //    rval += 1; 
            //    gval += 2;
            //    bval += 3;
            //}
            //if (rval > 255)
            //    rval = 0;
            //if (gval > 255)
            //    gval = 0;
            //if (bval > 255)
            //    bval = 0;


            //here's the delta time code*********************************************
            double deltatime = gameTime.ElapsedGameTime.TotalSeconds;
            
            rval += 5 * deltatime;
            if (rval > 255)
                rval = 0;
            gval += 10 * deltatime;
            if (gval > 255)
                gval = 0;
            bval += 15 * deltatime;
            if (bval > 255)
                bval = 0;

            //************************************************************************

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //over time bg colour change method***********************************
            GraphicsDevice.Clear(Color.FromNonPremultiplied((int)rval,(int)gval,(int)bval,255));

            //Normal bg clear
            //GraphicsDevice.Clear(Color.Aqua);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
