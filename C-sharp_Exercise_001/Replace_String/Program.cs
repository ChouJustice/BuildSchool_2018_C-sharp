using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork008
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, string> Number = new Dictionary<char, string>();
            Number.Add('1', "一");
            Number.Add('2', "二");
            Number.Add('3', "三");
            Number.Add('4', "四");
            Number.Add('5', "五");
            Number.Add('6', "六");
            Number.Add('7', "七");
            Number.Add('8', "八");
            Number.Add('9', "九");
            Number.Add('0', "零");

            List<Number> list = new List<Number>();
            list.Add(new Number() { Num = '1', CNum = "一" });
            list.Add(new Number() { Num = '2', CNum = "二" });
            list.Add(new Number() { Num = '3', CNum = "三" });
            list.Add(new Number() { Num = '4', CNum = "四" });
            list.Add(new Number() { Num = '5', CNum = "五" });
            list.Add(new Number() { Num = '6', CNum = "六" });
            list.Add(new Number() { Num = '7', CNum = "七" });
            list.Add(new Number() { Num = '8', CNum = "八" });
            list.Add(new Number() { Num = '9', CNum = "九" });
            list.Add(new Number() { Num = '0', CNum = "零" });

            Console.WriteLine("---字串替換---\n");

            while (true)
            {
                Console.Write("請輸入阿拉伯數字 : ");
                string input = Console.ReadLine();

                Console.WriteLine("---Switch---\n");
                for(int i=0;i<input.Length;i++)
                {
                    switch(input[i])
                    {
                        case '1':
                            Console.Write("一");
                            break;
                        case '2':
                            Console.Write("二");
                            break;
                        case '3':
                            Console.Write("三");
                            break;
                        case '4':
                            Console.Write("四");
                            break;
                        case '5':
                            Console.Write("五");
                            break;
                        case '6':
                            Console.Write("六");
                            break;
                        case '7':
                            Console.Write("七");
                            break;
                        case '8':
                            Console.Write("八");
                            break;
                        case '9':
                            Console.Write("九");
                            break;
                        case '0':
                            Console.Write("零");
                            break;
                    }
                }

                Console.WriteLine("\n\n---Dictionary---\n");

                for(int j=0;j<input.Length;j++)
                {
                    if(Number.ContainsKey(input[j]))
                    {
                        Console.Write(Number[input[j]]);
                    }
                }

                Console.WriteLine("\n\n---Linq---\n");

                for(int k=0;k<input.Length;k++)
                {
                    var result = list.Where(x => x.Num == input[k]);
                    foreach(var item in result)
                    {
                        Console.Write(item.CNum);
                    }
                }

                Console.WriteLine("\n\n");
            }
        }
    }
}
