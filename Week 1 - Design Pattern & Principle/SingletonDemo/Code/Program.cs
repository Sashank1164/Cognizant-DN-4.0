using System;

namespace SingletonDemo
{
    class Program
    {
        static void Main()
        {
            Logger logger1 = Logger.Instance;
            logger1.LogInfo("Application started.");

            Logger logger2 = Logger.Instance;
            logger2.LogWarning("This is a warning message.");

            Logger logger3 = Logger.Instance;
            logger3.LogError("This is an error message.");

            Console.WriteLine(logger1.InstanceDetails);
            Console.WriteLine(logger2.InstanceDetails);
            Console.WriteLine(logger3.InstanceDetails);
        }
        static void DemonstrateBasicSingleton()
{
    Console.WriteLine("=== Testing Singleton Pattern Implementation ===");
    Console.WriteLine("\nTest 1: Verifying Singleton Behavior");
    Console.WriteLine(new string('-', 40));

    var logger1 = Logger.Instance;
    var logger2 = Logger.Instance;
    var logger3 = Logger.Instance;

    Console.WriteLine("First instance: " + logger1.InstanceDetails);
    Console.WriteLine("Second instance: " + logger2.InstanceDetails);
    Console.WriteLine("Third instance: " + logger3.InstanceDetails);

    if (logger1 == logger2 && logger2 == logger3)
    {
        Console.WriteLine("✓ SUCCESS: All instances are the same object\n");
    }
    else
    {
        Console.WriteLine("✗ FAIL: Instances are different\n");
    }

    Console.WriteLine("Hash Code Verification:");
    Console.WriteLine($"logger1 hash: {logger1.GetHashCode()}");
    Console.WriteLine($"logger2 hash: {logger2.GetHashCode()}");
    Console.WriteLine($"logger3 hash: {logger3.GetHashCode()}");
}
static void DemonstrateAdvancedSingleton()
{
    Console.WriteLine("DEMO 3: Thread Safety Test\n");

    void LogFromThread(int threadNum)
    {
        var logger = AdvancedLogger.Instance;
        logger.AdvancedLog($"Message from Thread {threadNum} (Advanced)");
    }

    var threads = new List<Thread>();
    for (int i = 1; i <= 4; i++)
    {
        int copy = i;
        threads.Add(new Thread(() => LogFromThread(copy)));
    }

    threads.ForEach(t => t.Start());
    threads.ForEach(t => t.Join());

    Console.WriteLine("All threads completed. Check hash codes above to verify singleton behavior.\n");
}


    }
}
