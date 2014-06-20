/**
 * Author:  Hal Norwood <justhal@gmail.com>
 * Date:    29 March 2014
 * Spec:    http://www.reddit.com/r/dailyprogrammer/comments/13hmz3/11202012_challenge_113_easy_stringtype_checking/
 * Name:    Reddit Daily Programmer #113, Easy String Type Checking
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyProgrammer002
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input? ");
            String input = Console.ReadLine();
            Console.Write("Type: ");
            Console.Write(inferType(input));
        }

        static private String inferType(String input)
        {
            const String TEXT = "text";
            const String INTEGER = "int";
            const String FLOATING_POINT = "float";
            const String DATE = "date";
            const Char DECIMAL_POINT = '.';
            const Char DATE_SEPARATOR = '-';
            const Char POSITIVE = '+';
            const Char NEGATIVE = '-';

            String type = TEXT;
            bool numeric = true;
            int decimalPoints = 0;
            int dateParts = 0;
            bool sign = false;
            bool start = true;

            for (int index = 0; index != input.Length; index++ )
            {
                if(start && (input[index] == POSITIVE || input[index] == NEGATIVE))
                {
                    start = false;
                    sign = true;
                }
                
                if(input[index] < '0' || input[index] > '9')
                {
                    start = false;
                    numeric = false;
                }
                
                if(input[index] == DECIMAL_POINT)
                {
                    start = false;
                    decimalPoints++;
                }
            }

            return type;
        }
    }
}
