using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GreatestCommonDenominatior(24, 4));
        }

        static int GreatestCommonDenominatior(int a, int b)
        {
            int remainder;

            while ( b != 0 )
            {
                remainder = a % b;

                a = b;
                b = remainder;
            }

            return a;
        }
    }
}
