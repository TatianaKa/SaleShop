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
    /// Логика взаимодействия для DeliveryPage.xaml
    /// </summary>
    public partial class DeliveryPage : Page
    {
        private int Costs;
        private int IdOrder;
        public DeliveryPage(int Id, int Cost)
        {
            InitializeComponent();
            txbCost.Text = Cost.ToString();
            Costs = Cost;
            IdOrder = Id;
        }

        private void btnAddDelivery_Click(object sender, RoutedEventArgs e)
        {
            Delivery delivery = new Delivery();
            delivery.DateDelivery = DateTime.Now;
            delivery.Address = txbAddress.Text;
            delivery.IdOrder = IdOrder;
            ClassHelper.AppData.context.Delivery.Add(delivery);
            ClassHelper.AppData.context.SaveChanges();
            MessageBox.Show("Заказ прошел успешно!");
        }
    }
}
