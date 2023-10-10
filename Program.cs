using System.Runtime.ConstrainedExecution;

namespace AstroidExam
{
    internal class Program
    {
       

        static void Main(string[] args)
        {
            // **** 30x20 Game Table ******
            const int width = 30;
            const int height = 20;

            int[,] gameGrid = new int[height, width];

            Random rnd = new Random();

            void tableGrid()
            {
                int gouffre = 0;
                for (int i = 0; i < height; i++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        gouffre++;
                        int random = rnd.Next(0, 100);
                        if (gouffre == 5)
                        {
                            gameGrid[i, y] = 0;
                            gouffre = 0;
                        }
                        else if (random <= (int)Minerals.iron)
                        {
                            gameGrid[i, y] = 1;
                        }
                        else if (random <= (int)Minerals.iron + (int)Minerals.copper)
                        {
                            gameGrid[i, y] = 2;
                        }
                        else if (random <= (int)Minerals.iron + (int)Minerals.copper + (int)Minerals.Cobalt)
                        {
                            gameGrid[i, y] = 3;
                        }
                        else if (random <= (int)Minerals.iron + (int)Minerals.copper + (int)Minerals.Cobalt + (int)Minerals.silver)
                        {
                            gameGrid[i, y] = 4;
                        }
                        else if (random <= (int)Minerals.iron + (int)Minerals.copper + (int)Minerals.Cobalt + (int)Minerals.silver + (int)Minerals.gold)
                        {
                            gameGrid[i, y] = 5;
                        }
                    }
                }
                Console.WriteLine("");
            }

            void newTableGrid()
            {
                for (int i = 0; i < height; i++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        if (gameGrid[i, y] == 0)
                        {
                            Console.Write("  ");
                        }
                        else if (gameGrid[i, y] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write("I ");
                        }
                        else if (gameGrid[i, y] == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("C ");
                        }
                        else if (gameGrid[i, y] == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("T ");
                        }
                        else if (gameGrid[i, y] == 4)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("S ");
                        }
                        else if (gameGrid[i, y] == 5)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("G ");
                        }
                        else if (gameGrid[i, y] == 6)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("R ");
                        }
                    }
                    Console.WriteLine("");
                    Console.ResetColor();
                }
            }

            // Robot
            void robot()
            {
                for (int i = 0; i < height; i++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        if (gameGrid[i, y] != 5 && gameGrid[i, y] != 0)
                        {
                            if (i > 0 && gameGrid[i - 1, y] == 5)
                            {
                                gameGrid[i, y] = 6;
                            }
                            if (y > 0 && gameGrid[i, y - 1] == 5)
                            {
                                gameGrid[i, y] = 6;
                            }
                            if (y < height - 1 && gameGrid[i, y + 1] == 5)
                            {
                                gameGrid[i, y] = 6;
                            }
                            if (i < height - 1 && gameGrid[i + 1, y] == 5)
                            {
                                gameGrid[i, y] = 6;
                            }
                        }
                    }
                }
            }

            // Mineral % {iron = 50, copper = 20, cobalt =15, silver = 10, Gold = 5}
            void minerals(Func <string> message)
            {
                int iron = 0;
                int copper = 0;
                int cobalt = 0;
                int silver = 0;
                int gold = 0;
                int gouffre = 0;
                int robots = 0;
                int total = height * width;

                for (int i = 0; i < height; i++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        if (gameGrid[i, y] == 1)
                        {
                            iron++;
                        }
                        else if (gameGrid[i, y] == 2)
                        {
                            copper++;
                        }
                        else if (gameGrid[i, y] == 3)
                        {
                            cobalt++;
                        }
                        else if (gameGrid[i, y] == 4)
                        {
                            silver++;
                        }
                        else if (gameGrid[i, y] == 5)
                        {
                            gold++;
                        }
                        else if (gameGrid[i, y] == 6)
                        {
                            robots++;
                        }
                        else if (gameGrid[i, y] == 0)
                        {
                            gouffre++;
                        }
                    }
                }

                /*
               
                Console.WriteLine("");
                Console.WriteLine(message());
                Console.WriteLine("Iron: " + iron * 100 / total + "%");
                Console.WriteLine("Copper: " + copper * 100 / total + "%");
                Console.WriteLine("Cobalt: " + cobalt * 100 / total + "%");
                Console.WriteLine("Silver: " + silver * 100 / total + "%");
                Console.WriteLine("Gold: " + gold * 100 / total + "%");
                Console.WriteLine("Robots: " + robots * 100 / total + "%");
                Console.WriteLine("gouffre: " + gouffre * 100 / total + "%");
                Console.WriteLine("");
                */
               


            }



            tableGrid();
            minerals(() => "Mineral % before robots");
            robot();
            newTableGrid();
            minerals(() => "Mineral % after robots");

        }


    }

    enum Minerals
    {
        iron = 50,
        copper = 20,
        Cobalt = 15,
        silver = 10,
        gold = 5
    }
}