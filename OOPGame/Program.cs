using NConsoleGraphics;
using System;

namespace Tetris_OOPGame
{

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 60;
            Console.WindowHeight = 30;
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Console.Clear();
            GameEngine.restart = true;
            while (GameEngine.restart)
            {
                StartGame();
            }
        }

        public static void StartGame()
        {
            ConsoleGraphics graphics = new ConsoleGraphics();
            GameEngine engine = new SampleGameEngine(graphics);
            engine.Start();
        }
    }
}
