using NConsoleGraphics;
using System;

namespace Tetris_OOPGame
{
    public class Player : IMovable
    {
        private const uint fieldColor = 0xFF000000;
        private const uint figureColor = 0xFF0FFF00;
        private readonly int[,] fieldGrid;
        private IMovable figure;
        private Random rnd = new Random();
        private GameScore game;
        public bool IsRun { get; private set; }

        public Player(ConsoleGraphics graphics, GameScore score)
        {
            game = score;
            fieldGrid = new int[FieldSize.numberCellWidth, FieldSize.numberCellHeigh];
            for (int i = 0; i < FieldSize.numberCellWidth; i++)
            {
                for (int j = 0; j < FieldSize.numberCellHeigh; j++)
                {
                    fieldGrid[i, j] = 0;
                }
            }
        }

        public void Render(ConsoleGraphics graphics)
        {
            for (int i = 0; i < FieldSize.numberCellWidth; i++)
            {
                for (int j = 0; j < FieldSize.numberCellHeigh; j++)
                {
                    if (fieldGrid[i, j] == 1)
                    {
                        graphics.FillRectangle(figureColor, FieldSize.width * i + FieldSize.xMin, FieldSize.height * j +
                            FieldSize.yMin, FieldSize.width, FieldSize.height);
                        if (j == 0)
                        {
                            game.GameIsOn = false;
                        }
                    }
                }
            }
            figure?.Render(graphics);
            for (int i = FieldSize.xMin; i <= FieldSize.xMax; i += FieldSize.width * 10)
            {
                graphics.DrawLine(fieldColor, i, FieldSize.yMin, i, FieldSize.yMax, 3);
            }
            for (int i = FieldSize.yMin; i <= FieldSize.yMax; i += FieldSize.height * 20)
            {
                graphics.DrawLine(fieldColor, FieldSize.xMin, i, FieldSize.xMax, i, 3);
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
                for (int i = 0; i < FieldSize.numberCellHeigh; i++)
                {
                    for (int j = 0; j < FieldSize.numberCellWidth; j++)
                    {
                        if (fieldGrid[j, i] == 0)
                        {
                            break;
                        }
                        if (fieldGrid[j, i] == 1 && j == FieldSize.numberCellWidth - 1)
                        {
                            ++game.Score;
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
                for (int x = 0; x < FieldSize.numberCellWidth; x++)
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

        private IMovable ChooseFigure()
        {
            IMovable obj = null;
            int chooseFigure = rnd.Next(3, 4);
            switch (chooseFigure)
            {
                case 0:
                    obj = new LineFigure(fieldGrid);
                    break;
                case 1:
                    obj = new RightLFigure(fieldGrid);
                    break;
                case 2:
                    obj = new LeftLFigure(fieldGrid, new LeftLFigure());
                    break;
                case 3:
                    obj = new SquareFigure(fieldGrid, new SquareFigure());
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

            //Water water = new Water(new LiquidWaterState());
            //water.Heat();
            //water.Frost();
            //water.Frost();

        }
    }
}

