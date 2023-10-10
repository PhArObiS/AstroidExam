using System;

namespace AstroidExam
{
    internal class Program
    {
        const int Width = 20;
        const int Height = 30;

        static int[,] gameGrid = new int[Height, Width];
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            PopulateGameGrid();
            DisplayMineralPercentages("Mineral % before robots");
            PlaceRobots();
            DisplayGameGrid();
            DisplayMineralPercentages("Mineral % after robots");
        }

        static void PopulateGameGrid()
        {
            int gouffreCounter = 0;

            for (int i = 0; i < Height; i++)
            {
                for (int y = 0; y < Width; y++)
                {
                    gouffreCounter++;
                    int random = rnd.Next(0, 100);

                    if (gouffreCounter == 5)
                    {
                        gameGrid[i, y] = 0;
                        gouffreCounter = 0;
                    }
                    else if (random < (int)Minerals.Iron)
                    {
                        gameGrid[i, y] = 1;
                    }
                    else if (random < (int)Minerals.Iron + (int)Minerals.Copper)
                    {
                        gameGrid[i, y] = 2;
                    }
                    else if (random < (int)Minerals.Iron + (int)Minerals.Copper + (int)Minerals.Cobalt)
                    {
                        gameGrid[i, y] = 3;
                    }
                    else if (random < (int)Minerals.Iron + (int)Minerals.Copper + (int)Minerals.Cobalt + (int)Minerals.Silver)
                    {
                        gameGrid[i, y] = 4;
                    }
                    else
                    {
                        gameGrid[i, y] = 5;
                    }
                }
            }
        }

        static void DisplayGameGrid()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int y = 0; y < Width; y++)
                {
                    switch (gameGrid[i, y])
                    {
                        case 0:
                            Console.Write("  ");
                            break;
                        case 1:
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write("I ");
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("C ");
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("T ");
                            break;
                        case 4:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("S ");
                            break;
                        case 5:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("G ");
                            break;
                        case 6:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("R ");
                            break;
                    }
                }
                Console.WriteLine();
                Console.ResetColor();
            }
        }

        static void PlaceRobots()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int y = 0; y < Width; y++)
                {
                    if (gameGrid[i, y] != 5 && gameGrid[i, y] != 0)
                    {
                        if (i > 0 && gameGrid[i - 1, y] == 5 ||
                            y > 0 && gameGrid[i, y - 1] == 5 ||
                            y < Width - 1 && gameGrid[i, y + 1] == 5 ||
                            i < Height - 1 && gameGrid[i + 1, y] == 5)
                        {
                            gameGrid[i, y] = 6;
                        }
                    }
                }
            }
        }

        static void DisplayMineralPercentages(string message)
        {
            int[] counts = new int[7];
            double total = Height * Width;

            for (int i = 0; i < Height; i++)
            {
                for (int y = 0; y < Width; y++)
                {
                    counts[gameGrid[i, y]]++;
                }
            }

            Console.WriteLine("\n" + message);
            Console.WriteLine("Iron: " + counts[1] * 100 / total + "%");
            Console.WriteLine("Copper: " + counts[2] * 100 / total + "%");
            Console.WriteLine("Cobalt: " + counts[3] * 100 / total + "%");
            Console.WriteLine("Silver: " + counts[4] * 100 / total + "%");
            Console.WriteLine("Gold: " + counts[5] * 100 / total + "%");
            Console.WriteLine("Robots: " + counts[6] * 100 / total + "%");
            Console.WriteLine("Gouffre: " + counts[0] * 100 / total + "%\n");
        }
    }

    enum Minerals
    {
        Iron = 50,
        Copper = 20,
        Cobalt = 15,
        Silver = 10,
        Gold = 5
    }
}
