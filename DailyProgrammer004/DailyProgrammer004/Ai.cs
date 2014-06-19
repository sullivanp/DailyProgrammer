using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyProgrammer004
{
    class Ai
    {
        private int [] playerMoves = {0, 0, 0, 0, 0};
        
        public void playerMove(int move)
        {
            playerMoves[move]++;
        }
    }
}
