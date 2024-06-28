using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{

    class Program
    {
        static int[] numbers = new int[1000];
        static int generatedCount = 0;

        static int max = int.MinValue;
        static int min = int.MaxValue;
        static double average = 0;

        static ManualResetEvent generationCompleteEvent = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            Thread generatorThread = new Thread(GenerateNumbers);
            Thread maxThread = new Thread(FindMax);
            Thread minThread = new Thread(FindMin);
            Thread avgThread = new Thread(CalculateAverage);

            generatorThread.Start();
            maxThread.Start();
            minThread.Start();
            avgThread.Start();

            generatorThread.Join();
            maxThread.Join();
            minThread.Join();
            avgThread.Join();

            Console.WriteLine($"Max: {max}");
            Console.WriteLine($"Min: {min}");
            Console.WriteLine($"Average: {average}");
        }

        static void GenerateNumbers()
        {
            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                numbers[i] = random.Next(0, 5001);
                Console.WriteLine(numbers[i]);
            }
            generatedCount = 1000;
            generationCompleteEvent.Set();
        }

        static void FindMax()
        {
            generationCompleteEvent.WaitOne();
            foreach (var number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }
        }

        static void FindMin()
        {
            generationCompleteEvent.WaitOne();
            foreach (var number in numbers)
            {
                if (number < min)
                {
                    min = number;
                }
            }
        }

        static void CalculateAverage()
        {
            generationCompleteEvent.WaitOne();
            int sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }
            average = (double)sum / generatedCount;
        }
    }

}
