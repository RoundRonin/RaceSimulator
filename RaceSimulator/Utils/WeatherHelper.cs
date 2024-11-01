using System.Reflection;
using RaceSimulator.Weather.Interfaces;

namespace RaceSimulator.Utils;

public static class WeatherHelper
{
    public static List<Type> GetAllWeatherTypes()
    {
        return Assembly.GetAssembly(typeof(IWeatherState))
                       .GetTypes()
                       .Where(t => t.IsClass && !t.IsAbstract && typeof(IWeatherState).IsAssignableFrom(t))
                       .ToList();
    }
}
