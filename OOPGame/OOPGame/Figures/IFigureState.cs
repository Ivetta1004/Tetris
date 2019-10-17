using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    public interface IFigureState
    {
        IFigureState TurnFigure();
        IEnumerable<Cell> State { get; }
    }
}
