using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_LED
{
    class Program
    {
        static List<int> list = new List<int>();
        static void Main(string[] args)
        {
            Console.Write("請輸入字串 : ");
            var input = Console.ReadLine();

            foreach (var item in input)
            {
                list.Add(Convert.ToInt32(item.ToString()));
            }

            line_1();
            line_2();
            line_3();

            Console.ReadLine();
        }

        private static void line_1()
        {
            foreach (var item in list)
            {
                switch (item)
                {
                    case 0:
                        Console.Write("|￣|");
                        break;
                    case 1:
                        Console.Write("   |");
                        break;
                    case 2:
                        Console.Write(" ￣|");
                        break;
                    case 3:
                        Console.Write(" ￣|");
                        break;
                    case 4:
                        Console.Write("|__|");
                        break;
                    case 5:
                        Console.Write("|￣ ");
                        break;
                    case 6:
                        Console.Write("|￣ ");
                        break;
                    case 7:
                        Console.Write(" ￣|");
                        break;
                    case 8:
                        Console.Write("|￣|");
                        break;
                    case 9:
                        Console.Write("|￣|");
                        break;
                }
            }
            Console.WriteLine();
        }

        private static void line_2()
        {
            foreach (var item in list)
            {
                switch (item)
                {
                    case 0:
                        Console.Write("|  |");
                        break;
                    case 1:
                        Console.Write("   |");
                        break;
                    case 2:
                        Console.Write("|￣ ");
                        break;
                    case 3:
                        Console.Write(" ￣|");
                        break;
                    case 4:
                        Console.Write("   |");
                        break;
                    case 5:
                        Console.Write(" ￣|");
                        break;
                    case 6:
                        Console.Write("|￣|");
                        break;
                    case 7:
                        Console.Write("   |");
                        break;
                    case 8:
                        Console.Write("|￣|");
                        break;
                    case 9:
                        Console.Write(" ￣|");
                        break;
                }
            }
            Console.WriteLine();
        }

        private static void line_3()
        {
            foreach (var item in list)
            {
                switch (item)
                {
                    case 0:
                        Console.Write(" ￣ ");
                        break;
                    case 1:
                        Console.Write("    ");
                        break;
                    case 2:
                        Console.Write(" ￣ ");
                        break; 
                    case 3:
                        Console.Write(" ￣ ");
                        break;
                    case 4:
                        Console.Write("    ");
                        break;
                    case 5:
                        Console.Write(" ￣ ");
                        break;
                    case 6:
                        Console.Write(" ￣ ");
                        break;
                    case 7:
                        Console.Write("    ");
                        break;
                    case 8:
                        Console.Write(" ￣ ");
                        break;
                    case 9:
                        Console.Write(" ￣ ");
                        break;
                }
            }
            Console.WriteLine();
        }
    }
}
