using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Логика взаимодействия для WindowPassLost.xaml
    /// </summary>
    public partial class WindowPassLost : Window
    {
        public WindowPassLost()
        {
            InitializeComponent();
        }
        private void btnPass_Click(object sender, RoutedEventArgs e)
        {
            var Pass = ClassHelper.AppData.context.Client.Where(i => i.Login == txbPass.Text).ToList().FirstOrDefault();
            if (Pass != null)
            {
                SmtpClient smtp1 = new SmtpClient("smtp.mail.ru", 25);
                smtp1.Credentials = new NetworkCredential("sale_shop@internet.ru", "riE6eSfrdr9wU9FuYnZu");
                MailMessage message = new MailMessage();
                message.From = new MailAddress("sale_shop@internet.ru", "Поддержка SaleShop");
                message.To.Add(new MailAddress(Pass.Email));
                message.Subject = $"Ваш пароль:{Pass.Password.ToString()}";
                message.Body = Pass.Password.ToString();
                smtp1.EnableSsl = true;
                smtp1.Send(message);
                MessageBox.Show("Проверьте почту");
                Close();
            }


        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}
