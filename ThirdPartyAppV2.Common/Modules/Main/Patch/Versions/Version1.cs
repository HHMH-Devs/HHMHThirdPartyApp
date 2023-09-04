using PostSharp.Patterns.Diagnostics;
using System;

namespace ThirdPartyAppV2.Common.Modules.Main.Patch.Versions
{
    [Log]
    public static class Version1
    {
        readonly static string Db_AllowedVersion = "1.0.0.1";
        readonly static string Db_LatestVersion = "1.0.0.2";
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

                UpdateTblDischargeProcess();
                UpdateTblErToAdmission();

                PatchFunctions.UpdateDbVesion(Db_LatestVersion);
                logSource.Info.Write(FormattedMessageBuilder.Formatted("System patch done successfully. {Version}", Db_LatestVersion));
            }
            catch (Exception ex)
            {
                logSource.Error.Write(FormattedMessageBuilder.Formatted("An error occured. {Message}", ex.Message));
            }
        }

        private static void UpdateTblDischargeProcess()
        {
            var sql = "ALTER TABLE `thirdpartyappdb`.`dischargeprocess` " +
                "ADD COLUMN `DateEncoded` datetime NULL AFTER `PatExitEndDateTime`;";

            PatchFunctions.RunCommand(sql);

        }
        private static void UpdateTblErToAdmission()
        {
            var sql = "ALTER TABLE `thirdpartyappdb`.`ertoadmission` " +
                "ADD COLUMN `DateEncoded` datetime NULL AFTER `TransToRoomEndDateTime`;";

            PatchFunctions.RunCommand(sql);
        }
    }
}
