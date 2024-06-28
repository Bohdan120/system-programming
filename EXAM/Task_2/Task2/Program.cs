using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіть число, факторіал якого ви хочете обчислити: ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                if (number < 0)
                {
                    Console.WriteLine("Число повинно бути не від'ємним.");
                }
                else
                {
                    long result = CalculateFactorialParallel(number);
                    Console.WriteLine($"Факторіал числа {number} дорівнює {result}");
                }
            }
            else
            {
                Console.WriteLine("Введено некоректне число.");
            }
        }
        static long CalculateFactorialParallel(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }

            long result = 1;

            Parallel.For(2, n + 1, i =>
            {
                result *= i;
            });

            return result;
        }
    }
}
