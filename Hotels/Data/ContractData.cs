using Hotels.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Data
{
    public class ContractData : DataAccess
    {
        public int AddContract(Contract contract)
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(sQLiteConnection))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "INSERT INTO TA_Contract(Hotel_Name, Hotel_Id, Start_Date, End_Date, Price, Vists_count, Notes) VALUES (@Hotel_Name, @Hotel_Id, @Start_Date, @End_Date,@Price, @Vists_count, @Notes)";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Hotel_Name", contract.Hotel_Name);
                    cmd.Parameters.AddWithValue("@Hotel_Id", contract.Hotel_Id);
                    cmd.Parameters.AddWithValue("@Start_Date", contract.Start_Date);
                    cmd.Parameters.AddWithValue("@End_Date", contract.End_Date);
                    cmd.Parameters.AddWithValue("@Price", contract.Price);
                    cmd.Parameters.AddWithValue("@Vists_count", contract.Vists_count);
                    cmd.Parameters.AddWithValue("@Notes", contract.Notes);
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
    }
}
