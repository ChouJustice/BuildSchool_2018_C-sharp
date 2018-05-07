using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Get_Sat_Sun_Days
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int six = 0;
            int seven = 0;

            int year = int.Parse(textBox1.Text);

            DateTime date;

            date = new DateTime(year, 1, 1);

            for (int j = 0; j < date.DayOfYear; j++)
            {
                if (date.DayOfWeek == DayOfWeek.Saturday)
                {
                    six++;
                    date = date.AddDays(1);
                }
                else if (date.DayOfWeek == DayOfWeek.Sunday)
                {
                    seven++;
                    date = date.AddDays(1);
                }
                else
                {
                    date = date.AddDays(1);
                }
            }
            label1.Text = "星期六 : " + six.ToString() + " 天";
            label2.Text = "星期日 : " + seven.ToString() + " 天";
        }
    }
}
