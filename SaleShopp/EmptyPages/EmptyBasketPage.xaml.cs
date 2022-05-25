﻿using System;
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

namespace SaleShopp.EmptyPages
{
    /// <summary>
    /// Логика взаимодействия для EmptyBasketPage.xaml
    /// </summary>
    public partial class EmptyBasketPage : Page
    {
        public EmptyBasketPage()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Windows.AuthWindow auth = new Windows.AuthWindow();
            auth.Show();
        }
    }
}
