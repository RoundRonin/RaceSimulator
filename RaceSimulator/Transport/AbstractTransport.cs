using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceSimulator.Transport;

public abstract class Vehicle
{
    protected double CoordinateX;

    public string Name { get; set; }
    public double Speed { get; set; }
    public abstract double CalculatePosition();

    protected abstract void UpdateParams();
}

public abstract class GroundTransport : Vehicle
{
    protected double timeWithoutRest;
    protected double timeSpentResting;
    protected bool resting = false;


    public double TravelTimeBeforeRest { get; set; }
    public double RestDuration { get; set; }
    public double RestDurationCoefficient { get; set; }
    public override double CalculatePosition()
    {

        if (resting && timeSpentResting <= RestDuration)
        {
            timeSpentResting++;
            return CoordinateX;
        }
        else if (resting && timeSpentResting > RestDuration)
        {
            resting = false;
            timeSpentResting = 0;
        }

        double distanceIncrement = Speed;
        CoordinateX += distanceIncrement;

        timeWithoutRest++;

        if (timeWithoutRest >= TravelTimeBeforeRest)
        {
            resting = true;
            timeWithoutRest = 0;
        }

        UpdateParams();

        return CoordinateX;
    }
}

public abstract class AirTransport : Vehicle
{
    public double AccelerationCoefficient { get; set; }

    public override double CalculatePosition()
    {
        double distanceIncrement = Speed;
        CoordinateX += distanceIncrement;

        Speed += AccelerationCoefficient;

        UpdateParams();

        return CoordinateX;
    }
}
