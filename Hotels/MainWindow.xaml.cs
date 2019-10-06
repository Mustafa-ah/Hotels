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
            HotelsView hotelsView = new HotelsView();
            hotelsView.Show();
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

        private void ButtonContracts_Click(object sender, RoutedEventArgs e)
        {
            ContractsView contractsView = new ContractsView();
            contractsView.Show();
        }

        private void ButtonEmplyee_Click(object sender, RoutedEventArgs e)
        {
            EmplyeesView emplyeesView = new EmplyeesView();
            emplyeesView.Show();
        }

        private void ButtonOutGoing_Click(object sender, RoutedEventArgs e)
        {
            OutgoingView outgoingView = new OutgoingView();
            outgoingView.Show();
        }

        private void ButtonDeductions_Click(object sender, RoutedEventArgs e)
        {
            DeductionView deductionView = new DeductionView();
            deductionView.Show();
        }
    }
}
