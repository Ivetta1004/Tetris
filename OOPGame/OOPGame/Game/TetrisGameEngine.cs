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
        public TetrisGameEngine() { }

        public TetrisGameEngine(ConsoleGraphics graphics) : base(graphics)
        {
            player = new Player(graphics);
            AddObject(player);
        }
    }
}
