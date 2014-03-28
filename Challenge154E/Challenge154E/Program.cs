using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge154E
{
    class Program
    {
        static void Main(string[] args)
        {

           	char[] OpeningBrackets = { '(', '[', '{' };
	        char[] ClosingBrackets = { ')', ']', '}' };		
		    //string InputString = "((your[drink {remember to}]) ovaltine)";
            string InputString = "[racket for {brackets (matching) is a} computers]";
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
