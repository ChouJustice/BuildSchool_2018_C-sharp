using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odd_or_Even
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            Console.WriteLine("---奇偶數判斷---\n");
            while (true)
            {
                Console.Write("請輸入數字 : ");
                number = int.Parse(Console.ReadLine());

                if (number % 2 == 0)
                {
                    Console.WriteLine("\n數字 {0} 為 偶數", number);
                }
                else
                {
                    Console.WriteLine("\n數字 {0} 為 奇數", number);
                }
                Console.WriteLine();
            }
        }
    }
}
