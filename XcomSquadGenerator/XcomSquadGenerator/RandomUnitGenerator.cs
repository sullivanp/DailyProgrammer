using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcomSquadGenerator
{
    class RandomUnitGenerator
    {
        private RandomSoldierGenerator randomSoldierGenerator;
        private RandomNonSoldierGenerator randomNonSoldierGenerator;

        /*
        public Soldier RandomSoldier
        {
            get
            {
                return null;
            }
            private set
            {
                RandomSoldier = value;
            }
        }

        public NonSoldier RandomNonSoldier
        {
            get
            {
                return randomNonSoldierGenerator.RandomNonSoldier;
            }
        }
        */

        public RandomUnitGenerator(RandomSoldierGenerator randomSoldierGenerator, RandomNonSoldierGenerator randomNonSoldierGenerator)
        {
            this.randomNonSoldierGenerator = randomNonSoldierGenerator;
            this.randomSoldierGenerator = randomSoldierGenerator;
        }

        public Unit GenerateRandomUnit()
        {
            return randomNonSoldierGenerator.GenerateRandomNonSoldier();
        }
    }
}
