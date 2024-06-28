using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task_Sample_2_06._09_
{
    internal class Program
    {
        static void MyTask(int count, CancellationToken cancelToken)
        {
            cancelToken.ThrowIfCancellationRequested();
            Console.WriteLine("Start Task");

            for (int i = 0; i < count; i++)
            {
                if (cancelToken.IsCancellationRequested)
                    cancelToken.ThrowIfCancellationRequested();
                Thread.Sleep(1000);
                Console.WriteLine($"Result: {i}");
            }
        }

        static void Main(string[] args)
        {
            var cancelTokenSrc = new CancellationTokenSource();
            Task task = Task.Factory.StartNew(() => MyTask(10, cancelTokenSrc.Token), cancelTokenSrc.Token);

            Thread.Sleep(2000);

            try
            {
                cancelTokenSrc.Cancel();
                task.Wait();
            }
            catch (AggregateException ex)
            {
                if (task.IsCanceled)
                {
                    Console.WriteLine("Task Cancel");
                }
            }
            finally
            {
                task.Dispose();
                cancelTokenSrc.Dispose();
            }
        }
    }
}
