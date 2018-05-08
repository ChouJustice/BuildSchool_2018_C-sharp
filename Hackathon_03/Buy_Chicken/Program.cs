using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buy_Chicken
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 0; //公雞
            double y = 0; //母雞
            double z = 0; //小雞
            //double money = 1000;
            int circle_turn = 0;

            while(((x + y + z) != 100.0) && (((60.0*x) + (30.0*y) + (z)) != 1000.0))
            {
                x++;
                //Console.WriteLine($"x = {x}");
                //Console.WriteLine($"f(x) = {((900.0 - (59.0 * x)) % 29.0)}");
                if(((900.0 - (59.0 * x)) % 29.0) == 0.0)
                {
                    y = ((900.0 - (59.0 * x)) / 29.0);
                    //Console.WriteLine($"y = {y}");
                    z = (100.0 - x - y);
                }
                circle_turn++;
            }

            Console.WriteLine($"公雞 = {x} , 母雞 = {y} , 小雞 = {z} , 迴圈 {circle_turn} 圈");
            Console.ReadLine();
        }
    }
}
