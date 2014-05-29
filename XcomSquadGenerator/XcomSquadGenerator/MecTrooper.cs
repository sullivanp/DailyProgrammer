using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcomSquadGenerator
{
    class MecTrooper : Unit
    {
        public MecSuit MecSuit
        {
            get;
            set;
        }

        public MecTrooper(int points, string name, string type, string subType = "") : base(points, name, "Soldier", "MEC Trooper") {}
    }
}
