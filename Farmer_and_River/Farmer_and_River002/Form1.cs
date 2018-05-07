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
        private List<string> _leftList;
        private List<string> _rightList;
        Stack<List<string>> _lefthistory = new Stack<List<string>>();
        Stack<List<string>> _righthistory = new Stack<List<string>>();
        bool go = true; //true = 可以往右走 反之 可以往左走
        public Form1()
        {
            InitializeComponent();
            CreateList();
            UIInit();
        }
        private void CreateList() //初始List
        {
            _leftList = new List<string>();
            _leftList.Add("農夫");
            _leftList.Add("狼");
            _leftList.Add("羊");
            _leftList.Add("菜");
            _rightList = new List<string>();
        }
        private void UIInit() //UI初始
        {
            listBox1.SelectionMode = SelectionMode.One;
            listBox2.SelectionMode = SelectionMode.One;
            listBox1.DataSource = _leftList;
            listBox2.DataSource = _rightList;
            listBox1.Enabled = true;
            listBox2.Enabled = false;
            button2.Enabled = false;
            go = true;
        }
        private void Refresh() //刷新ListBox
        {
            listBox1.DataSource = null;
            listBox2.DataSource = null;
            listBox1.DataSource = _leftList;
            listBox2.DataSource = _rightList;
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
            if (_rightList.Contains("農夫") && _rightList.Contains("羊") && _rightList.Contains("狼") && _rightList.Contains("菜"))
            {
                MessageBox.Show("Win ~~~ ");
                Application.Exit();
            }
            if (_leftList.Contains("農夫") == false)
            {
                if (_leftList.Contains("狼") && _leftList.Contains("羊"))
                {
                    MessageBox.Show("羊 被 狼 吃了");
                    button1.Enabled = false;
                }
                else if (_leftList.Contains("羊") && _leftList.Contains("菜"))
                {
                    MessageBox.Show("菜 被 羊 吃了");
                    button1.Enabled = false;
                }
            }
            else if (_rightList.Contains("農夫") == false)
            {
                if (_rightList.Contains("狼") && _rightList.Contains("羊"))
                {
                    MessageBox.Show("羊 被 狼 吃了");
                    button1.Enabled = false;
                }
                else if (_rightList.Contains("羊") && _rightList.Contains("菜"))
                {
                    MessageBox.Show("菜 被 羊 吃了");
                    button1.Enabled = false;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e) //Move
        {
            //紀錄至Stack
            List<string> tmp = new List<string>();
            _lefthistory.Push(tmp = _leftList.ToList());
            _righthistory.Push(tmp = _rightList.ToList());
            button2.Enabled = true;
            
            string farmer = "農夫";
            if (go == true)
            {
                if ((string)listBox1.SelectedItem == farmer)
                {
                    _leftList.Remove(farmer);
                    _rightList.Add(farmer);
                    go = false;
                }
                else if ((string)listBox1.SelectedItem != farmer)
                {
                    string item = (string)listBox1.SelectedItem;
                    _leftList.Remove(item);
                    _leftList.Remove(farmer);
                    _rightList.Add(item);
                    _rightList.Add(farmer);
                    go = false;
                }
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
                    _leftList.Add(farmer);
                    _rightList.Remove(farmer);
                    go = true;
                }
                else if ((string)listBox2.SelectedItem != farmer)
                {
                    string item = (string)listBox2.SelectedItem;
                    _leftList.Add(item);
                    _leftList.Add(farmer);
                    _rightList.Remove(item);
                    _rightList.Remove(farmer);
                    go = true;
                }
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
                _leftList = _lefthistory.Pop();
                _rightList = _righthistory.Pop();
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
            button1.Enabled = true;
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
