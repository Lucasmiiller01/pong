using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace WindowsGame1.Classes 
{
    class Ball : GameObject
    {
        public Vector2 Velocity;
        public Random random;
        
        public Ball() {
            
            random = new Random();
        }
        public void CheckPlayerCollision(Player player, Player player2) {
            if ((Position.X < player.Position.X + player.Texture.Width) && (Position.Y > player.Position.Y) && (Position.Y < player.Position.Y + player.Texture.Height))
            {
                
                Velocity.X *= -1;
              
            }
            else if ((Position.X > player2.Position.X - player2.Texture.Width) && (Position.Y > player2.Position.Y) && (Position.Y < player2.Position.Y + player2.Texture.Height))
            {

                Velocity.X *= -1;

            }

            
        }
        public void CheckWallCollision() {
            if (Position.Y < 0)
            {
                Position.Y = 0;
                Velocity.Y *= -1;
            }
            if (Position.Y + Texture.Height > Game1.ScreenHeigth)
            {
                Position.Y = Game1.ScreenHeigth - Texture.Height;
                Velocity.Y *= -1;
            }
            
        } 
        public void Launch(float speed) { 
            Position = new Vector2(Game1.ScreenWidth / 2 - Texture.Width/2,Game1.ScreenHeigth /2 -Texture.Height /2);
            float rotation = (float) ( Math.PI/2 + (random.NextDouble() * (Math.PI/1.5f) - Math.PI/3));
            Velocity.X = (float)Math.Sin(rotation);
            Velocity.Y = (float)Math.Cos(rotation);
            if (random.Next(2) == 1) {
                Velocity.X *= -1;
            }
            Velocity *= speed;
        }
    }
}
