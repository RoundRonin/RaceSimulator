﻿using RaceSimulator.Weather.Interfaces;
using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Utils; 
namespace RaceSimulator.Weather.Implementations;

[Name("Sunny weather")]
public class SunnyState : IWeatherState
{
    public void ApplyWeather(AbstractVehicle vehicle)
    {
        vehicle.Speed *= 1.0; 
    }
}
