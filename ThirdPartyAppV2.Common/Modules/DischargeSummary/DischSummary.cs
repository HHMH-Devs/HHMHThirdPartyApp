using PostSharp.Patterns.Diagnostics;
using System;
using System.Data;
using ThirdPartyAppV2.Common.DBConnections.DB;
using ThirdPartyAppV2.Common.DBConnections.Helper;

namespace ThirdPartyAppV2.Common.Modules.DischargeSummary
{
    public class DischSummary
    {
        private readonly LogSource logSource = LogSource.Get();

        public DataSet LoadDischSummary(int id)
        {
            var data = new DataSet();
            var sql = string.Empty;
            try
            {
                sql = "SELECT DATENAME(m, a.registrydate) AS AdmissionMonth, DAY(a.registrydate) AS AdmissionDay, YEAR(a.registrydate) AS AdmissionYear, " +
                    "CONVERT(varchar, a.registrydate, 109) AS AdmissionTime, a.registrydate, ISNULL(CONVERT(VARCHAR, a.registrydate, 110), N'') " +
                    "AS registrydate1, ISNULL(CONVERT(VARCHAR, a.registrydate, 100), N'') AS registrydate2, ISNULL(CONVERT(VARCHAR, a.registrydate, 108), " +
                    "N'') AS registrydate3, DATENAME(m, a.dischdate) AS DischargeMonth, DAY(a.dischdate) AS DischargeDay, YEAR(a.dischdate) " +
                    "AS DischargeYear, a.dischargedate, a.dischdate, ISNULL(CONVERT(VARCHAR, a.dischdate, 110), N'') AS dischdate1, " +
                    "ISNULL(CONVERT(VARCHAR, a.dischdate, 100), N'') AS dischdate2, ISNULL(CONVERT(VARCHAR, a.dischdate, 108), N'') AS dischdate3, " +
                    "a.PackageCode, a.TrancheNo, a.filtercardno, CONVERT(VARCHAR, a.deathDate, 110) AS deathdate1, CONVERT(VARCHAR, a.deathDate, 100) " +
                    "AS deathdate2, CONVERT(VARCHAR, a.deathDate, 108) AS deathdate3, a.PK_TRXNO, a.referredfrom, ISNULL(CONVERT(VARCHAR, " +
                    "a.referredTo), N'') AS referredTo, a.impression, a.FK_mscDispositions, a.FK_mscPHICMemberships, a.AccommodationType, " +
                    "a.FK_mscPHICEntities, a.FK_mscPHICPackages, CASE WHEN SUBSTRING(CONVERT(VARCHAR, a.dischdate, 100), 13, 1) " +
                    "<> 1 THEN '0' ELSE '1' END AS dischdate4, a.appldate, a.applno, a.processtype, a.processdate, a.processby, a.fileddate, a.filedby, " +
                    "a.transmitdate, a.PHICTYPE, a.fullname, CASE WHEN SUBSTRING(CONVERT(VARCHAR, a.registrydate, 100), 13, 1) " +
                    "<> 1 THEN '0' ELSE '1' END AS registrydate4, a.registryno, a.finaldxcode, a.finaldx, a.Membership, a.ServiceType, a.gender, a.birthdate, " +
                    "a.payment, a.phicno, a.PhicEntities, a.PhicMembership, a.referredFromHCI, a.referredFromHCICode, a.referredFromHCIAddress, " +
                    "a.referredToHCI, a.referredToHCICode, a.referredToHCIAddress, a.pDisposition, a.referralReason, a.isHemodialysis, a.isPeritoneal, a.isLINAC, " +
                    "a.isCOBALT, a.isBloodTrans, a.isChemotherapy, a.isBrachytherapy, a.isDebridement, a.pHemoDates, a.pPeritonealDates, a.pLINACDates, " +
                    "a.pCOBALTDates, a.pTransfusionDates, a.pBrachyDates, a.pChemoDates, a.pDebridementDates, a.specialPackageCode, " +
                    "CONVERT(DATETIME, a.dischdate) AS dischdate, ISNULL ((SELECT impression FROM psPatRegisters AS b WHERE (PK_psPatRegisters = a.FK_psPatRegisters)), N'') AS adminDiagnosis, ISNULL " +
                    "((SELECT chiefcomplaint FROM psPatRegisters AS b WHERE (PK_psPatRegisters = a.FK_psPatRegisters)), N'') AS Chiefcomplaint, " +
                    "ISNULL((SELECT dischdiagnosis FROM psPatRegisters AS b WHERE (PK_psPatRegisters = a.FK_psPatRegisters)), N'') " +
                    "AS Dischargediagnosis, ISNULL ((SELECT FK_mscAdmResults FROM psPatRegisters AS c WHERE (PK_psPatRegisters = a.FK_psPatRegisters)), N'') AS admissionresult, " +
                    "ISNULL ((SELECT deathDate FROM psPatRegisters AS d WHERE (PK_psPatRegisters = a.FK_psPatRegisters)), N'') AS deathdate, z.UseCategoryForPhilHealthPackages AS Packagecateg, " +
                    "a.TBType, a.pLabNo, CONVERT(VARCHAR, CASE WHEN a.specialPackageCode <> 'M' THEN a.pLMPDate ELSE (SELECT x.pLMPMaternityDate FROM psPHICMaternityPackage x " +
                    " WHERE a.PK_TRXNO = x.FK_TRXNO_PHIC) END, 101) AS LMPdate, a.bedno, a.applassistby, a.FK_emdPatients FROM vwReportPHICLedgers_circ13 AS a LEFT OUTER JOIN " +
                    $"mscPHICPackages AS z ON a.FK_mscPHICPackages = z.PK_mscPHICPackages WHERE (a.FK_psPatRegisters = {id})";

                var settings = new HHMHBBSettings();
                var helper = new HHMHBBHelper(settings.GetConfigurationString("HHMHBB"));
                helper.Db_ConnOpen();
                data = helper.LoadSQL(sql, "PHICLedgers");

                var table = new DataTable();

                sql = "SELECT vwReportPatientProfile.pattrantype, vwReportPatientProfile.patientno, vwReportPatientProfile.patid, " +
                    "vwReportPatientProfile.fk_mscdispositions, vwReportPatientProfile.pk_pspersonaldata, vwReportPatientProfile.pk_pspatregisters, " +
                    "dbo.udf_GetAttendingDoctors(vwReportPatientProfile.pk_pspatregisters) AS Expr1, " +
                    "vwReportPatientProfile.PatientFirstName + ' ' + vwReportPatientProfile.SuffixName AS PatientFirstName, vwReportPatientProfile.SuffixName, " +
                    "vwReportPatientProfile.PatientLastName, vwReportPatientProfile.PatientMiddleName, vwReportPatientProfile.Gender, " +
                    "vwReportPatientProfile.CivilStatus, vwReportPatientProfile.BirthDate, CASE WHEN CONVERT(VARCHAR, age2) = 0 THEN CONVERT(VARCHAR, age) ELSE CONVERT(VARCHAR, age2) " +
                    "END AS age, vwReportPatientProfile.PHICNo, vwReportPatientProfile.PagIbigNo, " +
                    "vwReportPatientProfile.PassportNo, vwReportPatientProfile.Tin, vwReportPatientProfile.SSSNo, vwReportPatientProfile.fk_mscadmresults, " +
                    "(SELECT referralReason FROM psPatRegisters WHERE (PK_psPatRegisters = @pk_pspatregisters)) AS referralReason, vwReportPatientProfile.Barangay, vwReportPatientProfile.TownCity, " +
                    "vwReportPatientProfile.Province, vwReportPatientProfile.address, vwReportPatientProfile.MobileNo, vwReportPatientProfile.PhoneNo, " +
                    "vwReportPatientProfile.PhoneNo2, vwReportPatientProfile.Religion, vwReportPatientProfile.Occupation, vwReportPatientProfile.Service, " +
                    "vwReportPatientProfile.AllergiesDesc, vwReportPatientProfile.FK_psRooms, vwReportPatientProfile.PK_emdpatients, " +
                    "vwReportPatientProfile.GuarantorName, mscHospCaseTypes.description FROM vwReportPatientProfile INNER JOIN mscHospCaseTypes ON vwReportPatientProfile.FK_mscHospCaseTypes = mscHospCaseTypes.PK_mscHospCaseTypes " +
                    $"WHERE (vwReportPatientProfile.pk_pspatregisters = {id});";

                table = helper.LoadSQL(sql, "PatientInfo").Tables[0];
                data.Tables.Add(table);

                sql = "SELECT CASE @isCovid19 WHEN 0 THEN (SELECT FK_mscICD10Mstr AS code FROM psPatFinalDXDtls WHERE (FK_psPatRegisters = @pk_pspatregisters) AND (isFirstCaseRate = 1) " +
                    "UNION SELECT b.surcproccode AS code FROM psPHICSurgProc AS a INNER JOIN mscSurgProc AS b ON a.FK_mscSurgProc = b.PK_mscSurgProc WHERE (a.FK_psPatRegisters = @pk_pspatregisters) " +
                    "AND (a.isFirstCaseRate = 1)) ELSE (SELECT b.surcproccode AS code FROM psPHICSurgProc AS a INNER JOIN mscSurgProc AS b ON a.FK_mscSurgProc = b.PK_mscSurgProc WHERE " +
                    $"(a.FK_psPatRegisters = {id}) END AS caserate1";

                table = new DataTable();
                table = helper.LoadSQL(sql, "CaseRate1").Tables[0];
                data.Tables.Add(table);

                sql = "SELECT CASE WHEN @isCovid19 = 0 THEN (SELECT FK_mscICD10Mstr AS code FROM psPatFinalDXDtls WHERE ( FK_psPatRegisters = @pk_pspatregisters )  AND ( isSecondCaseRate = 1 ) UNION " +
                    $"SELECT b.surcproccode AS code FROM psPHICSurgProc AS a INNER JOIN mscSurgProc AS b ON a.FK_mscSurgProc = b.PK_mscSurgProc WHERE ( a.FK_psPatRegisters = {id} ) AND " +
                    "( a.isSecondCaseRate = 1 ) ) ELSE '' END AS caserate2;";

                table = new DataTable();
                table = helper.LoadSQL(sql, "CaseRate2").Tables[0];
                data.Tables.Add(table);

                sql = "SELECT ISNULL( CONVERT ( VARCHAR, a.checkupdate1, 110 ), '' ) AS checkupdate1, ISNULL( CONVERT ( VARCHAR, a.checkupdate2, 110 ), '' ) AS checkupdate2, " +
                    "ISNULL( CONVERT ( VARCHAR, a.checkupdate3, 110 ), '' ) AS checkupdate3, ISNULL( CONVERT ( VARCHAR, a.checkupdate4, 110 ), '' ) AS checkupdate4, " +
                    "ISNULL( CONVERT ( VARCHAR, a.pLMPMaternityDate, 110 ), '' ) AS LMPMaternityDate FROM psPHICMaternityPackage AS a INNER JOIN psPHICLedgers AS b ON a.FK_TRXNO_PHIC = b.PK_TRXNO " +
                    $"WHERE ( b.FK_psPatRegisters = {id} );";

                table = new DataTable();
                table = helper.LoadSQL(sql, "PHICMaternityPackage").Tables[0];
                data.Tables.Add(table);

                sql = "SELECT pEssential, pHearing, pScreening, dryingNewborn, earlySkin, cordClamping, prophylaxis, nonSeparation, weighingNewborn, vitaminK, BCG, hepatitisB " +
                    $"FROM psPHICNewbornCarePackage a INNER JOIN psPHICLedgers b ON a.FK_TRXNO_PHIC = b.PK_TRXNO WHERE b.FK_psPatRegisters = {id};";

                table = new DataTable();
                table = helper.LoadSQL(sql, "psPHICNewbornCarePackage").Tables[0];
                data.Tables.Add(table);

                sql = "SELECT PK_psPHICApplCF1, tstamp, FK_psPHICAppl, PatientDepID, MemberPIN, MemberLastName, MemberFirstName, MemberMiddleName, MemberSuffixName, MemberBirthDate, " +
                    "MemberGender, memberemail, MemberStreet, MemberBarangay, MemberTownCity, MemberProvince, MemberZipCode, MemberPhone, Membertype, PatientIs, IsMember, IsDependent, " +
                    "EmployerPEN, EmployerName, EmployerStreet, EmployerTownCity, EmployerProvince, EmployerZipCode, EmployerPhone, FK_emdPatients, FK_psPatRegisters, MemberMobileNo, " +
                    "dependentId, cf1depid, outrdepid, MemberBirthDate2, consentDate, consentType, relationtoPatient, othRelation, reasonForSigning, othReason, thumbMark, IsDelete, cancelflag " +
                    "FROM (SELECT a.PK_psPHICApplCF1, a.tstamp, a.FK_psPHICAppl, CASE WHEN len(a.PatientDepID) > 12 OR a.PatientDepID = '' THEN '' " +
                    "ELSE SUBSTRING(a.PatientDepID, 1, 2) + '-' + SUBSTRING(a.PatientDepID, 3, 9) + '-' + RIGHT(a.PatientDepID, 1) END AS PatientDepID, " +
                    "CASE WHEN len(a.MemberPIN) > 12 OR a.MemberPIN = '' THEN '' ELSE SUBSTRING(a.MemberPIN, 1, 2) + '-' + SUBSTRING(a.MemberPIN, 3, 9) + '-' + RIGHT(a.MemberPIN, 1) END AS MemberPIN, " +
                    "a.MemberLastName, a.MemberFirstName, a.MemberMiddleName, a.MemberSuffixName, a.MemberBirthDate, a.MemberGender, a.memberemail, a.MemberStreet, a.MemberBarangay, " +
                    "a.MemberTownCity, a.MemberProvince, a.MemberZipCode, a.MemberPhone, CASE WHEN a.PatientIs = 'M' THEN 1 ELSE 0 END AS Membertype, a.PatientIs, a.IsMember, a.IsDependent, a.EmployerPEN, " +
                    "a.EmployerName, a.EmployerStreet, a.EmployerTownCity, a.EmployerProvince, a.EmployerZipCode, a.EmployerPhone, a.FK_emdPatients, a.FK_psPatRegisters, a.MemberMobileNo, b.dependentId, CASE ISNULL(a.PatientDepID, '') " +
                    "WHEN '' THEN '' ELSE a.PatientDepID END AS cf1depid, CASE ISNULL(b.dependentId, '') WHEN '' THEN '' ELSE b.dependentId END AS outrdepid, ISNULL(CONVERT(VARCHAR, a.MemberBirthDate, 101) " +
                    "+ ' ' + REPLACE(REPLACE(RIGHT(CONVERT(VARCHAR, a.MemberBirthDate, 109), 14), ' ', 0), ':000', ' '), SPACE(22)) AS MemberBirthDate2, ISNULL(CONVERT(VARCHAR, b.consentDate, 101) + ' ' + " +
                    "REPLACE(REPLACE(RIGHT(CONVERT(VARCHAR, b.consentDate, 109), 14), ' ', 0), ':000', ' '), SPACE(22)) AS consentDate, b.consentType, b.relationtoPatient, b.othRelation, " +
                    "b.reasonForSigning, b.othReason, b.thumbMark, ISNULL(b.IsDelete, 0) AS IsDelete, ISNULL(b.cancelflag, 0) AS cancelflag FROM psPHICApplCF1 AS a LEFT OUTER JOIN psPHICLedgers AS b " +
                    $"ON a.FK_psPatRegisters = b.FK_psPatRegisters) AS a_1 WHERE (FK_psPatRegisters = {id}) AND (IsDelete = 0) AND (cancelflag <> 1);";

                table = new DataTable();
                table = helper.LoadSQL(sql, "psPHICApplCF1").Tables[0];
                data.Tables.Add(table);

                sql = $"SELECT a.orderDate, a.remarks FROM psPHICCF4DctrOrder a WHERE (a.FK_psPatRegisters = {id}) and isHide=0";

                table = new DataTable();
                table = helper.LoadSQL(sql, "psPHICCF4DctrOrder").Tables[0];
                data.Tables.Add(table);

                sql = "SELECT * FROM SELECT 1 AS Covid, CASE WHEN isCOVID19 = 1 THEN chiefcomplaint END AS chiefcomplaint, CASE WHEN isCOVID19 = 1 THEN impression END AS impression, " +
                    "CASE WHEN isCOVID19 = 1 THEN dischdiagnosis END AS dischdiagnosis FROM psPatRegisters WHERE PK_psPatRegisters = @pk_pspatregisters AND isCOVID19 = 1 UNION ALL " +
                    "SELECT 0 AS Covid, CASE WHEN isCOVID19 = 1 THEN ( SELECT chiefcomplaint FROM psPHICCF4 WHERE FK_psPatRegisters = @pk_pspatregisters AND isCOVID19 = 0 ) END AS chiefcomplaint, " +
                    "CASE WHEN isCOVID19 = 1 THEN ( SELECT admdiagnosis FROM psPHICCF4 WHERE FK_psPatRegisters = @pk_pspatregisters AND isCOVID19 = 0 ) END AS impression, " +
                    "CASE WHEN isCOVID19 = 1 THEN ( SELECT dischdiagnosis FROM psPHICCF4 WHERE FK_psPatRegisters = @pk_pspatregisters AND isCOVID19 = 0 ) END AS dischdiagnosis " +
                    "FROM psPatRegisters WHERE PK_psPatRegisters = @pk_pspatregisters AND isCOVID19 = 1 UNION ALL SELECT 0 AS Covid, CASE WHEN isCOVID19 = 0 THEN chiefcomplaint END AS chiefcomplaint, " +
                    "CASE WHEN isCOVID19 = 0 THEN impression END AS impression, CASE WHEN isCOVID19 = 0 THEN dischdiagnosis END AS dischdiagnosis FROM psPatRegisters " +
                    $"WHERE PK_psPatRegisters = {id} )  AS X;";

                table = new DataTable();
                table = helper.LoadSQL(sql, "Diagnosis").Tables[0];
                data.Tables.Add(table);

                helper.Db_ConnClose();
                return data;
            }
            catch (Exception ex)
            {
                logSource.Error.Write(FormattedMessageBuilder.Formatted("An erro occured while executing the request. {Message} - {sql}", ex.Message, sql));
                return data;
            }
        }
    }
}
