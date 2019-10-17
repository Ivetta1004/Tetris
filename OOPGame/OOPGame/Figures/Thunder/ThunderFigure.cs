using System;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    internal partial class ThunderFigure : Figure
    {
        public ThunderFigure(int[,] grid) : base(grid) { }

        protected override IFigureState CreateState()
        {
            return new ThunderFigureState1(this);
        }
    }
}
