using RaceSimulator.Transportation.Abstractions;

namespace RaceSimulator.Transportation;

public static class VehicleFactory
{
    public static AbstractVehicle CreateVehicle(string vehicleType)
    {
        // Initial factory implementation, requires additional thinking
        return vehicleType switch
        {
            "Centaur" => new Centaur(),
            "SevenLeagueBoots" => new SevenLeagueBoots(),
            "MagicCarpet" => new MagicCarpet(),
            "BabaYagasStupa" => new BabaYagasStupa(),

            _ => throw new ArgumentException("Unknown vehicle type")
        };
    }
}

