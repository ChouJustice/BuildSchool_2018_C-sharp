using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cellphone_TelRate
{
    public partial class Form1 : Form
    {
        List<Tel_Rate> list = new List<Tel_Rate>();
        public Form1()
        {
            InitializeComponent();
            DataInit();
        }

        private void DataInit()
        {
            list.Add(new Tel_Rate() { Name = "中華電信", Month_low = 350, Minute_money = 4, Minutes = 0});
            list.Add(new Tel_Rate() { Name = "遠傳", Month_low = 400, Minute_money = 3, Minutes = 0});
            list.Add(new Tel_Rate() { Name = "台灣大哥大", Month_low = 500, Minute_money = 2, Minutes = 0});
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int minute = int.Parse(textBox1.Text);

            foreach(var item in list)
            {
                item.Minutes = minute;
            }

            var result = list.Select(x => new { SName = x.Name, Price = x.Month_low + x.Minute_money * x.Minutes });

            var Min = result.Min(x => x.Price);

            var myFind = result.Where(x => x.Price == Min);

            dataGridView1.DataSource = myFind.ToList();
        }
    }
}
