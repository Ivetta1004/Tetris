using System.Collections.Generic;
using System.Linq;

namespace Tetris_OOPGame
{
    internal partial class LeftLFigure
    {
        private class LeftLFigureState2 : FigureState
        {
            public LeftLFigureState2(Figure figure) : base(figure) { }

            public override IEnumerable<Cell> State
            {
                get
                {
                    var first = _figure.Cells.First() ?? new Cell { Color = ColorFigure.leftLColor, X = FieldSize.xMin, Y = FieldSize.yMin };

                    if (first.X >= 180)
                    {
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X - 2 * FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X - 2 * FieldSize.width, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X - FieldSize.width, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X, Y = first.Y + FieldSize.height };
                    }
                    if (first.X < 180)
                    {
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X - FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X - FieldSize.width, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X + FieldSize.width, Y = first.Y + FieldSize.height };
                    }
                }
            }

            public override IFigureState TurnFigure()
            {
                return new LeftLFigureState3(_figure);
            }
        }
    }
}


