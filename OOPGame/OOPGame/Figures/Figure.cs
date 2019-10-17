using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace Tetris_OOPGame
{
    public abstract class Figure : IMovable
    {
        private const int _speed = 3;
        private const int size = 4;
        private int[,] _grid;
        private int _step;
        private IFigureState _state;
        private Cell[] _cells = new Cell[size];
        public bool IsRun { get; private set; }

        public Figure(int[,] grid)
        {
            _step = 1;
            IsRun = true;
            _grid = grid;
            _state = CreateState();
            _cells = _state.State.ToArray();
        }

        public IEnumerable<Cell> Cells => _cells;

        protected abstract IFigureState CreateState();

        public void Render(ConsoleGraphics graphics)
        {
            for (int i = 0; i < _cells.Length; i++)
            {
                graphics.FillRectangle(_cells[i].Color, _cells[i].X, _cells[i].Y, FieldSize.width, FieldSize.height);
            }
        }

        public void Update(GameEngine engine)
        {
            if (Input.IsKeyDown(Keys.LEFT))
            {
                if (CanMove(Keys.LEFT))
                {
                    for (int i = 0; i < _cells.Length; i++)
                    {
                        _cells[i].X -= FieldSize.width;
                    }
                }
            }
            else if (Input.IsKeyDown(Keys.RIGHT))
            {
                if (CanMove(Keys.RIGHT))
                {
                    for (int i = 0; i < _cells.Length; i++)
                    {
                        _cells[i].X += FieldSize.width;
                    }
                }
            }
            else if (Input.IsKeyDown(Keys.DOWN))
            {
                if (CanMove(Keys.DOWN))
                {
                    for (int i = 0; i < _cells.Length; i++)
                    {
                        _cells[i].Y += FieldSize.height;
                    }
                }
            }
            if (Input.IsKeyDown(Keys.SPACE))
            {
                if (CanMove(Keys.SPACE))
                {
                    _state = _state.TurnFigure();
                    _cells = _state.State.ToArray();
                }
            }
            if (_step % _speed == 0)
            {
                if (CanMove(Keys.DOWN))
                {
                    for (int i = 0; i < _cells.Length; i++)
                    {
                        _cells[i].Y += FieldSize.height;
                    }
                }
                else
                {
                    IsRun = false;
                    for (int i = 0; i < _cells.Length; i++)
                    {
                        int gridX = (_cells[i].X - FieldSize.xMin) / FieldSize.width;
                        int gridY = (_cells[i].Y - FieldSize.yMin) / FieldSize.height;
                        _grid[gridX, gridY] = 1;
                    }
                }
            }
            _step++;
        }

        protected bool CanMove(Keys key)
        {
            for (int i = 0; i < _cells.Length; i++)
            {
                int gridX = (_cells[i].X - FieldSize.xMin) / FieldSize.width;
                int gridY = (_cells[i].Y - FieldSize.yMin) / FieldSize.height;
                if (key == Keys.LEFT)
                {
                    if (gridX <= 0 || _grid[gridX - 1, gridY] == 1)
                    {
                        return false;
                    }
                }
                if (key == Keys.RIGHT)
                {
                    if (gridX + 1 >= _grid.GetLength(0) || _grid[gridX + 1, gridY] == 1)
                    {
                        return false;
                    }
                }
                if (key == Keys.DOWN)
                {
                    if (gridY + 1 >= _grid.GetLength(1) || _grid[gridX, gridY + 1] == 1)
                    {
                        return false;
                    }
                }
                if (key == Keys.SPACE)
                {
                    if (gridX == _grid.GetLength(0) || gridY + 1 >= _grid.GetLength(1)
                        || _grid[gridX, gridY + 1] == 1)
                        return false;
                }
            }
            return true;
        }
    }
}

