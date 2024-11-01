using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Presentation.Interfaces;
using RaceSimulator.Utils;

namespace RaceSimulator.Race;

[Name("Air Race")]
public class RaceLogicAir(IPrinter printer, int tickTimeMs = 1000) : RaceLogic(printer, tickTimeMs)
{
    override public void RegisterObject(AbstractVehicle vehicle) {
        if (vehicle is AbstractAirTransport airVehicle) vehicles.Add(airVehicle);
        else throw new ArgumentException("Vehicle type not supported by AirSimulator");
    }
}