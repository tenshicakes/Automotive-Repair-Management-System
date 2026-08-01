


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Olvarra_Capstone
{
    public static class DatabaseHelper
    {
        private static string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\olvarraDB.mdf;Integrated Security=True";

        // 1. Existing method (for simple queries without parameters)
        public static DataTable GetTable(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // 2. Parameters (Crucial for secure search boxes!)
        public static DataTable GetTable(string query, SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.Add((SqlParameter)((ICloneable)param).Clone());
                        }
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // 3. INSERT, UPDATE, DELETE operations
        public static int ExecuteQuery(string query, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.Add((SqlParameter)((ICloneable)param).Clone());
                        }
                    }

                    conn.Open();
                    return cmd.ExecuteNonQuery(); 
                }
            }
        }

        // 4.ExecuteScalar (Returns a single value, e.g., COUNT(*), MAX(ID), or Sums)
        public static object ExecuteScalar(string query, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.Add((SqlParameter)((ICloneable)param).Clone());
                        }
                    }

                    conn.Open();
                    return cmd.ExecuteScalar(); // Returns the first column of the first row
                }
            }
        }

        // 5. ExecuteTransaction (For multi-step operations where all must succeed or all fail)
        public static bool ExecuteTransaction(string[] queries, SqlParameter[][] allParameters)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.Transaction = transaction;
                        try
                        {
                            for (int i = 0; i < queries.Length; i++)
                            {
                                cmd.CommandText = queries[i];
                                cmd.Parameters.Clear();

                                if (allParameters != null && allParameters[i] != null)
                                {
                                    cmd.Parameters.AddRange(allParameters[i]);
                                }

                                cmd.ExecuteNonQuery();
                            }

                       
                            transaction.Commit();
                            return true;
                        }
                        catch (Exception)
                        {
                     
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
            }
        }
    }
}
