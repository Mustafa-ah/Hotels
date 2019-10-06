using Hotels.Data;
using Hotels.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Hotels.Views
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class AddVist : Window
    {

        List<Hotel> hotelsList;
        List<Emplyee> emplyeesList;

        string empsIds = "";

        public AddVist()
        {
            InitializeComponent();

            GetAllHotels();
            GetEmplyeesHotels();
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

        private void GetEmplyeesHotels()
        {
            EmplyeeData emplyeeData = new EmplyeeData();

            emplyeesList = emplyeeData.GetAllEmplyee();

            foreach (var item in emplyeesList)
            {
                listBoxEmplyees.Items.Add(item);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxHotelName.SelectedIndex == -1 )
            {
                MessageBox.Show("يجب اختيار فندق");
                return;
            }
            VistsData vistsData = new VistsData();

            Hotel ht = hotelsList[comboBoxHotelName.SelectedIndex];

            int.TryParse(textBoxPrice.Text, out int price);

            Vist vist = new Vist()
            {
                Name = ht.Name,
                Hotel_Id = ht.Id,
                Date = pickerVistDate.SelectedDate ?? DateTime.Now,
                Price = price,
                Emplyees = empsIds,
                Vist_Id = "0",
                Notes = textBoxNotes.Text
            };
            vistsData.AddVist(vist);

            MessageBox.Show("تم الحفظ");
        }

        private void ListBoxEmplyees_Selected(object sender, RoutedEventArgs e)
        {
            textBoxEmplyees.Text = "";
            empsIds = "";

            var seled = listBoxEmplyees.SelectedItems;
            foreach (var item in listBoxEmplyees.SelectedItems)
            {
                Emplyee emp = item as Emplyee;
                textBoxEmplyees.Text = textBoxEmplyees.Text + emp.Name + ", " ;
                empsIds = empsIds + emp.Id + ",";
            }
        }

        private void ListBoxEmplyees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBoxEmplyees.Text = "";
            empsIds = "";

            foreach (var item in listBoxEmplyees.SelectedItems)
            {
                Emplyee emp = item as Emplyee;
                textBoxEmplyees.Text = textBoxEmplyees.Text + emp.Name + ", ";
                empsIds = empsIds + emp.Id + ",";
            }
        }
    }
}
