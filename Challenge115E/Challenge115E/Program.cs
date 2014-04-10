using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
* -------------------------------------------------------------------------------------------------------
* File name: Challenge115E.sln
* Project name: Challenge115E.cs
* -------------------------------------------------------------------------------------------------------
* Creator: Patrick Sullivan, sullivanpatrickjohn@gmail.com
* Course: Daily Programmer
* http://www.reddit.com/r/dailyprogrammer/comments/15ul7q/122013_challenge_115_easy_guessthatnumber_game/
* Creation Date: 29 Mar 2014
* ------------------------------------------------------------------------------------------------------
*/

namespace Challenge115E
{
    class Program
    {
        static void Main(string[] args)
        {

            Random RandomNumber = new Random();
            int TargetNumber = RandomNumber.Next(100) + 1;      // generates a number between 1 and 100 (inclusive)
            string UserGuess;                                      // stores numbers input by user
            bool Exit = false;                                  // continues program loop until condition is true

            while (!Exit)
            {
                Console.Write("Guess a number between 1-100.  (Type 'Exit' to close the program): ");
                UserGuess = Console.ReadLine();  // get user input

                if (UserGuess.Equals("exit"))
                {
                    Exit = true;
                }
                else if (int.Parse(UserGuess) - TargetNumber > 0)   // user guess is above target number
                {
                    Console.WriteLine("\nWrong!  That number is above my number!  Guess again.");
                }
                else if (int.Parse(UserGuess) - TargetNumber < 0)   // user guess is below target number   
                {
                    Console.WriteLine("\nWrong!  That number is below my number!  Guess again.");
                }
                else if (int.Parse(UserGuess) == TargetNumber)                     
                {
                    Console.WriteLine("\nYou have correctly guessed the number!  Great jarb!");
                    Console.ReadLine(); // halt until user keypress
                    Exit = true;        // terminate while loop and exit the program
                }
            }

        }
    }
}
