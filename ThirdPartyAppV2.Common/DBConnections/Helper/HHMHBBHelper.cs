using MySql.Data.MySqlClient;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdPartyAppV2.Common.DBConnections.Helper.Security;

namespace ThirdPartyAppV2.Common.DBConnections.Helper
{
    [Log]
    public class HHMHBBHelper
    {
        private readonly LogSource logSource = LogSource.Get();
        public SqlConnection Con;
        private readonly EncryptConnString security = new EncryptConnString();


        public HHMHBBHelper(string connectionString)
        {
            Con = new SqlConnection(security.Decrypt(connectionString));
        }

        public bool IsConnected()
        {
            try
            {
                if (string.IsNullOrEmpty(Con.ConnectionString))
                {
                    return false;
                }
                if (Con.State == ConnectionState.Closed)
                    Con.Open();
                Con.Close();
                return true;
            }
            catch (SqlException ex)
            {
                logSource.Error.Write(FormattedMessageBuilder.Formatted("An error occured. {Message}", ex.Message));
                return false;
            }           
        }

        public void Db_ConnOpen()
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
            }
            Con.Open();
        }

        public void Db_ConnClose()
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
            }
        }

        public SqlDataReader DataReader(string sqlquery)
        {
            var cmd = new SqlCommand(sqlquery, Con);
            var dr = cmd.ExecuteReader();
            return dr;
        }

        public DataSet LoadSQL(string query, string srcTbl = "QuickSql")
        {
            var ds = new DataSet();

            using (var da = new SqlDataAdapter(query, Con))
            {
               da.Fill(ds, srcTbl);
            }
            
            return ds;
        }
    }
}
