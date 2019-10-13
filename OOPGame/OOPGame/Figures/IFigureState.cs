using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    public interface IFigureState
    {
        IFigureState TurnFigure(Figure figure, Cell[] cell);
        IEnumerable<Cell> State { get; }
    }
}
