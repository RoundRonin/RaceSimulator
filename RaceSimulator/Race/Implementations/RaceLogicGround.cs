using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Presentation.Interfaces;

namespace RaceSimulator.Race;

public class RaceLogicGround : RaceLogic
{
    public RaceLogicGround(IPrinter printer, int tickTimeMs = 1000) : base(printer, tickTimeMs) {
        Name = "Race only for flying transport";
    }
    public void RegisterObject(AbstractGroundTransport groundTransport) {
        _vehicles.Add(groundTransport);
    }
}