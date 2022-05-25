using SaleShopp.EF;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SaleShopp.Pages
{
    /// <summary>
    /// Логика взаимодействия для FavoritePage.xaml
    /// </summary>
    public partial class FavoritePage : Page
    {
        private int IdClient;
        public FavoritePage(int IdClients)
        {
            InitializeComponent();
            IdClient = IdClients;
            LvFavorite.ItemsSource = ClassHelper.AppData.context.Favorite.Where(i => i.IdClient == IdClients).ToList();

        }
        private void btnDelFav_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var Mes = MessageBox.Show("Вы уверены?", "Вопрос", MessageBoxButton.YesNo);
            if (Mes == MessageBoxResult.Yes)
            {
                var favorite1 = LvFavorite.SelectedItem as Favorite;
                Favorite favorite = new Favorite();
                favorite.IdProduct = favorite1.IdProduct;
                favorite.IdClient = IdClient;
                favorite.Qty = favorite.Qty;
                ClassHelper.AppData.context.Favorite.Remove(favorite);
                ClassHelper.AppData.context.SaveChanges();
                MessageBox.Show("Товар удален из избранного");
            }
        }

        private void txbAddBaket_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Favorite favorite = new Favorite();

            Favorite favorite1 = LvFavorite.SelectedItem as Favorite;

            DateTime date = DateTime.Now;
            //добавление в заказ
            Order order = new Order();
            var Costs = ClassHelper.AppData.context.Favorite.Where(i => i.IdProduct == favorite1.IdProduct).FirstOrDefault().Cost;
            var Qty = ClassHelper.AppData.context.Favorite.Where(i => i.IdProduct == favorite1.IdProduct).FirstOrDefault().Qty;
            int FinishCost = Convert.ToInt32(Costs * Qty);
            order.Qty = Qty;
            order.FinishCost = FinishCost;
            order.DateOrder = date;

            order.IdClient = IdClient;
            order.IdProduct = favorite1.IdProduct;
            ClassHelper.AppData.context.Order.Add(order);
            ClassHelper.AppData.context.SaveChanges();
        }
    }
}
