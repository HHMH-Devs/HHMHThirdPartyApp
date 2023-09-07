﻿using PostSharp.Patterns.Diagnostics;
using System;
using System.Data;
using ThirdPartyAppV2.Common.DBConnections.DB;
using ThirdPartyAppV2.Common.DBConnections.Helper;

namespace ThirdPartyAppV2.Common.Modules.Main
{
    public class LoadData
    {
        private readonly LogSource logSource;

        public LoadData()
        {
            logSource = LogSource.Get();
        }

        public DataSet LoadAdmitted(string searchText, string startDate, string endDate)
        {
            var sql = string.Empty;
            try
            {
                sql = "SELECT TOP 10 " +
               "B.pk_pspatregisters, " +
               "B.PatientFullName, " +
               "B.pattrantype, " +
               "B.registrydate, " +
               "ISNULL((Select dischdate from psPatRegisters where PK_psPatRegisters = B.pk_pspatregisters ), NULL) as [dischDatetime], " +
               "dbo.udf_GetAttendingDoctors ( B.pk_pspatregisters ) AS AttendingDoctor " +
               "FROM " +
               "vwReportPatientProfile B " +
               "WHERE " +
               $"dbo.udf_GetFullName ( B.PK_emdpatients ) LIKE '%{searchText}%' and B.registrydate BETWEEN " +
               $"'{startDate} 00:00:00' " +
               $"and '{endDate} 23:59:59' " +
               "AND B.pattrantype <> 'O' " +
               "ORDER BY B.registrydate DESC;";

                var settings = new HHMHBBSettings();
                var helper = new HHMHBBHelper(settings.GetConfigurationString("HHMHBB"));
                helper.Db_ConnOpen();
                var data = helper.LoadSQL(sql);
                helper.Db_ConnClose();

                return data;
            }
            catch (Exception ex)
            {
                logSource.Error.Write(FormattedMessageBuilder.Formatted("An erro occured while executing the request. {Message} - {sql}", ex.Message, sql));
                return null;
            }
        }

        public DataSet LoadNPSAverageDischarge(string startDate, string endDate)
        {
            var sql = string.Empty;
            try
            {
                sql = $"select * from dischargeprocess where DateEncoded between '{startDate}' and '{endDate}'";
                var settings = new MYSQLDBSettings();
                var helper = new MYSQLDBHelper(settings.GetConfigurationString("MySQLDB"));
                helper.Db_ConnOpen();
                var data = helper.LoadSQL(sql);
                helper.Db_ConnClose();
                return data;
            }
            catch (Exception ex)
            {
                logSource.Error.Write(FormattedMessageBuilder.Formatted("An erro occured while executing the request. {Message} - {sql}", ex.Message, sql));
                return null;
            }
        }

        public DataSet LoadNPSAverageErToAdmission(string startDate, string endDate)
        {
            var sql = string.Empty;
            try
            {
                sql = $"select * from ertoadmission where DateEncoded between '{startDate}' and '{endDate}'";
                var settings = new MYSQLDBSettings();
                var helper = new MYSQLDBHelper(settings.GetConfigurationString("MySQLDB"));
                helper.Db_ConnOpen();
                var data = helper.LoadSQL(sql);
                helper.Db_ConnClose();
                return data;
            }
            catch (Exception ex)
            {
                logSource.Error.Write(FormattedMessageBuilder.Formatted("An erro occured while executing the request. {Message} - {sql}", ex.Message, sql));
                return null;
            }
        }
    }
}
