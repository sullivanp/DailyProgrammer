using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcomSquadGenerator
{
    class Unit
    {
        public int Points
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        public string SubType
        {
            get;
            set;
        }

        public Unit(int points, string name, string type, string subType = "")
        {
            Points = points;
            Name = name;
            Type = type;
            SubType = subType;
        }
    }
}
