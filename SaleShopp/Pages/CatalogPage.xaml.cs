using SaleShopp.EF;
using System.Linq;
using System.Windows.Controls;

namespace SaleShopp.Pages
{
    /// <summary>
    /// Логика взаимодействия для CatalogPage.xaml
    /// </summary>
    public partial class CatalogPage : Page
    {
        private int IdClient;
        private bool IsAuth=false;
        public CatalogPage()
        {
            InitializeComponent();
            LvCatalog.ItemsSource = ClassHelper.AppData.context.Product.ToList();
            IsAuth = false;
        }
        public CatalogPage(int Id)
        {
            InitializeComponent();
            IdClient = Id;
            IsAuth = true;
            LvCatalog.ItemsSource = ClassHelper.AppData.context.Product.ToList();
        }

        private void LvCatalog_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var product = LvCatalog.SelectedItem as Product;
            if (IsAuth == true)
            {
                ProductPage productPage = new ProductPage(product.Id, IdClient);
                frame.Navigate(productPage);
            }
            else 
            {
                ProductPage productPage = new ProductPage(product.Id);
                frame.Navigate(productPage);
            }
        }
    }
}
