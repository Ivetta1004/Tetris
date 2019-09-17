using NConsoleGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    public class SampleGameEngine : GameEngine
    {
        public SampleGameEngine(ConsoleGraphics graphics) : base(graphics)
        {
            AddObject(new SamplePlayer(graphics));
        }
    }
}
