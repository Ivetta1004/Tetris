using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    internal class SquareFigure : Figure
    {
        private const uint squareColor = 0xFFFF0000;

        public SquareFigure(int[,] grid) : base(grid)
        {
            for (int i = 0; i < cell.Length; i++)
            {
                cell[i] = new Cell { Color = squareColor, X = field.xMin, Y = field.yMin };
            }
            DoFigure();
        }

        protected override Cell[] DoFigure()
        {
            cell[0] = new Cell { Color = squareColor, X = cell[0].X, Y = cell[0].Y };
            cell[1] = new Cell { Color = squareColor, X = cell[0].X + field.width, Y = cell[0].Y };
            cell[2] = new Cell { Color = squareColor, X = cell[0].X, Y = cell[0].Y + field.height };
            cell[3] = new Cell { Color = squareColor, X = cell[0].X + field.width, Y = cell[0].Y + field.height };
            return cell;
        }

        protected override Cell[] TurnFigure(Cell[] cell)
        {
            DoFigure();
            return cell;
        }
    }
}
