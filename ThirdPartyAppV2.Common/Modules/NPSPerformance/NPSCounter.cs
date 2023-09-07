using PostSharp.Patterns.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ThirdPartyAppV2.Common.DBConnections.DB;
using ThirdPartyAppV2.Common.DBConnections.Helper;
using static ThirdPartyAppV2.Common.Modules.Main.ReportsDataset.ThirdPartyAppDataSet;

namespace ThirdPartyAppV2.Common.Modules.NPSPerformance
{
    public class NPSCounter
    {
        private readonly LogSource logSource;
        private DataSet ds;

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
                    newRow["RPEndDateTime"] = RPEnd == DateTime.MinValue ? DBNull.Value : RPEnd;
                    newRow["NCOStartDateTime"] = NCOStart == DateTime.MinValue ? DBNull.Value : NCOStart;
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
                        rw["RPEndDateTime"] = RPEnd == DateTime.MinValue ? DBNull.Value : RPEnd;
                        rw["NCOStartDateTime"] = NCOStart == DateTime.MinValue ? DBNull.Value : NCOStart;
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

        #region reports
        public DataSet LoadHospinfo()
        {
            var sql = "select * from appsysconfiggeneral";
            var settings = new HHMHBBSettings();
            var helper = new HHMHBBHelper(settings.GetConfigurationString("HHMHBB"));
            helper.Db_ConnOpen();
            var data = helper.LoadSQL(sql);
            helper.Db_ConnClose();
            HospitalInfoDataTable hospInfo = null;
            foreach (DataRow dr in data.Tables[0].Rows)
            {
                hospInfo = new HospitalInfoDataTable();
                var newRow = hospInfo.NewRow();
                newRow["PK_appsysConfigGeneral"] = dr["PK_appsysConfigGeneral"];
                newRow["tstamp"] = dr["tstamp"];
                newRow["HospOwnerID"] = dr["HospOwnerID"];
                newRow["HospDCNO"] = dr["HospDCNO"];
                newRow["HospName"] = dr["HospName"];
                newRow["HospLogo"] = dr["HospLogo"];
                newRow["HospTelephone"] = dr["HospTelephone"];
                newRow["HospWebsite"] = dr["HospWebsite"];
                newRow["HospOwner"] = dr["HospOwner"];
                newRow["HospTIN"] = dr["HospTIN"];
                newRow["HospStreetBldg1"] = dr["HospStreetBldg1"];
                newRow["HospStreetBldg2"] = dr["HospStreetBldg2"];
                newRow["HospStreetBldg3"] = dr["HospStreetBldg3"];
                newRow["HospBarangay"] = dr["HospBarangay"];
                newRow["HospTownCity"] = dr["HospTownCity"];
                newRow["HospProvince"] = dr["HospProvince"];
                newRow["HospRegion"] = dr["HospRegion"];
                newRow["HospCountry"] = dr["HospCountry"];
                newRow["HospArea"] = dr["HospArea"];
                newRow["HospZipcode"] = dr["HospZipcode"];
                newRow["HospAddress"] = dr["HospAddress"];
                newRow["HospAccrBeds"] = dr["HospAccrBeds"];
                newRow["HospBedCapacity"] = dr["HospBedCapacity"];
                newRow["HospAccrNo"] = dr["HospAccrNo"];
                newRow["HospType"] = dr["HospType"];
                newRow["HospCategory"] = dr["HospCategory"];
                newRow["HospPHICAccrNo"] = dr["HospPHICAccrNo"];
                newRow["HospPHICDaysCovered"] = dr["HospPHICDaysCovered"];
                newRow["CodeFormat"] = dr["CodeFormat"];
                newRow["CodeType"] = dr["CodeType"];
                newRow["CodeSeparator"] = dr["CodeSeparator"];
                newRow["MinPasswordTrial"] = dr["MinPasswordTrial"];
                newRow["MinPasswordLength"] = dr["MinPasswordLength"];
                newRow["urlreportpath"] = dr["urlreportpath"];
                newRow["defaultpicture"] = dr["defaultpicture"];
                newRow["HospSSS"] = dr["HospSSS"];
                newRow["phicfacility"] = dr["phicfacility"];
                newRow["phicfacilityoth"] = dr["phicfacilityoth"];
                newRow["HospCountryCode"] = dr["HospCountryCode"];
                newRow["pmcc"] = dr["pmcc"];
                newRow["pUserName"] = dr["pUserName"];
                newRow["pUserPwd"] = dr["pUserPwd"];
                newRow["urlimagepath"] = dr["urlimagepath"];
                newRow["HospFax"] = dr["HospFax"];
                newRow["HospEmailAdd"] = dr["HospEmailAdd"];
                newRow["proxyserverurl"] = dr["proxyserverurl"];
                newRow["isHHRshortageArea"] = dr["isHHRshortageArea"];
                newRow["HospHMOServerName"] = dr["HospHMOServerName"];
                newRow["HospHMOServerSQLAdmin"] = dr["HospHMOServerSQLAdmin"];
                newRow["HospHMOServerPassword"] = dr["HospHMOServerPassword"];
                newRow["HospHMOServerDB"] = dr["HospHMOServerDB"];
                newRow["historicaldatalookupurl"] = dr["historicaldatalookupurl"];
                newRow["FK_faCustomers"] = dr["FK_faCustomers"];
                newRow["HospEDPMSCode"] = dr["HospEDPMSCode"];
                newRow["HospEDPMSUserName"] = dr["HospEDPMSUserName"];
                newRow["HospEDPMSUserPass"] = dr["HospEDPMSUserPass"];
                newRow["DCHospID"] = dr["DCHospID"];
                newRow["DCuser"] = dr["DCuser"];
                newRow["DCpassword"] = dr["DCpassword"];
                newRow["DCProxyURL"] = dr["DCProxyURL"];
                newRow["StatWarningSound"] = dr["StatWarningSound"];
                newRow["StatWarningSoundDesc"] = dr["StatWarningSoundDesc"];
                newRow["cirrusID"] = dr["cirrusID"];
                newRow["cirrusURL"] = dr["cirrusURL"];
                newRow["useraccountlockoutduration"] = dr["useraccountlockoutduration"];
                newRow["IsNCR"] = dr["IsNCR"];
                newRow["HospCode"] = dr["HospCode"];
                newRow["BranchCode"] = dr["BranchCode"];
                newRow["cywareURL"] = dr["cywareURL"];
                newRow["pBIRpermitNo"] = dr["pBIRpermitNo"];
                newRow["controldept"] = dr["controldept"];
                newRow["patientImageURL"] = dr["patientImageURL"];
                newRow["videoURL"] = dr["videoURL"];
                newRow["videoresolution"] = dr["videoresolution"];
                newRow["consultantImageURL"] = dr["consultantImageURL"];
                newRow["videocompressor"] = dr["videocompressor"];
                newRow["dmsURL"] = dr["dmsURL"];
                newRow["dmsToken"] = dr["dmsToken"];
                newRow["EMRReportUrl"] = dr["EMRReportUrl"];
                newRow["eClaimPublicKey"] = dr["eClaimPublicKey"];
                newRow["rolClaims"] = dr["rolClaims"];
                newRow["dmsLocalUrl"] = dr["dmsLocalUrl"];
                newRow["dmsLocalClaims"] = dr["dmsLocalClaims"];
                newRow["dmsLocalClientId"] = dr["dmsLocalClientId"];
                newRow["dmsLocalClientSecret"] = dr["dmsLocalClientSecret"];
                newRow["dmsAuthProviderEndPoint"] = dr["dmsAuthProviderEndPoint"];
                newRow["dmsLocalClientRefreshToken"] = dr["dmsLocalClientRefreshToken"];
                newRow["csvIntegrationURL"] = dr["csvIntegrationURL"];
                newRow["processtime"] = dr["processtime"];
                newRow["dateactivatedGLHIS"] = dr["dateactivatedGLHIS"];
                newRow["isLockDMSOwner"] = dr["isLockDMSOwner"];
                newRow["smsUrl"] = dr["smsUrl"];
                newRow["smsHospId"] = dr["smsHospId"];
                newRow["PfForwardingEmail"] = dr["PfForwardingEmail"];
                newRow["ExamResultForwardingEmail"] = dr["ExamResultForwardingEmail"];
                newRow["eClaimsToken"] = dr["eClaimsToken"];
                newRow["eClaimsClientSecret"] = dr["eClaimsClientSecret"];
                newRow["beaconID"] = dr["beaconID"];
                newRow["beaconClientSecret"] = dr["beaconClientSecret"];
                newRow["beaconUrl"] = dr["beaconUrl"];
                newRow["beaconTokenUrl"] = dr["beaconTokenUrl"];
                newRow["beaconToken"] = dr["beaconToken"];
                newRow["beaconTokenRefresh"] = dr["beaconTokenRefresh"];
                newRow["qmuUrl"] = dr["qmuUrl"];
                newRow["hs8Url"] = dr["hs8Url"];
                newRow["redeemedPointsPath"] = dr["redeemedPointsPath"];
                newRow["earningPointsPath"] = dr["earningPointsPath"];
                newRow["loa"] = dr["loa"];
                newRow["bills"] = dr["bills"];
                newRow["pcuser"] = dr["pcuser"];
                newRow["pcpassword"] = dr["pcpassword"];
                newRow["pctokenid"] = dr["pctokenid"];
                newRow["pcapi"] = dr["pcapi"];
                newRow["medExpressUrl"] = dr["medExpressUrl"];
                newRow["philCareProvCode"] = dr["philCareProvCode"];
                newRow["philCareUserName"] = dr["philCareUserName"];
                newRow["philCarePassword"] = dr["philCarePassword"];
                newRow["philCareTokenID"] = dr["philCareTokenID"];
                newRow["beaconLocalUrl"] = dr["beaconLocalUrl"];
                newRow["dohHfhudCode"] = dr["dohHfhudCode"];
                newRow["dohUrl"] = dr["dohUrl"];
                newRow["phicStorageUserName"] = dr["phicStorageUserName"];
                newRow["phicStoragePassword"] = dr["phicStoragePassword"];
                newRow["ehrIntegrationEndPoint"] = dr["ehrIntegrationEndPoint"];
                newRow["ehrIntegrationEndPoint"] = dr["ehrIntegrationEndPoint"];
                newRow["PHICDocImageURL"] = dr["PHICDocImageURL"];
                newRow["MghClearanceWarningSound"] = dr["MghClearanceWarningSound"];
                newRow["MghClearanceWarningSoundDesc"] = dr["MghClearanceWarningSoundDesc"];
                newRow["exmQRCodeURL"] = dr["exmQRCodeURL"];
                newRow["exmQRDocFolder"] = dr["exmQRDocFolder"];
                newRow["POWarningSound"] = dr["POWarningSound"];
                newRow["POWarningSoundDesc"] = dr["POWarningSoundDesc"];
                newRow["StockIssWarningSound"] = dr["StockIssWarningSound"];
                newRow["StockIssWarningSoundDesc"] = dr["StockIssWarningSoundDesc"];
                newRow["ExpIssWarningSound"] = dr["ExpIssWarningSound"];
                newRow["ExpIssWarningSoundDesc"] = dr["ExpIssWarningSoundDesc"];
                newRow["eclaimsLogsPath"] = dr["eclaimsLogsPath"];
                hospInfo.Rows.Add(newRow);
            }
            ds = new DataSet();
            hospInfo.TableName = "HospitalInfo";
            ds.Tables.Add(hospInfo);
            return ds;
        }

