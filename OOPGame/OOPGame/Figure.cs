using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace Tetris_OOPGame
{
    internal class Figure : IGameObject
    {
        protected Coordinate coord = new Coordinate();
        protected int _speed;
        protected int[,] _grid;
        private const int size = 4;
        protected Cell[] cell = new Cell[size];
        private int _step;
        protected int option;

        public Figure(int x, int y, int width, int height, int speed, ref int[,] grid)
        {
            coord.x = x;
            coord.y = y;
            coord.width = width;
            coord.height = height;
            _speed = speed;
            _step = 1;
            IsRun = true;
            cell = FillCell();
            cell = DoFigure();
            _grid = grid;
            option = 0;
        }
        public bool IsRun { get; set; }
        private Cell[] FillCell()
        {
            for (int i = 0; i < cell.Length; i++)
            {
                cell[i] = new Cell { Color = 0xFFFF0000, X = coord.x, Y = coord.y };
            }
            return cell;
        }
        protected virtual Cell[] DoFigure()
        {
            return null;
        }
        public void Render(ConsoleGraphics graphics)
        {
            for (int i = 0; i < cell.Length; i++)
            {
                graphics.FillRectangle(cell[i].Color, cell[i].X, cell[i].Y, coord.width, coord.height);
            }
        }
        public void Update(GameEngine engine)
        {
            if (Input.IsKeyDown(Keys.LEFT))
            {
                if (CanMove(Keys.LEFT))
                {
                    for (int i = 0; i < cell.Length; i++)
                    {
                        cell[i].X -= coord.width;
                    }
                }
            }
            else if (Input.IsKeyDown(Keys.RIGHT))
            {
                if (CanMove(Keys.RIGHT))
                {
                    for (int i = 0; i < cell.Length; i++)
                    {
                        cell[i].X += coord.width;
                    }
                }
            }
            else if (Input.IsKeyDown(Keys.DOWN))
            {
                if (CanMove(Keys.DOWN))
                {
                    for (int i = 0; i < cell.Length; i++)
                    {
                        cell[i].Y += coord.height;
                    }
                }
            }
            if (Input.IsKeyDown(Keys.SPACE))
            {
                if (CanMove(Keys.SPACE))
                {
                    TurnFigure(cell);
                }
            }
            if (_step % _speed == 0)
            {
                if (CanMove(Keys.DOWN))
                {
                    for (int i = 0; i < cell.Length; i++)
                    {
                        cell[i].Y += coord.height;
                    }
                }
                else
                {
                    IsRun = false;
                    for (int i = 0; i < cell.Length; i++)
                    {
                        int gridX = (cell[i].X - coord.x) / coord.width;
                        int gridY = (cell[i].Y - coord.y) / coord.height;
                        _grid[gridX, gridY] = 1;
                    }
                }
            }
            _step++;
        }
        protected virtual Cell[] TurnFigure(Cell[] cell)
        {
            return null;
        }
        protected bool CanMove(Keys key)
        {
            bool canMove = true;
            for (int i = 0; i < cell.Length; i++)
            {
                int gridX = (cell[i].X - coord.x) / coord.width;
                int gridY = (cell[i].Y - coord.y) / coord.height;
                if (key == Keys.LEFT)
                {
                    if (gridX <= 0 || _grid[gridX - 1, gridY] == 1)
                    {
                        canMove = false;
                    }
                }
                if (key == Keys.RIGHT)
                {
                    if (gridX + 1 >= _grid.GetLength(0) || _grid[gridX + 1, gridY] == 1)
                    {
                        canMove = false;
                    }
                }
                if (key == Keys.DOWN)
                {
                    if (gridY + 1 >= _grid.GetLength(1) || _grid[gridX, gridY + 1] == 1)
                    {
                        canMove = false;
                    }
                }
                if (key == Keys.SPACE)
                {
                    if (gridX == _grid.GetLength(0) || gridY + 1 >= _grid.GetLength(1)
                        || _grid[gridX, gridY + 1] == 1)
                        canMove = false;
                }
            }
            return canMove;
        }
    }
}

