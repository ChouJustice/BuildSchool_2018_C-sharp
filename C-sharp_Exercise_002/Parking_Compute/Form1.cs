using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parking_Compute
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime start_datetme = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, (int)numericUpDown1.Value, (int)numericUpDown3.Value, 0);
            DateTime end_datetme = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, dateTimePicker2.Value.Day, (int)numericUpDown2.Value, (int)numericUpDown4.Value, 0);

            var result = (end_datetme - start_datetme).TotalMinutes;

            label1.Text = $"停了 {result} 分鐘";

            Compute(result);
        }

        private void Compute(double time)
        {
            int price = 0;
            int level;
            switch((int)(time / 30))
            {
                case 0:
                    level = 0;
                    break;
                case 1:
                    level = 30;
                    break;
                case 2:
                    level = 30;
                    break;
                case 3:
                    level = 30;
                    break;
                case 4:
                    level = 40;
                    break;
                case 5:
                    level = 40;
                    break;
                case 6:
                    level = 40;
                    break;
                case 7:
                    level = 40;
                    break;
                default:
                    level = 60;
                    break;
            }

            price = level * (int)(time / 30);

            label1.Text += $"  共 {price} 元";
        }
    }
}
