using PostSharp.Patterns.Diagnostics;
using System;
using System.Data;
using ThirdPartyAppV2.Common.DBConnections.DB;
using ThirdPartyAppV2.Common.DBConnections.Helper;

namespace ThirdPartyAppV2.Common.Modules.Main.Patch.Versions
{
    [Log]
    public class PatchFunctions
    {
        private readonly LogSource log = LogSource.Get();

        protected internal bool IsPatchable(string allowedVersion)
        {
            try
            {
                string sql = $"select * from settings where `Key` = 'DbVersion'";
                var settings = new MYSQLDBSettings();
                var helper = new MYSQLDBHelper(settings.GetConfigurationString("MySQLDB"));
                helper.Db_ConnOpen();
                var data = helper.LoadSQL(sql);
                helper.Db_ConnClose();

                foreach (DataRow item in data.Tables[0].Rows)
                {
                    if (item["Values"].ToString() == allowedVersion)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error.Write(FormattedMessageBuilder.Formatted("An error occured. {Message}", ex.Message));
            }
            return false;
        }

        protected internal int RunCommand(string sql)
        {
            var i = 0;
            try
            {
                var settings = new MYSQLDBSettings();
                var helper = new MYSQLDBHelper(settings.GetConfigurationString("MySQLDB"));
                helper.Db_ConnOpen();
                i = helper.SqlCommand(sql);
                helper.Db_ConnClose();
                return i;
            }
            catch (Exception ex)
            {
                log.Error.Write(FormattedMessageBuilder.Formatted("An error occured. {Message}", ex.Message));
                return i;
            }
        }

        protected internal void UpdateDbVesion(string latestVersion)
        {
            try
            {
                var sql = "select * from settings where `Key` = 'DbVersion'";
                var settings = new MYSQLDBSettings();
                var helper = new MYSQLDBHelper(settings.GetConfigurationString("MySQLDB"));
                helper.Db_ConnOpen();
                var data = helper.LoadSQL(sql, "settings");               
                foreach (DataRow item in data.Tables[0].Rows)
                {
                    item["Values"] = latestVersion;
                }
                helper.SaveEntry(data, false);
                helper.Db_ConnClose();
            }
            catch (Exception ex)
            {
                log.Error.Write(FormattedMessageBuilder.Formatted("An error occured. {Message}", ex.Message));
            }
        }
    }
}
