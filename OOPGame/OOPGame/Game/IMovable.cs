using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_OOPGame
{
    public interface IMovable : IGameObject
    {
         bool IsRun { get; }
    }
}
