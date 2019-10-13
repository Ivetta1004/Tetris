using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NConsoleGraphics;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    internal class RightLFigureState1 : IFigureState
    {
        private const uint rightLColor = 0xFF8080FF;
        private Cell[] _cell;

        public RightLFigureState1() { }

        public RightLFigureState1(Cell[] cell)
        {
            _cell = cell;
        }

        public IEnumerable<Cell> State
        {
            get
            {
                if (_cell[0].X == 180)
                {
                    yield return _cell[0] = new Cell { Color = rightLColor, X = _cell[0].X - FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[1] = new Cell { Color = rightLColor, X = _cell[0].X, Y = _cell[0].Y + FieldSize.height };
                    yield return _cell[2] = new Cell { Color = rightLColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[3] = new Cell { Color = rightLColor, X = _cell[0].X + 2 * FieldSize.width, Y = _cell[0].Y };
                }
                if (_cell[0].X < 180)
                {
                    _cell[0] = new Cell { Color = rightLColor, X = _cell[0].X, Y = _cell[0].Y };
                    _cell[1] = new Cell { Color = rightLColor, X = _cell[0].X, Y = _cell[0].Y + FieldSize.height };
                    _cell[2] = new Cell { Color = rightLColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y };
                    _cell[3] = new Cell { Color = rightLColor, X = _cell[0].X + 2 * FieldSize.width, Y = _cell[0].Y };
                }
            }

        }

        public IFigureState TurnFigure(Figure figure, Cell[] cell)
        {
            _cell = cell;
            _cell = State.ToArray();
            figure.GetState = new RightLFigureState2(cell);
            return figure.GetState;
        }
    }

    internal class RightLFigureState2 : IFigureState
    {
        private const uint rightLColor = 0xFF8080FF;
        private Cell[] _cell;

        public RightLFigureState2(Cell[] cell) { _cell = cell; }

        public IEnumerable<Cell> State
        {
            get
            {
                if (_cell[0].X == 160)
                {
                    yield return _cell[0] = new Cell { Color = rightLColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[1] = new Cell { Color = rightLColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[2] = new Cell { Color = rightLColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y + FieldSize.height };
                    yield return _cell[3] = new Cell { Color = rightLColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y + 2 * FieldSize.height };
                }
                if (_cell[0].X < 160)
                {
                    yield return _cell[0] = new Cell { Color = rightLColor, X = _cell[0].X, Y = _cell[0].Y };
                    yield return _cell[1] = new Cell { Color = rightLColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[2] = new Cell { Color = rightLColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y + FieldSize.height };
                    yield return _cell[3] = new Cell { Color = rightLColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y + 2 * FieldSize.height };
                }
            }
        }

        public IFigureState TurnFigure(Figure figure, Cell[] cell)
        {
            _cell = State.ToArray();
            figure.GetState = new RightLFigureState3(cell);
            return figure.GetState;
        }
    }

    internal class RightLFigureState3 : IFigureState
    {
        private const uint rightLColor = 0xFF8080FF;
        private Cell[] _cell;

        public RightLFigureState3(Cell[] cell) { _cell = cell; }

        public IEnumerable<Cell> State
        {
            get
            {
                if (_cell[0].X == 180)
                {
                    yield return _cell[0] = new Cell { Color = rightLColor, X = _cell[0].X - FieldSize.width, Y = _cell[0].Y + FieldSize.height };
                    yield return _cell[1] = new Cell { Color = rightLColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[2] = new Cell { Color = rightLColor, X = _cell[0].X + 2 * FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[3] = new Cell { Color = rightLColor, X = _cell[0].X + 2 * FieldSize.width, Y = _cell[0].Y - FieldSize.height };
                }
                if (_cell[0].X < 180)
                {
                    yield return _cell[0] = new Cell { Color = rightLColor, X = _cell[0].X, Y = _cell[0].Y + FieldSize.height };
                    yield return _cell[1] = new Cell { Color = rightLColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[2] = new Cell { Color = rightLColor, X = _cell[0].X + 2 * FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[3] = new Cell { Color = rightLColor, X = _cell[0].X + 2 * FieldSize.width, Y = _cell[0].Y - FieldSize.height };
                }
            }
        }

        public IFigureState TurnFigure(Figure figure, Cell[] cell)
        {
            _cell = State.ToArray();
            figure.GetState = new RightLFigureState4(cell);
            return figure.GetState;
        }
    }

    internal class RightLFigureState4 : IFigureState
    {
        private const uint rightLColor = 0xFF8080FF;
        private Cell[] _cell;

        public RightLFigureState4(Cell[] cell) { _cell = cell; }

        public IEnumerable<Cell> State
        {
            get
            {
                if (_cell[0].X == 160)
                {
                    yield return _cell[0] = new Cell { Color = rightLColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[1] = new Cell { Color = rightLColor, X = _cell[0].X, Y = _cell[0].Y + FieldSize.height };
                    yield return _cell[2] = new Cell { Color = rightLColor, X = _cell[0].X, Y = _cell[0].Y + 2 * FieldSize.height };
                    yield return _cell[3] = new Cell { Color = rightLColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y + 2 * FieldSize.height };
                }
                if (_cell[0].X < 160)
                {
                    yield return _cell[0] = new Cell { Color = rightLColor, X = _cell[0].X, Y = _cell[0].Y };
                    yield return _cell[1] = new Cell { Color = rightLColor, X = _cell[0].X, Y = _cell[0].Y + FieldSize.height };
                    yield return _cell[2] = new Cell { Color = rightLColor, X = _cell[0].X, Y = _cell[0].Y + 2 * FieldSize.height };
                    yield return _cell[3] = new Cell { Color = rightLColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y + 2 * FieldSize.height };
                }
            }
        }

        public IFigureState TurnFigure(Figure figure, Cell[] cell)
        {
            _cell = State.ToArray();
            figure.GetState = new RightLFigureState1(cell);
            return figure.GetState;
        }
    }

    internal class RightLFigure : Figure, IFigureState
    {
        private const uint rightLColor = 0xFF8080FF;

        public RightLFigure() { }

        public RightLFigure(int[,] grid, IFigureState state) : base(grid, state)
        {
            for (int i = 0; i < cell.Length; i++)
            {
                cell[i] = new Cell { Color = rightLColor, X = FieldSize.xMin, Y = FieldSize.yMin };
            }
            DoFigure();
        }

        public IEnumerable<Cell> State { get; }

        public IFigureState TurnFigure(Figure figure, Cell[] cell)
        {
            return new RightLFigureState1().TurnFigure(figure, cell);
        }

        protected override Cell[] DoFigure()
        {
            cell[0] = new Cell { Color = rightLColor, X = cell[0].X, Y = cell[0].Y };
            cell[1] = new Cell { Color = rightLColor, X = cell[0].X, Y = cell[0].Y + FieldSize.height };
            cell[2] = new Cell { Color = rightLColor, X = cell[0].X, Y = cell[0].Y + 2 * FieldSize.height };
            cell[3] = new Cell { Color = rightLColor, X = cell[0].X + FieldSize.width, Y = cell[0].Y + 2 * FieldSize.height };
            return cell;
        }
    }
}
