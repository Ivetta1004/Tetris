using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NConsoleGraphics;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    internal class TFigureState1 : IFigureState
    {
        private const uint tColor = 0xFF33E6FF;
        private Cell[] _cell;

        public TFigureState1() { }

        public TFigureState1(Cell[] cell)
        {
            _cell = cell;
        }

        public IEnumerable<Cell> State
        {
            get
            {
                if (_cell[0].X == 160)
                {
                    yield return _cell[0] = new Cell { Color = tColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[1] = new Cell { Color = tColor, X = _cell[0].X, Y = _cell[0].Y + FieldSize.height };
                    yield return _cell[2] = new Cell { Color = tColor, X = _cell[0].X, Y = _cell[0].Y + 2 * FieldSize.height };
                    yield return _cell[3] = new Cell { Color = tColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y + FieldSize.height };
                }
                if (_cell[0].X < 180)
                {
                    yield return _cell[0] = new Cell { Color = tColor, X = _cell[0].X, Y = _cell[0].Y };
                    yield return _cell[1] = new Cell { Color = tColor, X = _cell[0].X, Y = _cell[0].Y + FieldSize.height };
                    yield return _cell[2] = new Cell { Color = tColor, X = _cell[0].X, Y = _cell[0].Y + 2 * FieldSize.height };
                    yield return _cell[3] = new Cell { Color = tColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y + FieldSize.height };
                }
            }
        }

        public IFigureState TurnFigure(Figure figure, Cell[] cell)
        {
            _cell = cell;
            _cell = State.ToArray();
            figure.GetState = new TFigureState2(cell);
            return figure.GetState;
        }
    }

    internal class TFigureState2 : IFigureState
    {
        private const uint tColor = 0xFF33E6FF;
        private Cell[] _cell;

        public TFigureState2(Cell[] cell)
        {
            _cell = cell;
        }

        public IEnumerable<Cell> State
        {
            get
            {
                if (_cell[0].X == 180)
                {
                    yield return _cell[0] = new Cell { Color = tColor, X = _cell[0].X - FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[1] = new Cell { Color = tColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y - FieldSize.height };
                    yield return _cell[2] = new Cell { Color = tColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[3] = new Cell { Color = tColor, X = _cell[0].X + 2 * FieldSize.width, Y = _cell[0].Y };
                }
                if (_cell[0].X < 180)
                {
                    yield return _cell[0] = new Cell { Color = tColor, X = _cell[0].X, Y = _cell[0].Y };
                    yield return _cell[1] = new Cell { Color = tColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y - FieldSize.height };
                    yield return _cell[2] = new Cell { Color = tColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[3] = new Cell { Color = tColor, X = _cell[0].X + 2 * FieldSize.width, Y = _cell[0].Y };
                }
            }
        }

        public IFigureState TurnFigure(Figure figure, Cell[] cell)
        {
            _cell = State.ToArray();
            figure.GetState = new TFigureState3(cell);
            return figure.GetState;
        }
    }

    internal class TFigureState3 : IFigureState
    {
        private const uint tColor = 0xFF33E6FF;
        private Cell[] _cell;

        public TFigureState3(Cell[] cell)
        {
            _cell = cell;
        }

        public IEnumerable<Cell> State
        {
            get
            {
                if (_cell[0].X == 160)
                {
                    yield return _cell[0] = new Cell { Color = tColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[1] = new Cell { Color = tColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y - FieldSize.height };
                    yield return _cell[2] = new Cell { Color = tColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[3] = new Cell { Color = tColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y + FieldSize.height };
                }
                if (_cell[0].X < 160)
                {
                    yield return _cell[0] = new Cell { Color = tColor, X = _cell[0].X, Y = _cell[0].Y };
                    yield return _cell[1] = new Cell { Color = tColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y - FieldSize.height };
                    yield return _cell[2] = new Cell { Color = tColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[3] = new Cell { Color = tColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y + FieldSize.height };
                }
            }
        }

        public IFigureState TurnFigure(Figure figure, Cell[] cell)
        {
            _cell = State.ToArray();
            figure.GetState = new TFigureState4(cell);
            return figure.GetState;
        }
    }

    internal class TFigureState4 : IFigureState
    {
        private const uint tColor = 0xFF33E6FF;
        private Cell[] _cell;

        public TFigureState4(Cell[] cell)
        {
            _cell = cell;
        }

        public IEnumerable<Cell> State
        {
            get
            {
                if (_cell[0].X == 180)
                {
                    yield return _cell[0] = new Cell { Color = tColor, X = _cell[0].X - FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[1] = new Cell { Color = tColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[2] = new Cell { Color = tColor, X = _cell[0].X + 2 * FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[3] = new Cell { Color = tColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y + FieldSize.height };
                }
                if (_cell[0].X < 180)
                {
                    yield return _cell[0] = new Cell { Color = tColor, X = _cell[0].X, Y = _cell[0].Y };
                    yield return _cell[1] = new Cell { Color = tColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[2] = new Cell { Color = tColor, X = _cell[0].X + 2 * FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[3] = new Cell { Color = tColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y + FieldSize.height };
                }
            }
        }

        public IFigureState TurnFigure(Figure figure, Cell[] cell)
        {
            _cell = State.ToArray();
            figure.GetState = new TFigureState1(cell);
            return figure.GetState;
        }
    }

    internal class TFigure : Figure, IFigureState
    {
        private const uint tColor = 0xFF33E6FF;

        public TFigure() { }

        public TFigure(int[,] grid, IFigureState state) : base(grid, state)
        {
            for (int i = 0; i < cell.Length; i++)
            {
                cell[i] = new Cell { Color = tColor, X = FieldSize.xMin, Y = FieldSize.yMin };
            }
            DoFigure();
        }

        public IEnumerable<Cell> State { get; }

        public IFigureState TurnFigure(Figure figure, Cell[] cell)
        {
            return new TFigureState1().TurnFigure(figure, cell);
        }

        protected override Cell[] DoFigure()
        {
            cell[0] = new Cell { Color = tColor, X = cell[0].X, Y = cell[0].Y };
            cell[1] = new Cell { Color = tColor, X = cell[0].X + FieldSize.width, Y = cell[0].Y };
            cell[2] = new Cell { Color = tColor, X = cell[0].X + 2 * FieldSize.width, Y = cell[0].Y };
            cell[3] = new Cell { Color = tColor, X = cell[0].X + FieldSize.width, Y = cell[0].Y + FieldSize.height };
            return cell;
        }
    }
}
