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
        private int y1speed;
        private int y2speed;
        private int pongXpos;
        private int pongYpos;
        private int pongxSpeed;
        private int pongySpeed;
        private Rectangle Play1, Play2, Pong;
        private float playerOneScore = 0;
        private float playerTwoScore = 0;
        private SpriteFont _font;
        private Vector2 scorepos = new Vector2 (910, 20);
        private int addOne = 0;
        private int subOne = 0;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.PreferredBackBufferWidth = 1920;
            IsMouseVisible = true;

            
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            pongxSpeed = 8;
            pongySpeed = 8;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _playerOne = Content.Load<Texture2D>("RedRec (2)");
            _playerTwo = Content.Load<Texture2D>("BlueRec (2)");
            _pongBall = Content.Load<Texture2D>("PongBall (2)");

            _font = Content.Load<SpriteFont>("Spritefont");
            
            p1xpos = 0;
            p1ypos = (_graphics.PreferredBackBufferHeight / 2) - (_playerOne.Height / 2);

            p2xpos = _graphics.PreferredBackBufferWidth - 50;
            p2ypos = (_graphics.PreferredBackBufferHeight / 2) - (_playerTwo.Height / 2);

            pongXpos = _graphics.PreferredBackBufferWidth / 2;
            pongYpos = _graphics.PreferredBackBufferHeight / 2;
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if (p1ypos > 0)
                {
                    p1ypos -= 15;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if (p1ypos + _playerOne.Height < _graphics.PreferredBackBufferHeight)
                {
                    p1ypos += 15;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if (p2ypos > 0)
                    p2ypos -= 15;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if (p2ypos + _playerTwo.Height < _graphics.PreferredBackBufferHeight)
                    p2ypos += 15;
            }



            pongXpos += pongxSpeed;
            pongYpos += pongySpeed;
            
             Play1 = new Rectangle(p1xpos, p1ypos, _playerOne.Width, _playerOne.Height);
             Play2 = new Rectangle(p2xpos, p2ypos, _playerTwo.Width, _playerTwo.Height);
             Pong = new Rectangle(pongXpos, pongYpos, _pongBall.Width, _pongBall.Height);
           
            if (pongYpos <= 0 || pongYpos + _pongBall.Height >= _graphics.PreferredBackBufferHeight)
            {
                pongySpeed = -pongySpeed;
            }
            if (Pong.Intersects(Play1))
            {
                addOne = addOne + 1;
                pongxSpeed = pongxSpeed + addOne;
            }
            if (Pong.Intersects(Play2))
            {
               subOne = subOne + 1;
                pongxSpeed = -pongxSpeed - subOne;
            }
            if(pongXpos < 0 )
            {
                playerTwoScore += 1;
                pongXpos = _graphics.PreferredBackBufferWidth / 2;
                pongYpos = _graphics.PreferredBackBufferHeight / 2;
                pongxSpeed = 0;
                pongxSpeed -= 5;
            }
            if (pongXpos + _pongBall.Width > 1920)
            {
                playerOneScore += 1;
                pongXpos = _graphics.PreferredBackBufferWidth / 2;
                pongYpos = _graphics.PreferredBackBufferHeight / 2;
                pongxSpeed = 0;
                pongxSpeed += 5;
            }
            if (playerOneScore == 10)
            {
                playerOneScore = (playerOneScore - 10);
                playerTwoScore = 0;

            }
            if (playerTwoScore == 10)
            {
                playerTwoScore = (playerTwoScore - 10);
                playerOneScore = 0;

            }



            // TODO: Add your update logic here

            base.Update(gameTime);
        }
        

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            // pong ball roughyl 25 by 25
            base.Draw(gameTime);
            _spriteBatch.Begin();

            _spriteBatch.Draw(_playerOne, Play1 , Color.Red);
            _spriteBatch.Draw(_playerTwo,Play2 , Color.Blue);
            _spriteBatch.Draw(_pongBall, Pong , Color.White);
            _spriteBatch.DrawString(_font, $"Score: {playerOneScore} : {playerTwoScore}",scorepos, Color.WhiteSmoke);

            _spriteBatch.End();
        }
    }
}
