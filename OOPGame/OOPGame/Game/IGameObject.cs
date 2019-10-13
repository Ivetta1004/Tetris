using NConsoleGraphics;

namespace Tetris_OOPGame
{
    public interface IGameObject
    {
        void Render(ConsoleGraphics graphics);
        void Update(GameEngine engine);
    }
}