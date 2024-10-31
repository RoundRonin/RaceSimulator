using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Presentation.Interfaces;

namespace RaceSimulator.Race;

public class RaceLogicGround : RaceLogic
{
    public RaceLogicGround(IPrinter printer, int tickTimeMs = 1000) : base(printer, tickTimeMs)
    {
        Name = "Race only for flying transport";
    }
    override public void RegisterObject(AbstractVehicle vehicle)
    {
        if (vehicle is AbstractGroundTransport groundVehicle) _vehicles.Add(groundVehicle);
        else throw new ArgumentException("Vehicle type not supported by AirSimulator");
    }
}