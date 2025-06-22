using System;

namespace SingletonDemo;

/// <summary>
/// Bill‑Pugh / static‑holder pattern – thread‑safe with zero locks.
/// </summary>
public sealed class AdvancedLogger : ICloneable
{
    private AdvancedLogger()
    {
        Console.WriteLine($"AdvancedLogger instance created at: {GetCurrentTimestamp()}");
    }

    // Nested static class guarantees lazy, thread-safe init
    private static class SingletonHolder
    {
        internal static readonly AdvancedLogger Instance = new();
    }

    public static AdvancedLogger Instance => SingletonHolder.Instance;

    // === Existing logging methods ===
    public void Log(string message)        => Console.WriteLine($"[{GetCurrentTimestamp()}] ADVANCED LOG: {message}");
    public void LogError(string message)   => Console.Error.WriteLine($"[{GetCurrentTimestamp()}] ADVANCED ERROR: {message}");
    public void LogWarning(string message) => Console.WriteLine($"[{GetCurrentTimestamp()}] ADVANCED WARNING: {message}");
    public void LogInfo(string message)    => Console.WriteLine($"[{GetCurrentTimestamp()}] ADVANCED INFO: {message}");

    // === NEW method used in testing ===
    public void AdvancedLog(string message)
    {
        Console.WriteLine($"[{GetCurrentTimestamp()}] ADVANCED LOG: {message} - Hash: {GetHashCode()}");
    }

    public string InstanceDetails => $"AdvancedLogger instance: {GetHashCode()}";

    private static string GetCurrentTimestamp() => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

    // Hard block against cloning
    public object Clone() => throw new NotSupportedException("Cannot clone singleton instance");
}
