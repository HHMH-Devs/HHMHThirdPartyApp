﻿using MySql.Data.MySqlClient;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Data;
using System.Data.Common;
using ThirdPartyAppV2.Common.Modules.Main.Patch.Versions;

namespace ThirdPartyAppV2.Common.DBConnections.Helper
{
    public class MYSQLDBHelper
    {
        private readonly LogSource logSource = LogSource.Get();
        public MySqlConnection Con;

        public MYSQLDBHelper([NotLogged] string connectionString)
        {
            Con = new MySqlConnection(connectionString);
            Con.StateChange += Con_StateChange;
        }

        private void Con_StateChange(object sender, StateChangeEventArgs e)
        {
            logSource.Info.Write(FormattedMessageBuilder.Formatted("Connection state: {OriginalState} -> {CurrentState}", e.OriginalState, e.CurrentState));
        }

        public bool IsConnected()
        {
            if (!PatchFunctions.IsDatabaseExists(Con.Database))
            {
                var sql = $"CREATE DATABASE `{Con.Database}` CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_general_ci';";
                PatchFunctions.RunCommand(sql);
            }
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
            catch (MySqlException ex)
            {
                logSource.Error.Write(FormattedMessageBuilder.Formatted("An error occured. {Message}", ex.Message));
                return false;
            }
        }

        public void Db_ConnOpen()
        {
            try
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
                Con.Open();
            }
            catch (Exception ex)
            {
                logSource.Error.Write(FormattedMessageBuilder.Formatted("An error occured. {Message}", ex.Message));
            }
        }

        public void Db_ConnClose()
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
            }
        }

        public int SqlCommand(string command)
        {
            try
            {
                var cmd = new MySqlCommand(command, Con)
                {
                    CommandType = CommandType.Text
                };
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                logSource.Error.Write(FormattedMessageBuilder.Formatted("An error occured. {Message}", ex.Message));
                return 0;
            }
        }

        public MySqlDataReader DataReader(string sqlquery)
        {
            var cmd = new MySqlCommand(sqlquery, Con);
            var dr = cmd.ExecuteReader();
            return dr;
        }

        public DataSet LoadSQL(string query, string srcTbl = "QuickSql")
        {
            var ds = new DataSet();

            try
            {
                using (var da = new MySqlDataAdapter(query, Con))
                {
                    da.Fill(ds, srcTbl);
                }
            }
            catch (Exception ex)
            {
                logSource.Error.Write(FormattedMessageBuilder.Formatted("An error occured. {Message}", ex.Message));
            }
            return ds;
        }

        public bool SaveEntry(DataSet dsEntry, bool isNew = true)
        {
            bool isSaved = false;
            if (dsEntry is null)
            {
                return isSaved;
            }
            string mySql;
            string fillData;
            using (var ds = dsEntry)
            {
                // Save all tables in the dataset
                foreach (DataTable dsTable in dsEntry.Tables)
                {
                    fillData = dsTable.TableName;
                    mySql = "SELECT * FROM " + fillData;
                    if (!isNew)
                    {
                        string colName = dsTable.Columns[0].ColumnName;
                        int idx = (int)dsTable.Rows[0].ItemArray[0];
                        mySql += string.Format(" WHERE {0} = {1};", colName, idx);
                        logSource.Info.Write(FormattedMessageBuilder.Formatted("ModifySQL: {mySql}", mySql));
                    }
                    else
                    {
                        mySql += " LIMIT 1;";
                        logSource.Info.Write(FormattedMessageBuilder.Formatted("ModifySQL: {mySql}", mySql));
                    }
                    using (var da = new MySqlDataAdapter(mySql, Con))
                    {
                        var cb = new MySqlCommandBuilder(da)
                        {
                            ConflictOption = ConflictOption.CompareAllSearchableValues,
                            CatalogLocation = CatalogLocation.Start,
                            SetAllValues = false
                        };

                        try
                        {
                            var rows = da.Update(ds, fillData);
                            logSource.Info.Write(FormattedMessageBuilder.Formatted("Rows Inserted/Updated : {rows}", rows));
                            isSaved = true;
                        }
                        catch (Exception ex)
                        {
                            logSource.Error.Write(FormattedMessageBuilder.Formatted("An error occured. {Message}", ex.Message));
                            isSaved = false;
                        }
                    }
                }
            }
            return isSaved;
        }
    }
}
