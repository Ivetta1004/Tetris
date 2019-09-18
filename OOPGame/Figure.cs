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
        private int _x;
        private int _y;
        private int _width;
        private int _height;
        private int _speed;
        private bool isRun;
        private Cell[] cell;
        private int[,] _grid;
        Random rnd = new Random();
        private int chooseFigure;
        private bool isTurn = true;
        private const int size = 4;
        private int _step;

        public Figure(int x, int y, int width, int height, int speed, ref int[,] grid)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            _speed = speed;
            _step = 1;
            isRun = true;
            cell = new Cell[size];
            chooseFigure = rnd.Next(0, 7);
            DoFigure();
            _grid = grid;
        }
        public bool IsRun
        {
            get { return isRun; }
        }
        private void DoFigure()
        {
            switch (chooseFigure)
            {
                case 0:
                    cell[0] = new Cell { Color = 0xFFFF0000, X = _x, Y = _y };
                    cell[1] = new Cell { Color = 0xFFFF0000, X = _x, Y = _y + _height };
                    cell[2] = new Cell { Color = 0xFFFF0000, X = _x, Y = _y + 2 * _height };
                    cell[3] = new Cell { Color = 0xFFFF0000, X = _x, Y = _y + 3 * _height };
                    break;
                case 1:
                    cell[0] = new Cell { Color = 0xFFFF0000, X = _x, Y = _y };
                    cell[1] = new Cell { Color = 0xFFFF0000, X = _x, Y = _y + _height };
                    cell[2] = new Cell { Color = 0xFFFF0000, X = _x, Y = _y + 2 * _height };
                    cell[3] = new Cell { Color = 0xFFFF0000, X = _x + _width, Y = _y + 2 * _height };
                    break;
                case 2:
                    cell[0] = new Cell { Color = 0xFFFF0000, X = _x, Y = _y };
                    cell[1] = new Cell { Color = 0xFFFF0000, X = _x, Y = _y + _height };
                    cell[2] = new Cell { Color = 0xFFFF0000, X = _x + _width, Y = _y + _height };
                    cell[3] = new Cell { Color = 0xFFFF0000, X = _x + _width, Y = _y + 2 * _height };
                    break;
                case 3:
                    cell[0] = new Cell { Color = 0xFFFF0000, X = _x, Y = _y };
                    cell[1] = new Cell { Color = 0xFFFF0000, X = _x + _width, Y = _y };
                    cell[2] = new Cell { Color = 0xFFFF0000, X = _x + 2 * _width, Y = _y };
                    cell[3] = new Cell { Color = 0xFFFF0000, X = _x + _width, Y = _y + _height };
                    break;
                case 4:
                    cell[0] = new Cell { Color = 0xFFFF0000, X = _x, Y = _y };
                    cell[1] = new Cell { Color = 0xFFFF0000, X = _x + _width, Y = _y };
                    cell[2] = new Cell { Color = 0xFFFF0000, X = _x + _width, Y = _y + _height };
                    cell[3] = new Cell { Color = 0xFFFF0000, X = _x + 2 * _width, Y = _y + _height };
                    break;
                case 5:
                    cell[0] = new Cell { Color = 0xFFFF0000, X = _x, Y = _y };
                    cell[1] = new Cell { Color = 0xFFFF0000, X = _x + _width, Y = _y };
                    cell[2] = new Cell { Color = 0xFFFF0000, X = _x, Y = _y + _height };
                    cell[3] = new Cell { Color = 0xFFFF0000, X = _x, Y = _y + 2 * _height };
                    break;
                case 6:
                    cell[0] = new Cell { Color = 0xFFFF0000, X = _x, Y = _y };
                    cell[1] = new Cell { Color = 0xFFFF0000, X = _x + _width, Y = _y };
                    cell[2] = new Cell { Color = 0xFFFF0000, X = _x + _width, Y = _y + _height };
                    cell[3] = new Cell { Color = 0xFFFF0000, X = _x, Y = _y + _height };
                    break;
            }
        }
        public void Render(ConsoleGraphics graphics)
        {
            for (int i = 0; i < cell.Length; i++)
            {
                graphics.FillRectangle(cell[i].Color, cell[i].X, cell[i].Y, _width, _height);
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
                        cell[i].X -= _width;
                    }
                }
            }
            else if (Input.IsKeyDown(Keys.RIGHT))
            {
                if (CanMove(Keys.RIGHT))
                {
                    for (int i = 0; i < cell.Length; i++)
                    {
                        cell[i].X += _width;
                    }
                }
            }
            else if (Input.IsKeyDown(Keys.DOWN))
            {
                if (CanMove(Keys.DOWN))
                {
                    for (int i = 0; i < cell.Length; i++)
                    {
                        cell[i].Y += _height;
                    }
                }
            }
            if (Input.IsKeyDown(Keys.SPACE))
            {
                if (CanMove(Keys.SPACE))
                {
                    if (isTurn)
                    {
                        TurnFigure();
                        isTurn = false;
                    }
                    else
                    {
                        DoFigure();
                        isTurn = true;
                    }
                }
            }
            if (_step % _speed == 0)
            {
                if (CanMove(Keys.DOWN))
                {
                    for (int i = 0; i < cell.Length; i++)
                    {
                        cell[i].Y += _height;
                    }
                }
                else
                {
                    isRun = false;
                    for (int i = 0; i < cell.Length; i++)
                    {
                        int gridX = (cell[i].X - _x) / _width;
                        int gridY = (cell[i].Y - _y) / _height;
                        _grid[gridX, gridY] = 1;
                    }
                }
            }
            _step++;
        }
        private void TurnFigure()
        {
            switch (chooseFigure)
            {
                case 0:
                    cell[0] = new Cell { Color = 0xFFFF0000, X = _x, Y = _y };
                    cell[1] = new Cell { Color = 0xFFFF0000, X = _x + _width, Y = _y };
                    cell[2] = new Cell { Color = 0xFFFF0000, X = _x + 2 * _width, Y = _y };
                    cell[3] = new Cell { Color = 0xFFFF0000, X = _x + 3 * _width, Y = _y };
                    break;
                case 1:
                    cell[0] = new Cell { Color = 0xFFFF0000, X = _x + _width, Y = _y };
                    cell[1] = new Cell { Color = 0xFFFF0000, X = _x + _width, Y = _y + _height };
                    cell[2] = new Cell { Color = 0xFFFF0000, X = _x + _width, Y = _y + 2 * _height };
                    cell[3] = new Cell { Color = 0xFFFF0000, X = _x, Y = _y + 2 * _height };
                    break;
                case 2:
                    cell[0] = new Cell { Color = 0xFFFF0000, X = _x + _width, Y = _y };
                    cell[1] = new Cell { Color = 0xFFFF0000, X = _x + _width, Y = _y + _height };
                    cell[2] = new Cell { Color = 0xFFFF0000, X = _x, Y = _y + _height };
                    cell[3] = new Cell { Color = 0xFFFF0000, X = _x, Y = _y + 2 * _height };
                    break;
                case 3:
                    cell[0] = new Cell { Color = 0xFFFF0000, X = _x, Y = _y + _height };
                    cell[1] = new Cell { Color = 0xFFFF0000, X = _x + _width, Y = _y };
                    cell[2] = new Cell { Color = 0xFFFF0000, X = _x + _width, Y = _y + _height };
                    cell[3] = new Cell { Color = 0xFFFF0000, X = _x + 2 * _width, Y = _y + _height };
                    break;
                case 4:
                    cell[0] = new Cell { Color = 0xFFFF0000, X = _x, Y = _y + _height };
                    cell[1] = new Cell { Color = 0xFFFF0000, X = _x + _width, Y = _y + _height };
                    cell[2] = new Cell { Color = 0xFFFF0000, X = _x + _width, Y = _y };
                    cell[3] = new Cell { Color = 0xFFFF0000, X = _x + 2 * _width, Y = _y };
                    break;
                case 5:
                    cell[0] = new Cell { Color = 0xFFFF0000, X = _x, Y = _y };
                    cell[1] = new Cell { Color = 0xFFFF0000, X = _x + _width, Y = _y };
                    cell[2] = new Cell { Color = 0xFFFF0000, X = _x + _width, Y = _y + _height };
                    cell[3] = new Cell { Color = 0xFFFF0000, X = _x + _width, Y = _y + 2 * _height };
                    break;
            }
        }
        private bool CanMove(Keys key)
        {
            bool canMove = true;
            for (int i = 0; i < cell.Length; i++)
            {
                int gridX = (cell[i].X - _x) / _width;
                int gridY = (cell[i].Y - _y) / _height;
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
            }
            return canMove;
        }
    }
}

