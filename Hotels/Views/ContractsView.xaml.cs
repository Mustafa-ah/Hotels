﻿using Hotels.Data;
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
    public partial class ContractsView : Window
    {
        List<Contract> Contracts;
        ContractData data = new ContractData();
        public ContractsView()
        {
            InitializeComponent();

            Contracts = data.GetAllContracts();
            ContractsGrid.ItemsSource = Contracts;

            CalcTotal(Contracts);
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

                List<Contract> tempList = Contracts.FindAll(v => v.Start_Date >= pickerFrom.SelectedDate && v.End_Date <= PickerTo.SelectedDate);

                ContractsGrid.ItemsSource = tempList;

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

                List<Contract> tempList = Contracts.FindAll(v => v.Hotel_Name.Contains(txtSearch.Text));

                ContractsGrid.ItemsSource = tempList;
                CalcTotal(tempList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void CalcTotal(List<Contract> tempList)
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
        }
    }
}
