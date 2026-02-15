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
    /// Логика взаимодействия для PageRoomDesc.xaml
    /// </summary>
    public partial class PageRoomDesc : Page
    {
        public Rooms currentRoom = new Rooms();
        public PageRoomDesc(Rooms _selectedRoom)
        {
            InitializeComponent();
            if (_selectedRoom != null)
            {
                currentRoom = _selectedRoom;
            }

            DataContext = currentRoom;
        }


        private void btnBron_Click(object sender, RoutedEventArgs e)
        {
            Manager.SecondFrame.Navigate(new PageBooking(null));
        }
    }
}
