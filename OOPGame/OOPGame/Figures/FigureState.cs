using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    public abstract class FigureState : IFigureState
    {
        protected readonly Figure _figure;

        public FigureState(Figure figure)
        {
            _figure = figure;
        }

        public abstract IEnumerable<Cell> State { get; }

        public abstract IFigureState TurnFigure();
    }
}
