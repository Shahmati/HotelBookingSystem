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
using HotelBookingSystem.Pages;
using HotelBookingSystem.Utils;

namespace HotelBookingSystem
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Users _currentUser;
        public MainWindow(Users users)
        {
            InitializeComponent();
            _currentUser = users;
            Manager.MainFrame = MainFrame;
            MainFrame.Navigate(new PageRooms(_currentUser));
        }
    }
}
