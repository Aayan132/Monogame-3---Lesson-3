using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;



namespace Monogame_3___Lesson_3
{

    enum Screen
    {
        Intro,
        Main,
        End
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        Texture2D tribbleBrownTexture, tribbleOrangeTexture, tribbleGreyTexture, tribbleCreamTexture;
        Rectangle browntribblerect, orangetribblerect, greytribblerect, creamtribblerect;
        Vector2 brownTribbleSpeed, orangeTribbleSpeed, greyTribbleSpeed, creamTribbleSpeed;
        Rectangle window;
        SoundEffect tribbleCoo;
        SpriteFont text;
        Double timer = 20.0;
        Random rand = new Random();

        Screen currentScreen;

        MouseState mouseState;

        public Game1()
        {


            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();
            browntribblerect = new Rectangle(rand.Next(0, window.Width - 100), rand.Next(0, window.Height - 100), 100, 100); ;
            brownTribbleSpeed = new Vector2(4, 2);
            orangetribblerect = new Rectangle(rand.Next(0, window.Width - 100), rand.Next(0, window.Height - 100), 100, 100); ;
            orangeTribbleSpeed = new Vector2(2, 0);
            greytribblerect = new Rectangle(rand.Next(0, window.Width - 100), rand.Next(0, window.Height - 100), 100, 100); ;
            greyTribbleSpeed = new Vector2(0, 2);
            currentScreen = Screen.Intro;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            tribbleCoo = Content.Load<SoundEffect>("tribble_coo");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            text = Content.Load<SpriteFont>("Title");


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (currentScreen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    currentScreen = Screen.Main;
                    timer = 20.0;
                }
            }
            else if (currentScreen == Screen.Main)
            {
                // TODO: Add your update logic 

                if (timer <= 0)
                {
                    currentScreen = Screen.End;
                }

                browntribblerect.X += (int)brownTribbleSpeed.X;
                if (browntribblerect.Right > window.Width || browntribblerect.Left <= 0)
                {
                    browntribblerect.X = rand.Next(0, window.Width - browntribblerect.Width);
                    brownTribbleSpeed.X += rand.Next(-1, 3);
                    tribbleCoo.Play();
                }



                browntribblerect.Y += (int)brownTribbleSpeed.Y;
                if (browntribblerect.Bottom > window.Height || browntribblerect.Top <= 0)
                {
                    browntribblerect.Y = rand.Next(0, window.Height - browntribblerect.Height);
                    brownTribbleSpeed.Y += rand.Next(-1, 3);
                }


                greytribblerect.Y += (int)greyTribbleSpeed.Y;
                if (greytribblerect.Bottom > window.Height || greytribblerect.Top <= 0)
                {
                    greyTribbleSpeed.Y *= -1;
                }

                orangetribblerect.X += (int)orangeTribbleSpeed.X;

                if (orangetribblerect.Left > window.Width)
                {
                    orangetribblerect.X = -orangetribblerect.Width;
                }
                else if (orangetribblerect.Right < 0)
                {
                    orangetribblerect.X = window.Width;
                }
            } 


                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();


            if (currentScreen == Screen.Intro)
            {
                _spriteBatch.DrawString(text, "Press Right Click to Proceed", new Vector2(100, 100), Color.White);
            }
            else if (currentScreen == Screen.Main)
            {
                _spriteBatch.Draw(tribbleBrownTexture, browntribblerect, Color.White);
                _spriteBatch.Draw(tribbleOrangeTexture, orangetribblerect, Color.White);
                _spriteBatch.Draw(tribbleGreyTexture, greytribblerect, Color.White);
            }



            _spriteBatch.End();
            
            
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
