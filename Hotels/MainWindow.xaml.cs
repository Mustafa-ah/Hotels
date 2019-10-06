using Hotels.Views;
using System;
using System.Windows;
using System.Windows.Input;

namespace Hotels
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
         
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Button_Click(sender, e);
                MessageBox.Show("تم الاتصال");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void AddVist_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Views.AddVist addVist = new AddVist();
            addVist.Show();
        }

        private void ButtonVists_Click(object sender, RoutedEventArgs e)
        {
            VistsView vistsView = new VistsView();
            vistsView.Show();
        }

        private void ButtonHotles_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void ImgAddHotel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AddHotel addHotel = new AddHotel();
            addHotel.Show();
        }

        private void ImgAddEmplyee_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AddEmplyee addEmplyee = new AddEmplyee();
            addEmplyee.Show();
        }

        private void ImgAddContract_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AddContract addContract = new AddContract();
            addContract.Show();
        }

        private void ImgOutgoing_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AddOutGoing addOutGoing = new AddOutGoing();
            addOutGoing.Show();
        }

        private void ImgDeduction_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AddDeduction addDeduction = new AddDeduction();
            addDeduction.Show();
        }
    }
}
