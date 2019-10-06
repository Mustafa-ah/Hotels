using Hotels.Data;
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
using System.Windows.Shapes;

namespace Hotels.Views
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class AddHotel : Window
    {
        public AddHotel()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            HotelsData hotelsData = new HotelsData();

            int.TryParse(textBoxTankCount.Text, out int count);
            int.TryParse(textBoxTankSize.Text, out int size);

            Hotels.Models.Hotel hotel = new Models.Hotel()
            {
                Name = textBoxName.Text,
                TanksCount = count,
                TankSize = size,
                Mobile = textBoxMobile.Text,
                Address = textBoxAdress.Text
            };

            hotelsData.AddHotel(hotel);

            MessageBox.Show("تم الحفظ");
        }
    }
}
