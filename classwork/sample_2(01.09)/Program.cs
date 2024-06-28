using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sample_2_01._09_
{
    internal class Program
    {
        static void MythreadFunc()
        {
            Console.WriteLine("Start Thread");
            Thread.Sleep(3000);
            Console.WriteLine("End Thread");

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Start Main");
            Thread t = new Thread(MythreadFunc);
            t.Start();
            Console.WriteLine("End Main");
            t.Join();
        }
    }
}
