using System;
using System.Diagnostics;

internal class Program
{
    public static void Main(string[] args)
    {
        //Garage
        Dictionary<ParkingSpot, int> perHourRates = new Dictionary<ParkingSpot, int>
        {
            { ParkingSpot.Small, 1 },
            { ParkingSpot.Medium, 2 },
            { ParkingSpot.Large, 3 },
        };

        var spaceIds = new List<(int Min, int Max, ParkingSpot size)>
        {
            //Floor 1

            (101, 120, ParkingSpot.Small),
            (121, 155, ParkingSpot.Medium),
            (156, 175, ParkingSpot.Large),

            //Floor 2

            (201, 220, ParkingSpot.Small),
            (221, 258, ParkingSpot.Medium),
            (259, 275, ParkingSpot.Large),
        };

        Dictionary<int, (string, int)> parkedCars = new Dictionary<int, (string, int)>();

        ParkingGarage parkingGarage = new ParkingGarage(spaceIds, parkedCars, perHourRates);

        //Vehicles
        var bike = new Vehicle("Bicycle", VehicleType.Bike);
        var car = new Vehicle("Mazda 3", VehicleType.Car);
        var truck = new Vehicle("F-150", VehicleType.Truck);

        //Method Calls
        Console.WriteLine(bike.Park(parkingGarage, 101, 10));
        Console.WriteLine(car.Park(parkingGarage, 121, 8));
        Console.WriteLine(truck.Park(parkingGarage, 156, 12));

        Console.WriteLine(car.Status());

        Console.WriteLine(bike.Unpark(parkingGarage));
        Console.WriteLine(car.Unpark(parkingGarage));
        Console.WriteLine(truck.Unpark(parkingGarage));

        Console.WriteLine(car.Status());
    }
}