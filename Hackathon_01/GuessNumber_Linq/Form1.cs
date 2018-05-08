using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessNumber_Linq
{
    public partial class Form1 : Form
    {
        private List<int> random_list = new List<int>();
        private List<int> input_list = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            random_list.Clear();

            RandomNumber();

            button1.Enabled = false;
        }

        private void RandomNumber()
        {
            Random random = new Random();

            while(random_list.Count < 4)
            {
                int temp = random.Next(0, 10);
                if (! random_list.Any((x) => x == temp))
                {
                    random_list.Add(temp);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string show = "";
            foreach(var item in random_list)
            {
                show += item.ToString();
            }
            MessageBox.Show(show);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            input_list.Clear();
            if(textBox2.Text != "" && textBox2.Text.Length == 4)
            {
                foreach(var item in textBox2.Text)
                {
                    input_list.Add(Convert.ToInt32(item) - '0');
                }
            }
            else
            {
                MessageBox.Show("請猜4個數字!!!");
                return;
            }

            //關鍵程式碼
            List<int> intersect = new List<int>();
            intersect = input_list.Intersect(random_list).ToList();
            int A = 0, B = 0;
            A = intersect.Count((x) => input_list.IndexOf(x) == random_list.IndexOf(x));
            B = intersect.Count - A;

            textBox1.Text += textBox2.Text + " --> " + A.ToString() + "A" + B.ToString() + "B" + Environment.NewLine;

            if(A == 4)
            {
                MessageBox.Show("猜對了!!!");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            random_list.Clear();
            input_list.Clear();
            textBox1.Clear();
            textBox2.Clear();

            RandomNumber();
        }
    }
}
