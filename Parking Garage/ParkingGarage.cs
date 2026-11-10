public enum ParkingSpot
{
    Small,
    Medium,
    Large,
}

public class ParkingGarage
{
    public Dictionary<int, (string, int)> _parkedVehicles;
    public Dictionary<ParkingSpot, int> _perHourRates;
    public List<(int Min, int Max, ParkingSpot size)> _spaceIds;

    public ParkingGarage(List<(int Min, int Max, ParkingSpot size)> spaceIds,
        Dictionary<int, (string, int)> parkedVehicles, Dictionary<ParkingSpot, int> perHourRates)
    {
        _spaceIds = spaceIds;
        _parkedVehicles = parkedVehicles;
        _perHourRates = perHourRates;
    }
}