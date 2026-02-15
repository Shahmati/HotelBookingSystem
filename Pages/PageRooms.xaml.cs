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
    /// Логика взаимодействия для PageRooms.xaml
    /// </summary>
    public partial class PageRooms : Page
    {
        private List<Rooms> allRooms;
        public PageRooms()
        {
            InitializeComponent();
            lvRooms.ItemsSource = DataBaseEntities.GetContext().Rooms.ToList();
            LoadRooms();
        }
        void LoadRooms()
        {
            //lvRooms.ItemsSource = DataBaseEntities.GetContext().Rooms.ToList();
            allRooms = DataBaseEntities.GetContext().Rooms.ToList();
            //lvRooms.ItemsSource = allRooms;
            LoadComboBoxData();
        }
        void LoadComboBoxData()
        {
            // Загрузка типов номеров
            var types = DataBaseEntities.GetContext().RoomTypes.ToList();
            types.Insert(0, new RoomTypes { RoomTypeId = 0, TypeName = "Все типы" });
            cmbType.ItemsSource = types;
            cmbType.DisplayMemberPath = "TypeName";
            cmbType.SelectedIndex = 0;

            // Загрузка этажей
            var floors = allRooms.Select(r => r.Floor).Distinct().OrderBy(f => f).ToList();
            floors.Insert(0, 0);
            cmbFloor.ItemsSource = floors;
            cmbFloor.SelectedIndex = 0;

            // Подписка
            cmbType.SelectionChanged += (s, e) => ApplyFilters();
            cmbFloor.SelectionChanged += (s, e) => ApplyFilters();
        }

        void ApplyFilters()
        {
            var rooms = allRooms;

            if (cmbType.SelectedItem is RoomTypes rt && rt.RoomTypeId != 0)
                rooms = rooms.Where(r => r.RoomTypeId == rt.RoomTypeId).ToList();

            if (cmbFloor.SelectedItem is int f && f != 0)
                rooms = rooms.Where(r => r.Floor == f).ToList();

            lvRooms.ItemsSource = rooms;
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void RoomCard_Click(object sender, RoutedEventArgs e)
        {
            var border = sender as Border;
            if (border == null) return;

            var room = border.DataContext as Rooms;
            if (room == null) return;

            Manager.SecondFrame.Navigate(new Page1(room));
        }
    }
}
