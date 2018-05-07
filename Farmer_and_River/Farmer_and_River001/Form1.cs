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
        bool go = true;
        public Form1()
        {
            InitializeComponent();
            CreateList();
            UIInit();
        }
        private void CreateList()
        {
            _leftList = new List<string>
            {
                "農夫","狼","羊","菜"
            };
            _rightList = new List<string>();
        }
        private void UIInit()
        {
            listBox1.SelectionMode = SelectionMode.One;
            listBox2.SelectionMode = SelectionMode.One;
            listBox1.DataSource = _leftList;
            listBox2.DataSource = _rightList;
            listBox1.Enabled = true;
            listBox2.Enabled = false;
            go = true;
        }
        private void Refresh()
        {
            listBox1.DataSource = null;
            listBox2.DataSource = null;
            listBox1.DataSource = _leftList;
            listBox2.DataSource = _rightList;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string farmer = "農夫";
            if (go == true)
            {
                if ((string)listBox1.SelectedItem == farmer)
                {
                    _leftList.Remove(farmer);
                    _rightList.Add(farmer);
                    go = false;
                }
                else if (listBox1.SelectedItem != null)
                {
                    string item = (string)listBox1.SelectedItem;
                    if (item == farmer) return;
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
                else if (listBox2.SelectedItem != null)
                {
                    string item = (string)listBox2.SelectedItem;
                    if (item == farmer) return;
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
        private void Check()
        {
            if(_rightList.Contains("農夫") && _rightList.Contains("羊") && _rightList.Contains("狼") && _rightList.Contains("菜"))
            {
                MessageBox.Show("Win ~~~ ");
                Application.Exit();
            }
            if (_leftList.Contains("農夫") == false)
            {
                if (_leftList.Contains("狼") && _leftList.Contains("羊"))
                {
                    MessageBox.Show("羊 被 狼 吃了");
                    CreateList();
                    UIInit();
                }
                else if (_leftList.Contains("羊") && _leftList.Contains("菜"))
                {
                    MessageBox.Show("菜 被 羊 吃了");
                    CreateList();
                    UIInit();
                }
            }
            else if(_rightList.Contains("農夫") == false)
            {
                if (_rightList.Contains("狼") && _rightList.Contains("羊"))
                {
                    MessageBox.Show("羊 被 狼 吃了");
                    CreateList();
                    UIInit();
                }
                else if (_rightList.Contains("羊") && _rightList.Contains("菜"))
                {
                    MessageBox.Show("菜 被 羊 吃了");
                    CreateList();
                    UIInit();
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            CreateList();
            UIInit();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" 農夫渡河規則:\n\n 農夫要帶著狼、羊菜過河。\n 小船不夠大，因此農夫每次只能帶一樣東西過河。\n 當農夫在的時候，狼、羊菜都不會有事情。\n 當農夫不在時，狼會吃羊菜。");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("農夫 羊 ->\n農夫 < -\n農夫 菜->\n農夫 羊 < -\n農夫 狼->\n農夫 < -\n農夫 羊->");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
