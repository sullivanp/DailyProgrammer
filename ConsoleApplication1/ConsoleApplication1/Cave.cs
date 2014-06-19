using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Cave
    {
       
     
      




        public void GenerateRooms(int CaveSize)
        {

            // create a 2d array of null Rooms
            Room[,] Map = new Room[CaveSize + 2, CaveSize + 2];

            // populate rooms
            Map[0,0] = new Room();

            // if column = 0, wall
            // if row = 0, wall
            // if column = CaveSize + 1, wall
            // if row = CaveSize + 1, wall


            // iterate thru rows
            for(int r = 0;  r < Map.GetLength(0); r++)
            {
                // iterate thru columns
                for(int c = 0; c < Map.GetLength(1); c++)
                {
                    // is the current cell on a map edge?  if so, it's a wall.
                    if(r == 0 || c == 0 || c == (CaveSize + 1) || r == (CaveSize + 1))
                    {

                    }

                    Map[r, c] = new Room();


                }
            }


            int NumRooms = CaveSize * CaveSize;
            int WumpusRooms = (int)(NumRooms * .15);    // Wumpus: 15% of rooms
            int PitTrapRooms = (int)(NumRooms * .05);   // Pit Trap: 5% of rooms
            int GoldRooms = (int)(NumRooms * .15);      // Gold: 15% of rooms
            int WeaponRooms = (int)(NumRooms *.15);      // Weapon: 15% of rooms


            Random RandNum = new Random();
            List<int> RoomList = new List<int>(NumRooms);  // stores numbers already generated
            
            while (!(NumRooms == RoomList.Count))
            {
                // generate a random number
                int NewNum = RandNum.Next(NumRooms);
                
                // add number to RoomList if it is not already there
                if (!RoomList.Contains(NewNum))
                {
                    RoomList.Add(NewNum);
                }

            }
        }

            public Room CreateRoom(string RoomType)
            {
                Room NewRoom = new Room();
                return NewRoom;
            }

            



        }


    }
}
