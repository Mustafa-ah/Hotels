using Hotels.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Data
{
    public class OutgoingData : DataAccess
    {
        public int AddOutgoing(Outgoing outgoing)
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(sQLiteConnection))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "INSERT INTO TA_OutGoings(OutGoing, Details, Notes, Date, Vist_Id) VALUES (@OutGoing, @Details, @Notes, @Date, @Vist_Id)";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@OutGoing", outgoing.OutGoing);
                    cmd.Parameters.AddWithValue("@Details", outgoing.Details);
                    cmd.Parameters.AddWithValue("@Notes", outgoing.Notes);
                    cmd.Parameters.AddWithValue("@Date", outgoing.Date);
                    cmd.Parameters.AddWithValue("@Vist_Id", outgoing.Vist_Id);
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

        public List<Outgoing> GetAllOutgoings()
        {
            List<Outgoing> data = new List<Outgoing>();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(sQLiteConnection))
                {
                    conn.Open();
                    string sql = "SELECT * FROM TA_OutGoings ";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime.TryParse(reader["Date"].ToString(), out DateTime startDate_);

                                Outgoing outgoing = new Outgoing
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    OutGoing = Convert.ToInt32(reader["OutGoing"]),
                                    Vist_Id = Convert.ToInt32(reader["Vist_Id"]),
                                    Details = reader["Details"].ToString(),
                                    Notes = reader["Notes"].ToString(),
                                    Date = startDate_
                                };

                                data.Add(outgoing);

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
