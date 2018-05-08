using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Return_Text
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入字串 : ");

            var input = Console.ReadLine();

            if (IsReturnText(input))
            {
                Console.WriteLine("是回文");
            }
            else
            {
                Console.WriteLine("不是回文");
            }

            Console.ReadLine();
        }

        private static bool IsReturnText(string input)
        {
            for(int i=0 ; i < (Math.Floor((decimal)input.Length/2)) ; i++)
            {
                if(input[(int)i] != input[input.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
