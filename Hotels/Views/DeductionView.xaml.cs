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
    public partial class DeductionView : Window
    {
        List<Deduction> Deductions;
        EmplyeeData data = new EmplyeeData();
        public DeductionView()
        {
            InitializeComponent();

            Deductions = data.GetAllDeductions();
            DeductionsGrid.ItemsSource = Deductions;
            DeductionsGrid.SelectedCellsChanged += DeductionsGrid_SelectedCellsChanged;
            CalcTotal(Deductions);
        }

        private void DeductionsGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (e.AddedCells.Count > 0)
            {
                if (e.AddedCells[0].Column.Header.ToString() == "Delete")
                {
                    Deduction deduction = e.AddedCells[0].Item as Deduction;
                    if (MessageBox.Show($" حذف {deduction.Reson}", "تأكيد الحذف", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.OK)
                        == MessageBoxResult.OK)
                    {
                        Deductions.Remove(deduction);
                        CalcTotal(Deductions);
                        MessageBox.Show($" تم حذف {deduction.Reson}");

                        DeductionsGrid.ItemsSource = null;
                        DeductionsGrid.ItemsSource = Deductions;
                        DeductionsGrid.Items.Refresh();

                        data.Delete(deduction.Id, "TA_Deduction");
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

                List<Deduction> tempList = Deductions.FindAll(v => v.Date >= pickerFrom.SelectedDate && v.Date <= PickerTo.SelectedDate);

                DeductionsGrid.ItemsSource = tempList;

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

                List<Deduction> tempList = Deductions.FindAll(v => v.Emplyee_Name.Contains(txtSearch.Text));

                DeductionsGrid.ItemsSource = tempList;
                CalcTotal(tempList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void CalcTotal(List<Deduction> tempList)
        {
            try
            {
                var tot = tempList.Sum(v => v.DeductionValue);

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
            else if (e.Column.Header.ToString() == "Emplyee_Id")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }
    }
}
