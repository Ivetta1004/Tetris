using NConsoleGraphics;
using System;

namespace Tetris_OOPGame
{
    public delegate int Score();
    public class Player : IGameObject
    {
        private IGameObject figure;
        private FieldSize field = new FieldSize();
        private const uint fieldColor = 0xFF000000;
        private const uint figureColor = 0xFF0FFF00;
        private readonly int[,] fieldGrid;
        internal static int _score;
       // internal int Score { get { return _score; } private set { _score = value; } }     // fix without static
        private Random rnd = new Random();
        private readonly int _speed;
        public bool IsRun { get; private set; }
        // Score delegateScore;
        //  public event Score MyEvent;
        internal static bool gameIsOver = false;

        public Player(int score)
        {

            _score = score;
            //MyEvent = GetScore;
        }

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
            _speed = 3;

        }

        //internal int IncrementScore()
        //{

        //    return ++_score;

        //}

        //internal int GetScore()
        //{
        //    return _score;
        //}

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
                            // GetScore();
                            //IncrementScore();
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
                    obj = new LineFigure(_speed, fieldGrid);
                    break;
                case 1:
                    obj = new RightLFigure(_speed, fieldGrid);
                    break;
                case 2:
                    obj = new LeftLFigure(_speed, fieldGrid);
                    break;
                case 3:
                    obj = new SquareFigure(_speed, fieldGrid);
                    break;
                case 4:
                    obj = new TFigure(_speed, fieldGrid);
                    break;
                case 5:
                    obj = new ThunderFigure(_speed, fieldGrid);
                    break;
                case 6:
                    obj = new ZFigure(_speed, fieldGrid);
                    break;
            }
            return obj;
        }
    }
}

