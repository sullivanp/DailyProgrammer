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
            const int NUMBER_OF_GAMES = 10;
            int gamesPlayed = 0;
            int playerWins = 0;
            int computerWins = 0;
            int ties = 0;

            for (gamesPlayed = 0; gamesPlayed != NUMBER_OF_GAMES; gamesPlayed++)
            {
                Console.Write("Player Picks: ");
                do
                {
                    String moveInput = Console.ReadLine().ToLower();
                    moveInput = moveInput.Trim();
                    for (int i = 0; i != moves.Length; i++)
                    {
                        if (moves[i].ToLower().Trim() == moveInput)
                        {
                            playerMoveIndex = i;
                            break;
                        }
                        else if(moveInput == "quit" || moveInput == "exit" || moveInput == "q" || moveInput == "x" || moveInput == "e" || moveInput == "")
                        {
                            playerMoveIndex = -2;
                        }
                    }
                    if (playerMoveIndex == -1)
                    {
                        Console.WriteLine("Invalid move.");
                    }
                } while (playerMoveIndex == -1);

                if(playerMoveIndex == -2)
                {
                    Console.WriteLine();
                    break;
                }

                computerMoveIndex = rng.Next(moves.Length);

                Console.Write("Computer Picks: ");
                Console.WriteLine(moves[computerMoveIndex]);
                Console.WriteLine();

                if (computerMoveIndex == playerMoveIndex)
                {
                    Console.WriteLine("Both players picked " + moves[computerMoveIndex].ToLower() + ", so the result is a tie.");
                    ties++;
                }
                else if (beats[playerMoveIndex, computerMoveIndex] != "")
                {
                    Console.Write(moves[playerMoveIndex] + " " + beats[playerMoveIndex, computerMoveIndex] + " " + moves[computerMoveIndex].ToLower());
                    Console.Write(".  Player wins!");
                    playerWins++;
                }
                else
                {
                    Console.Write(moves[computerMoveIndex] + " " + beats[computerMoveIndex, playerMoveIndex] + " " + moves[playerMoveIndex].ToLower());
                    Console.Write(".  Computer wins!");
                    computerWins++;
                }

                Console.WriteLine();
            }

            if (gamesPlayed == 0)
            {
                Console.WriteLine("Total games played: 0");
                Console.WriteLine("Computer wins: 0 (0%)");
                Console.WriteLine("Player wins: 0 (0%)");
                Console.WriteLine("Ties: 0 (0%)");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Total games played: " + gamesPlayed);
                Console.Write("Computer wins: " + computerWins);
                Console.WriteLine(" (" + 100 * Math.Round((double)((double)computerWins / (double)gamesPlayed), 1) + "%)");
                Console.Write("Player wins: " + playerWins);
                Console.WriteLine(" (" + 100 * Math.Round((double)((double)playerWins / (double)gamesPlayed), 1) + "%)");
                Console.Write("Ties: " + ties);
                Console.WriteLine(" (" + 100 * Math.Round((double)((double)ties / (double)gamesPlayed), 1) + "%)");
                Console.WriteLine();
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
