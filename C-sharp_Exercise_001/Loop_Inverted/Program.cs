using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Loop_Inverted
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            string[] s = { };
            string splits = ",";

            Console.WriteLine("---迴圈倒置1---\n");
            while (true)
            {
                Console.Write("請輸入一串逗號分隔的字串 : ");
                input = Console.ReadLine();

                for (int i = 0; i < input.Length; i++)  //字串分割
                {
                    s = Regex.Split(input, splits);
                }

                Console.Write("\n反向輸出 : ");
                for (int j = s.Length - 1; j >= 0; j--)
                {
                    if (j == 0)
                    {
                        Console.Write(s[j]);
                        break;
                    }
                    Console.Write(s[j] + ",");
                }
                Console.WriteLine("\n");
            }
        }
    }
}
