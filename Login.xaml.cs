using System;
using System.Collections.Generic;
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

namespace Wpf1
{
    /// <summary>
    /// Логика взаимодействия для TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        MainWindow windowM;
        public List<Classes.loginAndPassword> loginAndPasswords= new List<Classes.loginAndPassword>();
        Classes.loginAndPassword logAndPas;
        public TaskWindow(MainWindow window, int summa)
        {
            InitializeComponent();
            labelLoginSumma.Content= summa;
            this.windowM = window;
        }

        public void loginAndPasswordTrue()
        {
            string login = TextBoxEmail.Text.ToString();
            App.excelCels = App.excelBook.Sheets[login].Cells;
        }


        public void click()
        {
            App.isLogged = true;
        }

        private void ButtonSingUp_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
        }

        private void ButtonSignIn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExitMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonSignIn_Click_1(object sender, RoutedEventArgs e)
        {
            if (TextBoxEmail.Text.Equals(App.adminLogin))
            {
                if (TextBoxPassword.Text == App.adminPassword)
                {
                    this.Close();
                    MessageBox.Show("You are logged in");
                    App.isLogged= true;
                }
                else
                {
                    MessageBox.Show("Invalid password");
                }
            }
            else
            {
                MessageBox.Show("Invalid username");
            }
            
        }
    }
}
