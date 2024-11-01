using RaceSimulator.Transportation.Abstractions;

namespace RaceSimulator.Weather.Interfaces;

public interface IWeatherState
{
    void ApplyWeather(AbstractVehicle vehicle);
}
