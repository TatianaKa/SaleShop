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
using SaleShopp.Windows;

namespace SaleShopp.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }
        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            var userAuth = ClassHelper.AppData.context.Client.Where(i => i.Login == txbLogin.Text && i.Password == txbPassword.Password)
                .ToList().FirstOrDefault();
            if (userAuth != null)
            {
                Pages.MainPage main = new Pages.MainPage(userAuth.Id);
                MainWindow mainWindow = new MainWindow(userAuth.Id);
                mainWindow.txbAuth.Text = "Выйти";
                mainWindow.frameMain.Navigate(main);
                this.Close();
                mainWindow.Show();

            }
        }

        private void tblReg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RegWindow reg = new RegWindow();
            reg.ShowDialog();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void tblPasswordLost_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowPassLost window = new WindowPassLost();
            Hide();
            window.ShowDialog();

        }
    }
}
