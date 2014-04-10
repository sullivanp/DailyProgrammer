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
            bool validScore = false;
            int score = 0;

            while(score != -1)
            {
                Console.Write("Enter score: ");
                score = int.Parse(Console.ReadLine());
                if(score == -1)
                {
                    break;
                }
            
                validScore = IsValidScore(score);

                if(validScore)
                {
                    Console.WriteLine("Valid Score");
                } else
                {
                    Console.WriteLine("Invalid Score");
                }
            }
            Console.ReadKey();
        }

        public static bool IsValidScore(int score)
        {
            bool valid = false;

            const int FIELD_GOAL = 3;
            const int TOUCHDOWN = 6;
            const int TOUCHDOWN_EXTRA_POINT = 7;
            const int TOUCHDOWN_TWO_POINT_CONVERSION = 8;

            if(score == 0)
            {
                valid = true;
            }
            else if (score < 0)
            {
                valid = false;
            }
            else if (IsValidScore(score - FIELD_GOAL))
            {
                valid = true;
            }
            else if (IsValidScore(score - TOUCHDOWN))
            {
                valid = true;
            }
            else if (IsValidScore(score - TOUCHDOWN_EXTRA_POINT))
            {
                valid = true;
            }
            else if(IsValidScore(score - TOUCHDOWN_TWO_POINT_CONVERSION))
            {
                valid = true;
            }
            else
            {
                valid = false;
            }

            return valid;
        }
    }
}
