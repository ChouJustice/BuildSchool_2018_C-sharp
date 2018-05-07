using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicketFare.Models;

namespace TicketFare
{
    public partial class Form1 : Form
    {
        List<TicketFare.Models.TicketFare> Data = new List<Models.TicketFare>();
        public Form1()
        {
            InitializeComponent();
            InsertData();
            radioButton1.CheckedChanged += RadioButton_CheckedChanged;
            comboBox1.SelectedIndexChanged += StartComboBox_SelectedIndexChanged;
            radioButton1.Checked = true;
        }

        private void InsertData()
        {
            try
            {
                ContactsModel context = new ContactsModel();

                context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TicketFare]");

                context.SaveChanges();

                context.TicketFare.Add(new Models.TicketFare { StartStation = "台北", EndStation = "新竹", TicketPrice = 177 });
                context.TicketFare.Add(new Models.TicketFare { StartStation = "台北", EndStation = "台中", TicketPrice = 375 });
                context.TicketFare.Add(new Models.TicketFare { StartStation = "台北", EndStation = "嘉義", TicketPrice = 598 });
                context.TicketFare.Add(new Models.TicketFare { StartStation = "台北", EndStation = "台南", TicketPrice = 738 });
                context.TicketFare.Add(new Models.TicketFare { StartStation = "台北", EndStation = "高雄", TicketPrice = 842 });
                context.TicketFare.Add(new Models.TicketFare { StartStation = "新竹", EndStation = "台中", TicketPrice = 197 });
                context.TicketFare.Add(new Models.TicketFare { StartStation = "新竹", EndStation = "嘉義", TicketPrice = 421 });
                context.TicketFare.Add(new Models.TicketFare { StartStation = "新竹", EndStation = "台南", TicketPrice = 560 });
                context.TicketFare.Add(new Models.TicketFare { StartStation = "新竹", EndStation = "高雄", TicketPrice = 755 });
                context.TicketFare.Add(new Models.TicketFare { StartStation = "台中", EndStation = "嘉義", TicketPrice = 224 });
                context.TicketFare.Add(new Models.TicketFare { StartStation = "台中", EndStation = "台南", TicketPrice = 363 });
                context.TicketFare.Add(new Models.TicketFare { StartStation = "台中", EndStation = "高雄", TicketPrice = 469 });
                context.TicketFare.Add(new Models.TicketFare { StartStation = "嘉義", EndStation = "台南", TicketPrice = 139 });
                context.TicketFare.Add(new Models.TicketFare { StartStation = "嘉義", EndStation = "高雄", TicketPrice = 245 });
                context.TicketFare.Add(new Models.TicketFare { StartStation = "台南", EndStation = "高雄", TicketPrice = 106 });

                context.SaveChanges();

                Data = context.TicketFare.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                SetToSouthStartCombobox();
            }
            else
            {
                SetToNorthStartCombobox();
            }
        }

        private void StartComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                SetToSouthEndCombobox();
            }
            else
            {
                SetToNorthEndCombobox();
            }

        }

        private void SetToSouthStartCombobox()
        {
            //comboBox1.DataSource = Data.GroupBy((x) => x.StartStation).Select((x) => x.Key).ToList();
            comboBox1.DataSource = Data.Distinct(new StartSation()).Select(x => x.StartStation).ToList();
        }

        private void SetToNorthStartCombobox()
        {
            //comboBox1.DataSource = Data.GroupBy((x) => x.EndStation).Select((x) => x.Key).ToList();
            //comboBox1.DisplayMember = "StartStation";
            comboBox1.DataSource = Data.Distinct(new StartSation()).Select(x => x.StartStation).ToList();
        }

        private void SetToSouthEndCombobox()
        {
            string start = GetStartStation();
            comboBox2.DataSource = Data.Where((x) => x.StartStation == start).Select((x) => x.EndStation).ToList();
            //comboBox2.DataSource = Data.Distinct(new EndSation()).Select(x => x.EndStation).ToList();

        }

        private string GetStartStation()
        {
            return comboBox1.SelectedItem.ToString();
        }

        private void SetToNorthEndCombobox()
        {
            string start = GetStartStation();
            comboBox2.DataSource = Data.Where((x) => x.EndStation == start).Select((x) => x.StartStation).ToList();
            //comboBox2.DataSource = Data.Distinct(new EndSation()).Select(x => x.EndStation).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var calculator = new TicketCalculator();
            string start = comboBox1.SelectedItem.ToString();
            string end = comboBox2.SelectedItem.ToString();
            bool isToSouth = false;
            if (radioButton1.Checked)
            {
                isToSouth = true;
            }
            var result = calculator.GetFare(start, end, checkBox1.Checked, checkBox2.Checked, isToSouth);
            if (result.HasValue)
            {
                label1.Text = result.Fare.ToString();
            }
            else
            {
                label1.Text = "查無此起訖站";
            }
        }
    }
    public class StartSation : IEqualityComparer<TicketFare.Models.TicketFare>
    {
        public bool Equals(Models.TicketFare x, Models.TicketFare y)
        {
            return x.StartStation == y.StartStation;
        }

        public int GetHashCode(Models.TicketFare obj)
        {
            return obj.StartStation.GetHashCode();
        }
    }
    public class EndSation : IEqualityComparer<TicketFare.Models.TicketFare>
    {
        public bool Equals(Models.TicketFare x, Models.TicketFare y)
        {
            return x.EndStation == y.EndStation;
        }

        public int GetHashCode(Models.TicketFare obj)
        {
            return obj.EndStation.GetHashCode();
        }
    }

  
}
