using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Utils;

namespace RaceSimulator.Transportation;

[Name("Magic Carpet")]
public class MagicCarpet : AbstractAirTransport
{
    public MagicCarpet()
    {
        Name = "Magic Carpet";
        Speed = 20;
        AccelerationCoefficient = 1.2;
    }
    override protected void UpdateParams() { }
}
