using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Presentation.Interfaces;
using RaceSimulator.Utils;

namespace RaceSimulator.Race;

[Name("Ground Race")]
public class RaceLogicGround(IPrinter printer, int tickTimeMs = 1000) : RaceLogic(printer, tickTimeMs)
{
    override public void RegisterObject(AbstractVehicle vehicle)
    {
        if (vehicle is AbstractGroundTransport groundVehicle) _vehicles.Add(groundVehicle);
        else throw new ArgumentException("Vehicle type not supported by AirSimulator");
    }
}