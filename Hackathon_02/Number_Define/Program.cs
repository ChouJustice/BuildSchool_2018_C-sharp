using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_Define
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 100;
            define(x);

            Console.ReadLine();
        }

        private static void define(int x)
        {
            int i = 1;
            while(i <= x)
            {
                if(i % (3 * 5) !=0)
                {
                    Console.WriteLine(i);
                }
                i++;
            }
        }
    }
}
