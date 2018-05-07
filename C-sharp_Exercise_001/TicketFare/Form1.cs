using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork010
{
    public partial class Form1 : Form
    {
        int[,] price;
        List<Station> L_station_list;
        List<Station> R_station_list;
        public Form1()
        {
            InitializeComponent();
            CreateList();
            InitUI();
        }

        public void CreateList()
        {
            price = new int[6, 6] { { 0  ,177,375,598,738,842 },
                                    { 177,0  ,197,421,560,755 },
                                    { 375,197,0  ,224,363,469 },
                                    { 598,421,224,0  ,139,245 },
                                    { 738,560,363,139,0  ,106 },
                                    { 842,755,469,245,106,0   } };

            L_station_list = new List<Station>();
            L_station_list.Add(new Station() { Name = "台北", Id = 0 });
            L_station_list.Add(new Station() { Name = "新竹", Id = 1 });
            L_station_list.Add(new Station() { Name = "台中", Id = 2 });
            L_station_list.Add(new Station() { Name = "嘉義", Id = 3 });
            L_station_list.Add(new Station() { Name = "台南", Id = 4 });
            L_station_list.Add(new Station() { Name = "高雄", Id = 5 });

            R_station_list = new List<Station>();
            R_station_list.Add(new Station() { Name = "台北", Id = 0 });
            R_station_list.Add(new Station() { Name = "新竹", Id = 1 });
            R_station_list.Add(new Station() { Name = "台中", Id = 2 });
            R_station_list.Add(new Station() { Name = "嘉義", Id = 3 });
            R_station_list.Add(new Station() { Name = "台南", Id = 4 });
            R_station_list.Add(new Station() { Name = "高雄", Id = 5 });
        }

        public void InitUI()
        {
            comboBox1.DataSource = L_station_list;
            comboBox1.DisplayMember = "Name";
            comboBox2.DataSource = R_station_list;
            comboBox2.DisplayMember = "Name";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i; //陣列i
            var result1 = L_station_list.Find((x) => x.Name == comboBox1.Text); //用string 找ID
            i = result1.Id;

            int j; //陣列j
            var result2 = L_station_list.Find((x) => x.Name == comboBox2.Text); //找ID
            j = result2.Id;

            decimal total_price = (decimal)price[i,j]; //從二維陣列中取得票價

            if(checkBox1.Checked == true) //來回票
            {
                total_price = (total_price + total_price) * (decimal)0.9;
            }
            if(checkBox2.Checked == true) //優惠票
            {
                total_price = total_price * (decimal)0.9;
            }
            total_price = Math.Ceiling(total_price); //無條件進位

            label1.Text = "票價 : " + total_price.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            var result1 = L_station_list.OrderBy((x) => x.Id);
            L_station_list = result1.ToList();
            var result2 = R_station_list.OrderByDescending((x) => x.Id);
            R_station_list = result2.ToList();
            comboBox1.DataSource = L_station_list;
            comboBox1.DisplayMember = "Name";
            comboBox2.DataSource = R_station_list;
            comboBox2.DisplayMember = "Name";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            var result1 = L_station_list.OrderByDescending((x) => x.Id);
            L_station_list = result1.ToList();
            var result2 = R_station_list.OrderBy((x) => x.Id);
            R_station_list = result2.ToList();

      

            comboBox1.DataSource = L_station_list;
            comboBox1.DisplayMember = "Name";
            comboBox2.DataSource = R_station_list;
            comboBox2.DisplayMember = "Name";
        }
    }
}
