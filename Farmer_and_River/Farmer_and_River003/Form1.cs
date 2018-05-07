using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farmer_and_River
{
    public partial class Form1 : Form
    {
        private Member leftList;
        private Member rightList;
        Stack<List<string>> _lefthistory = new Stack<List<string>>();
        Stack<List<string>> _righthistory = new Stack<List<string>>();
        bool go = true; //true = 可以往右走 反之 可以往左走
        public Form1()
        {
            InitializeComponent();
            ResetGame();
        }
        private void CreateList() //初始List (資料)
        {
            leftList = new Member();
            leftList.list = new List<string>();
            leftList.list.Add("農夫");
            leftList.list.Add("狼");
            leftList.list.Add("羊");
            leftList.list.Add("菜");
            rightList = new Member();
            rightList.list = new List<string>();
            go = true;
        }
        private void UIInit() //UI初始
        {
            listBox1.SelectionMode = SelectionMode.One;
            listBox2.SelectionMode = SelectionMode.One;
            listBox1.Enabled = true;
            listBox2.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = false;
        }
        private void Refresh() //刷新ListBox
        {
            listBox1.DataSource = null;
            listBox2.DataSource = null;
            listBox1.DataSource = leftList.list;
            listBox2.DataSource = rightList.list;
        }
        private void ResetGame() //重新開始遊戲
        {
            CreateList();
            UIInit();
            Refresh();
            _lefthistory.Clear();
            _righthistory.Clear();
        }
        private void Check() //遊戲規則
        {
            string[] win = { "農夫","狼","羊","菜" };
            string[] farmer = { "農夫" };
            string[] wolf_sheep = { "狼", "羊" };
            string[] sheep_vage = { "羊", "菜" };

            if (rightList.Exists(rightList.list, win) == true)
            {
                MessageBox.Show("Win ~~~ ");
                Application.Exit();
            }
            else
            {
                if (! leftList.Exists(leftList.list,farmer))
                {
                    if(leftList.Exists(leftList.list,wolf_sheep))
                    {
                        MessageBox.Show("狼 吃 羊");
                        button1.Enabled = false;
                    }
                    if (leftList.Exists(leftList.list, sheep_vage))
                    {
                        MessageBox.Show("羊 吃 草");
                        button1.Enabled = false;
                    }
                }
                else if (!rightList.Exists(rightList.list, farmer))
                {
                    if (rightList.Exists(rightList.list, wolf_sheep))
                    {
                        MessageBox.Show("狼 吃 羊");
                        button1.Enabled = false;
                    }
                    if (rightList.Exists(rightList.list, sheep_vage))
                    {
                        MessageBox.Show("羊 吃 草");
                        button1.Enabled = false;
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e) //Move
        {
            //紀錄至Stack
            List<string> tmp = new List<string>();
            _lefthistory.Push(tmp = leftList.list.ToList());
            _righthistory.Push(tmp = rightList.list.ToList());
            button2.Enabled = true;

            string farmer = "農夫";
            if (go == true)
            {
                if ((string)listBox1.SelectedItem == farmer)
                {
                    leftList.list.Remove(farmer);
                    rightList.list.Add(farmer);
                }
                else if ((string)listBox1.SelectedItem != farmer)
                {
                    string item = (string)listBox1.SelectedItem;
                    leftList.list.Remove(farmer);
                    leftList.list.Remove(item);
                    rightList.list.Add(farmer);
                    rightList.list.Add(item);
                }
                go = false;
                Refresh();
                listBox1.Enabled = false;
                listBox2.Enabled = true;
                listBox2.SelectedIndex = 0;
                Check();
            }
            else if(go == false)
            {
                if ((string)listBox2.SelectedItem == farmer)
                {
                    leftList.list.Add(farmer);
                    rightList.list.Remove(farmer);
                }
                else if ((string)listBox2.SelectedItem != farmer)
                {
                    string item = (string)listBox2.SelectedItem;
                    leftList.list.Add(farmer);
                    leftList.list.Add(item);
                    rightList.list.Remove(farmer);
                    rightList.list.Remove(item);
                }
                go = true;
                Refresh();
                listBox1.Enabled = true;
                listBox2.Enabled = false;
                listBox1.SelectedIndex = 0;
                Check();
            }
        }
        private void button2_Click(object sender, EventArgs e) //Back
        {
            button1.Enabled = true;
            if (_lefthistory.Count != 0 || _righthistory.Count != 0)
            {
                leftList.list = _lefthistory.Pop();
                rightList.list = _righthistory.Pop();
                Refresh();
                if (_lefthistory.Count == 0) button2.Enabled = false;
                if (_lefthistory.Count % 2 != 0)
                {
                    listBox1.Enabled = false;
                    listBox2.Enabled = true;
                    go = false;
                }
                else
                {
                    listBox1.Enabled = true;
                    listBox2.Enabled = false;
                    go = true;
                }
            }
        }
        private void button3_Click(object sender, EventArgs e) //Reset
        {
            ResetGame();
        }
        private void button4_Click(object sender, EventArgs e) //Rule
        {
            MessageBox.Show(" 農夫渡河規則:\n\n 農夫要帶著狼、羊菜過河。\n 小船不夠大，因此農夫每次只能帶一樣東西過河。\n 當農夫在的時候，狼、羊菜都不會有事情。\n 當農夫不在時，狼會吃羊菜。");
        }
        private void button5_Click(object sender, EventArgs e) //Ans
        {
            MessageBox.Show("農夫 羊 ->\n農夫 < -\n農夫 菜->\n農夫 羊 < -\n農夫 狼->\n農夫 < -\n農夫 羊->");
        }
        private void button6_Click(object sender, EventArgs e) //Exit
        {
            Application.Exit();
        }
        
    }
}
