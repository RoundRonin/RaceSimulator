using RaceSimulator.Utils.Interface;
using RaceSimulator.Weather.Interfaces;
using RaceSimulator.Weather.Implementations;

namespace RaceSimulator.Transportation.Abstractions;

public abstract class AbstractVehicle : INamedObject
{
    protected IWeatherState? _currentWeather; 

    protected double CoordinateX;

    public required string Name { get; set; }
    public double Speed { get; set; }
    public double WeatherEffect1 { get; set; }
    public double WeatherEffect2 { get; set; }
    public abstract double CalculatePosition();

    protected abstract void UpdateParams();


    public void SetWeatherState(IWeatherState weather)
    {
        _currentWeather = weather;
    }

    public void ApplyWeather()
    {
        _currentWeather?.ApplyWeather(this);
    }
}