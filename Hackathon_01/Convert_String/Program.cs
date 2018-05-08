using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convert_String
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i=1;i<=100;i++)
            {
                var item = Convert.ToString(i);
                foreach(var j in item)
                {
                    if(j == '3')
                    {
                        Console.Write("A");
                        continue;
                    }
                    if (j == '5')
                    {
                        Console.Write("B");
                        continue;
                    }
                    if (j == '9')
                    {
                        Console.Write("C");
                        continue;
                    }
                    if (j == '0')
                    {
                        Console.Write("D");
                        continue;
                    }
                    Console.Write(j);
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
