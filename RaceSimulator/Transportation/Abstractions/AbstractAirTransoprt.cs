namespace RaceSimulator.Transportation.Abstractions;

public abstract class AbstractAirTransport : AbstractVehicle 
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