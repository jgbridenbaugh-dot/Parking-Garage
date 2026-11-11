using System.Linq.Expressions;

public enum VehicleType
{
    Bike,
    Car,
    Truck,
}

public class Vehicle
{
    private readonly string _name;
    private readonly VehicleType _type;
    private bool _isParked = false;
    private int _spaceNumber;
    private ParkingSpot _spaceSize;

    public Vehicle(string name, VehicleType type)
    {
        _name = name;
        _type = type;
    }

    public string Park(ParkingGarage garage, int spaceNumber, int duration)
    {
        bool isWithinRange = garage._spaceIds.Any(r => spaceNumber >= r.Min && spaceNumber <= r.Max);
        const string INVALID_DURATION_MESSAGE = "Duration must be a value greater than zero.";

        if (!isWithinRange)
        {
            return $"Parking space {spaceNumber} does not exist.";
        }

        if (_isParked)
        {
            return $"Could not park {_name} in space {spaceNumber}, it is already parked in space {_spaceNumber}.";
        }

        if (garage._parkedVehicles.ContainsKey(spaceNumber))
        {
            return $"Parking space {spaceNumber} is occupied.";
        }

        if (duration <= 0)
        {
            return INVALID_DURATION_MESSAGE;
        }

        ParkingSpot spaceSize = GetSpaceSize(garage, spaceNumber);

        if (spaceSize != GetRequiredSize(_type))
        {
            return $"Could not park {_name} in space {spaceNumber}, it is the wrong size.";
        }

        garage._parkedVehicles.Add(spaceNumber, (_name, duration));
        _spaceNumber = spaceNumber;
        _spaceSize = spaceSize;
        _isParked = true;

        return $"Successfully parked {_name} in space {spaceNumber} for {duration} hours.";
    }

    public string Status()
    {
        return (_isParked) switch
        {
            true => $"{_name} is parked",
            false => $"{_name} is not parked",
        };
    }

    public string Unpark(ParkingGarage garage)
    {
        string unparkSuccessfulMessage = $"Successfully unparked {_name} at space {_spaceNumber}.";

        if (!_isParked)
        {
            return $"Could not unpark {_name}, it is not parked in a space.";
        }
        else
        {
            int duration = garage._parkedVehicles[_spaceNumber].Item2;
            int ticketFee = duration * garage._perHourRates[_spaceSize];
            garage._parkedVehicles.Remove(_spaceNumber);
            _isParked = false;

            string ticketFeeMessage = $" Ticket Fee: ${ticketFee}";
            return $"{unparkSuccessfulMessage}{ticketFeeMessage}";
        }
    }

    private static ParkingSpot GetRequiredSize(VehicleType type)
    {
        return (type) switch
        {
            VehicleType.Bike => ParkingSpot.Small,
            VehicleType.Car => ParkingSpot.Medium,
            VehicleType.Truck => ParkingSpot.Large,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }

    public static ParkingSpot GetSpaceSize(ParkingGarage garage, int spaceNumber)
    {
        foreach ((int Min, int Max, ParkingSpot size) in garage._spaceIds)
        {
            if (spaceNumber >= Min && spaceNumber <= Max)
            {
                return size;
            }
        }
        throw new ArgumentOutOfRangeException(nameof(spaceNumber), $"Space {spaceNumber} does not exist.");
    }
}