using PostSharp.Patterns.Diagnostics;
using System;

namespace ThirdPartyAppV2.Common.Modules.Main.Patch.Versions
{
    [Log]
    public static class Version2
    {
        readonly static string Db_AllowedVersion = "1.0.0.2";
        readonly static string Db_LatestVersion = "1.0.0.3";
        private static readonly LogSource logSource = LogSource.Get();

        public static void PatchUp()
        {
            try
            {
                if (!PatchFunctions.IsPatchable(Db_AllowedVersion))
                {
                    logSource.Info.Write(FormattedMessageBuilder.Formatted("DbVesrion is updated {Db_LatestVersion}", Db_LatestVersion));
                    return;
                }

                AlterTblDischProc();
                AddNewColTblDischProc();
                DropColTblERToAdmission();
                AddNewColTblERToAdmission();

                PatchFunctions.UpdateDbVesion(Db_LatestVersion);
            }
            catch (Exception ex)
            {
                logSource.Error.Write(FormattedMessageBuilder.Formatted("An error occured. {Message}", ex.Message));
            }
        }

        private static void AlterTblDischProc()
        {
            var sql = "ALTER TABLE `thirdpartyappdb`.`dischargeprocess` " +
                "CHANGE COLUMN `BSStartDateTime` `IEStartDateTime` datetime NULL DEFAULT NULL AFTER `MDEndDateTime`, " +
                "CHANGE COLUMN `BSEndDateTime` `IEEndDateTime` datetime NULL DEFAULT NULL AFTER `IEStartDateTime`, " +
                "CHANGE COLUMN `BPStartDateTime` `BP2StartDateTime` datetime NULL DEFAULT NULL AFTER `BGEndDateTime`, " +
                "CHANGE COLUMN `BPEndDateTime` `BP2EndDateTime` datetime NULL DEFAULT NULL AFTER `BP2StartDateTime`;";

            PatchFunctions.RunCommand(sql);
        }

        private static void AddNewColTblDischProc()
        {
            var sql = "ALTER TABLE `thirdpartyappdb`.`dischargeprocess` " +
                "ADD COLUMN `BP1StartDateTime` datetime NULL AFTER `BGEndDateTime`," +
                "ADD COLUMN `BP1EndDateTime` datetime NULL AFTER `BP1StartDateTime`;";

            PatchFunctions.RunCommand(sql);
        }

        private static void DropColTblERToAdmission()
        {
            var sql = "ALTER TABLE `thirdpartyappdb`.`ertoadmission` " + 
                "DROP COLUMN `DToTStartDateTime`, " +
                "DROP COLUMN `DToTEndDateTime`, " +
                "DROP COLUMN `TriToRegStartDateTime`, " +
                "DROP COLUMN `TriToRegEndDateTime`; ";

            PatchFunctions.RunCommand(sql);
        }

        private static void AddNewColTblERToAdmission()
        {
            var sql = "ALTER TABLE `thirdpartyappdb`.`ertoadmission` " +
                "ADD COLUMN `APPStartDateTime` datetime NULL AFTER `DocOrderEndDateTime`, " +
                "ADD COLUMN `APPEndDateTime` datetime NULL AFTER `APPStartDateTime`, " +
                "ADD COLUMN `PHICStartDateTime` datetime NULL AFTER `APPEndDateTime`, " +
                "ADD COLUMN `PHICEndDateTime` datetime NULL AFTER `PHICStartDateTime`, " +
                "ADD COLUMN `RPStartDateTime` datetime NULL AFTER `PHICEndDateTime`, " +
                "ADD COLUMN `RPEndDateTime` datetime NULL AFTER `RPStartDateTime`, " +
                "ADD COLUMN `NCOStartDateTime` datetime NULL AFTER `RPDocEndDateTime`, " +
                "ADD COLUMN `NCOEndDateTime` datetime NULL AFTER `NCODocStartDateTime`;";

            PatchFunctions.RunCommand(sql);
        }
    }
}
