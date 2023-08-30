using PostSharp.Patterns.Diagnostics;
using System;

namespace ThirdPartyAppV2.Common.Modules.Main.Patch.Versions
{
    [Log]
    public class Version1
    {
        readonly string Db_AllowedVersion = "1.0.0.1";
        readonly string Db_LatestVersion = "1.0.0.2";
        private readonly PatchFunctions functions = new PatchFunctions();
        private readonly LogSource logSource = LogSource.Get();
        private int allExecuted = 0;

        public void PatchUp()
        {
            try
            {
                if (!functions.IsPatchable(Db_AllowedVersion))
                {
                    return;
                }
                UpdateTblDischargeProcess();
                UpdateTblErToAdmission();

                if (allExecuted > 0)
                {
                    functions.UpdateDbVesion(Db_LatestVersion);
                    logSource.Info.Write(FormattedMessageBuilder.Formatted("System patch done successfully. {Version}", Db_LatestVersion));
                }
                else
                {
                    logSource.Warning.Write(FormattedMessageBuilder.Formatted("System patch done with errors. {Version}", Db_LatestVersion));
                }
            }
            catch (Exception ex)
            {
                logSource.Error.Write(FormattedMessageBuilder.Formatted("An error occured. {Message}", ex.Message));
            }
        }

        private void UpdateTblDischargeProcess()
        {
            var sql = "ALTER TABLE `thirdpartyappdb`.`dischargeprocess` " +
                "ADD COLUMN `DateEncoded` datetime NULL AFTER `PatExitEndDateTime`;";

            var i = functions.RunCommand(sql);
            if (i > 0)
            {
                allExecuted = i;
            }
            else
            {
                allExecuted = 0;
            }

        }
        private void UpdateTblErToAdmission()
        {
            var sql = "ALTER TABLE `thirdpartyappdb`.`ertoadmission` " +
                "ADD COLUMN `DateEncoded` datetime NULL AFTER `TransToRoomEndDateTime`;";

            var i = functions.RunCommand(sql);
            if (i > 0)
            {
                allExecuted = i;
            }
            else
            {
                allExecuted = 0;
            }
        }
    }
}
