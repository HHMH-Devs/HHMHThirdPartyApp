using Bluegrams.Application;
using System;
using System.IO;
using System.Windows.Forms;
using ThirdPartyAppV2.Common.Logging;

namespace ThirdPartyAppV2.Main
{
    internal static class Program
    {
        private static readonly NlogConfiguration nlog = new NlogConfiguration();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!Directory.Exists("C:\\Users\\hadmin\\Documents\\Thirdpartyapp\\Settings"))
            {
                Directory.CreateDirectory("C:\\Users\\hadmin\\Documents\\Thirdpartyapp\\Settings");
            }
            nlog.ConfigureNlog();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            PortableSettingsProvider.SettingsFileName = "ThirdPartyApp.setting";
            PortableSettingsProviderBase.SettingsDirectory = "C:\\Users\\hadmin\\Documents\\Thirdpartyapp\\Settings";          
            PortableSettingsProvider.ApplyProvider(Properties.Settings.Default);
            Application.Run(new Main());
        }
    }
}
