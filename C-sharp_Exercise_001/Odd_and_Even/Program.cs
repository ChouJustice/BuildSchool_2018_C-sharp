using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Odd_and_Even
{
    class Program
    {
        static void Main(string[] args)
        {
            string splits = ",";
            string input = "";
            string[] s = { };

            Console.WriteLine("---奇偶數判斷---\n");
            while (true)
            {
                Console.WriteLine("請輸入一串逗號分隔的整數數字字串 : ");
                input = Console.ReadLine();
                for (int i = 0; i < input.Length; i++) //逗號拿掉
                {
                    s = Regex.Split(input, splits);
                }

                int[] int_array = new int[s.Length];

                for (int j = 0; j < s.Length; j++) //string[] => int[]
                {
                    int_array[j] = int.Parse(s[j]);
                }

                var order = int_array.OrderBy((x) => x); //先排序

                var groups = order.GroupBy((x) => x % 2 == 0); //再分群

                int count = 0;
                Console.WriteLine();
                foreach (var group in groups) //印出
                {
                    if (group.Key == true)
                    {
                        Console.WriteLine("偶數 : \n");
                    }
                    else
                    {
                        Console.WriteLine("奇數 : \n");
                    }
                    foreach (var item in group)
                    {
                        count++;
                        if (count == group.Count())
                        {
                            Console.Write(item);
                            break;
                        }
                        Console.Write(item + " , ");
                    }
                    count = 0;
                    Console.WriteLine("\n");
                }
            }
        }
    }
}
