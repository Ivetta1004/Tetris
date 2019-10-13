using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NConsoleGraphics;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    internal class LeftLFigureState1 : IFigureState
    {
        private const uint leftLColor = 0xFF8000FF;
        private Cell[] _cell;

        public LeftLFigureState1() { }

        public LeftLFigureState1(Cell[] cell)
        {
            _cell = cell;
        }

        public IEnumerable<Cell> State
        {
            get
            {
                if (_cell[0].X == 160 || _cell[0].X == 180)
                {
                    yield return _cell[0] = new Cell { Color = leftLColor, X = _cell[0].X - FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[1] = new Cell { Color = leftLColor, X = _cell[0].X, Y = _cell[0].Y + FieldSize.height };
                    yield return _cell[2] = new Cell { Color = leftLColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y + FieldSize.height };
                    yield return _cell[3] = new Cell { Color = leftLColor, X = _cell[0].X + 2 * FieldSize.width, Y = _cell[0].Y + FieldSize.height };
                }
                if (_cell[0].X < 180)
                {
                    yield return _cell[0] = new Cell { Color = leftLColor, X = _cell[0].X, Y = _cell[0].Y };
                    yield return _cell[1] = new Cell { Color = leftLColor, X = _cell[0].X, Y = _cell[0].Y + FieldSize.height };
                    yield return _cell[2] = new Cell { Color = leftLColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y + FieldSize.height };
                    yield return _cell[3] = new Cell { Color = leftLColor, X = _cell[0].X + 2 * FieldSize.width, Y = _cell[0].Y + FieldSize.height };
                }
            }
        }

        public IFigureState TurnFigure(Figure figure, Cell[] cell)
        {
            _cell = cell;
            _cell = State.ToArray();
            figure.GetState = new LeftLFigureState2(cell);
            return figure.GetState;
        }
    }

    internal class LeftLFigureState2 : IFigureState
    {
        private const uint leftLColor = 0xFF8000FF;
        private Cell[] _cell;

        public LeftLFigureState2(Cell[] cell) { _cell = cell; }

        public IEnumerable<Cell> State
        {
            get
            {
                if (_cell[0].X == 160 || _cell[0].X == 180)
                {
                    yield return _cell[0] = new Cell { Color = leftLColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[1] = new Cell { Color = leftLColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[2] = new Cell { Color = leftLColor, X = _cell[0].X, Y = _cell[0].Y + FieldSize.height };
                    yield return _cell[3] = new Cell { Color = leftLColor, X = _cell[0].X, Y = _cell[0].Y + 2 * FieldSize.height };
                }
                if (_cell[0].X < 180)
                {
                    yield return _cell[0] = new Cell { Color = leftLColor, X = _cell[0].X, Y = _cell[0].Y };
                    yield return _cell[1] = new Cell { Color = leftLColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[2] = new Cell { Color = leftLColor, X = _cell[0].X, Y = _cell[0].Y + FieldSize.height };
                    yield return _cell[3] = new Cell { Color = leftLColor, X = _cell[0].X, Y = _cell[0].Y + 2 * FieldSize.height };
                }
            }
        }

        public IFigureState TurnFigure(Figure figure, Cell[] cell)
        {
            _cell = State.ToArray();
            figure.GetState = new LeftLFigureState3(cell);
            return figure.GetState;
        }
    }

    internal class LeftLFigureState3 : IFigureState
    {
        private const uint leftLColor = 0xFF8000FF;
        private Cell[] _cell;

        public LeftLFigureState3(Cell[] cell) { _cell = cell; }

        public IEnumerable<Cell> State
        {
            get
            {
                if (_cell[0].X == 180)
                {
                    yield return _cell[0] = new Cell { Color = leftLColor, X = _cell[0].X - FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[1] = new Cell { Color = leftLColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[2] = new Cell { Color = leftLColor, X = _cell[0].X + 2 * FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[3] = new Cell { Color = leftLColor, X = _cell[0].X + 2 * FieldSize.width, Y = _cell[0].Y + FieldSize.height };

                }
                if (_cell[0].X < 180)
                {
                    yield return _cell[0] = new Cell { Color = leftLColor, X = _cell[0].X, Y = _cell[0].Y };
                    yield return _cell[1] = new Cell { Color = leftLColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[2] = new Cell { Color = leftLColor, X = _cell[0].X + 2 * FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[3] = new Cell { Color = leftLColor, X = _cell[0].X + 2 * FieldSize.width, Y = _cell[0].Y + FieldSize.height };
                }
            }
        }

        public IFigureState TurnFigure(Figure figure, Cell[] cell)
        {
            _cell = State.ToArray();
            figure.GetState = new LeftLFigureState4(cell);
            return figure.GetState;
        }
    }

    internal class LeftLFigureState4 : IFigureState
    {
        private const uint leftLColor = 0xFF8000FF;
        private Cell[] _cell;

        public LeftLFigureState4(Cell[] cell) { _cell = cell; }

        public IEnumerable<Cell> State
        {
            get
            {
                if (_cell[0].X == 160)
                {
                    yield return _cell[0] = new Cell { Color = leftLColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y + 2 * FieldSize.height };
                    yield return _cell[1] = new Cell { Color = leftLColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[2] = new Cell { Color = leftLColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y - FieldSize.height };
                    yield return _cell[3] = new Cell { Color = leftLColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y - 2 * FieldSize.height };
                }
                if (_cell[0].X < 160)
                {
                    yield return _cell[0] = new Cell { Color = leftLColor, X = _cell[0].X, Y = _cell[0].Y + 2 * FieldSize.height };
                    yield return _cell[1] = new Cell { Color = leftLColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[2] = new Cell { Color = leftLColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y - FieldSize.height };
                    yield return _cell[3] = new Cell { Color = leftLColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y - 2 * FieldSize.height };
                }
            }
        }

        public IFigureState TurnFigure(Figure figure, Cell[] cell)
        {
            _cell = State.ToArray();
            figure.GetState = new LeftLFigureState1(cell);
            return figure.GetState;
        }
    }

    internal class LeftLFigure : Figure, IFigureState
    {
        private const uint leftLColor = 0xFF8000FF;

        public LeftLFigure() { }

        public LeftLFigure(int[,] grid, IFigureState state) : base(grid, state)
        {
            for (int i = 0; i < cell.Length; i++)
            {
                cell[i] = new Cell { Color = leftLColor, X = FieldSize.xMin, Y = FieldSize.yMin };
            }
            DoFigure();
        }

        public IEnumerable<Cell> State { get; }

        protected override Cell[] DoFigure()
        {
            cell[0] = new Cell { Color = leftLColor, X = cell[0].X, Y = cell[0].Y + 2 * FieldSize.height };
            cell[1] = new Cell { Color = leftLColor, X = cell[0].X + FieldSize.width, Y = cell[0].Y };
            cell[2] = new Cell { Color = leftLColor, X = cell[0].X + FieldSize.width, Y = cell[0].Y - FieldSize.height };
            cell[3] = new Cell { Color = leftLColor, X = cell[0].X + FieldSize.width, Y = cell[0].Y - 2 * FieldSize.height };
            return cell;
        }

        public IFigureState TurnFigure(Figure figure, Cell[] cell)
        {
            return new LeftLFigureState1().TurnFigure(figure, cell);
        }
    }
}


