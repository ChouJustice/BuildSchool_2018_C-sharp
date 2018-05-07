using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Performance.Models;

namespace Performance
{
    public partial class Form1 : Form
    {
        List<Products> products_list = (new ContactsModel()).Products.ToList();
        List<Sales> Sales_list = (new ContactsModel()).Sales.ToList();
        List<Mylist> Join_list = new List<Mylist>();
        public Form1()
        {
            InitializeComponent();
            InsertMyData();
            GetJoinList();

            FindBestSales();
            FindBestProduct();

            //DataView();
        }

        private void InsertMyData()
        {
            try
            {
                ContactsModel context = new ContactsModel();

                //var P_rows = context.Products.ToList();

                //foreach(var row in P_rows)
                //{
                //    context.Products.Remove(row);
                //}

                //var S_rows = context.Sales.ToList();

                //foreach(var row in S_rows)
                //{
                //    context.Sales.Remove(row);
                //}

                context.Database.ExecuteSqlCommand("TRUNCATE TABLE [Products]");
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE [Sales]");

                context.SaveChanges();

                context.Products.Add(new Products { Product_Name = "原子筆", Product_Price = 12 });
                context.Products.Add(new Products { Product_Name = "鉛筆", Product_Price = 16 });
                context.Products.Add(new Products { Product_Name = "橡皮擦", Product_Price = 10 });
                context.Products.Add(new Products { Product_Name = "直尺", Product_Price = 14 });
                context.Products.Add(new Products { Product_Name = "立可白", Product_Price = 15 });

                context.Sales.Add(new Sales { Name = "Bill", Product_Name = "原子筆", Product_Quantity = 33 });
                context.Sales.Add(new Sales { Name = "Bill", Product_Name = "鉛筆", Product_Quantity = 32 });
                context.Sales.Add(new Sales { Name = "Bill", Product_Name = "橡皮擦", Product_Quantity = 56 });
                context.Sales.Add(new Sales { Name = "Bill", Product_Name = "直尺", Product_Quantity = 45 });
                context.Sales.Add(new Sales { Name = "Bill", Product_Name = "立可白", Product_Quantity = 33 });
                context.Sales.Add(new Sales { Name = "Jhon", Product_Name = "原子筆", Product_Quantity = 77 });
                context.Sales.Add(new Sales { Name = "Jhon", Product_Name = "鉛筆", Product_Quantity = 33 });
                context.Sales.Add(new Sales { Name = "Jhon", Product_Name = "橡皮擦", Product_Quantity = 68 });
                context.Sales.Add(new Sales { Name = "Jhon", Product_Name = "直尺", Product_Quantity = 45 });
                context.Sales.Add(new Sales { Name = "Jhon", Product_Name = "立可白", Product_Quantity = 23 });
                context.Sales.Add(new Sales { Name = "David", Product_Name = "原子筆", Product_Quantity = 43 });
                context.Sales.Add(new Sales { Name = "David", Product_Name = "鉛筆", Product_Quantity = 55 });
                context.Sales.Add(new Sales { Name = "David", Product_Name = "橡皮擦", Product_Quantity = 43 });
                context.Sales.Add(new Sales { Name = "David", Product_Name = "直尺", Product_Quantity = 67 });
                context.Sales.Add(new Sales { Name = "David", Product_Name = "立可白", Product_Quantity = 65 });

                context.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataView()
        {
            var context = new ContactsModel();
            var list1 = context.Products.ToList();
            dataGridView1.DataSource = Join_list;

            var list2 = context.Sales.ToList();
            dataGridView2.DataSource = list2;
        }

        private void FindBestSales()
        {
            var result = Join_list.GroupBy((x) => x.Sales_Name).Select((x) =>
            {
                return new { Salesman = x.Key, Amount = x.Sum((y) => y.Sum_of_Product_Price) };
            }
            );
            dataGridView1.DataSource = result.ToList();
            var best = result.FirstOrDefault((x) => x.Amount == result.Max((y) => y.Amount));
            label3.Text = best.Salesman;
        }
        private void FindBestProduct()
        {
            var result = Join_list.GroupBy((x) => x.Product_Name).Select((x) =>
            {
                return new { Item = x.Key, Amount = x.Sum((y) => y.Sum_of_Product_Price) };
            });

            dataGridView2.DataSource = result.ToList();
            var best = result.FirstOrDefault((x) => x.Amount == result.Max((y) => y.Amount));
            label4.Text = best.Item;
        }

        private void GetJoinList()
        {
            var list = from s in Sales_list
                       join p in products_list
                       on s.Product_Name equals p.Product_Name
                       select new Mylist
                       {
                           Product_Name = p.Product_Name,
                           Sales_Name = s.Name,
                           Sum_of_Product_Price = p.Product_Price * s.Product_Quantity
                       };

            Join_list = list.ToList();
        }
    }
}
