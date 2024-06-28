using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sample_4_1._09_
{
    internal class Program
    {
        static void MyThreadFunction(object obj)
        {
            Console.WriteLine("Threat Start");
            Thread.Sleep(2000);
            Console.WriteLine("Threat End");

        }
        static void Main(string[] args)
        {
            //int a = 0, b = 0; 
            //ThreadPool.GetMaxThreads(out a, out b);
            //Console.WriteLine($"Робочі потоки: {a}");
            //Console.WriteLine($"Фонові потоки: {b}");


        }
    }
}
