using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {




            // On running the game the user picks the size of the cave by entering a number N. 
            // This creates a cave NxN in size. N must be 10 to 20 in size.

            // Entrance: Only 1 of the rooms must be an entrance/exit point. 
            // This is where the player controlled hero spawns and can choose to leave the cave to end it.

            // Wumpus: 15% of the rooms must spawn a Wumpus. (A monster your hero seeks to slay). 
            // So if you have 100 rooms, 15 of them will spawn a Wumpus.

            // Pit Trap: 5% of the rooms must be a pit trap. 
            // If you walk into this room you fall to your doom. (And the game is over)

            // Gold: 15% of the rooms must have a gold to loot. 

            // Weapon: 15% of the rooms must have a weapon on the ground for the player to pick up to use for slaying monsters.

            // Empty: The remainder of rooms not assigned one of the above will be empty.

        }
    }
}
