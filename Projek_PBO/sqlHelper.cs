using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using Npgsql;

namespace tugas_npgsql
{
    public class DatabaseManager
    {
        private NpgsqlConnection con;
        public DatabaseManager(string connectionString)
        {
            try
            {
                con = new NpgsqlConnection(connectionString);
            }
            catch (Exception ex)
            {
            }
        }
        public void Dispose()
        {
            con.Close();
        }
        public bool Select(ref DataTable dataTable, string? table, string? query = null, NpgsqlParameter[]? parameter = null)
        {
            try
            {
                NpgsqlCommand cmd = con.CreateCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;

                if (query != null && parameter != null)
                {
                    cmd.CommandText = query;
                    foreach (var p in parameter)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                else if (table != null)
                {
                    cmd.CommandText = $"SELECT * FROM {table}";
                }
                else if (table == null && query == null && parameter == null)
                {
                    return false;
                }
                cmd.Connection.Open();
                NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter(cmd);
                npgsqlDataAdapter.Fill(dataTable);
                cmd.Connection.Close();
                cmd.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool ExecuteNonQuery(string query, NpgsqlParameter[] parameters)
        {
            try
            {
                NpgsqlCommand cmd = con.CreateCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = query;
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                cmd.Connection.Open();
                int res = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                cmd.Dispose();
                return res > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}