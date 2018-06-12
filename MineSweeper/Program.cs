using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("*********************");
            Console.WriteLine("*****MineSweeper*****");
            Console.WriteLine("*********************");
            Console.WriteLine("What's your name?");
            Console.WriteLine();

            string getName = Console.ReadLine();
            Player p1 = new Player(getName);
            Grid grid = new Grid();
            bool playGame = true;

            grid.PrintGrid(false);
            Console.WriteLine();

            do
            {
                grid.PrintGrid();
                Console.WriteLine("Select a cell, {0}", p1.Name);
                Console.Write("X Coordinate: ");
                bool xResult = int.TryParse(Console.ReadLine(), out int x);
                Console.Write("Y Coordinate: ");
                bool yResult = int.TryParse(Console.ReadLine(), out int y);

                if(yResult && xResult)
                {
                    try
                    {
                        if (!(grid.SelectCell(x, y)))
                        {
                            throw new HitMineException("You hit a mine!!");
                        }
                        else p1.NumberOfTurns++;
                    } catch(IndexOutOfRangeException)
                    {
                        Console.WriteLine("Coordinates are outside of the grid");
                        Console.WriteLine();
                    } catch(HitMineException e)
                    {
                        Console.WriteLine(e.Message);
                        break;
                    }
                }
                else
                {
                    continue;
                }

                if (!(p1.HasPlayerWon(grid)))
                {
                    Console.WriteLine("You win, {0}!!!", p1.Name);
                    break;
                }
                
            }
            while (playGame != false);

            grid.PrintGrid(false);
            Console.WriteLine("*********************");
            Console.WriteLine("*******GameOver******");
            Console.WriteLine("*********************");
            Console.ReadLine();
            
        }
    }
}
