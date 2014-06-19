using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyProgrammer002
{
    class RoomSquare
    {
        public Boolean EntranceExit
        {
            public get;
            public set;
        }

        public Boolean Wumpus
        {
            public get;
            public set;
        }

        public Boolean PitTrap
        {
            public get;
            public set;
        }

        public Boolean Gold
        {
            public get;
            public set;
        }

        public Boolean Weapon
        {
            public get;
            public set;
        }

        public Boolean Wall
        {
            public get;
            private set;
        }

        public Boolean Explored
        {
            public get;
            public set;
        }
        
        public Boolean Empty
        {
            public get
            {
                return !(EntranceExit || Wumpus || PitTrap || Gold || Weapon || Wall);
            }
        }

        public RoomSquare(Boolean entranceExit = false, Boolean wumpus = false,
            Boolean pitTrap = false, Boolean gold = false, Boolean weapon = false,
            Boolean wall = false, Boolean explored = false)
        {
            this.EntranceExit = entranceExit;
            this.Wumpus = wumpus;
            this.PitTrap = pitTrap;
            this.Gold = gold;
            this.Explored = explored;
        }

        public char ToChar()
        {
            if (Wall)
            {
                return '#';
            } else if (!Explored)
            {
                return '?';
            } else if (EntranceExit)
            {
                return '^';
            } else if (Wumpus)
            {
                return '&';
            } else if (PitTrap)
            {
                return '!';
            } else if (Weapon)
            {
                return 'W';
            } else if (Gold)
            {
                return '$';
            } else
            {
                return 'X';
            }
        }
    }
}
