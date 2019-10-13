using NConsoleGraphics;
using System;
using System.Threading;

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
            ConsoleGraphics graphics = new ConsoleGraphics();
            GameScore score = new GameScore();
            bool restart = false;

            while (true)
            {
                if (score.GameIsOn)
                    StartGame(graphics, score);
                if (!restart)
                {
                    Restart(graphics, score);
                    if (Input.IsKeyDown(Keys.SPACE))
                    {
                        restart = true;
                        score.GameIsOn = true;
                    }
                }
                graphics.FlipPages();
                Thread.Sleep(80);
            }
        }

        public static void StartGame(ConsoleGraphics graphics, GameScore score)
        {
            GameEngine engine = new TetrisGameEngine(graphics, score);
            score.Score = 0;
            engine.Start();
        }

        private static void Restart(ConsoleGraphics graphics, GameScore score)
        {
            graphics.FillRectangle(0xFFFFFFFF, 0, 0, graphics.ClientWidth, graphics.ClientHeight);
            graphics.DrawString("Game is over", "Arial", 0xFF000000, 150, 150);
            graphics.DrawString($"Your score: {score.Score.ToString()}", "Arial", 0xFF00FF00, 150, 170);
            graphics.DrawString("If you want to restart, press Space", "Arial", 0xFF000000, 150, 190);
        }
    }
}
