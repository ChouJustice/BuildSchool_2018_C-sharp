using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candy_Question
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            int x;
            int y;

            Console.Write("輸入幾個包裝紙換一顆糖果 : ");
            n = int.Parse(Console.ReadLine());
            Console.Write("輸入想吃幾顆糖果 : ");
            x = int.Parse(Console.ReadLine());

            int j = 0;
            int i = 0;
            int buy_candy = 0;
            for(i=1;i<=x;i++)
            {
                j++;
                buy_candy++;
                if(j == n)
                {
                    i++;
                    j = 1;
                }
            }

            Console.WriteLine("需要買 {0} 顆糖果",buy_candy);

            Console.ReadLine();
        }
    }
}
