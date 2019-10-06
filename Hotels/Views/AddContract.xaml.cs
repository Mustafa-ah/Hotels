using Hotels.Data;
using Hotels.Models;
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
    public partial class AddContract : Window
    {

        List<Hotel> hotelsList;

        public AddContract()
        {
            InitializeComponent();

            GetAllHotels();
        }

        private void GetAllHotels()
        {
            HotelsData hotelsData = new HotelsData();

            hotelsList = hotelsData.GetAllHotels();

            foreach (var item in hotelsList)
            {
                comboBoxHotelName.Items.Add(item);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxHotelName.SelectedIndex == -1 )
            {
                MessageBox.Show("يجب اختيار فندق");
                return;
            }
            ContractData contractData = new ContractData();

            Hotel ht = hotelsList[comboBoxHotelName.SelectedIndex];

            int.TryParse(textBoxPrice.Text, out int price);
            int.TryParse(textBoxVistsCount.Text, out int count);

            Contract contract = new Contract()
            {
                Hotel_Name = ht.Name,
                Hotel_Id = ht.Id,
                Start_Date = pickerStartDate.SelectedDate ?? DateTime.Now,
                End_Date = pickerEndDate.SelectedDate ?? DateTime.Now,
                Price = price,
                Vists_count = count,
                Notes = textBoxNotes.Text
            };

            contractData.AddContract(contract);

            MessageBox.Show("تم الحفظ");
        }
    }
}
