using Hotels.Data;
using Hotels.Models;
using System;
using System.Collections.Generic;
using System.Data;

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

namespace Hotels
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class HotelsView : Window
    {
        List<Hotel> Hotels;
        HotelsData data = new HotelsData();
        public HotelsView()
        {
            InitializeComponent();

            Hotels = data.GetAllHotels();
            HotelsGrid.ItemsSource = Hotels;

            HotelsGrid.SelectedCellsChanged += HotelsGrid_SelectedCellsChanged;

            CalcTotal(Hotels);
        }

        private void HotelsGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (e.AddedCells.Count > 0)
            {
                if (e.AddedCells[0].Column.Header.ToString() == "Delete")
                {
                    Hotel hotel = e.AddedCells[0].Item as Hotel;
                    if (MessageBox.Show($" حذف {hotel.Name}", "تأكيد الحذف", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.OK)
                        == MessageBoxResult.OK)
                    {
                        Hotels.Remove(hotel);
                        CalcTotal(Hotels);
                        MessageBox.Show($" تم حذف {hotel.Name}");

                        HotelsGrid.ItemsSource = null;
                        HotelsGrid.ItemsSource = Hotels;
                        HotelsGrid.Items.Refresh();

                        data.Delete(hotel.Id, "TA_Hotel");
                    }
                }

            }
        }


        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                List<Hotel> tempList = Hotels.FindAll(v => v.Name.Contains(txtSearch.Text));

                HotelsGrid.ItemsSource = tempList;
                CalcTotal(tempList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void CalcTotal(List<Hotel> tempList)
        {
            try
            {
                var tot = tempList.Count;

                labTotal.Content = tot.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void VistsGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Id")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }
    }
}
