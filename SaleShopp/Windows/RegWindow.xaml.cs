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

namespace SaleShopp.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        public RegWindow()
        {
            InitializeComponent();
        }
        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            var Mes = MessageBox.Show("Вы уверены?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Mes == MessageBoxResult.Yes)
            {
                EF.Client client = new EF.Client();
                client.LastName = txbLName.Text;
                client.FirstName = txbFName.Text;
                client.Email = txbEmail.Text;
                client.Phone = txbPhone.Text;
                client.Login = txbLogin.Text;
                if (txbPass.Text == txbRepeatPass.Text)
                {
                    client.Password = txbPass.Text;
                }
                ClassHelper.AppData.context.Client.Add(client);
                ClassHelper.AppData.context.SaveChanges();
                MessageBox.Show("Вы успешно зарегистрированы!");
                Hide();
            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}
