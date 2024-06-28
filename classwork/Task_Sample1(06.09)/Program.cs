using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_Sample1_06._09_
{
    internal class Program
    {
        static void Lex()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Lex");
        }
        static void Syntax(Task task)
        {
            Thread.Sleep(2000);
            Console.WriteLine("Syntax");
        }
        static void Semantic(Task task)
        {
            Thread.Sleep(3000);
            Console.WriteLine("Semantic");
        }
        static void Main(string[] args)
        {
            //----Холодний запуск
            //Task task = new Task(() =>
            //{
            //    Console.WriteLine("Start Task");
            //    Console.WriteLine($"Id: {Thread.CurrentThread.ManagedThreadId}");
            //});
            //task.Start();

            //task.Wait();

            //----Гарячий запуск
            //Task task = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("Start Task");
            //    Console.WriteLine($"Id: {Thread.CurrentThread.ManagedThreadId}");

            //});
            //task.Wait();

            //----Викликаючи статичнй метод Run
            //Task task = Task.Run(() =>
            //{
            //    Console.WriteLine("Start Task");
            //    Console.WriteLine($"Id: {Thread.CurrentThread.ManagedThreadId}");

            //});
            //task.Wait();

            //-----Синхронний спосіб
            //Task task = new Task(() =>
            //{
            //    Console.WriteLine("Start Task");
            //    Console.WriteLine($"ID: {Thread.CurrentThread.ManagedThreadId}");
            //});
            //task.RunSynchronously();
            //Console.WriteLine("Main");

            //------------ Властивості
            //Task task = new Task(() =>
            //{
            //    Console.WriteLine("Start Task");
            //    Console.WriteLine($"ID Thread: {Thread.CurrentThread.ManagedThreadId}");
            //    Console.WriteLine($"ID Task: {Task.CurrentId}");
            //});
            //task.Start();

            //Console.WriteLine($"Status Task: {task.Status}");
            //Console.WriteLine($"Is Canceled: {task.IsCanceled}");
            //Console.WriteLine($"Is Faulted: {task.IsFaulted}");
            //Thread.Sleep(1000); 
            //Console.WriteLine($"Status Task: {task.Status}");
            //task.Wait();

            Task taskLex = new Task(Lex);
            Task taskSntax = taskLex.ContinueWith(Syntax);
            Task taskSemantic = taskLex.ContinueWith(Semantic);

            taskLex.Start();

            Task.WaitAll(taskSntax, taskSemantic);

            taskLex.Dispose();
            taskSntax.Dispose();
            taskSemantic.Dispose();
        }
    }
}
