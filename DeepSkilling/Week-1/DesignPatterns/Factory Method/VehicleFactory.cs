// Factory Method Pattern - Creator Class
// This class contains the factory method for creating vehicle instances

public class VehicleFactory
{
    // Factory method that creates vehicle objects based on type
    public static IVehicle CreateVehicle(string vehicleType)
    {
        switch (vehicleType.ToLower())
        {
            case "car":
                Console.WriteLine("Car instance created");
                return new Car();

            case "bike":
                Console.WriteLine("Bike instance created");
                return new Bike();

            case "truck":
                Console.WriteLine("Truck instance created");
                return new Truck();

            default:
                throw new ArgumentException($"Unknown vehicle type: {vehicleType}");
        }
    }
}
