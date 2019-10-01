using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NConsoleGraphics;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    internal class RightLFigure : Figure
    {
        private const uint rightLColor = 0xFF8080FF;

        public RightLFigure(int[,] grid) : base(grid)
        {
            for (int i = 0; i < cell.Length; i++)
            {
                cell[i] = new Cell { Color = rightLColor, X = field.xMin, Y = field.yMin };
            }
            DoFigure();
        }

        protected override Cell[] DoFigure()
        {
            cell[0] = new Cell { Color = rightLColor, X = cell[0].X, Y = cell[0].Y };
            cell[1] = new Cell { Color = rightLColor, X = cell[0].X, Y = cell[0].Y + field.height };
            cell[2] = new Cell { Color = rightLColor, X = cell[0].X, Y = cell[0].Y + 2 * field.height };
            cell[3] = new Cell { Color = rightLColor, X = cell[0].X + field.width, Y = cell[0].Y + 2 * field.height };
            return cell;
        }

        protected override Cell[] TurnFigure(Cell[] cell)
        {
            int i = 0;
            if (CanMove(Keys.SPACE))
            {
                for (int y = 0; y < cell.Length; y++)
                {
                    if (cell[y].Y == 360 || cell[y].Y == 380 || cell[y].Y == 400 || cell[y].Y == 420)
                        break;
                }

                switch (option)
                {
                    case Option.option0:
                        if (cell[i].X == 180)
                        {
                            option = Option.option1;
                            cell[0] = new Cell { Color = rightLColor, X = cell[0].X - field.width, Y = cell[0].Y };
                            cell[1] = new Cell { Color = rightLColor, X = cell[0].X, Y = cell[0].Y + field.height };
                            cell[2] = new Cell { Color = rightLColor, X = cell[0].X + field.width, Y = cell[0].Y };
                            cell[3] = new Cell { Color = rightLColor, X = cell[0].X + 2 * field.width, Y = cell[0].Y };
                            break;
                        }
                        if (cell[i].X < 180)
                        {
                            option = Option.option1;
                            cell[0] = new Cell { Color = rightLColor, X = cell[0].X, Y = cell[0].Y };
                            cell[1] = new Cell { Color = rightLColor, X = cell[0].X, Y = cell[0].Y + field.height };
                            cell[2] = new Cell { Color = rightLColor, X = cell[0].X + field.width, Y = cell[0].Y };
                            cell[3] = new Cell { Color = rightLColor, X = cell[0].X + 2 * field.width, Y = cell[0].Y };
                            break;
                        }
                        break;
                    case Option.option1:
                        if (cell[i].X == 160)
                        {
                            option = Option.option2;
                            cell[0] = new Cell { Color = rightLColor, X = cell[0].X + field.width, Y = cell[0].Y };
                            cell[1] = new Cell { Color = rightLColor, X = cell[0].X + field.width, Y = cell[0].Y };
                            cell[2] = new Cell { Color = rightLColor, X = cell[0].X + field.width, Y = cell[0].Y + field.height };
                            cell[3] = new Cell { Color = rightLColor, X = cell[0].X + field.width, Y = cell[0].Y + 2 * field.height };
                            break;
                        }
                        if (cell[i].X < 160)
                        {
                            option = Option.option2;
                            cell[0] = new Cell { Color = rightLColor, X = cell[0].X, Y = cell[0].Y };
                            cell[1] = new Cell { Color = rightLColor, X = cell[0].X + field.width, Y = cell[0].Y };
                            cell[2] = new Cell { Color = rightLColor, X = cell[0].X + field.width, Y = cell[0].Y + field.height };
                            cell[3] = new Cell { Color = rightLColor, X = cell[0].X + field.width, Y = cell[0].Y + 2 * field.height };
                            break;
                        }
                        break;
                    case Option.option2:
                        if (cell[i].X == 180)
                        {
                            option = Option.option3;
                            cell[0] = new Cell { Color = rightLColor, X = cell[0].X - field.width, Y = cell[0].Y + field.height };
                            cell[1] = new Cell { Color = rightLColor, X = cell[0].X + field.width, Y = cell[0].Y };
                            cell[2] = new Cell { Color = rightLColor, X = cell[0].X + 2 * field.width, Y = cell[0].Y };
                            cell[3] = new Cell { Color = rightLColor, X = cell[0].X + 2 * field.width, Y = cell[0].Y - field.height };
                            break;
                        }
                        if (cell[i].X < 180)
                        {
                            option = Option.option3;
                            cell[0] = new Cell { Color = rightLColor, X = cell[0].X, Y = cell[0].Y + field.height };
                            cell[1] = new Cell { Color = rightLColor, X = cell[0].X + field.width, Y = cell[0].Y };
                            cell[2] = new Cell { Color = rightLColor, X = cell[0].X + 2 * field.width, Y = cell[0].Y };
                            cell[3] = new Cell { Color = rightLColor, X = cell[0].X + 2 * field.width, Y = cell[0].Y - field.height };
                            break;
                        }
                        break;
                    case Option.option3:
                        if (cell[i].X == 160)
                        {
                            option = Option.option0;
                            cell[0] = new Cell { Color = rightLColor, X = cell[0].X + field.width, Y = cell[0].Y };
                            cell[1] = new Cell { Color = rightLColor, X = cell[0].X, Y = cell[0].Y + field.height };
                            cell[2] = new Cell { Color = rightLColor, X = cell[0].X, Y = cell[0].Y + 2 * field.height };
                            cell[3] = new Cell { Color = rightLColor, X = cell[0].X + field.width, Y = cell[0].Y + 2 * field.height };
                            break;
                        }
                        if (cell[i].X < 160)
                        {
                            option = Option.option0;
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
