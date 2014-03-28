using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**
 * -------------------------------------------------------------------------------------------------
 * File name:       Challenge147E.sln<br/>
 * Project name:    Challenge147E.cs<br/>
 * -------------------------------------------------------------------------------------------------
 * Creator:         Patrick Sullivan, sullivanpatrickjohn@gmail.com     
 * Course:          Daily Programmer
 * http://www.reddit.com/r/dailyprogrammer/comments/1undyd/010714_challenge_147_easy_sport_points/
 * Creation Date:   27 March 2014
 * -------------------------------------------------------------------------------------------------
 */


namespace Challenge147E
{
    class Program
    {
        static void Main(string[] args)
        {

            bool ScoreValid = false;

            Console.Write("Enter a score: ");
            ScoreValid = VerifyScore(int.Parse(Console.ReadLine()));
                 
            Console.WriteLine("Valid Score: " + ScoreValid);
            Console.ReadLine();
	
        }

        public static bool VerifyScore(int Score)
        {

            int Quotient = Score / 3;
            int Remainder = Score % 3;
            bool ScoreValid = false;

            // if 3 divides evenly into the score without remainder, the score could be comprised of only field goals
            if (Remainder == 0 && Quotient > 0)
            {
                ScoreValid = true;
            }
            // if there is a remainder (1 or 2) then the score must include at least one touchdown to accomodate either
            // an extra point (1) or a two-point conversion (2).
            else if (Remainder != 0 && Quotient >= 2)
            {
                ScoreValid = true;
            }
            else
            {
                ScoreValid = false;
            }

            return ScoreValid;
        }
    }
}
