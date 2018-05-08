using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Text_Read_Convert.Models;

namespace Text_Read_Convert
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "test02.TXT";

            string[] lines = new string[] { };

            if(File.Exists(filename))
            {
                lines = File.ReadAllLines(filename);
            }

            foreach(var line in lines)
            {
                int num = int.Parse(line.Substring(0, 3));
                if(num == 695 || num == 525)
                {
                    var tick = line.Substring(0, 13);
                    var date1 = line.Substring(13, 4) + "/" + line.Substring(17, 2) + "/" + line.Substring(19, 2) + " 00:00:00";
                    var date2 = line.Substring(21, 4) + "/" + line.Substring(25, 2) + "/" + line.Substring(27, 2) + " 00:00:00";
                    DateTime fly , birth;
                    DateTime.TryParse(date1.ToString(), out fly);
                    DateTime.TryParse(date2.ToString(), out birth);

                    //Console.WriteLine(fly);
                    //Console.WriteLine(birth);

                    try
                    {
                        MyDataModel myData = new MyDataModel();
                        myData.TimeTable.Add(new TimeTable() { TickNumber = tick, FlyingDay = fly, BirthDay = birth });
                        myData.SaveChanges();
                        Console.WriteLine("Success");
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }

            var list = (new MyDataModel()).TimeTable.ToList();

            foreach(var item in list)
            {
                Console.WriteLine($"{item.Id} {item.TickNumber} {item.FlyingDay} {item.BirthDay}");
            }

            Console.ReadLine();
        }

        private static bool Define(string line)
        {
            return true;
        }
    }
}
