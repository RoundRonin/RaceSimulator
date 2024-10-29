using RaceSimulator.Transportation.Abstractions;

namespace RaceSimulator.Transportation;

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
