using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Data
{
    public class VistsData : DataAccess
    {
        public DataTable GetVists()
        {
            DataTable data = new DataTable();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(sQLiteConnection))
                {
                    conn.Open();
                    string sql = "SELECT * FROM TA_Vists " ;
                    
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                //T la = new T();
                                //la.LangTitle = reader["LangTitle"].ToString();
                                //la.Id = Int32.Parse(reader["Id"].ToString());
                                //langs.Add(la);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException e)
            {
            }
            return data;
        }
    }
}
