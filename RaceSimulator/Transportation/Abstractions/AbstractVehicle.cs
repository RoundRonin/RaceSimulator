﻿namespace RaceSimulator.Transportation.Abstractions;

public abstract class AbstractVehicle
{
    protected double CoordinateX;

    public string Name { get; set; }
    public double Speed { get; set; }
    public abstract double CalculatePosition();

    protected abstract void UpdateParams();
}