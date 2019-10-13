using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    internal class SquareFigure : Figure, IFigureState
    {
        private const uint squareColor = 0xFFFF0000;

        public SquareFigure() { }

        public SquareFigure(int[,] grid, IFigureState state) : base(grid, state)
        {
            for (int i = 0; i < cell.Length; i++)
            {
                cell[i] = new Cell { Color = squareColor, X = FieldSize.xMin, Y = FieldSize.yMin };
            }
            DoFigure();
        }

        public IEnumerable<Cell> State { get; }

        public IFigureState TurnFigure(Figure figure, Cell[] cell)
        {
            return new SquareFigure();
        }

        protected override Cell[] DoFigure()
        {
            cell[0] = new Cell { Color = squareColor, X = cell[0].X, Y = cell[0].Y };
            cell[1] = new Cell { Color = squareColor, X = cell[0].X + FieldSize.width, Y = cell[0].Y };
            cell[2] = new Cell { Color = squareColor, X = cell[0].X, Y = cell[0].Y + FieldSize.height };
            cell[3] = new Cell { Color = squareColor, X = cell[0].X + FieldSize.width, Y = cell[0].Y + FieldSize.height };
            return cell;
        }
    }
}
