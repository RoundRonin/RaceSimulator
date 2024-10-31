using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Presentation.Interfaces;
using RaceSimulator.Race.Interfaces;
using RaceSimulator.Utils;

namespace RaceSimulator.Race;

[Name("Universal Race")]
public class RaceLogic(IPrinter printer, int tickTimeMs = 1000) : ISimulator
{
    private double _distance = 0;
    protected readonly List<AbstractVehicle> _vehicles = [];

    public AbstractVehicle? Result { get; private set; }

    virtual public void RegisterObject(AbstractVehicle abstractVehicle)
    {
        _vehicles.Add(abstractVehicle);
    }

    public void SetSimulationParams(double distance)
    {
        _distance = distance;
    }

    public void StartSimulation()
    {
        double currentPosition = 0;
        bool done = false;
        while (true)
        {
            foreach (var vehicle in _vehicles)
            {
                currentPosition = vehicle.CalculatePosition();
                printer.PrintFormattedLine(vehicle.Name, currentPosition.ToString());
                if (currentPosition >= _distance)
                {
                    Result = vehicle;
                    done = true;
                    break;
                }
            }
            if (done) break;
            Thread.Sleep(tickTimeMs);
        }
    }
}
