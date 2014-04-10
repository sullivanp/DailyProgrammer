using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


/**
* -------------------------------------------------------------------------------------------------------
* File name: Challenge113E.sln
* Project name: Challenge113E.cs
* -------------------------------------------------------------------------------------------------------
* Creator: Patrick Sullivan, sullivanpatrickjohn@gmail.com
* Course: Daily Programmer
* http://www.reddit.com/r/dailyprogrammer/comments/13hmz3/11202012_challenge_113_easy_stringtype_checking/
* Creation Date: 29 Mar 2014
* ------------------------------------------------------------------------------------------------------
*/

namespace Challenge113E
{
    class Program
    {
        static void Main(string[] args)
        {

            string Expression = "^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\\d\\d$";
                                        // regular expression for verifying dates
            string UserInput;           // string value entered by user
            string DataType = "";       // data type of the string value
            int ParseInt;               // result of the int tryparse, unused
            float ParseFloat;           // result of the float tryparse, unused
           
            // get string input from user
            Console.Write("Enter a string: ");
            UserInput = Console.ReadLine();

            // test whether string contains an integer value
            if(Int32.TryParse(UserInput, out ParseInt))
            {
                DataType = "int";
            }
            // test whether string contains a date value
            else if(Regex.IsMatch(UserInput, Expression))
            {
                DataType = "date";
            }
            // test whether string contains a float value
            else if(float.TryParse(UserInput, out ParseFloat))
            {
                DataType = "float";
            }
            // if no other conditions apply, string is text
            else
            {
                DataType = "text";
            }

            // print results to screen
            Console.WriteLine("Data type is: " + DataType);
            Console.ReadLine(); // halt until user keypress
        }
    }
}
