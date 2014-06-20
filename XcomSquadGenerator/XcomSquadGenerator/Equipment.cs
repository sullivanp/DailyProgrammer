using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcomSquadGenerator
{
    class Equipment
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

        public string type
        {
            get;
            set;
        }

        public bool UsableByRookie
        {
            get;
            set;
        }

        public bool UsableByAssault
        {
            get;
            set;
        }

        public bool UsableByHeavy
        {
            get;
            set;
        }

        public bool UsableBySniper
        {
            get;
            set;
        }

        public bool UsableBySupport
        {
            get;
            set;
        }

        public bool UsableByMecTrooper
        {
            get;
            set;
        }

        public Equipment(int points, string name)
        {
            Name = name;
            Points = points;
        }
    }
}
