using System;
using SingletonDemo;

public static class SingletonTest
{
    public static void Run()
    {
        Console.WriteLine("\n=== Testing Singleton Pattern Implementation ===\n");

        TestSingletonBehavior();

        Console.WriteLine("\n" + new string('=', 50) + "\n");

        TestLoggerFunctionality();

        Console.WriteLine("\n" + new string('=', 50) + "\n");

        TestFromDifferentMethods();
    }

    private static void TestSingletonBehavior()
    {
        Console.WriteLine("Test 1: Verifying Singleton Behavior");
        Console.WriteLine(new string('-', 40));

        var logger1 = Logger.Instance;
        Console.WriteLine($"First instance: {logger1.InstanceDetails}");

        var logger2 = Logger.Instance;
        Console.WriteLine($"Second instance: {logger2.InstanceDetails}");

        var logger3 = Logger.Instance;
        Console.WriteLine($"Third instance: {logger3.InstanceDetails}");

        Console.WriteLine(logger1 == logger2 && logger2 == logger3
            ? "✓ SUCCESS: All instances are the same object"
            : "✗ FAILURE: Instances are different objects");

        Console.WriteLine("\nHash Code Verification:");
        Console.WriteLine($"logger1 hash: {logger1.GetHashCode()}");
        Console.WriteLine($"logger2 hash: {logger2.GetHashCode()}");
        Console.WriteLine($"logger3 hash: {logger3.GetHashCode()}");
    }

    private static void TestLoggerFunctionality()
    {
        Console.WriteLine("Test 2: Testing Logger Functionality");
        Console.WriteLine(new string('-', 40));

        var logger = Logger.Instance;

        logger.Log("Application started successfully");
        logger.LogInfo("User login attempt");
        logger.LogWarning("Memory usage is high");
        logger.LogError("Database connection failed");
        logger.Log("Application shutting down");
    }

    private static void TestFromDifferentMethods()
    {
        Console.WriteLine("Test 3: Testing from Different Methods");
        Console.WriteLine(new string('-', 40));

        var logger1 = GetLoggerFromMethod1();
        var logger2 = GetLoggerFromMethod2();

        Console.WriteLine($"Logger from method 1: {logger1.InstanceDetails}");
        Console.WriteLine($"Logger from method 2: {logger2.InstanceDetails}");

        Console.WriteLine(logger1 == logger2
            ? "✓ SUCCESS: Same instance returned from different methods"
            : "✗ FAILURE: Different instances returned from different methods");

        logger1.Log("Message from method 1 context");
        logger2.Log("Message from method 2 context");
    }

    private static Logger GetLoggerFromMethod1()
    {
        Console.WriteLine("Getting logger instance from method 1...");
        return Logger.Instance;
    }

    private static Logger GetLoggerFromMethod2()
    {
        Console.WriteLine("Getting logger instance from method 2...");
        return Logger.Instance;
    }
}
