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
            if (string.IsNullOrWhiteSpace(TxBoxLogin.Text) || TxBoxLogin.Text == "Введите логин")
            {
                MessageBox.Show("Введите логин!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Проверка на пустой пароль
            if (string.IsNullOrWhiteSpace(PsBoxPassword.Password))
            {
                MessageBox.Show("Введите пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Обращение к БД
            var users = DataBaseEntities.GetContext().Users
                .Include("Roles")
                .FirstOrDefault(u => u.Login == TxBoxLogin.Text && u.PasswordHash == PsBoxPassword.Password);
            //var user = DataBaseEntities.GetContext().Users
            //    .FirstOrDefault(u => u.Login == TxBoxLogin.Text && u.Password == PsBoxPassword.Password);

            if (users == null)
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show($"Добро пожаловать, {users.FullName}!",
                "Успешный вход", MessageBoxButton.OK, MessageBoxImage.Information);

            // Открытие главного окна
            MainWindow mainWindow = new MainWindow(users);
            mainWindow.Show();

            // Закрытие окна авторизации (если Page в отдельном окне)
            Application.Current.Windows
                .OfType<Window>()
                .FirstOrDefault(w => w is AuthWindow)
                ?.Close();
        }

    }
}
