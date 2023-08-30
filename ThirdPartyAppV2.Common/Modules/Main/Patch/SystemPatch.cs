using ThirdPartyAppV2.Common.Modules.Main.Patch.Versions;

namespace ThirdPartyAppV2.Common.Modules.Main.Patch
{
    public class SystemPatch
    {
        private readonly Version1 _version1;

        public SystemPatch()
        {
            _version1 = new Version1();
        }

        public void PatchSystem()
        {
            _version1.PatchUp();
        }
    }
}
