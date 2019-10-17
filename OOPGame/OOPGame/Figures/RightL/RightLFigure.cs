using System;
using System.Text;
using NConsoleGraphics;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    internal partial class RightLFigure : Figure
    {
        public RightLFigure(int[,] grid) : base(grid) { }

        protected override IFigureState CreateState()
        {
            return new RightLFigureState1(this);
        }
    }
}
