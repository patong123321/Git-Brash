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

        private Texture2D player;
        private Vector2 player_pos;

        private AnimatedTexture SpriteTexture;
        private const float Rotation = 0;
        private const float Scale = 1.0f;
        private const float Depth = 0.5f;
        private KeyboardState _keyboardState;
        bool personHit;
        Vector2 spritePosition = Vector2.Zero;
        private int row = 1;

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
            SpriteTexture = new AnimatedTexture(Vector2.Zero, Rotation, Scale, Depth);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        private Vector2 Xpos = new Vector2(0, 32);
        private const int Frames = 4;
        private const int FramesPerSec = 10;
        private const int FramesRow = 4;
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteTexture.Load(Content, "Char01", Frames, FramesRow, FramesPerSec);
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
            KeyboardState ks = Keyboard.GetState();
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (ks.IsKeyDown(Keys.Left) == true)
            {
                SpriteTexture.UpdateFrame(elapsed);
                player_pos.X -= 5;
                row = 2;
            }
            if (ks.IsKeyDown(Keys.Right) == true)
            {
                SpriteTexture.UpdateFrame(elapsed);
                player_pos.X += 5;
                row = 3;
            }
            if (ks.IsKeyDown(Keys.Up) == true)
            {
                SpriteTexture.UpdateFrame(elapsed);
                player_pos.Y -= 5;
                row = 4;
            }

            if (ks.IsKeyDown(Keys.Down) == true)
            {
                SpriteTexture.UpdateFrame(elapsed);
                player_pos.Y += 5;
                row = 1;
            }
            personHit = false;

            // TODO: Add your update logic here

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
            SpriteTexture.DrawFrame(_spriteBatch, player_pos, row);

            for (int i = 0; i < 4; i++)
            {
                _spriteBatch.Draw(ballTexture, ballPosition[i], new Rectangle(24 * ballColor[i], 0, 24, 24), Color.White);
            }
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
            /*sawarddee krub*/
        }
    }
}
