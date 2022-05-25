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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SaleShopp.EF;

namespace SaleShopp.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public bool IsAuth = false;
        private int IdClients;

        public MainPage(int IdClient)
        {
            InitializeComponent();
            IdClients = IdClient;
            LVMain.ItemsSource = ClassHelper.AppData.context.Product.ToList();
            IsAuth = true;
        }

        public MainPage()
        {
            InitializeComponent();
            LVMain.ItemsSource = ClassHelper.AppData.context.Product.ToList();
        }

        private void LVMain_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (IsAuth==true)
            {
                var product = LVMain.SelectedItem as Product;
                frame.Navigate(new ProductPage(product.Id,IdClients));
            }
            else
            {
                var product = LVMain.SelectedItem as Product;
                frame.Navigate(new ProductPage(product.Id));
            }
           
        }
    }
}
