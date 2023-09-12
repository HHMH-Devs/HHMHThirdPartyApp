using PostSharp.Patterns.Diagnostics;
using System;
using System.Data;
using ThirdPartyAppV2.Common.DBConnections.DB;
using ThirdPartyAppV2.Common.DBConnections.Helper;

namespace ThirdPartyAppV2.Common.Modules.DischargeInstruction
{
    public class DischInstruction
    {
        private readonly LogSource logSource = LogSource.Get();

        public DataSet LoadDischargeInstruction(int id, string startDate, string endDate)
        {
            var data = new DataSet();
            var sql = "SELECT " +
                "a.PK_psPatDischInstruction, a.tstamp, a.FK_psPatRegisters, a.FK_emdPatients, a.clinicalpharmaonduty, a.checkby, a.checktime, a.diet, " +
                "a.medcareinstruct, a.genreminders, a.diaglabtesttoprepfor, a.activityrelatedinstruct, a.attendingdctr, a.nurseonduty, " +
                "a.dischinstrucreceivedby " +
                "FROM psPatDischInstruction AS a INNER JOIN " +
                "psPatRegisters AS b ON a.FK_emdPatients = b.FK_emdPatients " +
                $"WHERE (a.FK_emdPatients = {id}) AND (b.registrydate BETWEEN '{startDate}' AND '{endDate}')";
            try
            {
                var dischInsId = 0;
                var settings = new HHMHBBSettings();
                var helper = new HHMHBBHelper(settings.GetConfigurationString("HHMHBB"));
                helper.Db_ConnOpen();
                data = helper.LoadSQL(sql, "psPatDischInstruction");

                foreach (DataRow row in data.Tables[0].Rows)
                {
                    dischInsId = (int)row["PK_psPatDischInstruction"];
                }

                var table = new DataTable();
                sql = "SELECT " +
                    "PK_psPatDischInstructionAppMeds, " +
                    "tstamp, FK_psPatDischInstruction, " +
                    "meddescription, methodofadministration, " +
                    "morning, afternoon, tevening, " +
                    "othinstructions, checkby, purpose, (select dbo.udf_GetGenericName(PK_iwItems) from iwItems WHERE itemdesc = meddescription) as ItemDesc " +
                    $"FROM psPatDischInstructionAppMeds WHERE (FK_psPatDischInstruction = {dischInsId})";

                table = helper.LoadSQL(sql, "psPatDischInstructionAppMeds").Tables[0];
                data.Tables.Add(table);

                sql = "SELECT PK_psPatDischIntructionCheckUp, tstamp, FK_psPatDischInstruction, " +
                    "doctorname, checkupdate, venuesched, checkuptime, checkuptime2 " +
                    "FROM psPatDischInstructionCheckUp " +
                    $"WHERE (FK_psPatDischInstruction = {dischInsId})";

                table = new DataTable();
                table = helper.LoadSQL(sql, "psPatDischInstructionCheckUp").Tables[0];
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