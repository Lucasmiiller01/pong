using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace WindowsGame1.Classes
{
    class Player : GameObject
    {
        public void Mov(Player player1, Player player2)
        {

            KeyboardState keyboardsState = Keyboard.GetState();

            if ((keyboardsState.IsKeyDown(Keys.W) ))
            {
                player1.Position.Y -= 5;
            }
            else if ((keyboardsState.IsKeyDown(Keys.S))) player1.Position.Y += 5;
            if ((keyboardsState.IsKeyDown(Keys.Up)))
            {
                player2.Position.Y -= 5;
            }
            else if ((keyboardsState.IsKeyDown(Keys.Down))) player2.Position.Y += 5;

        }
    }
}
