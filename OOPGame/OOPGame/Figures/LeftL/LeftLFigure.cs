using System;
using System.Text;
using NConsoleGraphics;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    internal partial class LeftLFigure : Figure
    {
        public LeftLFigure(int[,] grid) : base(grid) { }

        protected override IFigureState CreateState()
        {
            return new LeftLFigureState1(this);
        }
    }
}


