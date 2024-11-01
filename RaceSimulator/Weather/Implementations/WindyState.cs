﻿using RaceSimulator.Weather.Interfaces;
using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Utils; 

namespace RaceSimulator.Weather.Implementations;

[Name("Windy weather")]
public class WindyState : IWeatherState
{
    public void ApplyWeather(AbstractVehicle vehicle)
    {
        vehicle.Speed *= 0.9;
        vehicle.WeatherEffect1 = 0.9;
        vehicle.WeatherEffect2 = 1.2;
    }
}
