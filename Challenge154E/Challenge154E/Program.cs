using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * -------------------------------------------------------------------------------------------------------------
 * File name: Challenge154E.sln<br/>
 * Project name: Challenge154E.cs<br/>
 * -------------------------------------------------------------------------------------------------------------
 * Creator:   Patrick Sullivan, sullivanpatrickjohn@gmail.com<br/>
 * Course:  Daily Programmer Challenge 154 (Easy)<br/>
 * http://www.reddit.com/r/dailyprogrammer/comments/217klv/4242014_challenge_154_easy_march_madness_brackets/
 * Creation Date: 27 March 2014<br/>
 * -------------------------------------------------------------------------------------------------------------
 */



namespace Challenge154E
{
    class Program
    {
        static void Main(string[] args)
        {

           	char[] OpeningBrackets = { '(', '[', '{' };
	        char[] ClosingBrackets = { ')', ']', '}' };		
		    //string InputString = "((your[drink {remember to}]) ovaltine)";
            string InputString = "[can {and it(it (mix) up ) } look silly]";
            string OrderedString = "";  // properly assembled string

            int LastOpenBracket = 0;        // holds index of the last open bracket in the input string
            int FirstCloseBracket = 0;      // holds index of the first close bracket in the input string

            int Range = 0;

            while (LastOpenBracket > -1)
            {
                LastOpenBracket = InputString.LastIndexOfAny(OpeningBrackets); // find the last open bracket in string
                FirstCloseBracket = InputString.IndexOfAny(ClosingBrackets);   // find the first closing bracket in string


                // calculate substring range
                Range = FirstCloseBracket - LastOpenBracket + 1;

                // escape loop when there are no more opening brackets
                if (LastOpenBracket < 0)
                    break;

                // leading space to prevent substrings from being mashed together
                OrderedString += " ";

                // add substring to ordered string and trim out brackets and leading/trailing whitespace
                OrderedString += InputString.Substring(LastOpenBracket, Range).Trim().Trim(OpeningBrackets).Trim(ClosingBrackets);
                
                // test output the ordered string
                Console.WriteLine("Ordered String: " + OrderedString);

                // remove substring from the original input string
                InputString = InputString.Remove(LastOpenBracket, Range);

                // test output the original input string
                Console.WriteLine("Input String: " + InputString);
            } 

            // halt screen until keypress
            Console.ReadLine();


        }
    }
}
