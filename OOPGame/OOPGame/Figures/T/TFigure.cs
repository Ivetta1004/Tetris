using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NConsoleGraphics;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    internal class TFigure : Figure
    {
        public TFigure(int[,] grid) : base(grid) { }

        protected override IFigureState CreateState()
        {
            return new TFigureState1(this);
        }

        private class TFigureState1 : FigureState
        {
            public TFigureState1(Figure figure) : base(figure) { }

            public override IEnumerable<Cell> State
            {
                get
                {
                    var first = _figure.cell.First() ?? new Cell { Color = ColorFigure.tColor, X = FieldSize.xMin, Y = FieldSize.yMin };

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

        private class TFigureState2 : FigureState
        {
            public TFigureState2(Figure figure) : base(figure) { }

            public override IEnumerable<Cell> State
            {
                get
                {
                    var first = _figure.cell.First() ?? new Cell { Color = ColorFigure.tColor, X = FieldSize.xMin, Y = FieldSize.yMin };

                    if (first.X >= 160)
                    {
                        yield return new Cell { Color = ColorFigure.tColor, X = first.X + FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.tColor, X = first.X + FieldSize.width, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.tColor, X = first.X + FieldSize.width, Y = first.Y + 2 * FieldSize.height };
                        yield return new Cell { Color = ColorFigure.tColor, X = first.X + 2 * FieldSize.width, Y = first.Y + FieldSize.height };
                    }
                    if (first.X < 160)
                    {
                        yield return first;
                        yield return new Cell { Color = ColorFigure.tColor, X = first.X, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.tColor, X = first.X, Y = first.Y + 2 * FieldSize.height };
                        yield return new Cell { Color = ColorFigure.tColor, X = first.X + FieldSize.width, Y = first.Y + FieldSize.height };
                    }
                }
            }

            public override IFigureState TurnFigure()
            {
                return new TFigureState3(_figure);
            }
        }

        private class TFigureState3 : FigureState
        {
            public TFigureState3(Figure figure) : base(figure) { }

            public override IEnumerable<Cell> State
            {
                get
                {
                    var first = _figure.cell.First() ?? new Cell { Color = ColorFigure.tColor, X = FieldSize.xMin, Y = FieldSize.yMin };

                    if (first.X >= 180)
                    {
                        yield return first;
                        yield return new Cell { Color = ColorFigure.tColor, X = first.X - FieldSize.width, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.tColor, X = first.X, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.tColor, X = first.X + FieldSize.width, Y = first.Y + FieldSize.height };
                    }
                    if (first.X < 180)
                    {
                        yield return first;
                        yield return new Cell { Color = ColorFigure.tColor, X = first.X + FieldSize.width, Y = first.Y - FieldSize.height };
                        yield return new Cell { Color = ColorFigure.tColor, X = first.X + FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.tColor, X = first.X + 2 * FieldSize.width, Y = first.Y };
                    }
                }
            }

            public override IFigureState TurnFigure()
            {
                return new TFigureState4(_figure);
            }
        }

        private class TFigureState4 : FigureState
        {
            public TFigureState4(Figure figure) : base(figure) { }

            public override IEnumerable<Cell> State
            {
                get
                {
                    var first = _figure.cell.First() ?? new Cell { Color = ColorFigure.tColor, X = FieldSize.xMin, Y = FieldSize.yMin };

                    if (first.X >= 160)
                    {
                        yield return new Cell { Color = ColorFigure.tColor, X = first.X + FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.tColor, X = first.X + FieldSize.width, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.tColor, X = first.X, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.tColor, X = first.X + FieldSize.width, Y = first.Y + 2 * FieldSize.height };
                    }
                    if (first.X < 160)
                    {
                        yield return first;
                        yield return new Cell { Color = ColorFigure.tColor, X = first.X + FieldSize.width, Y = first.Y - FieldSize.height };
                        yield return new Cell { Color = ColorFigure.tColor, X = first.X + FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.tColor, X = first.X + FieldSize.width, Y = first.Y + FieldSize.height };
                    }
                }
            }

            public override IFigureState TurnFigure()
            {
                return new TFigureState1(_figure);
            }
        }
    }
}
