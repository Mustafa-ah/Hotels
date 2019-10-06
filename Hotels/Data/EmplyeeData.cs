using Hotels.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Data
{
    public class EmplyeeData : DataAccess
    {
        public int AddEmplyee(Emplyee emplyee)
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(sQLiteConnection))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "INSERT INTO TA_Emplyee(Name, Moble, Salary) VALUES (@name, @Moble, @Salary)";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@name", emplyee.Name);
                    cmd.Parameters.AddWithValue("@Moble", emplyee.Moble);
                    cmd.Parameters.AddWithValue("@Salary", emplyee.Salary);
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

        public List<Emplyee> GetAllEmplyee()
        {
            List<Emplyee> data = new List<Emplyee>();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(sQLiteConnection))
                {
                    conn.Open();
                    string sql = "SELECT * FROM TA_Emplyee ";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Emplyee emplyee = new Emplyee
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Name = reader["Name"].ToString(),
                                    Salary = float.Parse(reader["Salary"].ToString()),
                                    Moble = reader["Moble"].ToString()
                                };

                                data.Add(emplyee);

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

        public int AddDeduction(Deduction deduction)
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(sQLiteConnection))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "INSERT INTO TA_Deduction(Emplyee_Name, Emplyee_Id, DeductionValue, Date, Reson, Notes) VALUES (@Emplyee_Name, @Emplyee_Id, @Deduction, @Date, @Reson, @Notes)";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Emplyee_Name", deduction.Emplyee_Name);
                    cmd.Parameters.AddWithValue("@Emplyee_Id", deduction.Emplyee_Id);
                    cmd.Parameters.AddWithValue("@Deduction", deduction.DeductionValue);
                    cmd.Parameters.AddWithValue("@Date", deduction.Date);
                    cmd.Parameters.AddWithValue("@Reson", deduction.Reson);
                    cmd.Parameters.AddWithValue("@Notes", deduction.Notes);
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

        public List<Deduction> GetAllDeductions()
        {
            List<Deduction> data = new List<Deduction>();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(sQLiteConnection))
                {
                    conn.Open();
                    string sql = "SELECT * FROM TA_Deduction ";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                           
                            while (reader.Read())
                            {
                                DateTime.TryParse(reader["Date"].ToString(), out DateTime startDate_);
                                Deduction deduction = new Deduction
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Emplyee_Id = Convert.ToInt32(reader["Emplyee_Id"]),
                                    Emplyee_Name = reader["Emplyee_Name"].ToString(),
                                    DeductionValue = float.Parse(reader["DeductionValue"].ToString()),
                                    Reson = reader["Reson"].ToString(),
                                    Notes = reader["Notes"].ToString(),
                                    Date = startDate_
                                };

                                data.Add(deduction);

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
