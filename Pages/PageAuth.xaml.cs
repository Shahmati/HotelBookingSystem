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
using HotelBookingSystem.Utils;

namespace HotelBookingSystem.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAuth.xaml
    /// </summary>
    public partial class PageAuth : Page
    {
        public PageAuth()
        {
            InitializeComponent();
        }
        private void PsBoxPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PsBoxPassword.Password.Length == 0)
            {
                TxBlPassword.Visibility = Visibility.Visible;
            }
            else
            {
                TxBlPassword.Visibility = Visibility.Collapsed;
            }
        }

        private void TxBoxLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TxBoxLogin.Text == "Введите логин")
            {
                TxBoxLogin.Text = "";
            }
        }

        private void TxBoxLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxBoxLogin.Text))
            {
                TxBoxLogin.Text = "Введите логин";
            }
        }

        private void BtnSingIn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Application.Current.Windows
                    .OfType<AuthWindow>()
                    .FirstOrDefault()?
                    .Close();
        }

    }
}
