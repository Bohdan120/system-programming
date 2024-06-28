using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _5._09
{
    class Program
    {
        static Semaphore ticSemaphore = new Semaphore(1, 1);
        static Semaphore tacSemaphore = new Semaphore(0, 1);
        static int n = 5; // Кількість потоків

        static void Main()
        {
            for (int i = 0; i < n; i++)
            {
                Thread ticThread = new Thread(Tic);
                Thread tacThread = new Thread(Tac);

                ticThread.Start();
                tacThread.Start();
            }

            Console.ReadKey();
        }

        static void Tic()
        {
            while (true)
            {
                ticSemaphore.WaitOne();
                Console.WriteLine("TIC");
                tacSemaphore.Release();
            }
        }

        static void Tac()
        {
            while (true)
            {
                tacSemaphore.WaitOne();
                Console.WriteLine("TAC");
                ticSemaphore.Release();
            }
        }
    }
}
