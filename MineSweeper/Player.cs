using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    class Player
    {
        public string Name { get; set; }
        public int NumberOfTurns { get; set; }

        public Player(string name)
        {
            Name = name;
        }

        public bool HasPlayerWon(Grid grid)
        {
            return grid.SafeCellCount == NumberOfTurns ? false : true;
        }
    }
}
