using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race.Transportation;

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