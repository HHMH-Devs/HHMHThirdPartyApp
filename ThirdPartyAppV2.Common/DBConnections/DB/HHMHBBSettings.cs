using PostSharp.Patterns.Diagnostics;
using System.Configuration;
using System.Data.SqlClient;
using ThirdPartyAppV2.Common.DBConnections.DB.DBAttributes;
using ThirdPartyAppV2.Common.DBConnections.Helper.Security;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace ThirdPartyAppV2.Common.DBConnections.DB
{
    public class HHMHBBSettings
    {
        private readonly Configuration _config;
        private readonly EncryptConnString _security;

        public HHMHBBSettings()
        {
            _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            _security = new EncryptConnString();
        }

        public HHMHBB_DBAttribs MSSQLLoadConstrings(string key)
        {
            var msSql = new SqlConnectionStringBuilder(GetConfigurationString(key));
            var HHMHBB_DBAttribs = new HHMHBB_DBAttribs
            {
                Server = msSql.DataSource,
                Database = msSql.InitialCatalog,
                UserId = msSql.UserID,
                Password = msSql.Password,
            };

            return HHMHBB_DBAttribs;
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
            _config.ConnectionStrings.ConnectionStrings[key].ProviderName = "System.Data.SqlClient";
            _config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
