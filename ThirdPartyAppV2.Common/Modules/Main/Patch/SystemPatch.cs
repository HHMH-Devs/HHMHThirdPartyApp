using ThirdPartyAppV2.Common.Modules.Main.Patch.Versions;

namespace ThirdPartyAppV2.Common.Modules.Main.Patch
{
    public static class SystemPatch
    {
        public static void PatchSystem()
        {
            Version1.PatchUp();
            Version2.PatchUp();
        }

        public static void CreateTable()
        {
            var sql = "CREATE TABLE `thirdpartyappdb`.`ertoadmission`  " +
                "( `ID` int NOT NULL AUTO_INCREMENT, " +
                "`PatientName` varchar(255) NULL, " +
                "`RegToDocStartDateTime` datetime NULL, " +
                "`RegToDocEndDateTime` datetime NULL, " +
                "`DocOrderStartDateTime` datetime NULL, " +
                "`DocOrderEndDateTime` datetime NULL, " +
                "`APPStartDateTime` datetime NULL, " +
                "`APPEndDateTime` datetime NULL, " +
                "`PHICStartDateTime` datetime NULL, " +
                "`PHICEndDateTime` datetime NULL, " +
                "`RPStartDateTime` datetime NULL, " +
                "`RPEndDateTime` datetime NULL, " +
                "`NCOStartDateTime` datetime NULL, " +
                "`NCOEndDateTime` datetime NULL, " +
                "`ReadyToTransStartDateTime` datetime NULL, " +
                "`ReadyToTransEndDateTime` varchar(255) NULL, " +
                "`TransToRoomStartDateTime` datetime NULL, " +
                "`TransToRoomEndDateTime` datetime NULL, " +
                "`DateEncoded` datetime NULL, " +
                "PRIMARY KEY (`ID`) " +
                ");";
            if (!PatchFunctions.IsTableExists("ertoadmission"))
            {
                PatchFunctions.RunCommand(sql);
            }


            sql = "CREATE TABLE `thirdpartyappdb`.`dischargeprocess`  ( " +
                "`ID` int NOT NULL AUTO_INCREMENT, " +
                "`PatientName` varchar(255) NULL, " +
                "`MDStartDateTime` datetime NULL, " +
                "`MDEndDateTime` datetime NULL, " +
                "`IEStartDateTime` datetime NULL, " +
                "`IEEndDateTime` datetime NULL, " +
                "`BGStartDateTime` datetime NULL, " +
                "`BGEndDateTime` datetime NULL, " +
                "`BP1StartDateTime` datetime NULL, " +
                "`BP1EndDateTime` datetime NULL, " +
                "`BP2StartDateTime` datetime NULL, " +
                "`BP2EndDateTime` datetime NULL, " +
                "`DIDStartDateTime` datetime NULL, " +
                "`DIDEndDateTime` datetime NULL, " +
                "`PatExitStartDateTime` datetime NULL, " +
                "`PatExitEndDateTime` datetime NULL, " +
                "`DateEncoded` datetime NULL, " +
                "PRIMARY KEY (`ID`) " +
                ");";

            if (!PatchFunctions.IsTableExists("dischargeprocess"))
            {
                PatchFunctions.RunCommand(sql);
            }

            sql = "CREATE TABLE `thirdpartyappdb`.`appsettings`  ( " +
                "`ID` int NOT NULL AUTO_INCREMENT, " +
                "`Key` varchar(255) NULL, " +
                "`Value` varchar(255) NULL, " +
                "`Comment` varchar(255) NULL, " +
                "PRIMARY KEY (`ID`) " +
                ");";

            if (!PatchFunctions.IsTableExists("appsettings"))
            {
                PatchFunctions.RunCommand(sql);
            }

            sql = "CREATE TABLE `thirdpartyappdb`.`Untitled`  ( " +
                "`ID` int NOT NULL, " +
                "`HypertensionMeds` varchar(255) NULL, " +
                "`DiabetesMeds` varchar(255) NULL, " +
                "`AsthmaMeds` varchar(255) NULL, " +
                "`Otherppmh` varchar(255) NULL, " +
                "`OtherppmhMeds` varchar(255) NULL, " +
                "`Smoking` varchar(255) NULL, " +
                "`Alchohol` varchar(255) NULL, " +
                "`Psh_Others` varchar(255) NULL, " +
                "`IsPedia` tinyint(1) NOT NULL DEFAULT 0, " +
                "`Feeding` varchar(255) NULL, " +
                "`Pedia_Others` varchar(255) NULL, " +
                "`BCG` tinyint(1) NOT NULL DEFAULT 0, " +
                "`DtPolio` tinyint(1) NOT NULL DEFAULT 0, " +
                "`Hepa` tinyint(1) NOT NULL DEFAULT 0, " +
                "`Measles` tinyint(1) NOT NULL DEFAULT 0, " +
                "`Ih_Others` varchar(255) NULL, " +
                "`Food` varchar(255) NULL, " +
                "`Drugs` varchar(255) NULL, " +
                "`Allergies_Others` varchar(255) NULL, " +
                "`EssentiallyNormal` tinyint(1) NOT NULL DEFAULT 0, " +
                "`EnlargePostale` tinyint(1) NOT NULL DEFAULT 0, " +
                "`Mass` tinyint(1) NOT NULL DEFAULT 0, " +
                "`Hemoriods` tinyint(1) NOT NULL DEFAULT 0, " +
                "`Plus` tinyint(1) NOT NULL DEFAULT 0, " +
                "`Digi_Others` varchar(255) NULL, " +
                "PRIMARY KEY (`ID`) " +
                ");";

            if (!PatchFunctions.IsTableExists("appsettings"))
            {
                PatchFunctions.RunCommand(sql);
            }
        }
    }
}
