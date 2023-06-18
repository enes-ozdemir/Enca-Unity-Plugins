namespace Enca.Debug
{
    public class Logger
    {
        private bool _showInfoLogs;
        private readonly string _className;

        public Logger(string className, bool showLogs = true)
        {
            _className = className;
            _showInfoLogs = showLogs;
        }

        public void Info(object message)
        {
            if (_showInfoLogs)
                UnityEngine.Debug.Log($"<color=turquoise>{_className}: {message}</color>");
        }

        public void Error(object message)
        {
            UnityEngine.Debug.Log($"<color=red>{_className}: {message}</color>");
        }

        public void Warning(object message)
        {
            UnityEngine.Debug.Log($"<color=yellow>{_className}: {message}</color>");
        }

        public void EnableInfoLogs() => _showInfoLogs = true;
        public void DisableInfoLogs() => _showInfoLogs = false;
    }
}