using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcomSquadGenerator
{
    class RandomSquadGenerator
    {
        private RandomUnitGenerator randomUnitGenerator;

        private int minSquadSize;
        private int maxSquadSize;
        private int minPoints;
        private int maxPoints;

        public RandomSquadGenerator(List<NonSoldier> nonSoldiers, int minSquadSize = 1, int maxSquadSize = 6, int minPoints = 400, int maxPoints = 1000000)
        {
            this.randomUnitGenerator = new RandomUnitGenerator(new RandomSoldierGenerator(), new RandomNonSoldierGenerator(nonSoldiers));
            this.minSquadSize = minSquadSize;
            this.maxSquadSize = maxSquadSize;
            this.minPoints = minPoints;
            this.maxPoints = maxPoints;
        }

        public Squad GenerateRandomSquad(int tries)
        {
            Squad randomSquad = new Squad();
            bool done = false;
            int tryNum = 0;

            do
            {
                for (int i = 0; i != this.maxSquadSize; i++)
                {
                    if (maxPoints - randomSquad.Points < 400)
                    {
                        continue;
                    }
                    Unit unit;
                    int triesLeft = 1000000;
                    do
                    {
                        unit = randomUnitGenerator.GenerateRandomUnit();
                    } while (unit.Points <= maxPoints && triesLeft-- != 0);
                    randomSquad.AddUnit(unit);
                }
                if (randomSquad.Points <= maxPoints)
                {
                    done = true;
                    break;
                }
                else
                {
                    tryNum++;
                }
                if (tryNum == tries)
                {
                    randomSquad = new Squad();
                    done = true;
                }
            } while (!done);

            return randomSquad;
        }
    }
}
