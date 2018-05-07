using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loop_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int input;
            Console.WriteLine("---迴圈倒置2---\n");
            while (true)
            {
                Console.Write("請輸入一個整數數字 : ");

                input = int.Parse(Console.ReadLine());

                Console.WriteLine();
                for (int i = input; i > 0; i--)
                {
                    for (int j = 0; j != input - i + 1; j++)
                    {
                        Console.Write(i);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
