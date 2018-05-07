using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork009
{
    public partial class Form1 : Form
    {
        static List<Item> itemlist;
        static List<Seller> selllist;
        public Form1()
        {
            InitializeComponent();
            CreateList();
            //DataView();
            Linq();
            DataView();
            Find_Best();
        }

        static void CreateList()
        {
            itemlist = new List<Item>();
            itemlist.Add(new Item() { 商品 = "原子筆", 單價 = 12 , 總銷售額 = 0 });
            itemlist.Add(new Item() { 商品 = "鉛筆", 單價 = 16 , 總銷售額 = 0 });
            itemlist.Add(new Item() { 商品 = "橡皮擦", 單價 = 10 , 總銷售額 = 0 });
            itemlist.Add(new Item() { 商品 = "直尺", 單價 = 14 , 總銷售額 = 0 });
            itemlist.Add(new Item() { 商品 = "立可白", 單價 = 15 , 總銷售額 = 0 });

            selllist = new List<Seller>();
            selllist.Add(new Seller() { 銷售員 = "Bill", 原子筆 = 33, 鉛筆 = 32, 橡皮擦 = 56, 直尺 = 45, 立可白 = 33 , 銷售業績 = 0 });
            selllist.Add(new Seller() { 銷售員 = "Jhon", 原子筆 = 77, 鉛筆 = 33, 橡皮擦 = 68, 直尺 = 45, 立可白 = 23, 銷售業績 = 0 });
            selllist.Add(new Seller() { 銷售員 = "David", 原子筆 = 43, 鉛筆 = 55, 橡皮擦 = 43, 直尺 = 67, 立可白 = 65, 銷售業績 = 0 });
        }

        public void DataView()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.DataSource = selllist;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView2.DataSource = itemlist;
        }
        public void Linq()
        {
            int Bill_total = 0 , Jhon_total = 0 , David_total = 0;
            int pen_price , pencil_price , eraser_price , ruler_price , white_price;
            int pen_total = 0;
            int pencil_total = 0;
            int eraser_total = 0;
            int ruler_total = 0;
            int white_total = 0;
            
            var item_result = itemlist.Find((x) => x.商品 == "原子筆");
            pen_price = item_result.單價;
            item_result = itemlist.Find((x) => x.商品 == "鉛筆");
            pencil_price = item_result.單價;
            item_result = itemlist.Find((x) => x.商品 == "橡皮擦");
            eraser_price = item_result.單價;
            item_result = itemlist.Find((x) => x.商品 == "直尺");
            ruler_price = item_result.單價;
            item_result = itemlist.Find((x) => x.商品 == "立可白");
            white_price = item_result.單價;

            foreach(var item in selllist)
            {
                if(item.銷售員 == "Bill")
                {
                    Bill_total = item.原子筆 * pen_price + item.鉛筆 * pencil_price + item.橡皮擦 * eraser_price + item.直尺 * ruler_price + item.立可白 * white_price;
                }
                if (item.銷售員 == "Jhon")
                {
                    Jhon_total = item.原子筆 * pen_price + item.鉛筆 * pencil_price + item.橡皮擦 * eraser_price + item.直尺 * ruler_price + item.立可白 * white_price;
                }
                if( item.銷售員 == "David")
                {
                    David_total = item.原子筆 * pen_price + item.鉛筆 * pencil_price + item.橡皮擦 * eraser_price + item.直尺 * ruler_price + item.立可白 * white_price;
                }
                pen_total += (item.原子筆 * pen_price);
                pencil_total += (item.鉛筆 * pencil_price);
                eraser_total += (item.橡皮擦 * eraser_price);
                ruler_total += (item.直尺 * ruler_price);
                white_total += (item.立可白 * white_price);
            }

            var sell_result = selllist.Find((x) => x.銷售員 == "Bill");
            sell_result.銷售業績 = Bill_total;
            sell_result = selllist.Find((x) => x.銷售員 == "Jhon");
            sell_result.銷售業績 = Jhon_total;
            sell_result = selllist.Find((x) => x.銷售員 == "David");
            sell_result.銷售業績 = David_total;

            item_result = itemlist.Find((x) => x.商品 == "原子筆");
            item_result.總銷售額 = pen_total;
            item_result = itemlist.Find((x) => x.商品 == "鉛筆");
            item_result.總銷售額 = pencil_total;
            item_result = itemlist.Find((x) => x.商品 == "橡皮擦");
            item_result.總銷售額 = eraser_total;
            item_result = itemlist.Find((x) => x.商品 == "直尺");
            item_result.總銷售額 = ruler_total;
            item_result = itemlist.Find((x) => x.商品 == "立可白");
            item_result.總銷售額 = white_total;
        }

        public void Find_Best()
        {
            var result1 = selllist.Find((x) => x.銷售業績 == selllist.Max((y) => y.銷售業績));
            label1.Text = result1.銷售員;
            var result2 = itemlist.Find((x) => x.總銷售額 == itemlist.Max((y) => y.總銷售額));
            label2.Text = result2.商品;
        }
    }
}
