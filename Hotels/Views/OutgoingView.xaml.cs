using Hotels.Data;
using Hotels.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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
    public partial class OutgoingView : Window
    {
        List<Outgoing> Outgoings;
        OutgoingData data = new OutgoingData();
        public OutgoingView()
        {
            InitializeComponent();

            Outgoings = data.GetAllOutgoings();
            OutgoingsGrid.ItemsSource = Outgoings;

            CalcTotal(Outgoings);
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

                List<Outgoing> tempList = Outgoings.FindAll(v => v.Date >= pickerFrom.SelectedDate && v.Date <= PickerTo.SelectedDate);

                OutgoingsGrid.ItemsSource = tempList;

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

                List<Outgoing> tempList = Outgoings.FindAll(v => v.Details.Contains(txtSearch.Text));

                OutgoingsGrid.ItemsSource = tempList;
                CalcTotal(tempList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void CalcTotal(List<Outgoing> tempList)
        {
            try
            {
                var tot = tempList.Sum(v => v.OutGoing);

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
            else if (e.Column.Header.ToString() == "Vist_Id")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }
    }
}
