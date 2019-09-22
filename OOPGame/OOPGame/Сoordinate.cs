using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    internal class Coordinate
    {
        internal int x { get; set; }
        internal int y { get; set; }
        internal int width = 20;
        internal int height = 20;
        internal int xMin = 20;
        internal int yMin = 20;
        internal int xMax = 220;
        internal int yMax = 420;
        internal int numberCellHeigh = 20;
        internal int numberCellWidth = 10;
    }
}
