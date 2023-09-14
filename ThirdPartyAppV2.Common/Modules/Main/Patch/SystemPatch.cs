using System.Collections.Generic;
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

            sql = "CREATE TABLE `historysheet` ( " +
                "`ID` INT NOT NULL, " +
                "`HypertensionMeds` VARCHAR ( 255 ) DEFAULT NULL, " +
                "`DiabetesMeds` VARCHAR ( 255 ) DEFAULT NULL, " +
                "`AsthmaMeds` VARCHAR ( 255 ) DEFAULT NULL, " +
                "`Otherppmh` VARCHAR ( 255 ) DEFAULT NULL, " +
                "`OtherppmhMeds` VARCHAR ( 255 ) DEFAULT NULL, " +
                "`Smoking` VARCHAR ( 255 ) DEFAULT NULL, " +
                "`Alchohol` VARCHAR ( 255 ) DEFAULT NULL, " +
                "`Psh_Others` VARCHAR ( 255 ) DEFAULT NULL, " +
                "`IsPedia` TINYINT ( 1 ) NOT NULL DEFAULT '0', " +
                "`Feeding` VARCHAR ( 255 ) DEFAULT NULL, " +
                "`Pedia_Others` VARCHAR ( 255 ) DEFAULT NULL, " +
                "`BCG` TINYINT ( 1 ) NOT NULL DEFAULT '0', " +
                "`DtPolio` TINYINT ( 1 ) NOT NULL DEFAULT '0', " +
                "`Hepa` TINYINT ( 1 ) NOT NULL DEFAULT '0', " +
                "`Measles` TINYINT ( 1 ) NOT NULL DEFAULT '0', " +
                "`Ih_Others` VARCHAR ( 255 ) DEFAULT NULL, " +
                "`Food` VARCHAR ( 255 ) DEFAULT NULL, " +
                "`Drugs` VARCHAR ( 255 ) DEFAULT NULL, " +
                "`Allergies_Others` VARCHAR ( 255 ) DEFAULT NULL, " +
                "`EssentiallyNormal` TINYINT ( 1 ) NOT NULL DEFAULT '0', " +
                "`EnlargePostale` TINYINT ( 1 ) NOT NULL DEFAULT '0', " +
                "`Mass` TINYINT ( 1 ) NOT NULL DEFAULT '0', " +
                "`Hemoriods` TINYINT ( 1 ) NOT NULL DEFAULT '0', " +
                "`Plus` TINYINT ( 1 ) NOT NULL DEFAULT '0', " +
                "`Digi_Others` VARCHAR ( 255 ) DEFAULT NULL, " +
                "PRIMARY KEY ( `ID` ) " +
                ") ENGINE = INNODB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci;";

            if (!PatchFunctions.IsTableExists("historysheet"))
            {
                PatchFunctions.RunCommand(sql);
            }
        }

        public static void AddSettingsVariables(Dictionary<string, object> keyValues)
        {
            if (PatchFunctions.CountSettingsData() <= 0)
            {
                PatchFunctions.AddSettingsData("appsettings", keyValues);
            }
        }
    }
}
