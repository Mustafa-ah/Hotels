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
    public partial class AddEmplyee : Window
    {
        public AddEmplyee()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            EmplyeeData emplyeeData = new EmplyeeData();

            float.TryParse(textBoxSalary.Text, out float salary);

            Emplyee emplyee = new Emplyee()
            {
                Name = textBoxName.Text,
                Moble = textBoxMobile.Text,
                Salary = salary
            };

            emplyeeData.AddEmplyee(emplyee);

            MessageBox.Show("تم الحفظ");
        }
    }
}
