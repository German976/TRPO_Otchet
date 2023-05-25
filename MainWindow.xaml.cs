using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;


namespace Wpf1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Classes.ProductsInBasket> productsInBaskets = new List<Classes.ProductsInBasket>();   
        List<string> orders = new List<string>();
        
        public MainWindow()
        {
            InitializeComponent();

            App.productsInBasket = new List<Classes.ProductsInBasket>();
            labelSumma.Content = App.labelSummaMain;
            try
            {
                App.excelApp = new Excel.Application();
                App.excelApp.Visible = false;
                //MessageBox.Show("У Вас установлен MS Excel");
                if (File.Exists(App.fileMenu))
                {
                    App.excelBook = App.excelApp.Workbooks.Open(App.fileMenu);
                }
                else
                {
                    MessageBox.Show("Файл с меню отсутсвует");
                    this.Close();
                }
            }
            catch 
            {
                MessageBox.Show("Установлен MS Excel");
                this.Close();
            }
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            App.excelApp.Quit();
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(App.excelApp);
            GC.Collect();
            foreach (System.Windows.Window window in App.Current.Windows)
            {
                window.Close();
            }
        }

        private void Price_list_Click(object sender, RoutedEventArgs e)
        {
            App.excelApp.Visible = true;
            MessageBox.Show("Прайс-лист");
        }

        private void Create_Zakaz_Click(object sender, RoutedEventArgs e)
        {
            double sum = 1000;
            //MessageBox.Show($"Мы заглянули на Вашу карту.На ней сумма: {sum} рублей");

            Make_an_order make_An_Order = new Make_an_order(this, int.Parse(labelSumma.Content.ToString() as string), productsInBaskets);
            this.Hide();
            make_An_Order.Owner = this;
            make_An_Order.ShowDialog();
            this.Show();
        }

        private void Work_Katalog_Click(object sender, RoutedEventArgs e)
        {
            if (App.isLogged == true)
            {
                Basket basket = new Basket(productsInBaskets);
                this.Hide();
                basket.ShowDialog();
                this.Show(); 
            }
            else
            {
                TaskWindow taskWindow = new TaskWindow(this, int.Parse(labelSumma.Content.ToString() as string));
                this.Hide();
                taskWindow.ShowDialog();
                this.Show();
            }
            
            //MessageBox.Show("Работа с каталогом");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TaskWindow taskWindow = new TaskWindow(this, int.Parse(labelSumma.Content.ToString() as string));
            this.Hide();
            taskWindow.ShowDialog();
            this.Show();
        }

        private void TextBoxSignUpMenu_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            buttonExit_Click(null, null);
            App.excelApp.Quit();
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(App.excelApp);
            GC.Collect();
            foreach (System.Windows.Window window in App.Current.Windows)
            {
                window.Close();
            }
        }
    }
}
