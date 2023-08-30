using MySql.Data.MySqlClient;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using ThirdPartyAppV2.Common.DBConnections.DB;
using ThirdPartyAppV2.Common.DBConnections.DB.DBAttributes;
using ThirdPartyAppV2.Common.DBConnections.Helper;
using ThirdPartyAppV2.Common.DBConnections.Helper.Security;

namespace ThirdPartyAppV2.Main.Forms.DBConnectionConfig
{
    [Log]
    public partial class AppDBSettings : Form
    {
        private readonly MYSQLDBSettings mYSQLDBSettings = new MYSQLDBSettings();
        private readonly HHMHBBSettings hHMHBBSettingsSettings = new HHMHBBSettings();
        private readonly LogSource logSource = LogSource.Get();
        private readonly EncryptConnString security = new EncryptConnString();

        public AppDBSettings()
        {
            InitializeComponent();
            LoadConsStrings();
        }

        private void LoadConsStrings()
        {
            var MySqlConString = mYSQLDBSettings.MySQLLoadConstrings("MySQLDB");
            if (MySqlConString != null)
            {
                ServerMySQL_Text.Text = MySqlConString.Server;
                DatabaseMySQL_Text.Text = MySqlConString.Database;
                PortMySQL_Text.Text = MySqlConString.Port.ToString();
                UserNameMySQL_Text.Text = MySqlConString.UserId;
                PasswordMySQL_Text.Text = MySqlConString.Password;
            }

            var mSSQLConString = hHMHBBSettingsSettings.MSSQLLoadConstrings("HHMHBB");
            if (mSSQLConString != null)
            {
                ServerMSSQL_Text.Text = mSSQLConString.Server;
                DatabaseMSSQL_Text.Text = mSSQLConString.Database;
                UserNameMSSQL_Text.Text = mSSQLConString.UserId;
                PasswordMSSQL_Text.Text = mSSQLConString.Password;
            }
        }

        private void SaveRestart_Btn_Click(object sender, EventArgs e)
        {
            var hasError = false;
            var hhmhbb = new HHMHBB_DBAttribs
            {
                Server = ServerMSSQL_Text.Text,
                Database = DatabaseMSSQL_Text.Text,
                UserId = UserNameMSSQL_Text.Text,
                Password = PasswordMSSQL_Text.Text
            };

            var mysqldb = new MYSQL_DBAttribs
            {
                Server = ServerMySQL_Text.Text,
                Database = DatabaseMySQL_Text.Text,
                Port = Convert.ToUInt32(PortMySQL_Text.Text),
                UserId = UserNameMySQL_Text.Text,
                Password = PasswordMySQL_Text.Text
            };

            var hhmhBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = hhmhbb.Server,
                InitialCatalog = hhmhbb.Database,
                UserID = hhmhbb.UserId,
                Password = hhmhbb.Password,
                Encrypt = false,
                MultiSubnetFailover = false,
                PersistSecurityInfo = true,
                TrustServerCertificate = true,
                ApplicationIntent = ApplicationIntent.ReadOnly,
                ApplicationName = Application.ProductName
            };

            var mysqlBuilder = new MySqlConnectionStringBuilder()
            {
                Server = mysqldb.Server,
                Database = mysqldb.Database,
                UserID = mysqldb.UserId,
                Password = mysqldb.Password,
                Port = mysqldb.Port,
                UseCompression = true,
                ConnectionTimeout = 120,
                UseAffectedRows = true,
                ConvertZeroDateTime = true,
                PersistSecurityInfo = true
            };

            var mssqlhelper = new HHMHBBHelper(hhmhBuilder.ConnectionString);
            if (mssqlhelper.IsConnected())
            {
                var mssqlsetting = new HHMHBBSettings();
                mssqlsetting.SaveConnectionString("HHMHBB", hhmhBuilder.ConnectionString);
                Properties.Settings.Default.HHMHBBDbConstring = security.Encrypt(hhmhBuilder.ConnectionString);
                logSource.Info.Write(FormattedMessageBuilder.Formatted("Connected to {DataSource}", hhmhBuilder.DataSource));
                MessageBox.Show("Connection string for MSSQL DB successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Unable to connect to Microsoft Sql database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                hasError = true;
            }

            var mysqlhelper = new MYSQLDBHelper(mysqlBuilder.ConnectionString);
            if (mysqlhelper.IsConnected())
            {
                var mysqlsetting = new MYSQLDBSettings();
                mysqlsetting.SaveConnectionString("MySQLDB", mysqlBuilder.ConnectionString);
                Properties.Settings.Default.MySQLDbConstring = security.Encrypt(mysqlBuilder.ConnectionString);
                logSource.Info.Write(FormattedMessageBuilder.Formatted("Connected to {Server}", mysqlBuilder.Server)); 
                MessageBox.Show("Connection string for MySQL DB successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Unable to connect to MySQL database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                hasError = true;
            }
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            if (!hasError)
            {
                Application.Restart();
            }
            Close();
        }

        private void AppDBSettings_Load(object sender, EventArgs e)
        {
            var hhmhBuilder = new SqlConnectionStringBuilder(security.Decrypt(Properties.Settings.Default.HHMHBBDbConstring));
            ServerMSSQL_Text.Text = hhmhBuilder.DataSource;
            DatabaseMSSQL_Text.Text = hhmhBuilder.InitialCatalog;
            UserNameMSSQL_Text.Text = hhmhBuilder.UserID;
            PasswordMSSQL_Text.Text = hhmhBuilder.Password;

            var mysqlBuilder = new MySqlConnectionStringBuilder(security.Decrypt(Properties.Settings.Default.MySQLDbConstring));
            ServerMySQL_Text.Text = mysqlBuilder.Server;
            DatabaseMySQL_Text.Text = mysqlBuilder.Database;
            PortMySQL_Text.Text = mysqlBuilder.Port.ToString();
            UserNameMySQL_Text.Text = mysqlBuilder.UserID;
            PasswordMySQL_Text.Text = mysqlBuilder.Password;
        }
    }
}
