using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Utils;

namespace RaceSimulator.Transportation;

[Name("Centaur")]
public class Centaur : AbstractGroundTransport
{
    public Centaur()
    {
        Name = "Centaur";
        Speed = 40;
        TravelTimeBeforeRest = 12;
        RestDuration = 7;
    }
    override protected void UpdateParams()
    {
        if (RestDuration > 5 && resting) RestDuration -= 0.01;
    }
}
