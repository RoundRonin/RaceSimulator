using RaceSimulator.Weather.Interfaces;
using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Utils;

namespace RaceSimulator.Weather.Implementations;

[Name("Rainy weather")]
public class RainyState : IWeatherState
{
    public void ApplyWeather(AbstractVehicle vehicle)
    {
        vehicle.Speed *= 0.3;
    }
}
