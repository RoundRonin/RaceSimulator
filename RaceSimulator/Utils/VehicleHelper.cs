using System.Reflection;
using RaceSimulator.Transportation.Abstractions;

namespace RaceSimulator.Utils;

public static class VehicleHelper
{
    public static List<Type> GetAllVehicleTypes()
    {
        return Assembly.GetAssembly(typeof(AbstractVehicle))
                       .GetTypes()
                       .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(AbstractVehicle)))
                       .ToList();
    }
}