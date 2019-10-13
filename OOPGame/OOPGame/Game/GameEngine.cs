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
        private GameScore _game;

        public GameEngine(ConsoleGraphics graphics, GameScore score)
        {
            _graphics = graphics;
            _game = score;
        }

        public void AddObject(IGameObject obj)
        {
            tempObjects.Add(obj);
        }

        public void Start()
        {
            while (_game.GameIsOn)
            {
                // Game Loop
                foreach (var obj in objects)
                    obj.Update(this);

                objects.AddRange(tempObjects);
                tempObjects.Clear();

                // clearing screen before painting new frame
                _graphics.FillRectangle(0xFFFFFFFF, 0, 0, _graphics.ClientWidth, _graphics.ClientHeight);

                foreach (var obj in objects)
                    obj.Render(_graphics);

                // double buffering technique is used
                _graphics.FlipPages();
                Thread.Sleep(100);
            }
        }
    }
}
