using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcomSquadGenerator
{
    class Squad : List<Unit>
    {
        public int Points
        {
            get;
            private set;
        }
        
        public int Size
        {
            get;
            private set;
        }

        public Unit [] Units;

        public Squad()
        {
            Points = 0;
            Size = 0;
            Units = new Unit[6];
            for(int i = 0; i != 6; i++)
            {
                Units[i] = null;
            }
        }

        public bool AddUnit(Unit unit)
        {
            bool success = false;

            for(int i = 0; i != 6; i++)
            {
                if(Units[i] == null)
                {
                    Units[i] = unit;
                    Points += unit.Points;
                    Size++;
                    success = true;
                    break;
                }
            }

            return success;
        }

        public string ToString()
        {
            string squad = "";
            return squad;
        }
    }
}
