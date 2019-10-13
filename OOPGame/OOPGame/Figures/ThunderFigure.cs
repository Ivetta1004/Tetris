using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    internal class ThunderFigure : Figure //, IFigureState
    {
        private const uint thunderColor = 0xFFa8329d;

        public ThunderFigure(int[,] grid) : base(grid)
        {
            for (int i = 0; i < cell.Length; i++)
            {
                cell[i] = new Cell { Color = thunderColor, X = FieldSize.xMin, Y = FieldSize.yMin };
            }
            DoFigure();
        }

        public void TurnFigure(Figure figure)
        {
            throw new NotImplementedException();
        }

        protected override Cell[] DoFigure()
        {
            cell[0] = new Cell { Color = thunderColor, X = cell[0].X, Y = cell[0].Y };
            cell[1] = new Cell { Color = thunderColor, X = cell[0].X, Y = cell[0].Y + FieldSize.height };
            cell[2] = new Cell { Color = thunderColor, X = cell[0].X + FieldSize.width, Y = cell[0].Y + FieldSize.height };
            cell[3] = new Cell { Color = thunderColor, X = cell[0].X + FieldSize.width, Y = cell[0].Y + 2 * FieldSize.height };
            return cell;
        }

        protected override Cell[] TurnFigure(Cell[] cell)
        {
            int i = 0;
            switch (option)
            {
                case Option.option0:
                    if (cell[i].X == 180)
                    {
                        option = Option.option1;
                        cell[0] = new Cell { Color = thunderColor, X = cell[0].X- FieldSize.width, Y = cell[0].Y };
                        cell[1] = new Cell { Color = thunderColor, X = cell[0].X + FieldSize.width, Y = cell[0].Y };
                        cell[2] = new Cell { Color = thunderColor, X = cell[0].X + FieldSize.width, Y = cell[0].Y - FieldSize.height };
                        cell[3] = new Cell { Color = thunderColor, X = cell[0].X + 2 * FieldSize.width, Y = cell[0].Y - FieldSize.height };
                        break;
                    }
                    if (cell[i].X < 180)
                    {
                        option = Option.option1;
                        cell[0] = new Cell { Color = thunderColor, X = cell[0].X, Y = cell[0].Y };
                        cell[1] = new Cell { Color = thunderColor, X = cell[0].X + FieldSize.width, Y = cell[0].Y };
                        cell[2] = new Cell { Color = thunderColor, X = cell[0].X + FieldSize.width, Y = cell[0].Y - FieldSize.height };
                        cell[3] = new Cell { Color = thunderColor, X = cell[0].X + 2 * FieldSize.width, Y = cell[0].Y - FieldSize.height };
                        break;
                    }
                    break;
                case Option.option1:
                    if (cell[i].X == 160)
                    {
                        option = Option.option0;
                        cell[0] = new Cell { Color = thunderColor, X = cell[0].X + FieldSize.width, Y = cell[0].Y };
                        cell[1] = new Cell { Color = thunderColor, X = cell[0].X, Y = cell[0].Y + FieldSize.height };
                        cell[2] = new Cell { Color = thunderColor, X = cell[0].X + FieldSize.width, Y = cell[0].Y + FieldSize.height };
                        cell[3] = new Cell { Color = thunderColor, X = cell[0].X + FieldSize.width, Y = cell[0].Y + 2 * FieldSize.height };
                        break;
                    }
                    if (cell[i].X < 180)
                    {
                        option = Option.option0;
                        DoFigure();
                        break;
                    }
                    break;
            }
            return cell;
        }
    }
}
