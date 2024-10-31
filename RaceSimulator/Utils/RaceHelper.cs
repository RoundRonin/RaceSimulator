using System.Reflection;
using RaceSimulator.Race;
using RaceSimulator.Race.Interfaces;

namespace RaceSimulator.Utils;

public static class RaceHelper
{
    public static List<Type> GetAllRaceTypes()
    {
        return Assembly.GetAssembly(typeof(RaceLogic))
                       .GetTypes()
                       .Where(t => t.IsClass && (t == typeof(RaceLogic) || t.IsSubclassOf(typeof(RaceLogic))))
                       .ToList();
    }
}