using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Presentation.Interfaces;

namespace RaceSimulator.Race;

public class RaceLogicAir : RaceLogic
{
    public RaceLogicAir(IPrinter printer, int tickTimeMs = 1000) : base(printer, tickTimeMs) {
        Name = "Race only for flying transport";
    }
    public void RegisterObject(AbstractAirTransport airTransport) {
        _vehicles.Add(airTransport);
    }
}