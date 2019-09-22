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
        public TetrisGameEngine(ConsoleGraphics graphics) : base(graphics)
        {
            AddObject(new Player(graphics));
        }
    }
}
