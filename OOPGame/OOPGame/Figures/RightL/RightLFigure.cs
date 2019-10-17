using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NConsoleGraphics;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    internal class RightLFigure : Figure
    {
        public RightLFigure(int[,] grid) : base(grid) { }

        protected override IFigureState CreateState()
        {
            return new RightLFigureState1(this);
        }

        private class RightLFigureState1 : FigureState
        {
            public RightLFigureState1(Figure figure) : base(figure) { }

            public override IEnumerable<Cell> State
            {
                get
                {
                    var first = _figure.cell.First() ?? new Cell { Color = ColorFigure.rightLColor, X = FieldSize.xMin, Y = FieldSize.yMin };

                    if (first.X >= 160)
                    {
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X - FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X - FieldSize.width, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X - FieldSize.width, Y = first.Y + 2 * FieldSize.height };
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X, Y = first.Y + 2 * FieldSize.height };
                    }
                    if (first.X < 160)
                    {
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X, Y = first.Y + 2 * FieldSize.height };
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X + FieldSize.width, Y = first.Y + 2 * FieldSize.height };
                    }
                }
            }

            public override IFigureState TurnFigure()
            {
                return new RightLFigureState2(_figure);
            }
        }

        private class RightLFigureState2 : FigureState
        {
            public RightLFigureState2(Figure figure) : base(figure) { }

            public override IEnumerable<Cell> State
            {
                get
                {
                    var first = _figure.cell.First() ?? new Cell { Color = ColorFigure.rightLColor, X = FieldSize.xMin, Y = FieldSize.yMin };
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

        private class RightLFigureState3 : FigureState
        {
            public RightLFigureState3(Figure figure) : base(figure) { }

            public override IEnumerable<Cell> State
            {
                get
                {
                    var first = _figure.cell.First() ?? new Cell { Color = ColorFigure.rightLColor, X = FieldSize.xMin, Y = FieldSize.yMin };
                    if (first.X >= 160)
                    {
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X + FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X + 2 * FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X + 2 * FieldSize.width, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X + 2 * FieldSize.width, Y = first.Y + 2 * FieldSize.height };
                    }
                    if (first.X < 160)
                    {
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X + FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X + FieldSize.width, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X + FieldSize.width, Y = first.Y + 2 * FieldSize.height };
                    }
                }
            }

            public override IFigureState TurnFigure()
            {
                return new RightLFigureState4(_figure);
            }
        }

        private class RightLFigureState4 : FigureState
        {
            public RightLFigureState4(Figure figure) : base(figure) { }

            public override IEnumerable<Cell> State
            {
                get
                {
                    var first = _figure.cell.First() ?? new Cell { Color = ColorFigure.rightLColor, X = FieldSize.xMin, Y = FieldSize.yMin };
                    if (first.X >= 180)
                    {
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X + FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X + FieldSize.width, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X - FieldSize.width, Y = first.Y + FieldSize.height };
                    }
                    if (first.X < 180)
                    {
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X + FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X + 2 * FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.rightLColor, X = first.X + 2 * FieldSize.width, Y = first.Y - FieldSize.height };
                    }
                }
            }

            public override IFigureState TurnFigure()
            {
                return new RightLFigureState1(_figure);
            }
        }
    }
}
