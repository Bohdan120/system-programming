using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace samp_2_05._09_
{
    class Counter
    {
        public int Count { get; set; } = 0;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter();
            Thread[] threads = new Thread[5];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread((obj) => {
                    Counter c = obj as Counter; lock (c)
                    {
                        int tmp = c.Count;
                        Interlocked.Increment(ref tmp); c.Count = tmp;
                        Thread.Sleep(500);
                    }
                }); threads[i].Start(counter);
            }
            for (int i = 0; i < threads.Length; i++)
                threads[i].Join();
            Console.WriteLine($"Counter: {counter.Count}");
        }
    }
}
