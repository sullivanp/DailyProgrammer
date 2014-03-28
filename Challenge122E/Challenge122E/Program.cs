using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/**
 * -------------------------------------------------------------------------------------------------------
 * File name:       Challenge122E.sln<br/>
 * Project name:    Challenge122E.cs<br/>
 * -------------------------------------------------------------------------------------------------------
 * Creator:         Patrick Sullivan, sullivanpatrickjohn@gmail.com<br/>			           
 * Course:          Daily Programmer<br/>
 * http://www.reddit.com/r/dailyprogrammer/comments/1aih0v/031813_challenge_122_easy_words_with_ordered/
 * Creation Date:   28 Mar 2014<br/>
  * ------------------------------------------------------------------------------------------------------
 */


namespace Challenge122E
{
    class Program
    {
        static void Main(string[] args)
        {
            string Line;                               // temp. stores words as they are being read from file
            string Expression = "[^aeiou]*[a]{1}[^aeiou]*[e]{1}[^aeiou]*[i]{1}[^aeiou]*[o]{1}[u]{1}[^aeiou]*";
            
            StreamReader File = new StreamReader("enable1.txt");    // read in provided text file
            while ((Line = File.ReadLine()) != null)                // loop until end of file
            {
                // check word against regex
                if (Regex.IsMatch(Line, Expression))
                {                     
                    Console.WriteLine(Line);                        // if word matches regex, print to screen
                }
            }

            Console.WriteLine("\nPress any key to exit program");
            Console.ReadLine();     // halt until user keypress

        }
    }
}
