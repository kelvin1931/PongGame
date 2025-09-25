using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace PongGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _playerOne;
        private Texture2D _playerTwo;
        private Texture2D _pongBall;
        private int p1xpos;
        private int p1ypos;
        private int p2xpos;
        private int p2ypos;
        private int pongxpos;
        private int pongypos;
        private int pongspeed;
        private int y1speed;
        private int y2speed;

        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferHeight = 800;
            _graphics.PreferredBackBufferWidth = 600;
            IsMouseVisible = true;

            p1xpos = 100;
            p1ypos = _graphics.PreferredBackBufferHeight / 2;

            p2xpos = 700;
            p2ypos = _graphics.PreferredBackBufferHeight / 2;

            pongxpos = _graphics.PreferredBackBufferWidth / 2;
            pongypos = _graphics.PreferredBackBufferHeight / 2;

            p1Wsize
            p1Lsize 
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _playerOne = Content.Load<Texture2D>("RedRec (2)");
            _playerTwo = Content.Load<Texture2D>("BlueRec (2)");
            _pongBall = Content.Load<Texture2D>("PongBall (2)");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if (p1xpos > 40)
                {
                    y1speed -= 5;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if (p1xpos > 693)
                {
                    y1speed += 5;
                }
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.GhostWhite);

            // TODO: Add your drawing code here
            // pong ball roughyl 25 by 25
            base.Draw(gameTime);
            _spriteBatch.Begin();

            _spriteBatch.Draw(new Rectangle(p1xpos, p1ypos, p1size, _playerOne.Width,playerOne.Height));

            _spriteBatch.End();
        }
    }
}
