using RaceSimulator.Transportation.Abstractions;

namespace RaceSimulator.Transportation;

public static class VehicleFactory
{
    public static AbstractVehicle CreateVehicle(int vehicleType)
    {
        // Initial factory implementation, requires additional thinking
        return vehicleType switch
        {
            1 => new Centaur(),
            2 => new SevenLeagueBoots(),
            3 => new MagicCarpet(),
            4 => new BabaYagasStupa(),

            _ => throw new ArgumentException("Unknown vehicle type")
        };
    }
}

