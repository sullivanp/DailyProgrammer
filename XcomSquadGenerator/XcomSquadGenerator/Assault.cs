﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcomSquadGenerator
{
    class Assault : Soldier
    {
        public Assault(int points, string name) : base(points, name, "Soldier", "Assault") {}
    }
}
