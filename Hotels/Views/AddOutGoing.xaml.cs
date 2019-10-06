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
    public partial class AddOutGoing : Window
    {

        List<Vist> vistsList;

        public AddOutGoing()
        {
            InitializeComponent();

            GetAllVists();
        }

        private void GetAllVists()
        {
            VistsData vistsData = new VistsData();

            vistsList = vistsData.GetAllVists();

            foreach (var item in vistsList)
            {
                comboBoxVists.Items.Add(item);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            int vistId = 0;
            if (comboBoxVists.SelectedIndex > -1 )
            {
                vistId = vistsList[comboBoxVists.SelectedIndex].Id;
            }
            OutgoingData outgoingData = new OutgoingData();

            if (int.TryParse(textBoxPrice.Text, out int price))
            {
                Outgoing outgoing = new Outgoing()
                {
                    OutGoing = price,
                    Details = textBoxDetails.Text,
                    Date = pickerStartDate.SelectedDate ?? DateTime.Now,
                    Vist_Id = vistId,
                    Notes = textBoxNotes.Text
                };

                outgoingData.AddOutgoing(outgoing);

                MessageBox.Show("تم الحفظ");
            }
            else
            {
                MessageBox.Show("تاكد من قيمة المصروف");
            }
        }
    }
}
