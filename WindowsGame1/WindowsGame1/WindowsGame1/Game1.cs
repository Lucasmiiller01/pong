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
using WindowsGame1.Classes;

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static int ScreenWidth;
        public static int ScreenHeigth;
        const float BALL_START_SPEED = 8f;
        
        const int PADDLE_OFFSET = 70;

        Player player1;
        Player player2;
        Ball ball;
        Input input ;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.Window.Title = "Pong";
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ScreenWidth = GraphicsDevice.Viewport.Width; 
            ScreenHeigth = GraphicsDevice.Viewport.Height;
            
            player1 = new Player();
            player2 = new Player();
            ball = new Ball();
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player1.Texture = Content.Load<Texture2D>("Content/Paddle");
            player2.Texture = Content.Load<Texture2D>("Content/Paddle");

            player1.Position = new Vector2(PADDLE_OFFSET,ScreenHeigth/2 - player1.Texture.Height/2);
            player2.Position = new Vector2(ScreenWidth - player2.Texture.Width - PADDLE_OFFSET, ScreenHeigth / 2 - player2.Texture.Height / 2);
            ball.Texture = Content.Load<Texture2D>("Content/Ball");
            ball.Launch(BALL_START_SPEED);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
          
            ScreenWidth = GraphicsDevice.Viewport.Width;
            ScreenHeigth = GraphicsDevice.Viewport.Height; 
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            ball.Move(ball.Velocity);
            ball.CheckWallCollision();
            player1.Mov(player1, player2);
           // input.Mov(player1, player2);
            ball.CheckPlayerCollision(player1 ,player2);
            //ball.CheckPlayerCollision(player1);

            //player1.Move(player1Velocity);
            //player2.Move(player2Velocity);
            if (ball.Position.X + ball.Texture.Width < 0) {
                ball.Launch(BALL_START_SPEED);

            }
            if (ball.Position.X > ScreenWidth) {
                ball.Launch(BALL_START_SPEED);
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
       
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

         
           
            spriteBatch.Begin();
            player1.Draw(spriteBatch);
            player2.Draw(spriteBatch);
            ball.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
              
        }
    }
}
