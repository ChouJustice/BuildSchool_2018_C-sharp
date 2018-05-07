using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Luwei_Store
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal total = numericUpDown1.Value * Food.高麗菜 + numericUpDown2.Value * Food.豆干 + numericUpDown3.Value * Food.海帶 + numericUpDown4.Value * Food.肉片;
            label1.Text = string.Format($"總價 : {total}");
            MoneyCount(total);
        }

        private void MoneyCount(decimal money)
        {
            decimal[] Level = new decimal[7] { 1000, 500, 100, 50 ,10 ,5 ,1 };
            decimal[] Count = new decimal[7] { 0,0,0,0,0,0,0 };

            for(int i=0;i < Level.Length;i++)
            {
                Count[i] = (decimal)((int)(money / Level[i]));
                money = money % Level[i];
            }

            label2.Text = string.Format($"1000 : {Environment.NewLine} 500 : {Environment.NewLine} 100 : {Environment.NewLine}  50 : {Environment.NewLine}  10 : {Environment.NewLine}   5 : {Environment.NewLine}   1 : {Environment.NewLine}");

            label3.Text = "";
            foreach(var item in Count)
            {
                label3.Text += item.ToString() + Environment.NewLine;
            }
        }
    }

    public static class Food
    {
        public const decimal 高麗菜 = 30;
        public const decimal 豆干 = 15;
        public const decimal 海帶 = 15;
        public const decimal 肉片 = 40;
    }
}
