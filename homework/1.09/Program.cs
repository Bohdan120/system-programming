using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1._09
{
    internal class Program
    {
        static int Add(int a, int b)
        {
            Console.WriteLine("Start Add");
            Thread.Sleep(3000);
            Console.WriteLine("End Add!");
            return a + b;
        }

        //Функція зворотнього виклику 
        static void MyCallBack(IAsyncResult ar)
        {
            Console.WriteLine("Start MyCallBack");
            MyDel d = ar.AsyncState as MyDel;
            int res = d.EndInvoke(ar);
            Console.WriteLine(res.ToString());
        }
     
        public delegate int MyDel(int a, int b);
        static void Main(string[] args)
        {
            Console.WriteLine("Start Main");
            MyDel d1 = Add;
            d1.BeginInvoke(5, 4, MyCallBack, d1);
            Console.ReadLine();
            Console.WriteLine("End Main");
          

        }
    }
}
