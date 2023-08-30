using PostSharp.Patterns.Diagnostics;
using System;
using System.Data;
using ThirdPartyAppV2.Common.DBConnections.DB;
using ThirdPartyAppV2.Common.DBConnections.Helper;
using ThirdPartyAppV2.Common.DBConnections.Helper.Security;

namespace ThirdPartyAppV2.Common.Modules.NPSPerformance
{
    [Log]
    public class NPSCounter
    {
        private readonly LogSource logSource;

        public NPSCounter()
        {
            logSource = LogSource.Get();
        }

        public string InPatientMGH(string id)
        {
            var sql = string.Empty;
            var mghDate = string.Empty;
            try
            {
                sql = $"select * from psPatRegisters where PK_psPatRegisters = {id};";

                var settings = new HHMHBBSettings();
                var helper = new HHMHBBHelper(settings.GetConfigurationString("HHMHBB"));
                helper.Db_ConnOpen();
                var data = helper.LoadSQL(sql);
                helper.Db_ConnClose();
                foreach (DataRow item in data.Tables[0].Rows)
                {
                    mghDate = item["mghdatetime"].ToString();
                }
                return mghDate;
            }
            catch (Exception ex)
            {
                logSource.Error.Write(FormattedMessageBuilder.Formatted("An erro occured while executing the request. {Message} - {sql}", ex.Message, sql));
                return null;
            }
        }

