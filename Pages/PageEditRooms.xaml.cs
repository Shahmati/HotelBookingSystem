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
    /// Логика взаимодействия для PageEditRooms.xaml
    /// </summary>
    public partial class PageEditRooms : Page
    {
        public Rooms currentRoom = new Rooms();
        public PageEditRooms(Rooms _selectedRoom)
        {
            InitializeComponent();
            cmbType.ItemsSource = DataBaseEntities.GetContext().RoomTypes.ToList();

            if (_selectedRoom != null)
            {
                currentRoom = _selectedRoom;
            }

            DataContext = currentRoom;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            
            if (tbNumber.Text == null)
                errors.AppendLine("Укажите номер!");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (currentRoom.RoomId == 0)
            {
                try
                {
                    DataBaseEntities.GetContext().Rooms.Add(currentRoom);
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
                Manager.MainFrame.Navigate(new PageRooms(null));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите вернуться назад?", "Подтверждение выхода",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Manager.MainFrame.Navigate(new PageRooms(null));

            }
        }
    }
}
