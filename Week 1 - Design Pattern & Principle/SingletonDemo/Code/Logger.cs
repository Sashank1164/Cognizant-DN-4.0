using System;

namespace SingletonDemo
{
    /// <summary>
    /// Lazy singleton using double‑checked locking
    /// </summary>
    public sealed class Logger
    {
        private static Logger? _instance;
        private static readonly object _lock = new();

        private Logger()
        {
            Console.WriteLine($"Logger instance created at: {GetCurrentTimestamp()}");
        }

        public static Logger Instance
        {
            get
            {
                if (_instance is null)
                {
                    lock (_lock)
                    {
                        _instance ??= new Logger();
                    }
                }
                return _instance;
            }
        }

        public void Log(string message) => Console.WriteLine($"[{GetCurrentTimestamp()}] LOG: {message}");
        public void LogError(string message) => Console.Error.WriteLine($"[{GetCurrentTimestamp()}] ERROR: {message}");
        public void LogWarning(string message) => Console.WriteLine($"[{GetCurrentTimestamp()}] WARNING: {message}");
        public void LogInfo(string message) => Console.WriteLine($"[{GetCurrentTimestamp()}] INFO: {message}");

        public string InstanceDetails => $"Logger instance: {GetHashCode()}";

        private static string GetCurrentTimestamp() => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }
}
