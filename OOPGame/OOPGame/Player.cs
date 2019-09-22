using NConsoleGraphics;
using System;

namespace Tetris_OOPGame
{
    public class Player : IGameObject
    {
        private IGameObject figure;
        private Coordinate coord = new Coordinate();  
        private int[,] fieldGrid;
        internal static int _score = 0;
        internal static bool gameIsOver = false;
        Random rnd = new Random();
        private int _speed;
        public bool IsRun { get; set; }
       
        public Player(ConsoleGraphics graphics)
        {
            fieldGrid = new int[coord.numberCellWidth, coord.numberCellHeigh];
            for (int i = 0; i < coord.numberCellWidth; i++)
            {
                for (int j = 0; j < coord.numberCellHeigh; j++)
                {
                    fieldGrid[i, j] = 0;
                }
            }
            _speed = 3;
        }
        public void Render(ConsoleGraphics graphics)
        {
            for (int i = 0; i < coord.numberCellWidth; i++)
            {
                for (int j = 0; j < coord.numberCellHeigh; j++)
                {
                    if (fieldGrid[i, j] == 1)
                    {
                        graphics.FillRectangle(0xFF0FFF00, coord.width * i + coord.xMin, coord.height * j + 
                            coord.yMin, coord.width, coord.height);
                        if(j == 0)
                        {
                            gameIsOver = true;
                        }
                    }
                }
            }
            figure?.Render(graphics);
            for (int i = coord.xMin; i <= coord.xMax; i += coord.width * 10)
            {
                graphics.DrawLine(0xFF000000, i, coord.yMin, i, coord.yMax, 3);
            }
            for (int i = coord.yMin; i <= coord.yMax; i += coord.height * 20)
            {
                graphics.DrawLine(0xFF000000, coord.xMin, i, coord.xMax, i, 3);
            }
        }
        public void Update(GameEngine engine)
        {
            if (figure == null)
            {
                figure = ChooseFigure();
            }
            if (figure.IsRun)
            {
                figure.Update(engine);
            }
            else
            {
                for (int i = 0; i < coord.numberCellHeigh; i++)
                {
                    for (int j = 0; j < coord.numberCellWidth ; j++)
                    {
                        if (fieldGrid[j, i] == 0)
                        {
                            break;
                        }
                        if (fieldGrid[j, i] == 1 && j == coord.numberCellWidth - 1)
                        {
                            _score++;
                            for (int y = i; y >= 0; y--)
                            {
                                for (int x = 0; x < coord.numberCellWidth; x++)
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
                figure = ChooseFigure();
            }
        }
        private IGameObject ChooseFigure()
        {
            IGameObject obj = null;
            int chooseFigure = rnd.Next(0, 7);
            switch (chooseFigure)
            {
                case 0:
                obj = new LineFigure(coord.xMin, coord.yMin, coord.width, coord.height, _speed, ref fieldGrid);
                    break;
                case 1:
                    obj = new RightLFigure(coord.xMin, coord.yMin, coord.width, coord.height, _speed, ref fieldGrid);
                    break;
                case 2:
                    obj = new LeftLFigure(coord.xMin, coord.yMin, coord.width, coord.height, _speed, ref fieldGrid);
                    break;
                case 3:
                    obj = new SquareFigure(coord.xMin, coord.yMin, coord.width, coord.height, _speed, ref fieldGrid);
                    break;
                case 4:
                    obj = new TFigure(coord.xMin, coord.yMin, coord.width, coord.height, _speed, ref fieldGrid);
                    break;
                case 5:
                    obj = new ThunderFigure(coord.xMin, coord.yMin, coord.width, coord.height, _speed, ref fieldGrid);
                    break;
                case 6:
                    obj = new ZFigure(coord.xMin, coord.yMin, coord.width, coord.height, _speed, ref fieldGrid);
                    break;
            }
            return obj;
        }
    }
}

