using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monkey_King
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("輸入猴子有幾隻 : ");
            int monkey = int.Parse(Console.ReadLine());

            List<int> list = new List<int>();
            Dictionary<int, int> dic = new Dictionary<int, int>();

            for(int i=1;i<=monkey;i++)
            {
                dic.Add(i, i);
                list.Add(i);
            }

            int monkeycount = monkey;
            int countNum = 0;   
            int index = 0;      
            int number = 3;

            while (monkeycount != 1)
            {
                if (list[index] == index+1) //判斷猴子有無出局 true = 還沒出局
                {
                    countNum++; //算1,2,3 沒出局才能報數

                    if (countNum == number) //數到3 
                    {
                        countNum = 0; //數數歸零
                        list[index] = -1;
                        Console.WriteLine($"第 {index +1} 隻猴子 出局");
                        monkeycount--; //猴子總數 -1
                    }
                }
                
                index++;

                if (index == monkey)
                {
                    index = 0; //超出index歸 0
                }
            }

            var king = list.Find(x => x != -1);

            Console.WriteLine($"{Environment.NewLine}第 { king } 隻猴子是大王");

            Console.ReadLine();
        }
    }
}
