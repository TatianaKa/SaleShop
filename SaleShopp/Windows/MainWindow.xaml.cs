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
using SaleShopp.Pages;
using SaleShopp.EF;
using SaleShopp.Windows;
using SaleShopp.EmptyPages;


namespace SaleShopp
{
    public partial class MainWindow : Window
    {
        List<Product> products = new List<Product> { };
        public int IdClient;
        private bool isAuth = false;
        public MainWindow()
        {
            InitializeComponent();
            frameMain.Navigate(new MainPage());
            Filter();
        }
        public MainWindow(int Id)
        {
            InitializeComponent();
            isAuth = true;
            IdClient = Id;
            Filter();
        }

        public void Filter()
        {
            MainPage main = new MainPage();
            products = ClassHelper.AppData.context.Product.ToList();
            products = products.Where(i => i.NameProduct.Contains(txbSearch.Text)).ToList();
            main.LVMain.ItemsSource = products;
        }

        private void btnAuth_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (isAuth == false)
            {
                AuthWindow auth = new AuthWindow();
                auth.Show();
                Close();
            }
            else
            {
                var Mes = MessageBox.Show("Вы уверены?", "Выход", MessageBoxButton.YesNo);
                if (Mes == MessageBoxResult.Yes)
                {
                    txbAuth.Text = "Войти";
                    isAuth = false;
                }
            }
        }

        private void btnOrder_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (isAuth == false) frameMain.Navigate(new EmptyOrderPage());
           else frameMain.Navigate(new OrderPage(IdClient));
        }

        private void btnFavorites_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (isAuth == false) frameMain.Navigate(new EmptyFavoritePage());
            else frameMain.Navigate(new FavoritePage(IdClient));
        }

        private void btnBasket_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (isAuth == false) frameMain.Navigate(new EmptyBasketPage());
            else frameMain.Navigate(new BasketPage(IdClient));
        }
        //Не видно навигации
        private void myFrame_ContentRendered(object sender, EventArgs e)
        {
            frameMain.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }

        private void txbSlogan_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainPage main = new MainPage();
            frameMain.Navigate(main);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Filter();

        }

        private void txbCatalog_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (isAuth == true)
            {
                CatalogPage catalog = new CatalogPage(IdClient);
                frameMain.Navigate(catalog);
            }
            else
            {
                CatalogPage catalogPage = new CatalogPage();
                frameMain.Navigate(catalogPage);
            }
        }
    }
}
