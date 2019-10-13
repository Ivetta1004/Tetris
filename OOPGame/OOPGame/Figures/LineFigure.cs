﻿using System;
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

        
        public LineFigure(int[,] grid) : base(grid)
        {
            for (int i = 0; i < cell.Length; i++)
            {
                cell[i] = new Cell { Color = lineColor, X = FieldSize.xMin, Y = FieldSize.yMin };
            }
            DoFigure();
        }

        public void TurnFigure()
        {
           // State.TurnFigure();
            cell[0] = new Cell { Color = lineColor, X = cell[0].X, Y = cell[0].Y };
            cell[1] = new Cell { Color = lineColor, X = cell[0].X - FieldSize.width, Y = cell[0].Y };
            cell[2] = new Cell { Color = lineColor, X = cell[0].X - 2 * FieldSize.width, Y = cell[0].Y };
            cell[3] = new Cell { Color = lineColor, X = cell[0].X - 3 * FieldSize.width, Y = cell[0].Y };
        }

        protected override Cell[] DoFigure()
        {
            cell[0] = new Cell { Color = lineColor, X = cell[0].X, Y = cell[0].Y };
            cell[1] = new Cell { Color = lineColor, X = cell[0].X, Y = cell[0].Y + FieldSize.height };
            cell[2] = new Cell { Color = lineColor, X = cell[0].X, Y = cell[0].Y + 2 * FieldSize.height };
            cell[3] = new Cell { Color = lineColor, X = cell[0].X, Y = cell[0].Y + 3 * FieldSize.height };
            return cell;
        }

        protected override Cell[] TurnFigure(Cell[] cell)
        {
            int i = 0;
            if (CanMove(Keys.SPACE))
            {
                switch (option)
                {
                    case Option.option0:
                        if (cell[i].X == 160 || cell[i].X == 180 || cell[i].X == 200)
                        {
                            option = Option.option1;
                            cell[0] = new Cell { Color = lineColor, X = cell[0].X, Y = cell[0].Y };
                            cell[1] = new Cell { Color = lineColor, X = cell[0].X - FieldSize.width, Y = cell[0].Y };
                            cell[2] = new Cell { Color = lineColor, X = cell[0].X - 2 * FieldSize.width, Y = cell[0].Y };
                            cell[3] = new Cell { Color = lineColor, X = cell[0].X - 3 * FieldSize.width, Y = cell[0].Y };
                            break;
                        }
                        if (cell[i].X < 160)
                        {
                            option = Option.option1;
                            cell[0] = new Cell { Color = lineColor, X = cell[0].X, Y = cell[0].Y };
                            cell[1] = new Cell { Color = lineColor, X = cell[0].X + FieldSize.width, Y = cell[0].Y };
                            cell[2] = new Cell { Color = lineColor, X = cell[0].X + 2 * FieldSize.width, Y = cell[0].Y };
                            cell[3] = new Cell { Color = lineColor, X = cell[0].X + 3 * FieldSize.width, Y = cell[0].Y };
                            break;
                        }
                        break;
                    case Option.option1:
                        if (cell[i].Y == 360 || cell[i].Y == 380 || cell[i].Y == 400)
                        {
                            option = Option.option0;
                            cell[0] = new Cell { Color = lineColor, X = cell[0].X, Y = cell[0].Y };
                            cell[1] = new Cell { Color = lineColor, X = cell[0].X, Y = cell[0].Y - FieldSize.height };
                            cell[2] = new Cell { Color = lineColor, X = cell[0].X, Y = cell[0].Y - 2 * FieldSize.height };
                            cell[3] = new Cell { Color = lineColor, X = cell[0].X, Y = cell[0].Y - 3 * FieldSize.height };
                            break;
                        }
                        else
                        {
                            option = Option.option0;
                            DoFigure();
                        }
                        break;
                }
            }
            return cell;
        }
    }
}
