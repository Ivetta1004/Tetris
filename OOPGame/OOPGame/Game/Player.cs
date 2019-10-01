using NConsoleGraphics;
using System;

namespace Tetris_OOPGame
{
    public class Player : IGameObject
    {
        private IGameObject figure;
        private FieldSize field = new FieldSize();
        private const uint fieldColor = 0xFF000000;
        private const uint figureColor = 0xFF0FFF00;
        private readonly int[,] fieldGrid;
        private Random rnd = new Random();
        internal bool gameIsOver = false;
        private int _score;
        internal int Score { get { return _score; } }  
        public bool IsRun { get; private set; }

        public Player() { }

        public Player(ConsoleGraphics graphics)
        {
            fieldGrid = new int[field.numberCellWidth, field.numberCellHeigh];
            for (int i = 0; i < field.numberCellWidth; i++)
            {
                for (int j = 0; j < field.numberCellHeigh; j++)
                {
                    fieldGrid[i, j] = 0;
                }
            }
        }

        public void Render(ConsoleGraphics graphics)
        {
            for (int i = 0; i < field.numberCellWidth; i++)
            {
                for (int j = 0; j < field.numberCellHeigh; j++)
                {
                    if (fieldGrid[i, j] == 1)
                    {
                        graphics.FillRectangle(figureColor, field.width * i + field.xMin, field.height * j +
                            field.yMin, field.width, field.height);
                        if (j == 0)
                        {
                            gameIsOver = true;
                        }
                    }
                }
            }
            figure?.Render(graphics);
            for (int i = field.xMin; i <= field.xMax; i += field.width * 10)
            {
                graphics.DrawLine(fieldColor, i, field.yMin, i, field.yMax, 3);
            }
            for (int i = field.yMin; i <= field.yMax; i += field.height * 20)
            {
                graphics.DrawLine(fieldColor, field.xMin, i, field.xMax, i, 3);
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
                for (int i = 0; i < field.numberCellHeigh; i++)
                {
                    for (int j = 0; j < field.numberCellWidth; j++)
                    {
                        if (fieldGrid[j, i] == 0)
                        {
                            break;
                        }
                        if (fieldGrid[j, i] == 1 && j == field.numberCellWidth - 1)
                        {
                            ++_score;
                            DeleteLine(i);
                        }
                    }
                }
                figure = ChooseFigure();
            }
        }

        private int[,] DeleteLine(int i)
        {
            for (int y = i; y >= 0; y--)
            {
                for (int x = 0; x < field.numberCellWidth; x++)
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
            return fieldGrid;
        }

        private IGameObject ChooseFigure()
        {
            IGameObject obj = null;
            int chooseFigure = rnd.Next(0, 7);
            switch (chooseFigure)
            {
                case 0:
                    obj = new LineFigure(fieldGrid);
                    break;
                case 1:
                    obj = new RightLFigure(fieldGrid);
                    break;
                case 2:
                    obj = new LeftLFigure(fieldGrid);
                    break;
                case 3:
                    obj = new SquareFigure(fieldGrid);
                    break;
                case 4:
                    obj = new TFigure(fieldGrid);
                    break;
                case 5:
                    obj = new ThunderFigure(fieldGrid);
                    break;
                case 6:
                    obj = new ZFigure(fieldGrid);
                    break;
            }
            return obj;
        }
    }
}

