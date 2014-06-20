using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcomSquadGenerator
{
    class Rookie : Soldier
    {
        public Rookie(int points, string name, string type) : base(points, name, "Soldier", "Rookie") {}
    }
}