        public DateTime StartOfWeek(DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        public DataSet LoadDischargeProc(string rptType = "Monthly", string dateNow = "")
        {
            if (string.IsNullOrEmpty(dateNow))
            {
                dateNow = DateTime.Now.ToString();
            }
            var startDate = DateTime.Today;
            var endDate = DateTime.Today;
            var startDateString = string.Empty;
            var endDateString = string.Empty;

            switch (rptType)
            {
                case "Weekly":
                    startDate = StartOfWeek(DateTime.Parse(dateNow), DayOfWeek.Sunday);
                    endDate = startDate.AddDays(6);
                    startDateString = $"{startDate:yyyy-MM-dd} 00:00:00";
                    endDateString = $"{endDate:yyyy-MM-dd} 23:59:59";
                    break;
                case "Daily":
                    startDate = DateTime.Parse(dateNow);
                    endDate = DateTime.Parse(dateNow);
                    startDateString = $"{startDate:yyyy-MM-dd} 00:00:00";
                    endDateString = $"{endDate:yyyy-MM-dd} 23:59:59";
                    break;
                default:
                    startDate = new DateTime(DateTime.Parse(dateNow).Year, DateTime.Parse(dateNow).Month, 1);
                    endDate = startDate.AddMonths(1).AddSeconds(-1);
                    startDateString = $"{startDate:yyyy-MM-dd} 00:00:00";
                    endDateString = $"{endDate:yyyy-MM-dd} 23:59:59";
                    break;
            }

            var dischargeProcDateList = new List<TimeSpan>();

            var sql = $"select * from dischargeprocess where `DateEncoded` Between '{startDateString}' and '{endDateString}'";

            var settings = new MYSQLDBSettings();
            var helper = new MYSQLDBHelper(settings.GetConfigurationString("MySQLDB"));
            helper.Db_ConnOpen();
            var data = helper.LoadSQL(sql);
            helper.Db_ConnClose();

            DischargeProcSummaryDataTable dt = new();
            var newRow = dt.NewRow();

            var medDisch = new TimeSpan();
            var integCheck = new TimeSpan();
            var billGen = new TimeSpan();
            var billPrint = new TimeSpan();
            var billPay = new TimeSpan();
            var docu = new TimeSpan();
            var patExit = new TimeSpan();

            var medDischCount = 0;
            var integCheckCount = 0;
            var billGenCount = 0;
            var billPrintCount = 0;
            var billPayCount = 0;
            var docuCount = 0;
            var patExitCount = 0;

            foreach (DataRow dr in data.Tables[0].Rows)
            {
                if (!DBNull.Value.Equals(dr["MDStartDateTime"]) && !DBNull.Value.Equals(dr["MDEndDateTime"]))
                {
                    medDischCount++;
                    medDisch += Convert.ToDateTime(dr["MDEndDateTime"]).Subtract(Convert.ToDateTime(dr["MDStartDateTime"]));
                    dischargeProcDateList.Add(Convert.ToDateTime(dr["MDEndDateTime"]).Subtract(Convert.ToDateTime(dr["MDStartDateTime"])));
                }
                if (!DBNull.Value.Equals(dr["IEStartDateTime"]) && !DBNull.Value.Equals(dr["IEEndDateTime"]))
                {
                    integCheckCount++;
                    integCheck += Convert.ToDateTime(dr["IEEndDateTime"]).Subtract(Convert.ToDateTime(dr["IEStartDateTime"]));
                    dischargeProcDateList.Add(Convert.ToDateTime(dr["IEEndDateTime"]).Subtract(Convert.ToDateTime(dr["IEStartDateTime"])));
                }
                if (!DBNull.Value.Equals(dr["BGStartDateTime"]) && !DBNull.Value.Equals(dr["BGEndDateTime"]))
                {
                    billGenCount++;
                    billGen += Convert.ToDateTime(dr["BGEndDateTime"]).Subtract(Convert.ToDateTime(dr["BGStartDateTime"]));
                    dischargeProcDateList.Add(Convert.ToDateTime(dr["BGEndDateTime"]).Subtract(Convert.ToDateTime(dr["BGStartDateTime"])));
                }
                if (!DBNull.Value.Equals(dr["BP1StartDateTime"]) && !DBNull.Value.Equals(dr["BP1EndDateTime"]))
                {
                    billPrintCount++;
                    billPrint += Convert.ToDateTime(dr["BP1EndDateTime"]).Subtract(Convert.ToDateTime(dr["BP1StartDateTime"]));
                    dischargeProcDateList.Add(Convert.ToDateTime(dr["BP1EndDateTime"]).Subtract(Convert.ToDateTime(dr["BP1StartDateTime"])));
                }
                if (!DBNull.Value.Equals(dr["BP2StartDateTime"]) && !DBNull.Value.Equals(dr["BP2EndDateTime"]))
                {
                    billPayCount++;
                    billPay += Convert.ToDateTime(dr["BP2EndDateTime"]).Subtract(Convert.ToDateTime(dr["BP2StartDateTime"]));
                    dischargeProcDateList.Add(Convert.ToDateTime(dr["BP2EndDateTime"]).Subtract(Convert.ToDateTime(dr["BP2StartDateTime"])));
                }
                if (!DBNull.Value.Equals(dr["DIDStartDateTime"]) && !DBNull.Value.Equals(dr["DIDEndDateTime"]))
                {
                    docuCount++;
                    docu += Convert.ToDateTime(dr["DIDEndDateTime"]).Subtract(Convert.ToDateTime(dr["DIDStartDateTime"]));
                    dischargeProcDateList.Add(Convert.ToDateTime(dr["DIDEndDateTime"]).Subtract(Convert.ToDateTime(dr["DIDStartDateTime"])));
                }
                if (!DBNull.Value.Equals(dr["PatExitStartDateTime"]) && !DBNull.Value.Equals(dr["PatExitEndDateTime"]))
                {
                    patExitCount++;
                    patExit += Convert.ToDateTime(dr["PatExitEndDateTime"]).Subtract(Convert.ToDateTime(dr["PatExitStartDateTime"]));
                    dischargeProcDateList.Add(Convert.ToDateTime(dr["PatExitEndDateTime"]).Subtract(Convert.ToDateTime(dr["PatExitStartDateTime"])));
                }
            }

            if (dischargeProcDateList.Count > 0)
            {
                var dischProcAverage = dischargeProcDateList.Average(timeSpan => timeSpan.TotalSeconds);
                var totalTAT = dischargeProcDateList.Sum(timeSpan => timeSpan.TotalSeconds);
                newRow["TotalAverageTAT"] = dischProcAverage;
                newRow["TotalTAT"] = totalTAT;
            }

            newRow["MedicalDischarge"] = medDisch;
            newRow["IntegrityCheck"] = integCheck;
            newRow["BillGeneration"] = billGen;
            newRow["BillPrnting"] = billPrint;
            newRow["BillPayment"] = billPay;
            newRow["Documentation"] = docu;
            newRow["PatientExit"] = patExit;
            ds = new DataSet();
            dt.Rows.Add(newRow);
            dt.TableName = "DischargeProcess";
            ds.Tables.Add(dt);

            ds.Tables["DischargeProcess"].Columns.Add("TotalMedDischargeAvg");
            ds.Tables["DischargeProcess"].Columns.Add("TotalIntegrityCheckAvg");
            ds.Tables["DischargeProcess"].Columns.Add("TotalBillGenAvg");
            ds.Tables["DischargeProcess"].Columns.Add("TotalBillPrintAvg");
            ds.Tables["DischargeProcess"].Columns.Add("TotalBillPayAvg");
            ds.Tables["DischargeProcess"].Columns.Add("TotalDocumentationAvg");
            ds.Tables["DischargeProcess"].Columns.Add("TotalPatExitAvg");

            ds.Tables["DischargeProcess"].Rows[0]["TotalMedDischargeAvg"] = ((medDisch.TotalSeconds / medDischCount) / 60);
            ds.Tables["DischargeProcess"].Rows[0]["TotalIntegrityCheckAvg"] = ((integCheck.TotalSeconds / integCheckCount) / 60);
            ds.Tables["DischargeProcess"].Rows[0]["TotalBillGenAvg"] = ((billGen.TotalSeconds / billGenCount) / 60);
            ds.Tables["DischargeProcess"].Rows[0]["TotalBillPrintAvg"] = ((billPrint.TotalSeconds / billPrintCount) / 60);
            ds.Tables["DischargeProcess"].Rows[0]["TotalBillPayAvg"] = ((billPay.TotalSeconds / billPayCount) / 60);
            ds.Tables["DischargeProcess"].Rows[0]["TotalDocumentationAvg"] = ((docu.TotalSeconds / docuCount) / 60);
            ds.Tables["DischargeProcess"].Rows[0]["TotalPatExitAvg"] = ((patExit.TotalSeconds / patExitCount) / 60);

            return ds;
        }

        public DataSet LoadErToAdmission(string rptType = "Monthly", string dateNow = "")
        {

            if (string.IsNullOrEmpty(dateNow))
            {
                dateNow = DateTime.Now.ToString();
            }
            var startDate = DateTime.Today;
            var endDate = DateTime.Today;
            var startDateString = string.Empty;
            var endDateString = string.Empty;

            switch (rptType)
            {
                case "Weekly":
                    startDate = StartOfWeek(DateTime.Parse(dateNow), DayOfWeek.Sunday);
                    endDate = startDate.AddDays(6);
                    startDateString = $"{startDate:yyyy-MM-dd} 00:00:00";
                    endDateString = $"{endDate:yyyy-MM-dd} 23:59:59";
                    break;
                case "Daily":
                    startDate = DateTime.Parse(dateNow);
                    endDate = DateTime.Parse(dateNow);
                    startDateString = $"{startDate:yyyy-MM-dd} 00:00:00";
                    endDateString = $"{endDate:yyyy-MM-dd} 23:59:59";
                    break;
                default:
                    startDate = new DateTime(DateTime.Parse(dateNow).Year, DateTime.Parse(dateNow).Month, 1);
                    endDate = startDate.AddMonths(1).AddSeconds(-1);
                    startDateString = $"{startDate:yyyy-MM-dd} 00:00:00";
                    endDateString = $"{endDate:yyyy-MM-dd} 23:59:59";
                    break;
            }

            var erToAdmissionDateList = new List<TimeSpan>();

            var sql = $"select * from ertoadmission where `DateEncoded` Between '{startDateString}' and '{endDateString}'";
            var settings = new MYSQLDBSettings();
            var helper = new MYSQLDBHelper(settings.GetConfigurationString("MySQLDB"));
            helper.Db_ConnOpen();
            var data = helper.LoadSQL(sql);
            helper.Db_ConnClose();

            ErToAdmissionSummaryDataTable dt = new();
            var newRow = dt.NewRow();

            var regToDoc = new TimeSpan();
            var docOrder = new TimeSpan();
            var profiling = new TimeSpan();
            var phicSubmit = new TimeSpan();
            var roomPrep = new TimeSpan();
            var nurseCarryOut = new TimeSpan();
            var readyToTrans = new TimeSpan();
            var transToRoom = new TimeSpan();

            var regToDocCount = 0;
            var docOrderCount = 0;
            var profilingCount = 0;
            var phicSubmitCount = 0;
            var roomPrepCount = 0;
            var nurseCarryOutCount = 0;
            var readyToTransCount = 0;
            var transToRoomCount = 0;

            foreach (DataRow dr in data.Tables[0].Rows)
            {
                if (!DBNull.Value.Equals(dr["RegToDocStartDateTime"]) && !DBNull.Value.Equals(dr["RegToDocEndDateTime"]))
                {
                    regToDocCount++;
                    regToDoc += Convert.ToDateTime(dr["RegToDocEndDateTime"]).Subtract(Convert.ToDateTime(dr["RegToDocStartDateTime"]));
                    erToAdmissionDateList.Add(Convert.ToDateTime(dr["RegToDocEndDateTime"]).Subtract(Convert.ToDateTime(dr["RegToDocStartDateTime"])));
                }
                if (!DBNull.Value.Equals(dr["DocOrderStartDateTime"]) && !DBNull.Value.Equals(dr["DocOrderEndDateTime"]))
                {
                    docOrderCount++;
                    docOrder += Convert.ToDateTime(dr["DocOrderEndDateTime"]).Subtract(Convert.ToDateTime(dr["DocOrderStartDateTime"]));
                    erToAdmissionDateList.Add(Convert.ToDateTime(dr["DocOrderEndDateTime"]).Subtract(Convert.ToDateTime(dr["DocOrderStartDateTime"])));
                }
                if (!DBNull.Value.Equals(dr["APPStartDateTime"]) && !DBNull.Value.Equals(dr["APPEndDateTime"]))
                {
                    profilingCount++;
                    profiling += Convert.ToDateTime(dr["APPEndDateTime"]).Subtract(Convert.ToDateTime(dr["APPStartDateTime"]));
                    erToAdmissionDateList.Add(Convert.ToDateTime(dr["APPEndDateTime"]).Subtract(Convert.ToDateTime(dr["APPStartDateTime"])));
                }
                if (!DBNull.Value.Equals(dr["PHICStartDateTime"]) && !DBNull.Value.Equals(dr["PHICEndDateTime"]))
                {
                    phicSubmitCount++;
                    phicSubmit += Convert.ToDateTime(dr["PHICEndDateTime"]).Subtract(Convert.ToDateTime(dr["PHICStartDateTime"]));
                    erToAdmissionDateList.Add(Convert.ToDateTime(dr["PHICEndDateTime"]).Subtract(Convert.ToDateTime(dr["PHICStartDateTime"])));
                }
                if (!DBNull.Value.Equals(dr["RPStartDateTime"]) && !DBNull.Value.Equals(dr["RPEndDateTime"]))
                {
                    roomPrepCount++;
                    roomPrep += Convert.ToDateTime(dr["RPEndDateTime"]).Subtract(Convert.ToDateTime(dr["RPStartDateTime"]));
                    erToAdmissionDateList.Add(Convert.ToDateTime(dr["RPEndDateTime"]).Subtract(Convert.ToDateTime(dr["RPStartDateTime"])));
                }
                if (!DBNull.Value.Equals(dr["NCOStartDateTime"]) && !DBNull.Value.Equals(dr["NCOEndDateTime"]))
                {
                    nurseCarryOutCount++;
                    nurseCarryOut += Convert.ToDateTime(dr["NCOEndDateTime"]).Subtract(Convert.ToDateTime(dr["NCOStartDateTime"]));
                    erToAdmissionDateList.Add(Convert.ToDateTime(dr["NCOEndDateTime"]).Subtract(Convert.ToDateTime(dr["NCOStartDateTime"])));
                }
                if (!DBNull.Value.Equals(dr["ReadyToTransStartDateTime"]) && !DBNull.Value.Equals(dr["ReadyToTransEndDateTime"]))
                {
                    readyToTransCount++;
                    readyToTrans += Convert.ToDateTime(dr["ReadyToTransEndDateTime"]).Subtract(Convert.ToDateTime(dr["ReadyToTransStartDateTime"]));
                    erToAdmissionDateList.Add(Convert.ToDateTime(dr["ReadyToTransEndDateTime"]).Subtract(Convert.ToDateTime(dr["ReadyToTransStartDateTime"])));
                }
                if (!DBNull.Value.Equals(dr["TransToRoomStartDateTime"]) && !DBNull.Value.Equals(dr["TransToRoomEndDateTime"]))
                {
                    transToRoomCount++;
                    transToRoom += Convert.ToDateTime(dr["TransToRoomEndDateTime"]).Subtract(Convert.ToDateTime(dr["TransToRoomStartDateTime"]));
                    erToAdmissionDateList.Add(Convert.ToDateTime(dr["TransToRoomEndDateTime"]).Subtract(Convert.ToDateTime(dr["TransToRoomStartDateTime"])));
                }
            }

            if (erToAdmissionDateList.Count > 0)
            {
                var dischProcAverage = erToAdmissionDateList.Average(timeSpan => timeSpan.TotalSeconds);
                var totalTAT = erToAdmissionDateList.Sum(timeSpan => timeSpan.TotalSeconds);
                newRow["TotalAverageTAT"] = dischProcAverage;
                newRow["TotalTAT"] = totalTAT;
            }

            newRow["RegToDocOrder"] = regToDoc;
            newRow["DocOrderCarryOut"] = docOrder;
            newRow["PatientProfiling"] = profiling;
            newRow["PHICSubmission"] = phicSubmit;
            newRow["RoomPrep"] = roomPrep;
            newRow["NursesCarryOut"] = nurseCarryOut;
            newRow["ReadyToTransfer"] = readyToTrans;
            newRow["TransferToRoom"] = transToRoom;

            ds = new DataSet();

            dt.Rows.Add(newRow);
            dt.TableName = "ErToAdmission";
            ds.Tables.Add(dt);

            ds.Tables["ErToAdmission"].Columns.Add("TotalRegToDocOrderAvg");
            ds.Tables["ErToAdmission"].Columns.Add("TotalDocOrderCarryOutAvg");
            ds.Tables["ErToAdmission"].Columns.Add("TotalPatientProfilingAvg");
            ds.Tables["ErToAdmission"].Columns.Add("TotalPHICSubmissionAvg");
            ds.Tables["ErToAdmission"].Columns.Add("TotalRoomPrepAvg");
            ds.Tables["ErToAdmission"].Columns.Add("TotalNursesCarryOutAvg");
            ds.Tables["ErToAdmission"].Columns.Add("TotalReadyToTransferAvg");
            ds.Tables["ErToAdmission"].Columns.Add("TotalTransferToRoomAvg");

            ds.Tables["ErToAdmission"].Rows[0]["TotalRegToDocOrderAvg"] = ((regToDoc.TotalSeconds / regToDocCount) / 60);
            ds.Tables["ErToAdmission"].Rows[0]["TotalDocOrderCarryOutAvg"] = ((docOrder.TotalSeconds / docOrderCount) / 60);
            ds.Tables["ErToAdmission"].Rows[0]["TotalPatientProfilingAvg"] = ((profiling.TotalSeconds / profilingCount) / 60);
            ds.Tables["ErToAdmission"].Rows[0]["TotalPHICSubmissionAvg"] = ((phicSubmit.TotalSeconds / phicSubmitCount) / 60);
            ds.Tables["ErToAdmission"].Rows[0]["TotalRoomPrepAvg"] = ((roomPrep.TotalSeconds / roomPrepCount) / 60);
            ds.Tables["ErToAdmission"].Rows[0]["TotalNursesCarryOutAvg"] = ((nurseCarryOut.TotalSeconds / nurseCarryOutCount) / 60);
            ds.Tables["ErToAdmission"].Rows[0]["TotalReadyToTransferAvg"] = ((readyToTrans.TotalSeconds / readyToTransCount) / 60);
            ds.Tables["ErToAdmission"].Rows[0]["TotalTransferToRoomAvg"] = ((transToRoom.TotalSeconds / transToRoomCount) / 60);

            return ds;
        }
        #endregion
    }
}