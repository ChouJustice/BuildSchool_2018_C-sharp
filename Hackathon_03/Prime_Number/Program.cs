using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 101;
            int max = 200;
            for(i=101;i<=max;i++)
            {
                for(int y=2;y<i;y++)
                {
                    if(i % y == 0)
                    {
                        break;
                    }
                    if(i == y+1)
                    {
                        Console.WriteLine(i);
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
