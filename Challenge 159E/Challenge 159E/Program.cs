using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_159E
{
    class Program
    {
        static void Main(string[] args)
        {


            int UserChoice;             // stores user choice, between 1-5
            int ComputerChoice;         // stores random computer selection, between 1-5


            int NumPlayerWins = 0;    // tallies up number of player victories
            int NumComputerWins = 0;  // tallies up number of computer victories
            int NumRoundsPlayed = 0;

            
            Random Rand = new Random();

            string[] Moveset = new string[] { "Rock", "Paper", "Scissors", "Lizard", "Spock" };

            do
            {
                Console.WriteLine("Enter the number of your chosen move:");
                Console.WriteLine("1. Rock\n" +
                                  "2. Paper\n" +
                                  "3. Scissors\n" +
                                  "4. Lizard\n" +
                                  "5. Spock\n");

                UserChoice = int.Parse(Console.ReadLine());     // get user choice
                ComputerChoice = Rand.Next(1, 5);               // get computer choice

                // display user choice
                Console.WriteLine("Player Picks:\t " + Moveset[UserChoice - 1]);

                // display computer choice
                Console.WriteLine("Computer Picks:\t " + Moveset[ComputerChoice - 1]);

                //display result and winner
                Console.WriteLine(DetermineWinner(UserChoice, ComputerChoice));

                NumRoundsPlayed++;

                if (DetermineWinner(UserChoice, ComputerChoice).Contains("Computer Wins!"))
                    NumComputerWins++;
                else if (DetermineWinner(UserChoice, ComputerChoice).Contains("Player Wins!"))
                    NumPlayerWins++;


                Console.WriteLine("\nRunning Statistics:");
                Console.WriteLine("Rounds Played:\t" + NumRoundsPlayed);
                Console.WriteLine("Player Wins:\t" + NumPlayerWins);
                Console.WriteLine("Computer Wins:\t" + NumComputerWins);



                Console.WriteLine("\nPress 'Enter' to continue.");
                Console.ReadLine(); // halt until user keypress
                Console.Clear();

            } while (UserChoice > 0 && UserChoice < 6);
        }



      


        public static string DetermineWinner(int UserChoice, int ComputerChoice)
        {
            string Result = "\n";

            switch(UserChoice)
            {
                case 1: // user chooses Rock
                    switch(ComputerChoice)
                    {
                        case 1: Result += "Tie!  Match is a draw!";
                            break;
                        case 2: Result += "Paper Covers Rock! Computer Wins!";
                            break;
                        case 3: Result += "Rock Crushes Scissors! Player Wins!";
                          
                            break;
                        case 4: Result += "Rock Crushes Lizard! Player Wins!";
                            break;
                        case 5: Result += "Spock Vaporizes Rock! Computer Wins!";
                            break;
                    }
                    break;
                case 2: // user chooses Paper
                    switch (ComputerChoice)
                    {
                        case 1: Result += "Paper Covers Rock! Player Wins!";
                            break;
                        case 2: Result += "Tie! Match is a draw!";
                            break;
                        case 3: Result += "Scissors Cuts Paper! Computer Wins!";
                            break;
                        case 4: Result += "Lizard Eats Paper!  Computer Wins!";
                            break;
                        case 5: Result += "Paper Disproves Spock!  Player Wins!";
                            break;
                    }
                    break;
                case 3: // user chooses Scissors
                    switch (ComputerChoice)
                    {
                        case 1: Result += "Rock Crushes Scissors! Computer Wins!";
                            break;
                        case 2: Result += "Scissors Cuts Paper! Player Wins!";
                            break;
                        case 3: Result += "Tie!  Match is a draw!";
                            break;
                        case 4: Result += "Scissors Decapitates Lizard! Player Wins!";
                            break;
                        case 5: Result += "Spock Smashes Scissors! Computer Wins!";
                            break;
                    }
                    break;
                case 4: // user chooses Lizard
                    switch (ComputerChoice)
                    {
                        case 1: Result += "Rock Crushes Lizard! Computer Wins!";
                            break;
                        case 2: Result += "Lizard Eats Paper! Player Wins!";
                            break;
                        case 3: Result += "Scissors Decapitate Lizard! Computer Wins!";
                            break;
                        case 4: Result += "Tie! Match is a draw!";
                            break;
                        case 5: Result += "Lizard Poisons Spock! Player Wins!";
                            break;
                    }
                    break;
                case 5: // user chooses Spock
                    switch (ComputerChoice)
                    {
                        case 1: Result += "Spock Vaporizes Rock!  Player Wins!";
                            break;
                        case 2: Result += "Paper Disproves Spock! Computer Wins!";
                            break;
                        case 3: Result += "Spock Smashes Scissors! Player Wins!";
                            break;
                        case 4: Result += "Lizard Poisons Spock! Computer Wins!";
                            break;
                        case 5: Result += "Tie! Match is a draw!";
                            break;
                    }
                    break;
            }

            return Result;

        }



    }
}
