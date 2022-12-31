namespace Editor.Debug
{
    public static class Log
    {
        private static bool _showInfoLogs = true;

        public static void Info(object message)
        {
            if (_showInfoLogs) UnityEngine.Debug.Log($"<color=turquoise>{message}</color>");
        }

        public static void Info(object message, bool showInfoLog)
        {
            if (showInfoLog) UnityEngine.Debug.Log($"<color=turquoise>{message}</color>");
        }

        public static void Error(object message) => UnityEngine.Debug.Log($"<color=red>{message}</color>");
        public static void Warning(object message) => UnityEngine.Debug.Log($"<color=yellow>{message}</color>");

        public static void ShowInfoLogs() => _showInfoLogs = true;
        public static void HideInfoLogs() => _showInfoLogs = false;
    }
}