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
    public partial class Input : Form
    {
        public Input()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var date = dateTimePicker1.Value;
            var fuel = (float)numericUpDown1.Value;
            var kilometer = (float)numericUpDown2.Value;

            try
            {
                DataModel context = new DataModel();

                //context.Database.ExecuteSqlCommand("TRUNCATE TABLE [HistoryTable]");

                context.HistoryTable.Add(new HistoryTable() { RefudlingDate = date, Liter = fuel, Kilometer = kilometer });

                context.SaveChanges();

                MessageBox.Show("Success");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
        }
    }
}
