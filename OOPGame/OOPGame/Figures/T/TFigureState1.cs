﻿using System.Collections.Generic;
using System.Linq;

namespace Tetris_OOPGame
{
    internal partial class TFigure
    {
        private class TFigureState1 : FigureState
        {
            public TFigureState1(Figure figure) : base(figure) { }

            public override IEnumerable<Cell> State
            {
                get
                {
                    var first = _figure.Cells.First() ?? new Cell { Color = ColorFigure.tColor, X = FieldSize.xMin, Y = FieldSize.yMin };

                    if (first.X >= 180)
                    {
                        yield return new Cell { Color = ColorFigure.tColor, X = first.X - 2 * FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.tColor, X = first.X - FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.tColor, X = first.X, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.tColor, X = first.X - FieldSize.width, Y = first.Y + FieldSize.height };
                    }
                    if (first.X < 180)
                    {
                        yield return first;
                        yield return new Cell { Color = ColorFigure.tColor, X = first.X + FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.tColor, X = first.X + 2 * FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.tColor, X = first.X + FieldSize.width, Y = first.Y + FieldSize.height };
                    }
                }
            }

            public override IFigureState TurnFigure()
            {
                return new TFigureState2(_figure);
            }
        }
    }
}
