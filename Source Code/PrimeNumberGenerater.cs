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
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("||***Welcome to Prime Number Generator***||");
    //        Console.WriteLine("Enter start number(numeric value):");
    //        string num1 = (Console.ReadLine());
    //        Console.WriteLine("Enter end number(numeric value):");
    //        string num2 = (Console.ReadLine());
    //        if (Regex.IsMatch(num1, @"^[0-9]+$") && Regex.IsMatch(num2, @"^[0-9]+$"))
    //        {
    //            PrimeNumber obj = new PrimeNumber();
    //            if(obj.generate(Convert.ToInt32(num1), Convert.ToInt32(num2)).Count == 0)
    //                Console.WriteLine("No Prime Numbers between " + num1 + " to " + num2);
    //            else
    //                Console.WriteLine("Prime Numbers between " + num1 + " to " + num2 + " = " + string.Join(",", obj.generate(Convert.ToInt32(num1), Convert.ToInt32(num2))));
    //        }
    //        else
    //        {
    //            Console.WriteLine("Enter the valid numeric input!!!");
    //        }
    //        Console.Read();
    //    }
    //}
}
