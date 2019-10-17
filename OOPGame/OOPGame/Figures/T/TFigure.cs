using System;
using System.Text;
using NConsoleGraphics;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    internal partial class TFigure : Figure
    {
        public TFigure(int[,] grid) : base(grid) { }

        protected override IFigureState CreateState()
        {
            return new TFigureState1(this);
        }
    }
}
