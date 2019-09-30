﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    internal class ThunderFigure : Figure
    {
        private const uint thunderColor = 0xFFa8329d;

        public ThunderFigure(int speed, int[,] grid)
            : base(speed, grid)
        {
            for (int i = 0; i < cell.Length; i++)
            {
                cell[i] = new Cell { Color = thunderColor, X = field.xMin, Y = field.yMin };
            }
            DoFigure();
        }

        protected override Cell[] DoFigure()
        {
            cell[0] = new Cell { Color = thunderColor, X = cell[0].X, Y = cell[0].Y };
            cell[1] = new Cell { Color = thunderColor, X = cell[0].X, Y = cell[0].Y + field.height };
            cell[2] = new Cell { Color = thunderColor, X = cell[0].X + field.width, Y = cell[0].Y + field.height };
            cell[3] = new Cell { Color = thunderColor, X = cell[0].X + field.width, Y = cell[0].Y + 2 * field.height };
            return cell;
        }
        protected override Cell[] TurnFigure(Cell[] cell)
        {
            int i = 0;
            switch (option)
            {
                case 0:
                    if (cell[i].X == 180)
                    {
                        option = 1;
                        cell[0] = new Cell { Color = thunderColor, X = cell[0].X- field.width, Y = cell[0].Y };
                        cell[1] = new Cell { Color = thunderColor, X = cell[0].X + field.width, Y = cell[0].Y };
                        cell[2] = new Cell { Color = thunderColor, X = cell[0].X + field.width, Y = cell[0].Y - field.height };
                        cell[3] = new Cell { Color = thunderColor, X = cell[0].X + 2 * field.width, Y = cell[0].Y - field.height };
                        break;
                    }
                    if (cell[i].X < 180)
                    {
                        option = 1;
                        cell[0] = new Cell { Color = thunderColor, X = cell[0].X, Y = cell[0].Y };
                        cell[1] = new Cell { Color = thunderColor, X = cell[0].X + field.width, Y = cell[0].Y };
                        cell[2] = new Cell { Color = thunderColor, X = cell[0].X + field.width, Y = cell[0].Y - field.height };
                        cell[3] = new Cell { Color = thunderColor, X = cell[0].X + 2 * field.width, Y = cell[0].Y - field.height };
                        break;
                    }
                    break;
                case 1:
                    if (cell[i].X == 160)
                    {
                        option = 0;
                        cell[0] = new Cell { Color = thunderColor, X = cell[0].X + field.width, Y = cell[0].Y };
                        cell[1] = new Cell { Color = thunderColor, X = cell[0].X, Y = cell[0].Y + field.height };
                        cell[2] = new Cell { Color = thunderColor, X = cell[0].X + field.width, Y = cell[0].Y + field.height };
                        cell[3] = new Cell { Color = thunderColor, X = cell[0].X + field.width, Y = cell[0].Y + 2 * field.height };
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
            return cell;
        }
    }
}
