using PostSharp.Patterns.Diagnostics;
using System.Configuration;
using System.Data.SqlClient;
using ThirdPartyAppV2.Common.DBConnections.DB.DBAttributes;
using ThirdPartyAppV2.Common.DBConnections.Helper.Security;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace ThirdPartyAppV2.Common.DBConnections.DB
{
    [Log]
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
            var msSql = new SqlConnectionStringBuilder(_security.Decrypt(GetConfigurationString(key)));
            var HHMHBB_DBAttribs = new HHMHBB_DBAttribs
            {
                Server = msSql.DataSource,
                Database = msSql.InitialCatalog,
                UserId = msSql.UserID,
                Password = msSql.Password,
            };

            return HHMHBB_DBAttribs;
        }


        public string GetConfigurationString(string key)
        {
            return _config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
        }

        public void SaveConnectionString(string key, string value)
        {
            _config.ConnectionStrings.ConnectionStrings[key].ConnectionString = _security.Encrypt(value);
            _config.ConnectionStrings.ConnectionStrings[key].ProviderName = "System.Data.SqlClient";
            _config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
