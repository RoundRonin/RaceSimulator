using System.Reflection.Metadata;
using RaceSimulator.Transportation.Abstractions;

namespace RaceSimulator.Transportation;

public class VehicleFactory(List<Type> vehicleTypes) : IFactory<AbstractVehicle>
{
    private readonly List<Type> vehicleTypes = vehicleTypes;
    public List<Type> Types {
        get {return vehicleTypes; } 
    }

    public AbstractVehicle Create(int index)
    {
        if (index < 1 || index > vehicleTypes.Count)
        {
            throw new ArgumentException("Unknown vehicle type");
        }

        var vehicleTypeToCreate = vehicleTypes[index - 1];
        return (AbstractVehicle)Activator.CreateInstance(vehicleTypeToCreate);
    }
}
