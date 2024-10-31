using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Presentation.Interfaces;

namespace RaceSimulator.Race;

public class RaceLogicAir : RaceLogic
{
    public RaceLogicAir(IPrinter printer, int tickTimeMs = 1000) : base(printer, tickTimeMs) {
        Name = "Race only for flying transport";
    }
    override public void RegisterObject(AbstractVehicle vehicle) {
        if (vehicle is AbstractAirTransport airVehicle) _vehicles.Add(airVehicle);
        else throw new ArgumentException("Vehicle type not supported by AirSimulator");
    }
}