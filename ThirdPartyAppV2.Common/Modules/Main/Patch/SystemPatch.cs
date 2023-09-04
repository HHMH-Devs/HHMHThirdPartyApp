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
    }
}
