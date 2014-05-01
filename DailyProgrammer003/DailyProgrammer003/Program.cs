/**
 * Author:  Hal Norwood <justhal@gmail.com>
 * Date:    01 May 2014
 * Spec:    http://www.reddit.com/r/dailyprogrammer/comments/23lfrf/4212014_challenge_159_easy_rock_paper_scissors/
 * Name:    Reddit Daily Programmer #159 Easy Rock Paper Scissors Lizard Spock
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyProgrammer003
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] moves =    {   "Rock",         "Paper",    "Scissors",     "Lizard",       "Spock"     };
            String [,] beats =  { //Rock            Paper       Scissors        Lizard          Spock
            /* Rock */          {   "",             "",         "crushes",      "crushes",      ""          }, 
            /* Paper */         {   "covers",       "",         "",             "",             "disproves" }, 
            /* Scissors */      {   "",             "cut",      "",             "decapitate",   ""          }, 
            /* Lizard */        {   "",             "eats",     "",             "",             "poisons"   }, 
            /* Spock */         {   "vaporizes",    "",         "smashes",      "",             ""          }};

            int playerMoveIndex = -1;
            int computerMoveIndex = -1;
            Random rng = new Random();

            Console.Write("Player Picks: ");
            do
            {
                String moveInput = Console.ReadLine().ToLower();
                moveInput = moveInput.Trim();
                for(int i = 0; i != moves.Length; i++)
                {
                    if(moves[i].ToLower().Trim() == moveInput)
                    {
                        playerMoveIndex = i;
                        break;
                    }
                }
                if (playerMoveIndex == -1)
                {
                    Console.WriteLine("Invalid move.");
                }
            } while(playerMoveIndex == -1);

            computerMoveIndex = rng.Next(moves.Length);

            Console.Write("Computer Picks: ");
            Console.WriteLine(moves[computerMoveIndex]);
            Console.WriteLine();

            if(computerMoveIndex == playerMoveIndex)
            {
                Console.WriteLine("Both players picked " + moves[computerMoveIndex].ToLower() + ", so the result is a tie.");
            } else if(beats[playerMoveIndex, computerMoveIndex] != "")
            {
                Console.Write(moves[playerMoveIndex] + " " + beats[playerMoveIndex, computerMoveIndex] + " " + moves[computerMoveIndex].ToLower());
                Console.Write(".  Player wins!");
            }
            else
            {
                Console.Write(moves[computerMoveIndex] + " " + beats[computerMoveIndex, playerMoveIndex] + " " + moves[playerMoveIndex].ToLower());
                Console.Write(".  Computer wins!");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
