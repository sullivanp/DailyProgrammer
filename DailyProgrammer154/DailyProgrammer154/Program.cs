/**
 * Author:  Hal Norwood <justhal@gmail.com>
 * Date:    27 March 2014
 * Spec:    http://www.reddit.com/r/dailyprogrammer/comments/217klv/4242014_challenge_154_easy_march_madness_brackets/
 * Name:    Reddit Daily Programmer #154, March Madness Brackets
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyProgrammer154
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder mutable = new StringBuilder(input);

            for (int index = 0; index != mutable.Length; index++)
            {
                if (input[index] == '(')
                {
                    mutable.Remove(index, 1);
                    Parenthesis(mutable);
                }
                else if (input[index] == '[')
                {
                    mutable.Remove(index, 1);
                    SquareBracket(mutable);
                }
                else if (input[index] == '{')
                {
                    mutable.Remove(index, 1);
                    CurlyBracket(mutable);
                }
            }
            
            Console.ReadKey();
        }

        public static void Parenthesis(StringBuilder input)
        {
            for(int index = 0; index != input.Length; index++)
            {
                if(input[index] == ')')
                {
                    Console.Write(input.ToString(0, index));
                    Console.Write(" ");
                } else if(input[index] == '(')
                {
                    input.Remove(index, 1);
                    Parenthesis(input);
                } else if(input[index] == '[')
                {
                    input.Remove(index, 1);
                    SquareBracket(input);
                } else if(input[index] == '{')
                {
                    input.Remove(index, 1);
                    CurlyBracket(input);
                }
            }
        }

        public static void SquareBracket(StringBuilder input)
        {
            for (int index = 0; index != input.Length; index++)
            {
                if (input[index] == ']')
                {
                    Console.Write(input.ToString(0, index));
                    Console.Write(" ");
                }
                else if (input[index] == '(')
                {
                    input.Remove(index, 1);
                    Parenthesis(input);
                }
                else if (input[index] == '[')
                {
                    input.Remove(index, 1);
                    SquareBracket(input);
                }
                else if (input[index] == '{')
                {
                    input.Remove(index, 1);
                    CurlyBracket(input);
                }
            }
        }

        public static void CurlyBracket(StringBuilder input)
        {
            for (int index = 0; index != input.Length; index++)
            {
                if (input[index] == '}')
                {
                    Console.Write(input.ToString(0, index));
                    Console.Write(" ");
                }
                else if (input[index] == '(')
                {
                    input.Remove(index, 1);
                    Parenthesis(input);
                }
                else if (input[index] == '[')
                {
                    input.Remove(index, 1); 
                    SquareBracket(input);
                }
                else if (input[index] == '{')
                {
                    input.Remove(index, 1);
                    CurlyBracket(input);
                }
            }
        }
    }
}
