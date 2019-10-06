using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Data
{
    public class DataAccess
    {
        //https://www.codeproject.com/Tips/1057992/Using-SQLite-An-Example-of-CRUD-Operations-in-Csha

        readonly string connectionString = "Data Source=|DataDirectory|hotels_db.db; Version=3; FailIfMissing=True; Foreign Keys=True;";
        protected readonly SQLiteConnection sQLiteConnection;

        public DataAccess()
        {
            sQLiteConnection = new SQLiteConnection(connectionString);
        }

        protected void OpenConnection()
        {
            if (sQLiteConnection.State == System.Data.ConnectionState.Closed)
            {
                sQLiteConnection.Open();
            }
        }

        protected void CloseConnection()
        {
            if (sQLiteConnection.State == System.Data.ConnectionState.Open)
            {
                sQLiteConnection.Close();
            }
        }
    }
}
