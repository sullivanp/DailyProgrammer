/**
 * Author:  Hal Norwood <justhal@gmail.com>
 * Date:    27 March 2014
 * Spec:    http://www.reddit.com/r/dailyprogrammer/comments/1undyd/010714_challenge_147_easy_sport_points/
 * Name:    Reddit Daily Programmer #147, Easy Sports Points
 */

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
