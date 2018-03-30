using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PrimeNumberGenerater
{
    interface PrimeNumberGenerater
    {
        List<int> generate(int StartNumber, int EndNumber);
        bool isPrime(int Value);
    }
    class PrimeNumber : PrimeNumberGenerater
    {
        public bool isPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
        public List<int> generate(int StartNumber, int EndNumber)
        {
            List<int> result = new List<int>();
            int i = 0;
            if (StartNumber <= EndNumber)
            {
                for (i = StartNumber; i <= EndNumber; i++)
                {
                    if (isPrime(i))
                        result.Add(i);
                }
            }
            else
            {
                for (i = StartNumber; i >= EndNumber; i--)
                {
                    if (isPrime(i))
                        result.Add(i);
                }
            }

            return result;
        }
    }
}
