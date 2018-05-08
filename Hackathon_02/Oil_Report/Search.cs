using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oil_Report.Models;

namespace Oil_Report
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime start = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, 0, 0, 0);
            DateTime end = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, dateTimePicker2.Value.Day, 23, 59, 59);

            DataModel data = new DataModel();

            var list = data.HistoryTable.ToList();

            dataGridView1.DataSource = list.Where(x => x.RefudlingDate > start && x.RefudlingDate < end).ToList();

            var mycount = list.Where(x => x.RefudlingDate > start && x.RefudlingDate < end).ToList().Sum(x => (x.Kilometer / x.Liter) / 10);

            label1.Text = $"每公升平均油耗 {mycount} (里程/油耗)";
        }
    }
}
