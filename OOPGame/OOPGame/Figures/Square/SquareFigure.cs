using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    internal class SquareFigure : Figure
    {
        public SquareFigure(int[,] grid) : base(grid) { }

        protected override IFigureState CreateState()
        {
            return new SquareFigureState(this);
        }

        private class SquareFigureState : FigureState
        {
            public SquareFigureState(Figure figure) :  base(figure) { }

            public override IEnumerable<Cell> State
            {
                get
                {
                    var first = _figure.cell.First() ?? new Cell { Color = ColorFigure.squareColor, X = FieldSize.xMin, Y = FieldSize.yMin };

                    yield return new Cell { Color = ColorFigure.squareColor, X = first.X, Y = first.Y };
                    yield return new Cell { Color = ColorFigure.squareColor, X = first.X + FieldSize.width, Y = first.Y };
                    yield return new Cell { Color = ColorFigure.squareColor, X = first.X, Y = first.Y + FieldSize.height };
                    yield return new Cell { Color = ColorFigure.squareColor, X = first.X + FieldSize.width, Y = first.Y + FieldSize.height };
                }
            }

            public override IFigureState TurnFigure()
            {
                return new SquareFigureState(_figure);
            }
        }
    }
}
