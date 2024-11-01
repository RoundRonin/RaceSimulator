using System.Reflection.Metadata;
using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Weather.Interfaces;

namespace RaceSimulator.Transportation;

public class WeatherFactory(List<Type> weatherTypes) : IFactory<IWeatherState>
{
    private readonly List<Type> weatherTypes = weatherTypes;
    public List<Type> Types {
        get {return weatherTypes; } 
    }

    public IWeatherState Create(int index)
    {
        if (index < 1 || index > weatherTypes.Count)
        {
            throw new ArgumentException("Unknown weather type");
        }

        var weatherTypeToCreate = weatherTypes[index - 1];
        if (weatherTypeToCreate == null) { throw new NotImplementedException("weather types are not implemented"); }
        return (IWeatherState)Activator.CreateInstance(weatherTypeToCreate);
    }
}
