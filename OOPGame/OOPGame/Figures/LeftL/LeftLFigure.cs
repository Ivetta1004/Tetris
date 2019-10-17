using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NConsoleGraphics;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    internal class LeftLFigure : Figure
    {
        public LeftLFigure(int[,] grid) : base(grid) { }

        protected override IFigureState CreateState()
        {
            return new LeftLFigureState1(this);
        }

        private class LeftLFigureState1 : FigureState
        {
            public LeftLFigureState1(Figure figure) : base(figure) { }

            public override IEnumerable<Cell> State
            {
                get
                {
                    var first = _figure.cell.First() ?? new Cell { Color = ColorFigure.leftLColor, X = FieldSize.xMin, Y = FieldSize.yMin };

                    if (first.X >= 160)
                    {
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X + 2 * FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X + 2 * FieldSize.width, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X + 2 * FieldSize.width, Y = first.Y + 2 * FieldSize.height };
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X + FieldSize.width, Y = first.Y + 2 * FieldSize.height };
                    }
                    if (first.X < 160)
                    {
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X + FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X + FieldSize.width, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X + FieldSize.width, Y = first.Y + 2 * FieldSize.height };
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X, Y = first.Y + 2 * FieldSize.height };
                    }
                }
            }

            public override IFigureState TurnFigure()
            {
                return new LeftLFigureState2(_figure);
            }
        }

        private class LeftLFigureState2 : FigureState
        {
            public LeftLFigureState2(Figure figure) : base(figure) { }

            public override IEnumerable<Cell> State
            {
                get
                {
                    var first = _figure.cell.First() ?? new Cell { Color = ColorFigure.leftLColor, X = FieldSize.xMin, Y = FieldSize.yMin };

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

        private class LeftLFigureState3 : FigureState
        {
            public LeftLFigureState3(Figure figure) : base(figure) { }

            public override IEnumerable<Cell> State
            {
                get
                {
                    var first = _figure.cell.First() ?? new Cell { Color = ColorFigure.leftLColor, X = FieldSize.xMin, Y = FieldSize.yMin };

                    if (first.X >= 160)
                    {
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X + 2 * FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X + FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X + FieldSize.width, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X + FieldSize.width, Y = first.Y + 2 * FieldSize.height };
                    }
                    if (first.X < 160)
                    {
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X + FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X, Y = first.Y + 2 * FieldSize.height };
                    }
                }
            }

            public override IFigureState TurnFigure()
            {
                return new LeftLFigureState4(_figure);
            }
        }

        private class LeftLFigureState4 : FigureState
        {
            public LeftLFigureState4(Figure figure) : base(figure) { }

            public override IEnumerable<Cell> State
            {
                get
                {
                    var first = _figure.cell.First() ?? new Cell { Color = ColorFigure.lineColor, X = FieldSize.xMin, Y = FieldSize.yMin };

                    if (first.X >= 160)
                    {
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X - 2* FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X - FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X, Y = first.Y + FieldSize.height };

                    }
                    if (first.X < 160)
                    {
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X + FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X + 2 * FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.leftLColor, X = first.X + 2 * FieldSize.width, Y = first.Y + FieldSize.height };
                    }
                }
            }

            public override IFigureState TurnFigure()
            {
                return new LeftLFigureState1(_figure);
            }
        }
    }
}


