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
    /// Логика взаимодействия для PageBooking.xaml
    /// </summary>
    public partial class PageBooking : Page
    {
        public Bookings currentBooking = new Bookings();
        public PageBooking(Bookings _selectedBooking)
        {
            InitializeComponent();
            cmbRoom.ItemsSource = DataBaseEntities.GetContext().Rooms.ToList();
            cmbUser.ItemsSource = DataBaseEntities.GetContext().Users.ToList();

            if (_selectedBooking != null)
            {
                currentBooking = _selectedBooking;
            }

            DataContext = currentBooking;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (cmbUser.SelectedItem == null)
                errors.AppendLine("Укажите пользователя!");
            if (cmbRoom.SelectedItem == null)
                errors.AppendLine("Укажите комнату!");
            if (tbCheckInDate.Text == null)
                errors.AppendLine("Укажите дату заселения!");
            if (tbCheckOutDate.Text == null)
                errors.AppendLine("Укажите дату выселения!");
            if (tbPrice.Text == null)
                errors.AppendLine("Укажите цену!");
            if (tbGuests.Text == null)
                errors.AppendLine("Укажите кол-во гостей!");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (currentBooking.BookingId == 0)
            {
                try
                {
                    DataBaseEntities.GetContext().Bookings.Add(currentBooking);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            try
            {
                DataBaseEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!", "Информация",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                Manager.MainFrame.Navigate(new PageRooms());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
