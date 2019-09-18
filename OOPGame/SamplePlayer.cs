using NConsoleGraphics;
using System;

namespace Tetris_OOPGame
{
    public class SamplePlayer : IGameObject
    {
        private IGameObject gameObject;
        private int xMin = 20;
        private int yMin = 20;
        private int xMax = 220;
        private int yMax = 420;
        private int _width = 20;
        private int _height = 20;  
        private int numberCellHeigh = 20;  
        private int numberCellWidth = 10;  
        private int[,] fieldGrid;
        public static int _score = 0;
        public static bool gameIsOver = false;
        private int _speed;
        Random rnd = new Random();
        private ConsoleGraphics _graphics;
        public bool IsRun { get; }
        
        public SamplePlayer(ConsoleGraphics graphics)
        {
            fieldGrid = new int[numberCellWidth, numberCellHeigh];
            _graphics = graphics;
            for (int i = 0; i < numberCellWidth; i++)
            {
                for (int j = 0; j < numberCellHeigh; j++)
                {
                    fieldGrid[i, j] = 0;
                }
            }
            _speed = 10;
        }
        public void Render(ConsoleGraphics graphics)
        {
            for (int i = 0; i < numberCellWidth; i++)
            {
                for (int j = 0; j < numberCellHeigh; j++)
                {
                    if (fieldGrid[i, j] == 1)
                    {
                        graphics.FillRectangle(0xFF0FFF00, _width * i + xMin, _height * j + yMin, _width, _height);
                        if(j == 0)
                        {
                            gameIsOver = true;
                        }
                    }
                }
            }
            gameObject?.Render(graphics);
            for (int i = xMin; i <= xMax; i += _width * 10)
            {
                graphics.DrawLine(0xFFFFFF00, i, yMin, i, yMax);
            }
            for (int i = yMin; i <= yMax; i += _height * 20)
            {
                graphics.DrawLine(0xFFFFFF00, xMin, i, xMax, i);
            }
        }
        public void Update(GameEngine engine)
        {
            if (gameObject == null)
            {
                gameObject = ChooseFigure();
            }
            if (gameObject.IsRun)
            {
                gameObject.Update(engine);
            }
            else
            {
                for (int i = 0; i < numberCellHeigh; i++)
                {
                    for (int j = 0; j < numberCellWidth ; j++)
                    {
                        if (fieldGrid[j, i] == 0)
                        {
                            break;
                        }
                        if (fieldGrid[j, i] == 1 && j == numberCellWidth - 1)
                        {
                            _score++;
                            for (int y = i; y >= 0; y--)
                            {
                                for (int x = 0; x < numberCellWidth; x++)
                                {
                                    if (y != 0)
                                    {
                                        fieldGrid[x, y] = fieldGrid[x, y - 1];
                                    }
                                    else
                                    {
                                        fieldGrid[x, y] = 0;
                                    }
                                }
                            }
                        }
                    }
                }
                gameObject = ChooseFigure();
            }
        }
        private IGameObject ChooseFigure()
        {
            IGameObject obj = new Figure(xMin, yMin, _width, _height, _speed, ref fieldGrid);
            return obj;
        }
    }
}
