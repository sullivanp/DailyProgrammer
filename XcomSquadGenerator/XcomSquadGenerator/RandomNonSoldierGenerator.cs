using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcomSquadGenerator
{
    class RandomNonSoldierGenerator
    {
        private List<NonSoldier> nonSoldiers;

        private Random rng;

        /*
        public NonSoldier RandomNonSoldier
        {
            get
            {
                int unitIndex = rng.Next(nonSoldiers.Count);
                return nonSoldiers[unitIndex];
            }
            private set
            {
                RandomNonSoldier = value;
            }
        }
        */

        public RandomNonSoldierGenerator(List<NonSoldier> nonSoldiers)
        {
            this.rng = new Random();
            this.nonSoldiers = nonSoldiers;
        }

        public NonSoldier GenerateRandomNonSoldier()
        {
            int unitIndex = this.rng.Next(nonSoldiers.Count);
            return nonSoldiers[unitIndex];
        }
    }
}
