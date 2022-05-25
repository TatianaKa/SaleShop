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
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        private int Id;
        private int IdClient;
        private int Qtyy=1;
        private int Costs;
        private int FCost;
        private bool isAuth = false;
        public ProductPage(int IdProduct)
        {
            InitializeComponent();
            Id = IdProduct;
            isAuth = false;
            var cost = ClassHelper.AppData.context.Product.Where(i => i.Id == Id).ToList().FirstOrDefault().Cost;
            Costs = Convert.ToInt32(cost);
            LvProduct.ItemsSource = ClassHelper.AppData.context.Product.Where(i => i.Id == Id).ToList();
            FCost = Qtyy * Costs;
            txbQty.Text = Qtyy.ToString();
            txbFCost.Text = FCost.ToString();

            
        }
        public ProductPage(int IdProducts,int IdClients)
        {
            InitializeComponent();
            isAuth = true;
            Id = IdProducts;
            IdClient = IdClients;

            var cost = ClassHelper.AppData.context.Product.Where(i => i.Id == Id).ToList().FirstOrDefault().Cost;
            Costs = Convert.ToInt32(cost);
            LvProduct.ItemsSource = ClassHelper.AppData.context.Product.Where(i => i.Id == Id).ToList();
            FCost = Qtyy * Costs;
            txbQty.Text = Qtyy.ToString();
            txbFCost.Text = FCost.ToString();

           

        }

        private void btnAddBasket_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            if (isAuth==true)
            {
                order.IdClient = IdClient;
                order.IdProduct = Id;
                order.Qty = Convert.ToInt32(txbQty.Text);
                order.FinishCost = Costs * Qtyy;
                ClassHelper.AppData.context.Order.Add(order);
                ClassHelper.AppData.context.SaveChanges();
            }
            else MessageBox.Show("Внимание","Для продолжения скинь мне 100");
        }

        private void txbAddFavorite_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isAuth == true)
            {
                Favorite favorite = new Favorite();
                favorite.IdProduct = Id;
                favorite.IdClient = IdClient;
                favorite.Qty = Convert.ToInt32(txbQty.Text);
                favorite.Cost = Costs;
                ClassHelper.AppData.context.Favorite.Add(favorite);
                ClassHelper.AppData.context.SaveChanges();
            }
            else { }
        }

        private void txbMinus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Qtyy > 0)
            {
                txbQty.Text = $"{--Qtyy}".ToString();
                FCost = Qtyy * Costs;
                txbFCost.Text = FCost.ToString();
            }
            else { }
        }

        private void txbPlus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txbQty.Text = $"{++Qtyy}".ToString();
            FCost = Qtyy * Costs;
            txbFCost.Text = FCost.ToString();
        }
    }
}
