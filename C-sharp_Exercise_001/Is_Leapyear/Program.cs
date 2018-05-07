using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Is_Leapyear
{
    class Program
    {
        static void Main(string[] args)
        {
            int mingo_year = 1911; //民國年初
            int year;
            Console.WriteLine("---閏年---\n");

            while (true)
            {
                Console.Write("請輸入民國年 : ");
                year = int.Parse(Console.ReadLine());
                year = year + mingo_year;

                bool roon = DateTime.IsLeapYear(year);

                if (roon == true)
                {
                    Console.WriteLine("\n該年為 閏年");
                }
                else
                {
                    Console.WriteLine("\n該年為 平年");
                }
                Console.WriteLine();
                //        bool pin_or_rin;
                //        if (year % 4 == 0)
                //        {
                //            if (year % 100 == 0)
                //            {
                //                if (year % 400 == 0)
                //                {
                //                    pin_or_rin = true;
                //                }
                //                else
                //                {
                //                    pin_or_rin = false;
                //                }
                //            }
                //            else
                //            {
                //                pin_or_rin = true;
                //            }
                //        }
                //        else
                //        {
                //            pin_or_rin = false;
                //        }

                //        if(pin_or_rin == true)
                //        {
                //            Console.WriteLine("\n該年為 閏年");
                //        }
                //        else
                //        {
                //            Console.WriteLine("\n該年為 平年");
                //        }
                //        Console.WriteLine();
            }
        }
    }
}
