using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NConsoleGraphics;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    internal class LineFigure : Figure
    {
        private const uint lineColor = 0xFF3380FF;

        public LineFigure(int speed, int[,] grid)
            : base(speed, grid)
        {
            for (int i = 0; i < cell.Length; i++)
            {
                cell[i] = new Cell { Color = lineColor, X = field.xMin, Y = field.yMin };
            }
            DoFigure();
        }

        protected override Cell[] DoFigure()
        {
            cell[0] = new Cell { Color = lineColor, X = cell[0].X, Y = cell[0].Y };
            cell[1] = new Cell { Color = lineColor, X = cell[0].X, Y = cell[0].Y + field.height };
            cell[2] = new Cell { Color = lineColor, X = cell[0].X, Y = cell[0].Y + 2 * field.height };
            cell[3] = new Cell { Color = lineColor, X = cell[0].X, Y = cell[0].Y + 3 * field.height };
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
                        if (cell[i].X == 160 || cell[i].X == 180 || cell[i].X == 200)
                        {
                            option++;
                            cell[0] = new Cell { Color = lineColor, X = cell[0].X, Y = cell[0].Y };
                            cell[1] = new Cell { Color = lineColor, X = cell[0].X - field.width, Y = cell[0].Y };
                            cell[2] = new Cell { Color = lineColor, X = cell[0].X - 2 * field.width, Y = cell[0].Y };
                            cell[3] = new Cell { Color = lineColor, X = cell[0].X - 3 * field.width, Y = cell[0].Y };
                            break;
                        }
                        if (cell[i].X < 160)
                        {
                            option++;
                            cell[0] = new Cell { Color = lineColor, X = cell[0].X, Y = cell[0].Y };
                            cell[1] = new Cell { Color = lineColor, X = cell[0].X + field.width, Y = cell[0].Y };
                            cell[2] = new Cell { Color = lineColor, X = cell[0].X + 2 * field.width, Y = cell[0].Y };
                            cell[3] = new Cell { Color = lineColor, X = cell[0].X + 3 * field.width, Y = cell[0].Y };
                            break;
                        }
                        break;
                    case 1:
                        if (cell[i].Y == 360 || cell[i].Y == 380 || cell[i].Y == 400)
                        {
                            cell[0] = new Cell { Color = lineColor, X = cell[0].X, Y = cell[0].Y };
                            cell[1] = new Cell { Color = lineColor, X = cell[0].X, Y = cell[0].Y - field.height };
                            cell[2] = new Cell { Color = lineColor, X = cell[0].X, Y = cell[0].Y - 2 * field.height };
                            cell[3] = new Cell { Color = lineColor, X = cell[0].X, Y = cell[0].Y - 3 * field.height };
                            break;
                        }
                        else
                        {
                            option--;
                            DoFigure();
                        }
                        break;
                }
            }
            return cell;
        }
    }
}
