using System.Collections.Generic;
using System.Linq;

namespace Tetris_OOPGame
{
    internal partial class LineFigure
    {
        private class LineFigureState1 : FigureState
        {
            public LineFigureState1(Figure figure) : base(figure) { }

            public override IEnumerable<Cell> State
            {
                get
                {
                    var first = _figure.Cells.First() ?? new Cell { Color = ColorFigure.lineColor, X = FieldSize.xMin, Y = FieldSize.yMin };
                    if (first.Y == 360 || first.Y == 380 || first.Y == 400)
                    {
                        yield return first;
                        yield return new Cell { Color = ColorFigure.lineColor, X = first.X, Y = first.Y - FieldSize.height };
                        yield return new Cell { Color = ColorFigure.lineColor, X = first.X, Y = first.Y - 2 * FieldSize.height };
                        yield return new Cell { Color = ColorFigure.lineColor, X = first.X, Y = first.Y - 3 * FieldSize.height };
                    }
                    else
                    {
                        yield return first;
                        yield return new Cell { Color = ColorFigure.lineColor, X = first.X, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.lineColor, X = first.X, Y = first.Y + 2 * FieldSize.height };
                        yield return new Cell { Color = ColorFigure.lineColor, X = first.X, Y = first.Y + 3 * FieldSize.height };
                    }
                }
            }

            public override IFigureState TurnFigure()
            {
                return new LineFigureState2(_figure);
            }
        }
    }
}
