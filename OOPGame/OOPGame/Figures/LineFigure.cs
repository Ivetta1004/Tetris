using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NConsoleGraphics;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    internal class LineFigureState1 : IFigureState
    {
        private const uint lineColor = 0xFF3380FF;
        private Cell[] _cell;

        public LineFigureState1() { }

        public LineFigureState1(Cell[] cell)
        {
            _cell = cell;
        }

        public IEnumerable<Cell> State
        {
            get
            {
                if (_cell[0].X == 160 || _cell[0].X == 180 || _cell[0].X == 200)
                {
                    yield return _cell[0] = new Cell { Color = lineColor, X = _cell[0].X, Y = _cell[0].Y };
                    yield return _cell[1] = new Cell { Color = lineColor, X = _cell[0].X - FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[2] = new Cell { Color = lineColor, X = _cell[0].X - 2 * FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[3] = new Cell { Color = lineColor, X = _cell[0].X - 3 * FieldSize.width, Y = _cell[0].Y };
                }
                if (_cell[0].X < 160)
                {
                    yield return _cell[0] = new Cell { Color = lineColor, X = _cell[0].X, Y = _cell[0].Y };
                    yield return _cell[1] = new Cell { Color = lineColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[2] = new Cell { Color = lineColor, X = _cell[0].X + 2 * FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[3] = new Cell { Color = lineColor, X = _cell[0].X + 3 * FieldSize.width, Y = _cell[0].Y };
                }
            }
        }

        public IFigureState TurnFigure(Figure figure, Cell[] cell)
        {
            _cell = cell;
            _cell = State.ToArray();
            figure.GetState = new LineFigureState2(cell);
            return figure.GetState;
        }
    }

    internal class LineFigureState2 : IFigureState
    {
        private const uint lineColor = 0xFF3380FF;
        private Cell[] _cell;

        public LineFigureState2(Cell[] cell)
        {
            _cell = cell;
        }

        public IEnumerable<Cell> State
        {
            get
            {
                if (_cell[0].Y == 360 || _cell[0].Y == 380 || _cell[0].Y == 400)
                {
                    yield return _cell[0] = new Cell { Color = lineColor, X = _cell[0].X, Y = _cell[0].Y };
                    yield return _cell[1] = new Cell { Color = lineColor, X = _cell[0].X, Y = _cell[0].Y - FieldSize.height };
                    yield return _cell[2] = new Cell { Color = lineColor, X = _cell[0].X, Y = _cell[0].Y - 2 * FieldSize.height };
                    yield return _cell[3] = new Cell { Color = lineColor, X = _cell[0].X, Y = _cell[0].Y - 3 * FieldSize.height };
                }
                else
                {
                    yield return _cell[0] = new Cell { Color = lineColor, X = _cell[0].X, Y = _cell[0].Y };
                    yield return _cell[1] = new Cell { Color = lineColor, X = _cell[0].X, Y = _cell[0].Y + FieldSize.height };
                    yield return _cell[2] = new Cell { Color = lineColor, X = _cell[0].X, Y = _cell[0].Y + 2 * FieldSize.height };
                    yield return _cell[3] = new Cell { Color = lineColor, X = _cell[0].X, Y = _cell[0].Y + 3 * FieldSize.height };
                }
            }
        }

        public IFigureState TurnFigure(Figure figure, Cell[] cell)
        {
            _cell = State.ToArray();
            figure.GetState = new LineFigureState1(cell);
            return figure.GetState;
        }
    }

    internal class LineFigure : Figure, IFigureState
    {
        private const uint lineColor = 0xFF3380FF;

        public LineFigure() { }

        public LineFigure(int[,] grid, IFigureState state) : base(grid, state)
        {
            for (int i = 0; i < cell.Length; i++)
            {
                cell[i] = new Cell { Color = lineColor, X = FieldSize.xMin, Y = FieldSize.yMin };
            }
            DoFigure();
        }

        public IEnumerable<Cell> State { get; }

        public void TurnFigure()
        {
            cell[0] = new Cell { Color = lineColor, X = cell[0].X, Y = cell[0].Y };
            cell[1] = new Cell { Color = lineColor, X = cell[0].X - FieldSize.width, Y = cell[0].Y };
            cell[2] = new Cell { Color = lineColor, X = cell[0].X - 2 * FieldSize.width, Y = cell[0].Y };
            cell[3] = new Cell { Color = lineColor, X = cell[0].X - 3 * FieldSize.width, Y = cell[0].Y };
        }

        public IFigureState TurnFigure(Figure figure, Cell[] cell)
        {
            return new LineFigureState1().TurnFigure(figure, cell);
        }

        protected override Cell[] DoFigure()
        {
            cell[0] = new Cell { Color = lineColor, X = cell[0].X, Y = cell[0].Y };
            cell[1] = new Cell { Color = lineColor, X = cell[0].X, Y = cell[0].Y + FieldSize.height };
            cell[2] = new Cell { Color = lineColor, X = cell[0].X, Y = cell[0].Y + 2 * FieldSize.height };
            cell[3] = new Cell { Color = lineColor, X = cell[0].X, Y = cell[0].Y + 3 * FieldSize.height };
            return cell;
        }
    }
}
