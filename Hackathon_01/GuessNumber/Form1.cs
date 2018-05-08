using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessNumber
{
    public partial class Form1 : Form
    {
        //int ans = 0;
        string ans;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            string x;
            for(int i=0;i<4;i=i)
            {
                x = random.Next(0, 9).ToString();
                if(ans != null)
                {
                    for(int j=0;j<ans.Length;j++)
                    {
                        if(ans[j].ToString() == x)
                        {
                            break;
                        }
                        if(j == ans.Length -1)
                        {
                            ans += x;
                            i++;
                        }
                    }
                }
                else
                {
                    ans += x;
                    i++;
                }
            }
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("答案 : " + ans);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                string input = textBox2.Text;
                string answer = Convert.ToString(ans);
                int A = 0;
                int B = 0;
                int i, j;

                for(i = 0;i<answer.Length;i++)
                {
                    if (answer[i] == input[i]) //數字一樣 位置一樣
                    {
                        A++;
                        continue;
                    }
                    for (j = 0; j < input.Length; j++)
                    {
                        if(i != j) //位置不一樣
                        {
                            if(answer[i] == input[j])
                            {
                                B++;
                            }
                        }
                    }
                }

                textBox1.Text += input.ToString() + " --> " + A.ToString() + "A" + B.ToString() + "B" + Environment.NewLine;

                if(A == 4)
                {
                    MessageBox.Show("猜對了");
                }
            }
            else
            {
                MessageBox.Show("請猜數字!!!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            string x;
            for (int i = 0; i < 4; i = i)
            {
                x = random.Next(0, 9).ToString();
                if (ans != null)
                {
                    for (int j = 0; j < ans.Length; j++)
                    {
                        if (ans[j].ToString() == x)
                        {
                            break;
                        }
                        if (j == ans.Length - 1)
                        {
                            ans += x;
                            i++;
                        }
                    }
                }
                else
                {
                    ans += x;
                    i++;
                }
            }

            textBox1.Clear();
            textBox2.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
