using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    internal class ThunderFigure : Figure
    {
        public ThunderFigure(int[,] grid) : base(grid) { }

        protected override IFigureState CreateState()
        {
            return new ThunderFigureState1(this);
        }

        private class ThunderFigureState1 : FigureState
        {
            public ThunderFigureState1(Figure figure) : base(figure) { }

            public override IEnumerable<Cell> State
            {
                get
                {
                    var first = _figure.cell.First() ?? new Cell { Color = ColorFigure.thunderColor, X = FieldSize.xMin, Y = FieldSize.yMin };

                    if (first.X >= 160)
                    {
                        yield return new Cell { Color = ColorFigure.thunderColor, X = first.X + FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.thunderColor, X = first.X + FieldSize.width, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.thunderColor, X = first.X + 2 * FieldSize.width, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.thunderColor, X = first.X + 2 * FieldSize.width, Y = first.Y + 2 * FieldSize.height };
                    }
                    if (first.X < 160)
                    {
                        yield return new Cell { Color = ColorFigure.thunderColor, X = first.X, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.thunderColor, X = first.X, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.thunderColor, X = first.X + FieldSize.width, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.thunderColor, X = first.X + FieldSize.width, Y = first.Y + 2 * FieldSize.height };
                    }
                }
            }

            public override IFigureState TurnFigure()
            {
                return new ThunderFigureState2(_figure);
            }
        }

        private class ThunderFigureState2 : FigureState
        {
            public ThunderFigureState2(Figure figure) : base(figure) { }

            public override IEnumerable<Cell> State
            {
                get
                {
                    var first = _figure.cell.First() ?? new Cell { Color = ColorFigure.thunderColor, X = FieldSize.xMin, Y = FieldSize.yMin };

                    if (first.X >= 180)
                    {
                        yield return new Cell { Color = ColorFigure.thunderColor, X = first.X - FieldSize.width, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.thunderColor, X = first.X, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.thunderColor, X = first.X, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.thunderColor, X = first.X + FieldSize.width, Y = first.Y };
                    }
                    if (first.X < 180)
                    {
                        yield return new Cell { Color = ColorFigure.thunderColor, X = first.X, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.thunderColor, X = first.X + FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.thunderColor, X = first.X + FieldSize.width, Y = first.Y - FieldSize.height };
                        yield return new Cell { Color = ColorFigure.thunderColor, X = first.X + 2 * FieldSize.width, Y = first.Y - FieldSize.height };
                    }
                }
            }

            public override IFigureState TurnFigure()
            {
                return new ThunderFigureState1(_figure);
            }
        }
    }
}
