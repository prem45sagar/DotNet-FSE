using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Demonstration of Singleton Pattern
/// Shows that the same instance is shared across multiple references
/// and is thread-safe
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("========== SINGLETON PATTERN DEMONSTRATION ==========\n");

        // Test 1: Basic Singleton Usage
        Console.WriteLine("--- Test 1: Basic Singleton Usage ---");
        Logger logger1 = Logger.Instance;
        Logger logger2 = Logger.Instance;

        logger1.Log("Message from logger1");
        logger2.Log("Message from logger2");

        // Verify that both references point to the same object
        Console.WriteLine($"logger1 == logger2: {object.ReferenceEquals(logger1, logger2)}");
        Console.WriteLine($"logger1.GetHashCode() == logger2.GetHashCode(): {logger1.GetHashCode() == logger2.GetHashCode()}\n");

        // Test 2: Different logging levels
        Console.WriteLine("--- Test 2: Different Logging Levels ---");
        Logger logger3 = Logger.Instance;
        logger3.LogInfo("Application started");
        logger3.LogWarning("This is a warning message");
        logger3.LogError("This is an error message");
        Console.WriteLine();

        // Test 3: Thread Safety
        Console.WriteLine("--- Test 3: Thread Safety ---");
        Console.WriteLine("Creating Logger instance from multiple threads...\n");
        
        Logger[] loggers = new Logger[5];
        Task[] tasks = new Task[5];

        for (int i = 0; i < 5; i++)
        {
            int threadNumber = i + 1;
            tasks[i] = Task.Run(() =>
            {
                loggers[threadNumber - 1] = Logger.Instance;
                Console.WriteLine($"Thread {threadNumber} obtained Logger instance");
            });
        }

        Task.WaitAll(tasks);

        // Verify all threads got the same instance
        Console.WriteLine($"\nAll loggers are the same instance: {AreAllSame(loggers)}\n");

        // Test 4: Demonstrating persistence
        Console.WriteLine("--- Test 4: Logger State Persistence ---");
        Logger logger4 = Logger.Instance;
        logger4.LogInfo("Persistent state test");
        logger4.LogWarning("This data persists");
        Console.WriteLine();

        Console.WriteLine("========== END OF DEMONSTRATION ==========");
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    /// <summary>
    /// Helper method to verify all logger instances are the same
    /// </summary>
    static bool AreAllSame(Logger[] loggers)
    {
        for (int i = 1; i < loggers.Length; i++)
        {
            if (!object.ReferenceEquals(loggers[0], loggers[i]))
            {
                return false;
            }
        }
        return true;
    }
}