        public DataSet ErCaseDateTime(string id)
        {
            var sql = string.Empty;
            try
            {
                sql = $"select * from psPatRegisters where PK_psPatRegisters = {id};";

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

        public DataSet ErInPatient(string name, string admissionDate)
        {

            var sql = string.Empty;
            try
            {
                sql = $"select * from psPatRegisters " +
                    $"where dbo.udf_GetFullName(FK_emdPatients) = '{name}' " +
                    $"and (registrydate <= '{admissionDate}' or registrydate >= '{admissionDate}') " +
                    $"and pattrantype = 'I';";

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

        public DataSet LoadDataFromMySqlER(int id)
        {
            var sql = string.Empty;
            try
            {
                sql = $"Select * from ertoadmission where ID = {id}";
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

        public DataSet LoadDataFromMySqlDischarge(int id)
        {
            var sql = string.Empty;
            try
            {
                sql = $"Select * from dischargeprocess where ID = {id}";
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

        public bool SaveDataDischargeProcess(int id,
                             string patName,
                             DateTime MDStart,
                             DateTime MDEnd,
                             DateTime BSStart,
                             DateTime BSEnd,
                             DateTime BGStart,
                             DateTime BGEnd,
                             DateTime BPStart,
                             DateTime BPEnd,
                             DateTime DIDStart,
                             DateTime DIDEnd,
                             DateTime PEStart,
                             DateTime PEEnd)
        {
            var sql = string.Empty;
            var st = false;
            try
            {
                sql = $"Select * from dischargeprocess where ID = {id}";
                var settings = new MYSQLDBSettings();
                var helper = new MYSQLDBHelper(settings.GetConfigurationString("MySQLDB"));
                helper.Db_ConnOpen();
                var data = helper.LoadSQL(sql, "dischargeprocess");
                if (data.Tables[0].Rows.Count <= 0)
                {
                    var newRow = data.Tables[0].NewRow();
                    newRow["ID"] = id;
                    newRow["PatientName"] = patName;
                    newRow["MDStartDateTime"] = MDStart;
                    newRow["MDEndDateTime"] = MDEnd;
                    newRow["BSStartDateTime"] = BSStart;
                    newRow["BSEndDateTime"] = BSEnd;
                    newRow["BGStartDateTime"] = BGStart;
                    newRow["BGEndDateTime"] = BGEnd;
                    newRow["BPStartDateTime"] = BPStart;
                    newRow["BPEndDateTime"] = BPEnd;
                    newRow["DIDStartDateTime"] = DIDStart;
                    newRow["DIDEndDateTime"] = DIDEnd;
                    newRow["PatExitStartDateTime"] = PEStart;
                    newRow["PatExitEndDateTime"] = PEEnd;

                    data.Tables[0].Rows.Add(newRow);

                    st = helper.SaveEntry(data);
                }
                else
                {
                    foreach (DataRow rw in data.Tables[0].Rows)
                    {
                        rw["PatientName"] = patName;
                        rw["MDStartDateTime"] = MDStart;
                        rw["MDEndDateTime"] = MDEnd;
                        rw["BSStartDateTime"] = BSStart;
                        rw["BSEndDateTime"] = BSEnd;
                        rw["BGStartDateTime"] = BGStart;
                        rw["BGEndDateTime"] = BGEnd;
                        rw["BPStartDateTime"] = BPStart;
                        rw["BPEndDateTime"] = BPEnd;
                        rw["DIDStartDateTime"] = DIDStart;
                        rw["DIDEndDateTime"] = DIDEnd;
                        rw["PatExitStartDateTime"] = PEStart;
                        rw["PatExitEndDateTime"] = PEEnd;

                        st = helper.SaveEntry(data, false);
                    }
                }
                helper.Db_ConnClose();
                return st;
            }
            catch (Exception ex)
            {
                logSource.Error.Write(FormattedMessageBuilder.Formatted("An erro occured while executing the request. {Message} - {sql}", ex.Message, sql));
                return st;
            }
        }

        public bool SaveDataErToAdmission(int id,
                             string patName,
                             DateTime dToTStart,
                             DateTime dToTEnd,
                             DateTime triToRegStart,
                             DateTime triToRegEnd,
                             DateTime regToDocStart,
                             DateTime regToDocEnd,
                             DateTime docOrderStart,
                             DateTime docOrderEnd,
                             DateTime readyToTransStart,
                             DateTime readyToTransEnd,
                             DateTime transToRoomStart,
                             DateTime transToRoomEnd)
        {
            var sql = string.Empty;
            var st = false;
            try
            {
                sql = $"Select * from ertoadmission where ID = {id}";
                var settings = new MYSQLDBSettings();
                var helper = new MYSQLDBHelper(settings.GetConfigurationString("MySQLDB"));
                helper.Db_ConnOpen();
                var data = helper.LoadSQL(sql, "ertoadmission");
                if (data.Tables[0].Rows.Count <= 0)
                {
                    var newRow = data.Tables[0].NewRow();
                    newRow["ID"] = id;
                    newRow["PatientName"] = patName;
                    newRow["DToTStartDateTime"] = dToTStart;
                    newRow["DToTEndDateTime"] = dToTEnd;
                    newRow["TriToRegStartDateTime"] = triToRegStart;
                    newRow["TriToRegEndDateTime"] = triToRegEnd;
                    newRow["RegToDocStartDateTime"] = regToDocStart;
                    newRow["RegToDocEndDateTime"] = regToDocEnd;
                    newRow["DocOrderStartDateTime"] = docOrderStart;
                    newRow["DocOrderEndDateTime"] = docOrderEnd;
                    newRow["ReadyToTransStartDateTime"] = readyToTransStart;
                    newRow["ReadyToTransEndDateTime"] = readyToTransEnd;
                    newRow["TransToRoomStartDateTime"] = transToRoomStart;
                    newRow["TransToRoomEndDateTime"] = transToRoomEnd;

                    data.Tables[0].Rows.Add(newRow);

                    st = helper.SaveEntry(data);
                }
                else
                {
                    foreach (DataRow rw in data.Tables[0].Rows)
                    {
                        rw["PatientName"] = patName;
                        rw["DToTStartDateTime"] = dToTStart;
                        rw["DToTEndDateTime"] = dToTEnd;
                        rw["TriToRegStartDateTime"] = triToRegStart;
                        rw["TriToRegEndDateTime"] = triToRegEnd;
                        rw["RegToDocStartDateTime"] = regToDocStart;
                        rw["RegToDocEndDateTime"] = regToDocEnd;
                        rw["DocOrderStartDateTime"] = docOrderStart;
                        rw["DocOrderEndDateTime"] = docOrderEnd;
                        rw["ReadyToTransStartDateTime"] = readyToTransStart;
                        rw["ReadyToTransEndDateTime"] = readyToTransEnd;
                        rw["TransToRoomStartDateTime"] = transToRoomStart;
                        rw["TransToRoomEndDateTime"] = transToRoomEnd;

                        st = helper.SaveEntry(data, false);
                    }
                }
                helper.Db_ConnClose();
                return st;
            }
            catch (Exception ex)
            {
                logSource.Error.Write(FormattedMessageBuilder.Formatted("An erro occured while executing the request. {Message} - {sql}", ex.Message, sql));
                return st;
            }
        }
    }
}