using System;
using System.Collections.Generic;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string connectionString = @"Data Source=C:\Users\musta\source\repos\Hotels\hotels_db.db; Version=3; FailIfMissing=True; Foreign Keys=True;";
            string connectionString = "Data Source=|DataDirectory|hotels_db.db; Version=3; FailIfMissing=True; Foreign Keys=True;";
            SQLiteConnection sQLiteConnection = new SQLiteConnection(connectionString);

            sQLiteConnection.Open();

            using (SQLiteCommand cmd = new SQLiteCommand(sQLiteConnection))
            {
                cmd.CommandText = "INSERT INTO TA_Emplyee VALUES (@Id, @Name, @Moble, @Salary)";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@Name", "Mustafa");
                cmd.Parameters.AddWithValue("@Moble", "011131455652");
                cmd.Parameters.AddWithValue("@Salary", 5000);
                cmd.Parameters.AddWithValue("@Id", 5000);
                try
                {
                   var result = cmd.ExecuteNonQuery();
                }
                catch (SQLiteException ee)
                {
                    string ms = ee.Message;
                }
            }
            sQLiteConnection.Close();
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
            VistsView vistsView = new VistsView();
            vistsView.Show();
        }
    }
}
