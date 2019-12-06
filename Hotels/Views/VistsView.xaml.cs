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
    public partial class VistsView : Window
    {
        List<Vist> Vists;
        VistsData data = new VistsData();
        public VistsView()
        {
            InitializeComponent();

            Vists = data.GetAllVists();
            VistsGrid.ItemsSource = Vists;
            VistsGrid.SelectedCellsChanged += VistsGrid_SelectedCellsChanged;
            CalcTotal(Vists);
        }

        private void VistsGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (e.AddedCells.Count > 0)
            {
                if (e.AddedCells[0].Column.Header.ToString() == "Delete")
                {
                    Vist vist = e.AddedCells[0].Item as Vist;
                    if (MessageBox.Show($" حذف {vist.Name}", "تأكيد الحذف", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.OK)
                        == MessageBoxResult.OK)
                    {
                        Vists.Remove(vist);
                        CalcTotal(Vists);
                        MessageBox.Show($" تم حذف {vist.Name}");

                        VistsGrid.ItemsSource = null;
                        VistsGrid.ItemsSource = Vists;
                        VistsGrid.Items.Refresh();

                        data.Delete(vist.Id, "TA_Vists");
                    }
                }

            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (pickerFrom.SelectedDate == null || PickerTo.SelectedDate == null)
                {
                    MessageBox.Show("اختر تاريخ  من و الى");
                    return;
                }

                List<Vist> tempList = Vists.FindAll(v => v.Date >= pickerFrom.SelectedDate && v.Date <= PickerTo.SelectedDate);

                VistsGrid.ItemsSource = tempList;

                CalcTotal(tempList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                List<Vist> tempList = Vists.FindAll(v => v.Name.Contains(txtSearch.Text));

                VistsGrid.ItemsSource = tempList;
                CalcTotal(tempList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void CalcTotal(List<Vist> tempList)
        {
            try
            {
                var tot = tempList.Sum(v => v.Price);

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
            else if (e.Column.Header.ToString() == "Hotel_Id")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
            else if (e.Column.Header.ToString() == "Emplyees")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
            else if (e.Column.Header.ToString() == "Vist_Id")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }
    }
}
