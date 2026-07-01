// Factory Method Pattern - Product Interface
// This interface defines the common behavior for all products

public interface IVehicle
{
    void Drive();
    string GetVehicleType();
}

// Concrete Product - Car
public class Car : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Driving a Car...");
    }

    public string GetVehicleType()
    {
        return "Car";
    }
}

// Concrete Product - Bike
public class Bike : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Driving a Bike...");
    }

    public string GetVehicleType()
    {
        return "Bike";
    }
}

// Concrete Product - Truck
public class Truck : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Driving a Truck...");
    }

    public string GetVehicleType()
    {
        return "Truck";
    }
}
