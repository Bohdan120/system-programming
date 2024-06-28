using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace samp_1_05._09_
{
    class SharedState
    {
        public int State { get; set; } = 0;
    }
    class MyThread
    {
        SharedState shareState;
        public MyThread(SharedState shareState)
        {
            this.shareState = shareState;
        }
        public void ThreadFunc()
        {
            if (Monitor.TryEnter(shareState, 2000))
            {
                try
                {
                    for (int j = 0; j < 50000; j++)
                        shareState.State++; Thread.Sleep(1000);
                }
                finally { Monitor.Exit(shareState); }
            }
            else
            {
                Console.WriteLine($"Time out: {Thread.CurrentThread.ManagedThreadId} thread");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            SharedState R = new SharedState();
            Thread[] threads = new Thread[20];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(new MyThread(R).ThreadFunc); threads[i].Start();
            }
            for (int i = 0; i < threads.Length; i++) threads[i].Join();
            Console.WriteLine(R.State);
        }
    }
}
