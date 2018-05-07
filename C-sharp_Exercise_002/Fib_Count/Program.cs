using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fib_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            long x = 1 , y = 1;
            First(x,y);
            Fib(x,y);
            Console.ReadLine();
        }

        static void Fib(long x ,long y)
        {
            Console.WriteLine(x + y);
            if (Check(x + y)) return;
            Fib(y, x + y);
        }

        static bool Check(long x)
        {
            return x == 1836311903;
        }
        static void First(long x , long y)
        {
            Console.WriteLine(x);
            Console.WriteLine(y);
        }
    }
}
