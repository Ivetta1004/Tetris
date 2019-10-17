using System;
using System.Collections.Generic;
using System.Linq;
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

        private class LineFigureState2 : FigureState
        {
            public LineFigureState2(Figure figure) : base(figure) { }

            public override IEnumerable<Cell> State
            {
                get
                {
                    var first = _figure.Cells.First() ?? new Cell { Color = ColorFigure.lineColor, X = FieldSize.xMin, Y = FieldSize.yMin };

                    if (first.X == 160 || first.X == 180 || first.X == 200)
                    {
                        yield return first;
                        yield return new Cell { Color = ColorFigure.lineColor, X = first.X - FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.lineColor, X = first.X - 2 * FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.lineColor, X = first.X - 3 * FieldSize.width, Y = first.Y };
                    }
                    if (first.X < 160)
                    {
                        yield return first;
                        yield return new Cell { Color = ColorFigure.lineColor, X = first.X + FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.lineColor, X = first.X + 2 * FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.lineColor, X = first.X + 3 * FieldSize.width, Y = first.Y };
                    }
                }
            }
            
            public override IFigureState TurnFigure()
            {
                return new LineFigureState1(_figure);
            }
        }
    }
}
