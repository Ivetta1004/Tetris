using System.Collections.Generic;
using System.Linq;

namespace Tetris_OOPGame
{
    internal partial class RightLFigure
    {
        private class RightLFigureState2 : FigureState
        {
            public RightLFigureState2(Figure figure) : base(figure) { }

            public override IEnumerable<Cell> State
            {
                get
                {
                    var first = _figure.Cells.First() ?? new Cell { Color = ColorFigure.rightLColor, X = FieldSize.xMin, Y = FieldSize.yMin };
                    if (first.X >= 180)
                    {
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X - FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X - FieldSize.width, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X + FieldSize.width, Y = first.Y };
                    }
                    if (first.X < 180)
                    {
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X + FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X + 2 * FieldSize.width, Y = first.Y };
                    }
                }
            }

            public override IFigureState TurnFigure()
            {
                return new RightLFigureState3(_figure);
            }
        }
    }
}
