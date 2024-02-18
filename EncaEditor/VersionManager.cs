namespace Enca.SaveSystem
{
    public static class VersionManager
    {
        public static string CurrentVersion = "1.0";

        public static bool IsCompatible(string version)
        {
            return version == CurrentVersion;
        }
    }
}