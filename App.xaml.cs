using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;

namespace Wpf1
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Excel.Application excelApp;
        public static Excel.Workbook excelBook;
        public static Excel.Worksheet excelSheet;
        public static Excel.Range excelCels;

        public static string pathExe = Environment.CurrentDirectory;
        public static string fileAccounts = pathExe + @"\Supermarket.xlsx";
        public static string fileMenu = pathExe + @"\Supermarket-Menu.xlsx";
        public static string adminLogin = "German";
        public static string adminPassword = "german";
        public static bool isLogged = false;
        public static int labelSummaMain = 2500;
        public static int productPrice;
        public static int result;


        //public static List<Classes.ProductsInBasket> productsInBasket = new List<Classes.ProductsInBasket>();
        public static List<Classes.ProductsInBasket> productsInBasket;



    }
}
