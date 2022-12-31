namespace Editor.Debug
{
    public static class Analytics
    {
        public static void Log(object message) =>
            UnityEngine.Debug.Log($"<color=lightblue><b><size=13>Analytics: </size></b></color>{message}");
    }
}