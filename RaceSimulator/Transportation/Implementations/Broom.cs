using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Utils;

namespace RaceSimulator.Transportation;

[Name("Broom")]
public class Broom : AbstractAirTransport
{
    public Broom()
    {
        Name = "Broom";
        Speed = 50;
        AccelerationCoefficient = 1.4;
    }
    override protected void UpdateParams()
    {
        if (Speed < 70) { AccelerationCoefficient += 0.01; }
    }
}