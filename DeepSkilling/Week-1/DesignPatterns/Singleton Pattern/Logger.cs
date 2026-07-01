using System;
using System.IO;

/// <summary>
/// Thread-Safe Singleton Logger using Lazy<T>
/// This implementation ensures thread safety and lazy initialization
/// </summary>
public class Logger
{
    // Lazy initialization ensures thread-safety without explicit locking
    private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());

    // Private constructor to prevent instantiation
    private Logger()
    {
        Console.WriteLine("[Logger] Instance created at: " + DateTime.Now);
        InitializeLogFile();
    }

    // Public property to access the single instance
    public static Logger Instance => _instance.Value;

    private string _logFilePath;

    private void InitializeLogFile()
    {
        _logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "application.log");
        Console.WriteLine("[Logger] Log file path: " + _logFilePath);
    }

    /// <summary>
    /// Logs a message to console and file
    /// </summary>
    public void Log(string message)
    {
        string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
        Console.WriteLine(logEntry);
        
        try
        {
            File.AppendAllText(_logFilePath, logEntry + Environment.NewLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine("[Logger Error] Could not write to file: " + ex.Message);
        }
    }

    /// <summary>
    /// Logs an error message
    /// </summary>
    public void LogError(string message)
    {
        Log($"ERROR: {message}");
    }

    /// <summary>
    /// Logs a warning message
    /// </summary>
    public void LogWarning(string message)
    {
        Log($"WARNING: {message}");
    }

    /// <summary>
    /// Logs an info message
    /// </summary>
    public void LogInfo(string message)
    {
        Log($"INFO: {message}");
    }
}
