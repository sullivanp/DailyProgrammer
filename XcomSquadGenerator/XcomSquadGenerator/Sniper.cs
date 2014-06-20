using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcomSquadGenerator
{
    class Sniper : Soldier
    {
        public Sniper(int points, string name, string type, string soldierClass) : base(points, name, "Soldier", "Sniper") {}
    }
}
