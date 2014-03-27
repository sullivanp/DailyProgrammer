using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyProgrammer147
{
    class Program
    {
        static void Main(string[] args)
        {
            const int FIELD_GOAL_WITH_TWO_POINT_CONVERSION = 8;
            bool validScore = false;

            Console.Write("Enter score: ");
            int score = int.Parse(Console.ReadLine());
            
            int remainder = score % FIELD_GOAL_WITH_TWO_POINT_CONVERSION;
            if(remainder == 0 || remainder == 3 || remainder == 6 || remainder == 7)
            {
                validScore = true;
            } else
            {
                validScore = false;
            }

            if(validScore)
            {
                Console.WriteLine("Valid Score");
            } else
            {
                Console.WriteLine("Invalid Score");
            }
            Console.ReadKey();
        }
    }
}
