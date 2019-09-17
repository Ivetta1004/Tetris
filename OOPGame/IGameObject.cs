using NConsoleGraphics;

namespace Tetris_OOPGame
{
    public interface IGameObject
    {
        bool IsRun { get; }
        void Render(ConsoleGraphics graphics);
        void Update(GameEngine engine);
    }
}