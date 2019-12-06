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
    public partial class EmplyeesView : Window
    {
        List<Emplyee> Emplyees;
        EmplyeeData data = new EmplyeeData();

        public EmplyeesView()
        {
            InitializeComponent();

            Emplyees = data.GetAllEmplyee();
            EmplyeesGrid.ItemsSource = Emplyees;
            EmplyeesGrid.SelectedCellsChanged += EmplyeesGrid_SelectedCellsChanged;
           // AddDeleteCol();

            CalcTotal(Emplyees);
        }

        private void EmplyeesGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (e.AddedCells.Count > 0)
            {
                if (e.AddedCells[0].Column.Header.ToString() == "Delete") 
                {
                    Emplyee emplyee = e.AddedCells[0].Item as Emplyee;
                    if (MessageBox.Show($" حذف {emplyee.Name}", "تأكيد الحذف", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.OK)
                        == MessageBoxResult.OK)
                    {
                        Emplyees.Remove(emplyee);
                        CalcTotal(Emplyees);
                        MessageBox.Show($" تم حذف {emplyee.Name}");
     
                        EmplyeesGrid.ItemsSource = null;
                        EmplyeesGrid.ItemsSource = Emplyees;
                        EmplyeesGrid.Items.Refresh();

                        data.Delete(emplyee.Id, "TA_Emplyee");
                    }
                }
               
            }
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                List<Emplyee> tempList = Emplyees.FindAll(v => v.Name.Contains(txtSearch.Text));

                EmplyeesGrid.ItemsSource = tempList;
                CalcTotal(tempList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void CalcTotal(List<Emplyee> tempList)
        {
            try
            {
                var tot = tempList.Sum(emp => emp.Salary);

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
