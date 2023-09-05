using Org.BouncyCastle.Security.Certificates;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Data;
using ThirdPartyAppV2.Common.DBConnections.DB;
using ThirdPartyAppV2.Common.DBConnections.Helper;

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

        public DataSet InPatientMGH(string id)
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
                             DateTime IEStart,
                             DateTime IEEnd,
                             DateTime BGStart,
                             DateTime BGEnd,
                             DateTime BP1Start,
                             DateTime BP1End,
                             DateTime BP2Start,
                             DateTime BP2End,
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
                    newRow["MDStartDateTime"] = MDStart == DateTime.MinValue ? DBNull.Value : MDStart;
                    newRow["MDEndDateTime"] = MDEnd == DateTime.MinValue ? DBNull.Value : MDEnd;
                    newRow["IEStartDateTime"] = IEStart == DateTime.MinValue ? DBNull.Value : IEStart;
                    newRow["IEEndDateTime"] = IEEnd == DateTime.MinValue ? DBNull.Value : IEEnd;
                    newRow["BGStartDateTime"] = BGStart == DateTime.MinValue ? DBNull.Value : BGStart;
                    newRow["BGEndDateTime"] = BGEnd == DateTime.MinValue ? DBNull.Value : BGEnd;
                    newRow["BP1StartDateTime"] = BP1Start == DateTime.MinValue ? DBNull.Value : BP1Start;
                    newRow["BP1EndDateTime"] = BP1End == DateTime.MinValue ? DBNull.Value : BP1End;
                    newRow["BP2StartDateTime"] = BP2Start == DateTime.MinValue ? DBNull.Value : BP2Start;
                    newRow["BP2EndDateTime"] = BP2End == DateTime.MinValue ? DBNull.Value : BP2End;
                    newRow["DIDStartDateTime"] = DIDStart == DateTime.MinValue ? DBNull.Value : DIDStart;
                    newRow["DIDEndDateTime"] = DIDEnd == DateTime.MinValue ? DBNull.Value : DIDEnd;
                    newRow["PatExitStartDateTime"] = PEStart == DateTime.MinValue ? DBNull.Value : PEStart;
                    newRow["PatExitEndDateTime"] = PEEnd == DateTime.MinValue ? DBNull.Value : PEEnd;
                    newRow["DateEncoded"] = DateTime.Now;
                    data.Tables[0].Rows.Add(newRow);

                    st = helper.SaveEntry(data);
                }
                else
                {
                    foreach (DataRow rw in data.Tables[0].Rows)
                    {
                        rw["PatientName"] = patName;
                        rw["MDStartDateTime"] = MDStart == DateTime.MinValue ? DBNull.Value : MDStart;
                        rw["MDEndDateTime"] = MDEnd == DateTime.MinValue ? DBNull.Value : MDEnd;
                        rw["IEStartDateTime"] = IEStart == DateTime.MinValue ? DBNull.Value : IEStart;
                        rw["IEEndDateTime"] = IEEnd == DateTime.MinValue ? DBNull.Value : IEEnd;
                        rw["BGStartDateTime"] = BGStart == DateTime.MinValue ? DBNull.Value : BGStart;
                        rw["BGEndDateTime"] = BGEnd == DateTime.MinValue ? DBNull.Value : BGEnd;
                        rw["BP1StartDateTime"] = BP1Start == DateTime.MinValue ? DBNull.Value : BP1Start;
                        rw["BP1EndDateTime"] = BP1End == DateTime.MinValue ? DBNull.Value : BP1End;
                        rw["BP2StartDateTime"] = BP2Start == DateTime.MinValue ? DBNull.Value : BP2Start;
                        rw["BP2EndDateTime"] = BP2End == DateTime.MinValue ? DBNull.Value : BP2End;
                        rw["DIDStartDateTime"] = DIDStart == DateTime.MinValue ? DBNull.Value : DIDStart;
                        rw["DIDEndDateTime"] = DIDEnd == DateTime.MinValue ? DBNull.Value : DIDEnd;
                        rw["PatExitStartDateTime"] = PEStart == DateTime.MinValue ? DBNull.Value : PEStart;
                        rw["PatExitEndDateTime"] = PEEnd == DateTime.MinValue ? DBNull.Value : PEEnd;

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
                             DateTime regToDocStart,
                             DateTime regToDocEnd,
                             DateTime docOrderStart,
                             DateTime docOrderEnd,
                             DateTime APPStart,
                             DateTime APPEnd,
                             DateTime PhicStart,
                             DateTime PhicEnd,
                             DateTime RPStart,
                             DateTime RPEnd,
                             DateTime NCOStart,
                             DateTime NCOEnd,
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
                    newRow["RegToDocStartDateTime"] = regToDocStart == DateTime.MinValue ? DBNull.Value : regToDocStart;
                    newRow["RegToDocEndDateTime"] = regToDocEnd == DateTime.MinValue ? DBNull.Value : regToDocEnd;
                    newRow["DocOrderStartDateTime"] = docOrderStart == DateTime.MinValue ? DBNull.Value : docOrderStart;
                    newRow["DocOrderEndDateTime"] = docOrderEnd == DateTime.MinValue ? DBNull.Value : docOrderEnd;
                    newRow["APPStartDateTime"] = APPStart == DateTime.MinValue ? DBNull.Value : APPStart;
                    newRow["APPEndDateTime"] = APPEnd == DateTime.MinValue ? DBNull.Value : APPEnd;
                    newRow["PHICStartDateTime"] = PhicStart == DateTime.MinValue ? DBNull.Value : PhicStart;
                    newRow["PHICEndDateTime"] = PhicEnd == DateTime.MinValue ? DBNull.Value : PhicEnd;
                    newRow["RPStartDateTime"] = RPStart == DateTime.MinValue ? DBNull.Value : RPStart;
                    newRow["RPDocEndDateTime"] = RPEnd == DateTime.MinValue ? DBNull.Value : RPEnd;
                    newRow["NCODocStartDateTime"] = NCOStart == DateTime.MinValue ? DBNull.Value : NCOStart;
                    newRow["NCOEndDateTime"] = NCOEnd == DateTime.MinValue ? DBNull.Value : NCOEnd;
                    newRow["ReadyToTransStartDateTime"] = readyToTransStart == DateTime.MinValue ? DBNull.Value : readyToTransStart;
                    newRow["ReadyToTransEndDateTime"] = readyToTransEnd == DateTime.MinValue ? DBNull.Value : readyToTransEnd;
                    newRow["TransToRoomStartDateTime"] = transToRoomStart == DateTime.MinValue ? DBNull.Value : transToRoomStart;
                    newRow["TransToRoomEndDateTime"] = transToRoomEnd == DateTime.MinValue ? DBNull.Value : transToRoomEnd;
                    newRow["DateEncoded"] = DateTime.Now;

                    data.Tables[0].Rows.Add(newRow);

                    st = helper.SaveEntry(data);
                }
                else
                {
                    foreach (DataRow rw in data.Tables[0].Rows)
                    {
                        rw["PatientName"] = patName;
                        rw["RegToDocStartDateTime"] = regToDocStart == DateTime.MinValue ? DBNull.Value : regToDocStart;
                        rw["RegToDocEndDateTime"] = regToDocEnd == DateTime.MinValue ? DBNull.Value : regToDocEnd;
                        rw["DocOrderStartDateTime"] = docOrderStart == DateTime.MinValue ? DBNull.Value : docOrderStart;
                        rw["DocOrderEndDateTime"] = docOrderEnd == DateTime.MinValue ? DBNull.Value : docOrderEnd;
                        rw["APPStartDateTime"] = APPStart == DateTime.MinValue ? DBNull.Value : APPStart;
                        rw["APPEndDateTime"] = APPEnd == DateTime.MinValue ? DBNull.Value : APPEnd;
                        rw["PHICStartDateTime"] = PhicStart == DateTime.MinValue ? DBNull.Value : PhicStart;
                        rw["PHICEndDateTime"] = PhicEnd == DateTime.MinValue ? DBNull.Value : PhicEnd;
                        rw["RPStartDateTime"] = RPStart == DateTime.MinValue ? DBNull.Value : RPStart;
                        rw["RPDocEndDateTime"] = RPEnd == DateTime.MinValue ? DBNull.Value : RPEnd;
                        rw["NCODocStartDateTime"] = NCOStart == DateTime.MinValue ? DBNull.Value : NCOStart;
                        rw["NCOEndDateTime"] = NCOEnd == DateTime.MinValue ? DBNull.Value : NCOEnd;
                        rw["ReadyToTransStartDateTime"] = readyToTransStart == DateTime.MinValue ? DBNull.Value : readyToTransStart;
                        rw["ReadyToTransEndDateTime"] = readyToTransEnd == DateTime.MinValue ? DBNull.Value : readyToTransEnd;
                        rw["TransToRoomStartDateTime"] = transToRoomStart == DateTime.MinValue ? DBNull.Value : transToRoomStart;
                        rw["TransToRoomEndDateTime"] = transToRoomEnd == DateTime.MinValue ? DBNull.Value : transToRoomEnd;

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