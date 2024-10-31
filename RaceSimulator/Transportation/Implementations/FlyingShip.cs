using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Utils;

namespace RaceSimulator.Transportation;

[Name("Flying ship")]
public class FlyingShip : AbstractAirTransport
{
    public FlyingShip()
    {
        Name = "Flying ship";
        Speed = 30;
        AccelerationCoefficient = 1.1;
    }
    override protected void UpdateParams()
    {
        if (Speed < 50) { AccelerationCoefficient += 0.1; }
        if (Speed > 50 && AccelerationCoefficient > 0) { AccelerationCoefficient -= 0.5; }
        if (AccelerationCoefficient < 0) { AccelerationCoefficient = 0; }
    }
}
