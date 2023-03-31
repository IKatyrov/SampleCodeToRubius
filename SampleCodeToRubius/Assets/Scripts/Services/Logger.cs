using JetBrains.Annotations;

namespace Services
{
    public sealed class Logger : ILogger
    {
#if UNITY_EDITOR
        public void PrintLog([NotNull] string message)
        {
            UnityEngine.Debug.Log($"{message}. Время: {System.DateTime.Now}");
        }

        public void PrintWarning([NotNull] string message)
        {
            UnityEngine.Debug.LogWarning($"{message}. Время: {System.DateTime.Now}");
        }

        public void PrintError([NotNull] string message)
        {
            UnityEngine.Debug.LogError($"{message}. Время: {System.DateTime.Now}");
        }
#endif
    }
}