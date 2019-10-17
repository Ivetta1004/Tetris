using System;
using System.Text;
using NConsoleGraphics;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    internal partial class LineFigure : Figure
    {
        public LineFigure(int[,] grid) : base(grid) { }

        protected override IFigureState CreateState()
        {
            return new LineFigureState1(this);
        }
    }
}
