using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    internal class SquareFigure : Figure
    {
        public SquareFigure(int x, int y, int width, int height, int speed, ref int[,] grid)
            : base(x, y, width, height, speed, ref grid) { }

        protected override Cell[] DoFigure()
        {
            cell[0] = new Cell { Color = 0xFFFF0000, X = cell[0].X, Y = cell[0].Y };
            cell[1] = new Cell { Color = 0xFFFF0000, X = cell[0].X + coord.width, Y = cell[0].Y };
            cell[2] = new Cell { Color = 0xFFFF0000, X = cell[0].X, Y = cell[0].Y + coord.height };
            cell[3] = new Cell { Color = 0xFFFF0000, X = cell[0].X + coord.width, Y = cell[0].Y + coord.height };
            return cell;
        }
        protected override Cell[] TurnFigure(Cell[] cell)
        {
            DoFigure();
            return cell;
        }
    }
}
