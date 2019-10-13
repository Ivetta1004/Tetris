using NConsoleGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    public class TetrisGameEngine : GameEngine
    {
        public TetrisGameEngine(ConsoleGraphics graphics, GameScore score) : base(graphics, score)
        {
            AddObject(new Player(graphics, score));
            AddObject(score);
        }
    }
}
