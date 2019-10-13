using System;
using System.Collections.Generic;
using System.Linq;
using NConsoleGraphics;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    internal class ZFigureState1 : IFigureState
    {
        private const uint zColor = 0xFFFFFF00;
        private Cell[] _cell;

        public ZFigureState1() { }

        public ZFigureState1(Cell[] cell)
        {
            _cell = cell;
        }

        public IEnumerable<Cell> State
        {
            get
            {
                if (_cell[0].X == 160)
                {
                    yield return _cell[0] = new Cell { Color = zColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[1] = new Cell { Color = zColor, X = _cell[0].X, Y = _cell[0].Y + FieldSize.height };
                    yield return _cell[2] = new Cell { Color = zColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[3] = new Cell { Color = zColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y - FieldSize.height };
                }
                if (_cell[0].X < 160)
                {
                    yield return _cell[0] = new Cell { Color = zColor, X = _cell[0].X, Y = _cell[0].Y };
                    yield return _cell[1] = new Cell { Color = zColor, X = _cell[0].X, Y = _cell[0].Y + FieldSize.height };
                    yield return _cell[2] = new Cell { Color = zColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[3] = new Cell { Color = zColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y - FieldSize.height };
                }
            }
        }

        public IFigureState TurnFigure(Figure figure, Cell[] cell)
        {
            _cell = cell;
            _cell = State.ToArray();
            figure.GetState = new ZFigureState2(cell);
            return figure.GetState;
        }
    }

    internal class ZFigureState2 : IFigureState
    {
        private const uint zColor = 0xFFFFFF00;
        private Cell[] _cell;

        public ZFigureState2(Cell[] cell)
        {
            _cell = cell;
        }

        public IEnumerable<Cell> State
        {
            get
            {
                if (_cell[0].X == 180)
                {
                    yield return _cell[0] = new Cell { Color = zColor, X = _cell[0].X - FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[1] = new Cell { Color = zColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[2] = new Cell { Color = zColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y + FieldSize.height };
                    yield return _cell[3] = new Cell { Color = zColor, X = _cell[0].X + 2 * FieldSize.width, Y = _cell[0].Y + FieldSize.height };
                }
                if (_cell[0].X < 180)
                {
                    yield return _cell[0] = new Cell { Color = zColor, X = _cell[0].X, Y = _cell[0].Y };
                    yield return _cell[1] = new Cell { Color = zColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y };
                    yield return _cell[2] = new Cell { Color = zColor, X = _cell[0].X + FieldSize.width, Y = _cell[0].Y + FieldSize.height };
                    yield return _cell[3] = new Cell { Color = zColor, X = _cell[0].X + 2 * FieldSize.width, Y = _cell[0].Y + FieldSize.height };
                }
            }
        }

        public IFigureState TurnFigure(Figure figure, Cell[] cell)
        {
            _cell = State.ToArray();
            figure.GetState = new ZFigureState1(cell);
            return figure.GetState;
        }
    }

    internal class ZFigure : Figure, IFigureState
    {
        private const uint zColor = 0xFFFFFF00;

        public ZFigure() { }

        public ZFigure(int[,] grid, IFigureState state) : base(grid, state)
        {
            for (int i = 0; i < cell.Length; i++)
            {
                cell[i] = new Cell { Color = zColor, X = FieldSize.xMin, Y = FieldSize.yMin };
            }
            DoFigure();
        }

        public IEnumerable<Cell> State { get; }

        public IFigureState TurnFigure(Figure figure, Cell[] cell)
        {
            return new ZFigureState1().TurnFigure(figure, cell);
        }

        protected override Cell[] DoFigure()
        {
            cell[0] = new Cell { Color = zColor, X = cell[0].X, Y = cell[0].Y };
            cell[1] = new Cell { Color = zColor, X = cell[0].X + FieldSize.width, Y = cell[0].Y };
            cell[2] = new Cell { Color = zColor, X = cell[0].X + FieldSize.width, Y = cell[0].Y + FieldSize.height };
            cell[3] = new Cell { Color = zColor, X = cell[0].X + 2 * FieldSize.width, Y = cell[0].Y + FieldSize.height };
            return cell;
        }
    }
}
