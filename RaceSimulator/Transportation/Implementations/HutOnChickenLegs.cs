using RaceSimulator.Transportation.Abstractions;

namespace RaceSimulator.Transportation;

public class HutOnChickenLegs : AbstractGroundTransport
{
    public HutOnChickenLegs()
    {
        Name = "Hut on chicken legs";
        Speed = 30;
        TravelTimeBeforeRest = 5;
        RestDuration = 10;
    }
    override protected void UpdateParams()
    {
        Speed += 0.01;
        RestDuration += 0.01;
    }
}
