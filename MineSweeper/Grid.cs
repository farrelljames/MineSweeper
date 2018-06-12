using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    class Grid
    {
        public string[,] cells;
        public string[,] mines;
        public int GridSize { get; }
        public int SafeCellCount { get; set; }


        public Grid()
            : this(5) { }


        public Grid(int gridSize)
        {
            GridSize = gridSize;
            cells = new string[GridSize, GridSize]; 
            mines = new string[GridSize, GridSize];
            Random rnd = new Random();

            //initialise grid
            for (var i = 0; i < gridSize; i++)
            {
                for(var x = 0; x < gridSize; x++)
                {
                    cells[i, x] = "O";
                    if (rnd.Next(1, 3) == 1)
                    {
                        mines[i, x] = "O";
                        SafeCellCount++;
                    }
                    else
                    {
                        mines[i, x] = "M";
                    }
                }
            }
        }

        public bool SelectCell(int x, int y)
        {
            /*
             * Checks if user selects is a mine.
             * Depending ont he outcome a boolean is returned
             * if false is returned the while loop found in main will
             * terminate
             */
             try
            {
                if (mines[x, y] == "M")
                {
                    return false;
                }
                else
                {
                    cells[x, y] = "X";
                    return true;
                }
            } catch(IndexOutOfRangeException e)
            {
                throw e;
            }
            
        }

        public void PrintGrid(bool standardGrid = true)
        {
            if(standardGrid)
            {
                for (var i = 0; i < GridSize; i++)
                {
                    for (var x = 0; x < GridSize; x++)
                    {
                        Console.Write(cells[i, x]);
                    }
                    Console.WriteLine();
                }
            } else
            {
                for (var i = 0; i < GridSize; i++)
                {
                    for (var x = 0; x < GridSize; x++)
                    {
                        Console.Write(mines[i, x]);
                    }
                    Console.WriteLine();
                }
            }
            
        }

    }
}
