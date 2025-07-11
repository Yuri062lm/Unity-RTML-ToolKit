using UnityEngine;

namespace RTMLToolKit
{
    /// <summary>
    /// Basit, platform-bağımsız loglama sınıfı.
    /// </summary>
    public static class Logger
    {
        public static void Log(object message)
        {
            Debug.Log(message);
        }

        public static void LogWarning(object message)
        {
            Debug.LogWarning(message);
        }

        public static void LogError(object message)
        {
            Debug.LogError(message);
        }
    }
}
