// Factory Method Pattern - Program Class
// Demonstrates creating different vehicle types using the factory method

class Program
{
    static void Main(string[] args)
    {
        // Create different vehicle types using the factory method
        IVehicle vehicle1 = VehicleFactory.CreateVehicle("car");
        IVehicle vehicle2 = VehicleFactory.CreateVehicle("bike");
        IVehicle vehicle3 = VehicleFactory.CreateVehicle("truck");

        // Use the created vehicles
        Console.WriteLine($"\nVehicle 1 Type: {vehicle1.GetVehicleType()}");
        vehicle1.Drive();

        Console.WriteLine($"\nVehicle 2 Type: {vehicle2.GetVehicleType()}");
        vehicle2.Drive();

        Console.WriteLine($"\nVehicle 3 Type: {vehicle3.GetVehicleType()}");
        vehicle3.Drive();

        // Demonstrate that the factory method properly encapsulates object creation
        Console.WriteLine("\n--- Factory Method Pattern Benefits ---");
        Console.WriteLine("1. Object creation logic is encapsulated");
        Console.WriteLine("2. Easy to add new vehicle types without changing client code");
        Console.WriteLine("3. Promotes loose coupling between creator and products");
    }
}
