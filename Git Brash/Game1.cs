using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Git_Brash
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D ballTexture;
        Texture2D charTexture;
        Vector2 charPosition = new Vector2(0, 250);
        Vector2[] ballPosition = new Vector2[4];
        int[] ballColor = new int[4];
        Random rand = new Random();
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            charTexture = Content.Load<Texture2D>("Char01");
            ballTexture = Content.Load<Texture2D>("ball");


            for (int i = 0; i < 4; i++)
            {
                ballPosition[i].X = rand.Next(_graphics.GraphicsDevice.Viewport.Width - ballTexture.Width / 6);
                ballPosition[i].Y = rand.Next(_graphics.GraphicsDevice.Viewport.Height - ballTexture.Height);
                ballColor[i] = rand.Next(6);
            }

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            for (int i = 0; i < 4; i++)
            {
                ballPosition[i].X = rand.Next(_graphics.GraphicsDevice.Viewport.Width - ballTexture.Width / 6);
                ballPosition[i].Y = rand.Next(_graphics.GraphicsDevice.Viewport.Height - ballTexture.Height);
                ballColor[i] = rand.Next(6);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(charTexture, charPosition, new Rectangle(32, 48, 32, 48), Color.White);
            for (int i = 0; i < 4; i++)
            {
                _spriteBatch.Draw(ballTexture, ballPosition[i], new Rectangle(24 * ballColor[i], 0, 24, 24), Color.White);
            }
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
