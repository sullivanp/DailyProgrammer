using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyProgrammer001
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Filename: ");
            String filename = Console.ReadLine();

            using(StreamReader sr = new StreamReader(filename))
            {
                String line;
                while((line = sr.ReadLine()) != null)
                {
                    if (areVowelsInOrder(line))
                    {
                        Console.WriteLine(line);
                    }
                }
            }

            Console.ReadKey();
        }

        private static bool areVowelsInOrder(string input)
        {
            bool inOrder = true;
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y' };
            int vowelIndex = 0;

            for (int index = 0; index != input.Length; index++)
            {
                if (vowels.Contains(char.ToLower(input[index])))
                {
                    if (char.ToLower(input[index]) == vowels[vowelIndex])
                    {
                        vowelIndex++;
                    } else
                    {
                        // Repeated or out-of-order vowel
                        inOrder = false;
                    }
                }
            }

            inOrder &= (vowelIndex == vowels.Length);

            return inOrder;
        }
    }
}
