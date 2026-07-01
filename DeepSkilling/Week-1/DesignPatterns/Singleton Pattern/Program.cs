// Singleton Pattern - Program Class
// Demonstrates that the same Logger instance is used everywhere

class Program
{
    static void Main(string[] args)
    {
        // Get first Logger instance
        Logger logger1 = Logger.GetInstance();

        // Get second Logger instance  
        Logger logger2 = Logger.GetInstance();

        // Log messages
        logger1.Log("Message from logger1");
        logger2.Log("Message from logger2");

        // Check if both references point to the same object
        if (logger1 == logger2)
        {
            Console.WriteLine("Both logger1 and logger2 are the SAME object");
        }
        else
        {
            Console.WriteLine("logger1 and logger2 are DIFFERENT objects");
        }
    }
}
