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
    public partial class AddDeduction : Window
    {

        List<Emplyee> emplyeeList;
        EmplyeeData emplyeeData = new EmplyeeData();

        public AddDeduction()
        {
            InitializeComponent();

            GetAllVists();
        }

        private void GetAllVists()
        {
          
            emplyeeList = emplyeeData.GetAllEmplyee();

            foreach (var item in emplyeeList)
            {
                comboBoxEmplyees.Items.Add(item);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            if (comboBoxEmplyees.SelectedIndex == -1 )
            {
                MessageBox.Show("يجب اختيار موظف");
                return;
            }

            Emplyee emp = emplyeeList[comboBoxEmplyees.SelectedIndex];

            if (int.TryParse(textBoxPrice.Text, out int price))
            {
                Deduction deduction = new Deduction()
                {
                    DeductionValue = price,
                    Reson = textBoxDetails.Text,
                    Date = pickerStartDate.SelectedDate ?? DateTime.Now,
                    Emplyee_Name = emp.Name,
                    Emplyee_Id = emp.Id,
                    Notes = textBoxNotes.Text
                };

                emplyeeData.AddDeduction(deduction);

                MessageBox.Show("تم الحفظ");
            }
            else
            {
                MessageBox.Show("تاكد من قيمة الخصم \\ السلفة");
            }
        }
    }
}
