using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    class HitMineException : Exception
    {
        public HitMineException(string message)
            : base(message) { }
    }
}
