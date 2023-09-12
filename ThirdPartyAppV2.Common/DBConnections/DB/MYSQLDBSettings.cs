using MySql.Data.MySqlClient;
using PostSharp.Patterns.Diagnostics;
using System.Configuration;
using ThirdPartyAppV2.Common.DBConnections.DB.DBAttributes;
using ThirdPartyAppV2.Common.DBConnections.Helper.Security;

namespace ThirdPartyAppV2.Common.DBConnections.DB
{
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
            var mySql = new MySqlConnectionStringBuilder(GetConfigurationString(key));
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

        [return: NotLogged]
        public string GetConfigurationString(string key)
        {
            var st = _config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
            return _security.Decrypt(st);
        }

        public void SaveConnectionString(string key, string value)
        {
            _config.ConnectionStrings.ConnectionStrings[key].ConnectionString = _security.Encrypt(value);
            _config.ConnectionStrings.ConnectionStrings[key].ProviderName = "MySql.Data.MySqlClient";
            _config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
