using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NConsoleGraphics;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    internal class TFigure : Figure
    {
        public TFigure(int x, int y, int width, int height, int speed, ref int[,] grid)
            : base(x, y, width, height, speed, ref grid) { }

        protected override Cell[] DoFigure()
        {
            cell[0] = new Cell { Color = 0xFF33E6FF, X = cell[0].X, Y = cell[0].Y };
            cell[1] = new Cell { Color = 0xFF33E6FF, X = cell[0].X + coord.width, Y = cell[0].Y };
            cell[2] = new Cell { Color = 0xFF33E6FF, X = cell[0].X + 2 * coord.width, Y = cell[0].Y };
            cell[3] = new Cell { Color = 0xFF33E6FF, X = cell[0].X + coord.width, Y = cell[0].Y + coord.height };
            return cell;
        }
        protected override Cell[] TurnFigure(Cell[] cell)
        {
            int i = 0;
            if (CanMove(Keys.SPACE))
            {
                switch (option)
                {
                    case 0:
                        if (cell[i].X == 160)
                        {
                            option = 1;
                            cell[0] = new Cell { Color = 0xFF33E6FF, X = cell[0].X + coord.width, Y = cell[0].Y };
                            cell[1] = new Cell { Color = 0xFF33E6FF, X = cell[0].X, Y = cell[0].Y + coord.height };
                            cell[2] = new Cell { Color = 0xFF33E6FF, X = cell[0].X, Y = cell[0].Y + 2 * coord.height };
                            cell[3] = new Cell { Color = 0xFF33E6FF, X = cell[0].X + coord.width, Y = cell[0].Y + coord.height };
                            break;
                        }
                        if (cell[i].X < 180)
                        {
                            option = 1;
                            cell[0] = new Cell { Color = 0xFF33E6FF, X = cell[0].X, Y = cell[0].Y };
                            cell[1] = new Cell { Color = 0xFF33E6FF, X = cell[0].X, Y = cell[0].Y + coord.height };
                            cell[2] = new Cell { Color = 0xFF33E6FF, X = cell[0].X, Y = cell[0].Y + 2 * coord.height };
                            cell[3] = new Cell { Color = 0xFF33E6FF, X = cell[0].X + coord.width, Y = cell[0].Y + coord.height };
                            break;
                        }
                        break;
                    case 1:
                        if (cell[i].X == 180)
                        {
                            option = 2;
                            cell[0] = new Cell { Color = 0xFF33E6FF, X = cell[0].X - coord.width, Y = cell[0].Y };
                            cell[1] = new Cell { Color = 0xFF33E6FF, X = cell[0].X + coord.width, Y = cell[0].Y - coord.height };
                            cell[2] = new Cell { Color = 0xFF33E6FF, X = cell[0].X + coord.width, Y = cell[0].Y };
                            cell[3] = new Cell { Color = 0xFF33E6FF, X = cell[0].X + 2 * coord.width, Y = cell[0].Y };
                            break;
                        }
                        if (cell[i].X < 180)
                        {
                            option = 2;
                            cell[0] = new Cell { Color = 0xFF33E6FF, X = cell[0].X, Y = cell[0].Y };
                            cell[1] = new Cell { Color = 0xFF33E6FF, X = cell[0].X + coord.width, Y = cell[0].Y - coord.height };
                            cell[2] = new Cell { Color = 0xFF33E6FF, X = cell[0].X + coord.width, Y = cell[0].Y };
                            cell[3] = new Cell { Color = 0xFF33E6FF, X = cell[0].X + 2 * coord.width, Y = cell[0].Y };
                            break;
                        }
                        break;
                    case 2:
                        if (cell[i].X == 160)
                        {
                            option = 3;
                            cell[0] = new Cell { Color = 0xFF33E6FF, X = cell[0].X + coord.width, Y = cell[0].Y };
                            cell[1] = new Cell { Color = 0xFF33E6FF, X = cell[0].X + coord.width, Y = cell[0].Y - coord.height };
                            cell[2] = new Cell { Color = 0xFF33E6FF, X = cell[0].X + coord.width, Y = cell[0].Y };
                            cell[3] = new Cell { Color = 0xFF33E6FF, X = cell[0].X + coord.width, Y = cell[0].Y + coord.height };
                            break;
                        }
                        if (cell[i].X < 160)
                        {
                            option = 3;
                            cell[0] = new Cell { Color = 0xFF33E6FF, X = cell[0].X, Y = cell[0].Y };
                            cell[1] = new Cell { Color = 0xFF33E6FF, X = cell[0].X + coord.width, Y = cell[0].Y - coord.height };
                            cell[2] = new Cell { Color = 0xFF33E6FF, X = cell[0].X + coord.width, Y = cell[0].Y };
                            cell[3] = new Cell { Color = 0xFF33E6FF, X = cell[0].X + coord.width, Y = cell[0].Y + coord.height };
                            break;
                        }
                        break;
                    case 3:
                        if (cell[i].X == 180)
                        {
                            cell[0] = new Cell { Color = 0xFF33E6FF, X = cell[0].X - coord.width, Y = cell[0].Y };
                            cell[1] = new Cell { Color = 0xFF33E6FF, X = cell[0].X + coord.width, Y = cell[0].Y };
                            cell[2] = new Cell { Color = 0xFF33E6FF, X = cell[0].X + 2 * coord.width, Y = cell[0].Y };
                            cell[3] = new Cell { Color = 0xFF33E6FF, X = cell[0].X + coord.width, Y = cell[0].Y + coord.height };
                            break;
                        }
                        if (cell[i].X < 180)
                        {
                            option = 0;
                            DoFigure();
                            break;
                        }
                        break;
                }
            }
            return cell;
        }
    }
}
