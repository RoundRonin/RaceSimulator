using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Utils;

namespace RaceSimulator.Transportation;

[Name("Pumpking carriage")]
public class PumpkingCarriage : AbstractGroundTransport
{
    public PumpkingCarriage()
    {
        Name = "Pumpking carriage";
        Speed = 40;
        TravelTimeBeforeRest = 20;
        RestDuration = 15;
    }
    override protected void UpdateParams()
    {
        if (Speed > 30) Speed -= 0.01 * WeatherEffect1;
        if (Speed < 60 && resting) Speed += 0.01 * WeatherEffect2;
    }
}
