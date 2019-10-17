using System;
using System.Collections.Generic;
using System.Linq;
using NConsoleGraphics;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    internal class ZFigure : Figure
    {
        public ZFigure(int[,] grid) : base(grid) { }

        public IEnumerable<Cell> State { get; }

        protected override IFigureState CreateState()
        {
            return new ZFigureState1(this);
        }

        private class ZFigureState1 : FigureState
        {
            public ZFigureState1(Figure figure) : base(figure) { }

            public override IEnumerable<Cell> State
            {
                get
                {
                    var first = _figure.cell.First() ?? new Cell { Color = ColorFigure.zColor, X = FieldSize.xMin, Y = FieldSize.yMin };

                    if (first.X >= 180)
                    {
                        yield return new Cell { Color = ColorFigure.zColor, X = first.X - 2 * FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.zColor, X = first.X - FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.zColor, X = first.X - FieldSize.width, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.zColor, X = first.X, Y = first.Y + FieldSize.height };
                    }
                    if (first.X < 180)
                    {
                        yield return new Cell { Color = ColorFigure.zColor, X = first.X, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.zColor, X = first.X + FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.zColor, X = first.X + FieldSize.width, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.zColor, X = first.X + 2 * FieldSize.width, Y = first.Y + FieldSize.height };
                    }
                }
            }

            public override IFigureState TurnFigure()
            {
                return new ZFigureState2(_figure);
            }
        }

        private class ZFigureState2 : FigureState
        {
            public ZFigureState2(Figure figure) : base(figure) { }

            public override IEnumerable<Cell> State
            {
                get
                {
                    var first = _figure.cell.First() ?? new Cell { Color = ColorFigure.zColor, X = FieldSize.xMin, Y = FieldSize.yMin };
                    if (first.X >= 160)
                    {
                        yield return new Cell { Color = ColorFigure.zColor, X = first.X + 2 * FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.zColor, X = first.X + 2 * FieldSize.width, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.zColor, X = first.X + FieldSize.width, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.zColor, X = first.X + FieldSize.width, Y = first.Y + 2 * FieldSize.height };
                    }
                    if (first.X < 160)
                    {
                        yield return new Cell { Color = ColorFigure.zColor, X = first.X, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.zColor, X = first.X, Y = first.Y + FieldSize.height };
                        yield return new Cell { Color = ColorFigure.zColor, X = first.X + FieldSize.width, Y = first.Y };
                        yield return new Cell { Color = ColorFigure.zColor, X = first.X + FieldSize.width, Y = first.Y - FieldSize.height };
                    }
                }
            }

            public override IFigureState TurnFigure()
            {
                return new ZFigureState1(_figure);
            }
        }
    }
}
