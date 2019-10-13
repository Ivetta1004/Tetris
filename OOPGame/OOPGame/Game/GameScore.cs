using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NConsoleGraphics;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    public class GameScore : IGameObject
    {
        public int Score { get; set; }
        internal bool GameIsOn { get; set; } = true;

        public void Render(ConsoleGraphics graphics)
        {
            graphics.DrawString("Score: ", "Arial", 0xFF000000, 250, 250);
            graphics.DrawString(Score.ToString(), "Arial", 0xFF00FF00, 320, 250);
        }

        public void Update(GameEngine engine) { }
    }
}
