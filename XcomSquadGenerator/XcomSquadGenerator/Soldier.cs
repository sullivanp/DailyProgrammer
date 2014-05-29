using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcomSquadGenerator
{
    class Soldier : Unit
    {
        public string SoldierClass
        {
            get;
            set;
        }

        public PrimaryWeapon PrimaryWeapon
        {
            get;
            set;
        }

        public SecondaryWeapon SecondaryWeapon
        {
            get;
            set;
        }

        public Item Item
        {
            get;
            set;
        }

        public GeneMod GeneMod
        {
            get;
            set;
        }

        public Soldier(int points, string name, string type, string soldierClass) : base(points, name, type, soldierClass) {}
    }
}
