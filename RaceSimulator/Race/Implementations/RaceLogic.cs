using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Presentation.Interfaces;
using RaceSimulator.Race.Interfaces;
using RaceSimulator.Utils;
using RaceSimulator.Utils.Interface;

namespace RaceSimulator.Race;

[Name("Universal Race")]
public class RaceLogic(IPrinter printer, int tickTimeMs = 1000) : ISimulator
{
    private double _distance = 0;
    protected readonly List<AbstractVehicle> vehicles = [];

    public AbstractVehicle? Result { get; private set; }

    virtual public void RegisterObject(AbstractVehicle abstractVehicle)
    {
        vehicles.Add(abstractVehicle);
    }

    public void SetSimulationParams(double distance)
    {
        _distance = distance;
    }

    public void StartSimulation()
    {
        RepeatedNamesHelper.NormalizeNames(vehicles.Cast<INamedObject>().ToList());

        double currentPosition = 0;
        bool done = false;
        printer.InitRecuringState();
        while (true)
        {
            var lines = new Dictionary<string, string>();
            for (int i = 0; i < vehicles.Count; i++)
            {
                var vehicle = vehicles[i];
                currentPosition = vehicle.CalculatePosition();
                lines[vehicle.Name] = Math.Truncate(currentPosition).ToString();

                if (currentPosition >= _distance)
                {
                    Result = vehicle;
                    done = true;
                }

                // Print each group of vehicles
                if (i == vehicles.Count - 1)
                {
                    printer.PrintFormattedLines(lines);
                    lines.Clear();
                }
            }
            if (done) break;
            Thread.Sleep(tickTimeMs);
        }
        printer.StopRecuringState();
    }
}
