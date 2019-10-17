using System;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    internal partial class SquareFigure : Figure
    {
        public SquareFigure(int[,] grid) : base(grid) { }

        protected override IFigureState CreateState()
        {
            return new SquareFigureState(this);
        }
    }
}
