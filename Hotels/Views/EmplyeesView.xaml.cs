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

           // AddDeleteCol();

            CalcTotal(Emplyees);
        }

        private async Task AddDeleteCol()
        {
            await Task.Delay(1000);
            DataGridTextColumn cDel = new DataGridTextColumn
            {
                Header = "Num",

                Width = 110
            };
            EmplyeesGrid.Columns.Add(cDel);

            for (int i = 0; i < Emplyees.Count; i++)
            {
              //  EmplyeesGrid.celle
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
