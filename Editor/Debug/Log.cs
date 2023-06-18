namespace Enca.Debug
{
    public static class Log
    {
        private static readonly Logger GlobalLogger = new("Global");

        public static void Info(object message) => GlobalLogger.Info(message);
        public static void Error(object message) => GlobalLogger.Error(message);
        public static void Warning(object message) => GlobalLogger.Warning(message);

        public static void EnableInfoLogs() => GlobalLogger.EnableInfoLogs();
        public static void DisableInfoLogs() => GlobalLogger.DisableInfoLogs();
    }
}