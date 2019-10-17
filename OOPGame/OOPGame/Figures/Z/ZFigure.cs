using System;
using System.Collections.Generic;
using NConsoleGraphics;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    internal partial class ZFigure : Figure
    {
        public ZFigure(int[,] grid) : base(grid) { }

        public IEnumerable<Cell> State { get; }

        protected override IFigureState CreateState()
        {
            return new ZFigureState1(this);
        }
    }
}
