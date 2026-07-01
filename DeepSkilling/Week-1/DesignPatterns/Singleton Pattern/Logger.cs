// Singleton Pattern - Logger Class
// This is a simple Singleton class that ensures only one instance exists

public class Logger
{
    // Static variable to hold the single instance
    private static Logger instance;

    // Private constructor - prevents creating new objects with 'new'
    private Logger()
    {
        Console.WriteLine("Logger instance created");
    }

    // Static method to get the instance
    public static Logger GetInstance()
    {
        if (instance == null)
        {
            instance = new Logger();
        }
        return instance;
    }

    // Method to log messages
    public void Log(string message)
    {
        Console.WriteLine("LOG: " + message);
    }
}
