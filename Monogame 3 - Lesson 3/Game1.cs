using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

 

namespace Monogame_3___Lesson_3
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        Texture2D tribbleBrownTexture, tribbleOrangeTexture, tribbleGreyTexture, tribbleCreamTexture;
        Rectangle browntribblerect, orangetribblerect, greytribblerect, creamtribblerect;
        Vector2 brownTribbleSpeed, orangeTribbleSpeed, greyTribbleSpeed, creamTribbleSpeed;
        Rectangle window;
        SoundEffect tribbleCoo;

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
            browntribblerect = new Rectangle(300, 10, 100, 100);
            brownTribbleSpeed = new Vector2(4, 2);
            orangetribblerect = new Rectangle(300, 10, 100, 100);
            orangeTribbleSpeed = new Vector2(2, 0);
            greytribblerect = new Rectangle(300, 10, 100, 100);
            greyTribbleSpeed = new Vector2(0, 2);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            tribbleCoo = Content.Load<SoundEffect>("tribble_coo");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            browntribblerect.X += (int)brownTribbleSpeed.X;
            if (browntribblerect.Right > window.Width || browntribblerect.Left <= 0)
            {
                brownTribbleSpeed.X *= -1;
                tribbleCoo.Play();
            }


            browntribblerect.Y += (int)brownTribbleSpeed.Y;
            if (browntribblerect.Bottom > window.Height || browntribblerect.Top <= 0)
            {
                brownTribbleSpeed.Y *= -1;
            }

            orangetribblerect.X += (int)orangeTribbleSpeed.X;
            if (orangetribblerect.Right > window.Width || orangetribblerect.Left <= 0)
            {
                orangeTribbleSpeed.X *= -1;
            }

            greytribblerect.Y += (int)greyTribbleSpeed.Y;
            if (greytribblerect.Bottom > window.Height || greytribblerect.Top <= 0)
            {
                greyTribbleSpeed.Y *= -1;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(tribbleBrownTexture, browntribblerect, Color.White);
            _spriteBatch.Draw(tribbleOrangeTexture, orangetribblerect, Color.White);
            _spriteBatch.Draw(tribbleGreyTexture, greytribblerect, Color.White);

            _spriteBatch.End();
            
            
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
