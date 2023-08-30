using NLog;
using NLog.Config;
using NLog.Targets;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.NLog;
using System;
using LogLevel = NLog.LogLevel;

namespace ThirdPartyAppV2.Common.Logging
{
    public class NlogConfiguration
    {
        public void ConfigureNlog()
        {
            var header = NLog.Layouts.Layout.FromString($"------------------------------Start of Logging {DateTime.Now:G}------------------------------");
            var footer = NLog.Layouts.Layout.FromString($"------------------------------End of Logging {DateTime.Now:G}------------------------------\r\n");
            var nlogConfig = new LoggingConfiguration();

            var fileTarget = new FileTarget("file")
            {
                FileName = $"Logs\\Syslog.log",
                KeepFileOpen = true,
                ConcurrentWrites = true,
                OptimizeBufferReuse = true,
                Header = header,
                Footer = footer,
                ArchiveOldFileOnStartup = true,
                ArchiveNumbering = ArchiveNumberingMode.Date,
                ArchiveDateFormat = "yyyy-MMMM-dd",
                WriteFooterOnArchivingOnly = true,
                Layout = "${longdate} | ${level} | ${callsite} | ${message} | ${exception:format=ToString}",
            };

            nlogConfig.AddTarget(fileTarget);
            nlogConfig.LoggingRules.Add(new LoggingRule("*", LogLevel.Info, LogLevel.Fatal, fileTarget));

            var consoleTarget = new ConsoleTarget("console")
            {
                Layout = "${longdate} | ${level} | ${callsite} | ${message} | ${exception:format=ToString}",
                OptimizeBufferReuse = true
            };
            nlogConfig.AddTarget(consoleTarget);
            nlogConfig.LoggingRules.Add(new LoggingRule("*", LogLevel.Trace, LogLevel.Fatal, consoleTarget));          

            LoggingServices.DefaultBackend = new NLogLoggingBackend(new LogFactory(nlogConfig));
            LoggingServices.DefaultBackend.Options.IncludeActivityExecutionTime = true;

            LogManager.EnableLogging();
        }
    }
}
