using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcomSquadGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<NonSoldier> nonSoldiers = new List<NonSoldier>();
            nonSoldiers.Add(new NonSoldier(400, "", "Drone"));
            nonSoldiers.Add(new NonSoldier(500, "", "Sectoid"));
            nonSoldiers.Add(new NonSoldier(1000, "", "Floater"));
            nonSoldiers.Add(new NonSoldier(1000, "", "EXALT Medic"));
            nonSoldiers.Add(new NonSoldier(1100, "", "Thin Man"));
            nonSoldiers.Add(new NonSoldier(1200, "", "EXALT Operative"));
            nonSoldiers.Add(new NonSoldier(1400, "", "EXALT Sniper"));
            nonSoldiers.Add(new NonSoldier(1500, "", "EXALT Elite Medic"));
            nonSoldiers.Add(new NonSoldier(2200, "", "Muton"));
            nonSoldiers.Add(new NonSoldier(2200, "", "Seeker"));
            nonSoldiers.Add(new NonSoldier(2700, "", "Sectoid Commander"));
            nonSoldiers.Add(new NonSoldier(2900, "", "Muton Elite"));
            nonSoldiers.Add(new NonSoldier(2900, "", "EXALT Heavy"));
            nonSoldiers.Add(new NonSoldier(3000, "", "Heavy Floater"));
            nonSoldiers.Add(new NonSoldier(3000, "", "Chryssalid"));
            nonSoldiers.Add(new NonSoldier(3000, "", "EXALT Elite Operative"));
            nonSoldiers.Add(new NonSoldier(3200, "", "Mechtoid"));
            nonSoldiers.Add(new NonSoldier(3200, "", "EXALT Elite Sniper"));
            nonSoldiers.Add(new NonSoldier(3600, "", "EXALT Elite Heavy"));
            nonSoldiers.Add(new NonSoldier(4000, "", "Muton Berserker"));
            nonSoldiers.Add(new NonSoldier(5500, "", "Cyberdisc"));
            nonSoldiers.Add(new NonSoldier(10500, "", "Ethereal"));

            Console.WriteLine("Maximum points in squad: ");
            int maxPoints = int.Parse(Console.ReadLine());

            RandomSquadGenerator randomSquadGenerator = new RandomSquadGenerator(nonSoldiers, maxPoints: maxPoints);

            Squad randomSquad = randomSquadGenerator.GenerateRandomSquad(1000000);

            foreach (Unit unit in randomSquad.Units)
            {
                System.Console.WriteLine(unit.Points + "\t" + unit.Type);
            }

            System.Console.WriteLine("Total:\t" + randomSquad.Points);
            System.Console.ReadKey();
        }
    }
}
