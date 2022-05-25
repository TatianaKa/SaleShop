using SaleShopp.EF;
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

namespace SaleShopp.Pages
{
    /// <summary>
    /// Логика взаимодействия для BasketPage.xaml
    /// </summary>
    public partial class BasketPage : Page
    {
        private int Qty;
        private int IdOrder;
        public BasketPage(int Id)
        {
            InitializeComponent();
            LVBascet.ItemsSource = ClassHelper.AppData.context.Order.Where(i => i.IdClient == Id).ToList();
            Qty = ClassHelper.AppData.context.Order.Where(i => i.IdClient == Id).FirstOrDefault().Qty;
            txbQty.Text = Qty.ToString();
            var product = LVBascet.SelectedItem as EF.Order;
           

        }

        private void txbMin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Qty--;
            txbQty.Text = Qty.ToString();

        }

        private void txbPlus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Qty++;
            txbQty.Text=Qty.ToString();
        }

        private void txbAddOrder_Click(object sender, RoutedEventArgs e)
        {
            var product = LVBascet.SelectedItem as EF.Order;
            IdOrder = ClassHelper.AppData.context.Order.Where(i => i.IdProduct == product.IdProduct).FirstOrDefault().Id;
            Order order = new Order();
            order.DateOrder = DateTime.Now;
            order.IdProduct = product.IdProduct;
            order.FinishCost = product.FinishCost;
            order.Qty = Qty;
            order.IdClient =product.IdClient;
            ClassHelper.AppData.context.Order.Add(order);
            ClassHelper.AppData.context.SaveChanges();
            frame.Navigate(new DeliveryPage(IdOrder,Convert.ToInt32(txbFCost.Text)));
        }
    }
}
