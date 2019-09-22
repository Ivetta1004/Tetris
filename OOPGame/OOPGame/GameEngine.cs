using NConsoleGraphics;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Tetris_OOPGame
{
    public abstract class GameEngine
    {
        private readonly ConsoleGraphics _graphics;
        private readonly List<IGameObject> objects = new List<IGameObject>();
        private readonly List<IGameObject> tempObjects = new List<IGameObject>();
        internal static bool restart = false;
       
        public GameEngine(ConsoleGraphics graphics)
        {
            _graphics = graphics;
        }

        public void AddObject(IGameObject obj)
        {
            tempObjects.Add(obj);
        }

        public void Start()
        {
            restart = false;
            Player._score = 0;
            do
            {
                while (true)
                {
                    // Game Loop
                    foreach (var obj in objects)
                        obj.Update(this);

                    objects.AddRange(tempObjects);
                    tempObjects.Clear();

                    // clearing screen before painting new frame
                    _graphics.FillRectangle(0xFFFFFFFF, 0, 0, _graphics.ClientWidth, _graphics.ClientHeight);
                    _graphics.DrawString("Score: ", "Arial", 0xFF000000, 250, 250);
                    _graphics.DrawString(Player._score.ToString(), "Arial", 0xFF00FF00, 320, 250);
                    foreach (var obj in objects)
                        obj.Render(_graphics);
                    if (Player.gameIsOver)
                    {
                        Player.gameIsOver = false;
                        GameIsOver();
                        if (Input.IsKeyDown(Keys.SPACE))
                        {
                            restart = true;
                            break;
                        }
                    }
                    // double buffering technique is used
                    _graphics.FlipPages();
                    Thread.Sleep(100);
                }
            } while (Player.gameIsOver);
        }

        private void GameIsOver()
        {
            _graphics.FillRectangle(0xFFFFFFFF, 0, 0, _graphics.ClientWidth, _graphics.ClientHeight);
            _graphics.DrawString("Game is over", "Arial", 0xFF000000, 150, 150);
            _graphics.DrawString($"Your score: {Player._score.ToString()}", "Arial", 0xFF00FF00, 150, 170);
            _graphics.DrawString("If you want to restart, press Space", "Arial", 0xFF000000, 150, 190);
        }
    }
}
