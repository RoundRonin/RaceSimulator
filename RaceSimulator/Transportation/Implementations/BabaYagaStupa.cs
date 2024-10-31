using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Utils;

namespace RaceSimulator.Transportation;

[Name("Baba Yaga's Stupa")]
public class BabaYagasStupa : AbstractAirTransport
{
    public BabaYagasStupa()
    {
        Name = "Baba Yaga's Stupa";
        Speed = 10;
        AccelerationCoefficient = 2;
    }
    override protected void UpdateParams()
    {
        if (AccelerationCoefficient > 0) AccelerationCoefficient -= 0.01;
        if (Speed > 50) AccelerationCoefficient -= 0.03;
        if (AccelerationCoefficient < 0) AccelerationCoefficient += 0.1;
    }
}
