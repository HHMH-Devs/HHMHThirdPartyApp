using crypto;
using MySql.Data.MySqlClient;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdPartyAppV2.Common.DBConnections.DB.DBAttributes;
using ThirdPartyAppV2.Common.DBConnections.Helper.Security;

namespace ThirdPartyAppV2.Common.DBConnections.DB
{
    [Log]
    public class MYSQLDBSettings
    {
        private readonly Configuration _config;
        private readonly EncryptConnString _security;

        public MYSQLDBSettings()
        {
            _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            _security = new EncryptConnString();
        }

        public MYSQL_DBAttribs MySQLLoadConstrings(string key)
        {
            var mySql = new MySqlConnectionStringBuilder(_security.Decrypt(GetConfigurationString(key)));
            var MYSQL_DBAttribs = new MYSQL_DBAttribs
            {
                Server = mySql.Server,
                Database = mySql.Database,
                Port = mySql.Port,
                UserId = mySql.UserID,
                Password = mySql.Password,
            };

            return MYSQL_DBAttribs;
        }


        public string GetConfigurationString(string key)
        {
            return _config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
        }

        public void SaveConnectionString(string key, string value)
        {
            
            _config.ConnectionStrings.ConnectionStrings[key].ConnectionString = _security.Encrypt(value);
            _config.ConnectionStrings.ConnectionStrings[key].ProviderName = "MySql.Data.MySqlClient";
            _config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
