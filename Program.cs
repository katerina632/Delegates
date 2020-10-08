using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public delegate void CountDelegate(int limat);
    class SuperCounter
    {
        CountDelegate algorithm;

        public SuperCounter()
        {
            algorithm = delegate (int limit)
            {
                for (int i = 0; i <= limit; i++)
                {
                    Console.Write($"{i} ");
                }
                Console.WriteLine();
            };
           
        }
        public SuperCounter(CountDelegate algo)
        {
            algorithm = algo;
        }

        public void SetAlgo(CountDelegate algo)
        {
            algorithm = algo;
        }

        public void Calculate(int limit)
        {
            algorithm.Invoke(limit);
        }
    }

    class Program
    {
        public static void GradeTwo(int limit)
        {
            double number = 1;
            for (int i = 1; i <= limit; i++)
            {
                Console.Write($"{number} ");
                number = Math.Pow(2, i);
            }
            Console.WriteLine();
        }

        public static void PrimeNumbers(int limit)
        {
            bool isPrime;
            for (int i = 2; i <= limit; i++)
            {
                isPrime = true;
                int k = 2;
                while (k * k <= i)
                {
                    if (i % k == 0)
                    {
                        isPrime = false;
                        break;
                    }
                    k++;
                }
                if (isPrime)
                    Console.Write($"{i} ");
            }
            Console.WriteLine();
        }

        public static void Factorial(int limit)
        {
            int res = 1;
           
            for (int i = 1; i <= limit; i++)
            {
                res *= i;
                Console.Write($"{res} ");
            }
            Console.WriteLine();
        }




        static void Main(string[] args)
        {
            SuperCounter superCounter = new SuperCounter();
            int limit = 10;

            Console.WriteLine($"Number from 0 to {limit}");
            superCounter.Calculate(limit);
            Console.WriteLine();

            limit = 6;
            Console.WriteLine($"Numbers grade two until to {limit}");
            superCounter.SetAlgo(GradeTwo);
            superCounter.Calculate(limit);
            Console.WriteLine();

            limit = 11;
            Console.WriteLine($"Prime numbers from 2 to {limit}");
            superCounter.SetAlgo(PrimeNumbers);
            superCounter.Calculate(limit);
            Console.WriteLine();

            limit = 5;
            Console.WriteLine($"Factorial to {limit}");
            superCounter.SetAlgo(Factorial);
            superCounter.Calculate(limit);
            Console.WriteLine();
        }
    }
}
