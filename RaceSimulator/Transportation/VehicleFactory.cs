using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Transportation.Utils;

namespace RaceSimulator.Transportation;

public static class VehicleFactory
{
    public static AbstractVehicle CreateVehicle(int vehicleType)
    {
        var vehicleTypes = VehicleHelper.GetAllVehicleTypes();

        if (vehicleType < 1 || vehicleType > vehicleTypes.Count)
        {
            throw new ArgumentException("Unknown vehicle type");
        }

        var vehicleTypeToCreate = vehicleTypes[vehicleType - 1];
        return (AbstractVehicle)Activator.CreateInstance(vehicleTypeToCreate);
    }
}
