using Hotels.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Data
{
    public class HotelsData : DataAccess
    {
        public int AddHotel(Hotel hotel)
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(sQLiteConnection))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "INSERT INTO TA_Hotel(Name, TanksCount, TankSize, Address, Mobile) VALUES (@name, @TanksCounte, @TankSize, @Address, @Mobile)";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@name", hotel.Name);
                    cmd.Parameters.AddWithValue("@TanksCounte", hotel.TanksCount);
                    cmd.Parameters.AddWithValue("@TankSize", hotel.TankSize);
                    cmd.Parameters.AddWithValue("@Address", hotel.Address);
                    cmd.Parameters.AddWithValue("@Mobile", hotel.Mobile);
                    try
                    {
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException e)
                    {
                    }
                }
                conn.Close();
            }
            return result;
        }

        public List<Hotel> GetAllHotels()
        {
            List<Hotel> data = new List<Hotel>();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(sQLiteConnection))
                {
                    conn.Open();
                    string sql = "SELECT * FROM TA_Hotel ";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Hotel vist = new Hotel();
                                vist.Name = reader["Name"].ToString();
                                vist.Id = Convert.ToInt32(reader["Id"]);
                                vist.TanksCount = Convert.ToInt32(reader["TanksCount"]);
                                vist.TankSize = Convert.ToInt32(reader["TankSize"]);
                                vist.Address = reader["Address"].ToString();
                                vist.Mobile = reader["Mobile"].ToString();

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
    }
}
