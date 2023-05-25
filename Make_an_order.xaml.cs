using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wpf1.Classes;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace Wpf1
{
    /// <summary>
    /// Логика взаимодействия для Make_an_order.xaml
    /// </summary>
    public partial class Make_an_order : Window
    {
        //public List<Classes.ProductsInBasket> productsInBasket = new List<Classes.ProductsInBasket>();
        
        public List<string> basketProducts = new List<string>();
        public List<Classes.Product> products = new List<Classes.Product>();
        public List<string> order = new List<string>();
        public double OrderCost { get; set; }
        public double AmountOfMoney { get; set; }
        public int orderAmount;
        public List<Classes.ProductsInBasket> productsInBaskets;

        MainWindow windowM;
        public Make_an_order(MainWindow window, int summa, List<Classes.ProductsInBasket> productsInBaskets)
        {
            InitializeComponent();
            openExcel();
            LBCategory.ItemsSource= order;
            LBvegetables.ItemsSource = products;
            labelSummaOrder.Content = summa;
            this.windowM = window;
            this.productsInBaskets = productsInBaskets;
        }

        private void openExcel()
        {
            //if (File.Exists(App.fileMenu))
            //{
            //    App.excelBook = App.excelApp.Workbooks.Open(App.fileMenu);
            //}
            //else
            //{
            //    MessageBox.Show("Файл отсутсвует!"); this.Close();
            //}

            foreach (Excel.Worksheet sheet in App.excelBook.Worksheets)
            {
                order.Add(sheet.Name);
            }
        }

        public void click()
        {
            App.isLogged = true;
        }

        private void LBCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Random random = new Random();
            string categoryName = LBCategory.SelectedItem.ToString();
            App.excelCels = App.excelBook.Sheets[categoryName].Cells;

            Classes.Product product;
            products.Clear();
            for(int rows = 1; App.excelCels[rows, 1].value2 != null; rows++)
            {
                product = new Classes.Product();
                product.Name = App.excelCels.Cells[rows, 1].value2;
                product.Price = (int)App.excelCels.Cells[rows, 2].value2;

                int[] discounts = { 0, 15, 30, 35 };
                product.Discont = discounts[random.Next(0, discounts.Length)];
                product.PriceDisc = CalculatorDisc(product.Price, product.Discont);

                product.Calories = (int)App.excelCels.Cells[rows, 3].value2;
                product.Weight = (int)App.excelCels.Cells[rows, 4].value2;
                products.Add(product);
            }
            LBvegetables.Items.Refresh();
        }

        private double CalculatorDisc(int price, int discont)
        {
            double resCalcDisc = Math.Round((100.0 - discont) * price / 100, 2);
            return resCalcDisc;
        }

        private void ExitMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addProduct_Click(object sender, RoutedEventArgs e)
        {
            Classes.ProductsInBasket productInBasket = null;

            Classes.Product product = (sender as Button).DataContext as Classes.Product;
            string productName = product.Name;
            App.productPrice = product.Price;
            if(OrderCost + App.productPrice <= int.Parse(labelSummaOrder.Content.ToString()))
            {
                OrderCost += App.productPrice;
                labelSummaOrder.Content = int.Parse(labelSummaOrder.Content.ToString()) - OrderCost;

                int index = productsInBaskets.FindIndex(x => x.Name == productName);
                if(index < 0)
                {
                    productInBasket = new Classes.ProductsInBasket();
                    productInBasket.Name = productName;
                    productInBasket.Price = App.productPrice;
                    productInBasket.Amount = 1;
                    productInBasket.Total = App.productPrice;
                    productsInBaskets.Add(productInBasket);
                }
                else //если товар есть, то увеличиваем его  кол-во
                {
                    productsInBaskets[index].Amount++;
                    productsInBaskets[index].Total =productsInBaskets[index].Price * productsInBaskets[index].Amount;
                }
                //метод для диаграммы
            }
            else
            {
                MessageBox.Show("No money!");
            }
        }
    }
}
