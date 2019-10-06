using Hotels.Models;
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
        public List<Vist> GetAllVists()
        {
            List<Vist> data = new List<Vist>();
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
                                Vist vist = new Vist();
                                vist.Name = reader["Name"].ToString();
                                vist.Price = float.Parse(reader["Price"].ToString());
                                vist.Notes = reader["Notes"].ToString();
                                DateTime.TryParse(reader["Date"].ToString(), out DateTime date_);
                                vist.Date = date_;
                                vist.Id = Convert.ToInt32(reader["Id"]);
                                vist.Hotel_Id = Convert.ToInt32(reader["Hotel_Id"]);
                                vist.Emplyees = reader["Emplyees"].ToString();
                                data.Add(vist);
                                
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

        public int AddVist(Vist vist)
        {
            int result = -1;
            using (sQLiteConnection)
            {
                OpenConnection();
                using (SQLiteCommand cmd = new SQLiteCommand(sQLiteConnection))
                {
                    cmd.CommandText = "INSERT INTO TA_Vists(Name, Price, Date, Emplyees, Notes, Vist_Id, Hotel_Id) VALUES (@name, @price, @date, @emp, @not, @vistId, @hotilId)";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@name", vist.Name);
                    cmd.Parameters.AddWithValue("@price", vist.Price);
                    cmd.Parameters.AddWithValue("@date", vist.Date);
                    cmd.Parameters.AddWithValue("@not", vist.Notes);
                    cmd.Parameters.AddWithValue("@emp", vist.Emplyees);
                    cmd.Parameters.AddWithValue("@vistId", vist.Vist_Id);
                    cmd.Parameters.AddWithValue("@hotilId",vist.Hotel_Id);
                    try
                    {
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException e)
                    {
                    }
                }
                CloseConnection();
            }
            return result;
        }
    }
}
