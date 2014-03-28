using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyProgrammer122E
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input: ");
            int input = int.Parse(Console.ReadLine());
            int output = digitalRoot(input);
        }

        private static int digitalRoot(int input)
        {
            if(input == 0)
            {
                return 0;
            }

            int digits = (int) Math.Floor(Math.Log10(input));

            return 0;
        }
    }
}
