using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace Tetris_OOPGame
{
    internal abstract class Figure : IGameObject
    {
        protected FieldSize field = new FieldSize();
        private readonly int _speed = 3;
        private int[,] _grid;
        private const int size = 4;
        protected Cell[] cell = new Cell[size];
        private int _step;
        protected Option option;
        public bool IsRun { get; private set; }

        public Figure(int[,] grid)
        {
            _step = 1;
            IsRun = true;
            _grid = grid;
            option = Option.option0;
        }

        protected abstract Cell[] DoFigure();

        protected abstract Cell[] TurnFigure(Cell[] cell);

        public void Render(ConsoleGraphics graphics)
        {
            for (int i = 0; i < cell.Length; i++)
            {
                graphics.FillRectangle(cell[i].Color, cell[i].X, cell[i].Y, field.width, field.height);
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
                        cell[i].X -= field.width;
                    }
                }
            }
            else if (Input.IsKeyDown(Keys.RIGHT))
            {
                if (CanMove(Keys.RIGHT))
                {
                    for (int i = 0; i < cell.Length; i++)
                    {
                        cell[i].X += field.width;
                    }
                }
            }
            else if (Input.IsKeyDown(Keys.DOWN))
            {
                if (CanMove(Keys.DOWN))
                {
                    for (int i = 0; i < cell.Length; i++)
                    {
                        cell[i].Y += field.height;
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
                        cell[i].Y += field.height;
                    }
                }
                else
                {
                    IsRun = false;
                    for (int i = 0; i < cell.Length; i++)
                    {
                        int gridX = (cell[i].X - field.xMin) / field.width;
                        int gridY = (cell[i].Y - field.yMin) / field.height;
                        _grid[gridX, gridY] = 1;
                    }
                }
            }
            _step++;
        }
     
        protected bool CanMove(Keys key)
        {
            bool canMove = true;
            for (int i = 0; i < cell.Length; i++)
            {
                int gridX = (cell[i].X - field.xMin) / field.width;
                int gridY = (cell[i].Y - field.yMin) / field.height;
                if (key == Keys.LEFT)
                {
                    if (gridX <= 0 || _grid[gridX - 1, gridY] == 1)
                    {
                        return canMove = false;
                    }
                }
                if (key == Keys.RIGHT)
                {
                    if (gridX + 1 >= _grid.GetLength(0) || _grid[gridX + 1, gridY] == 1)
                    {
                        return canMove = false;
                    }
                }
                if (key == Keys.DOWN)
                {
                    if (gridY + 1 >= _grid.GetLength(1) || _grid[gridX, gridY + 1] == 1)
                    {
                        return canMove = false;
                    }
                }
                if (key == Keys.SPACE)
                {
                    if (gridX == _grid.GetLength(0) || gridY + 1 >= _grid.GetLength(1)
                        || _grid[gridX, gridY + 1] == 1)
                        return canMove = false;
                }
            }
            return canMove;
        }
    }
}

