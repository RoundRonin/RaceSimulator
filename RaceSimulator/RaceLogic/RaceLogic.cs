using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Presentation.Interfaces;

namespace RaceSimulator.RaceLogic;

public class RaceLogic(IPrinter printer, int TICK_TIME_MS = 1000) : ISimulator<AbstractVehicle>
{
    private double _distance = 0;
    private List<AbstractVehicle> _vehicles = [];

    public AbstractVehicle? Result { get; private set; }

    public void RegisterObject(AbstractVehicle objectToRegister)
    {
        _vehicles.Add(objectToRegister);
        printer.PrintFormattedLine("Vehicles", "Registered vehicle:");
        printer.PrintFormattedLine("Vehicles", objectToRegister.Name.ToString());
    }

    public void SetSimulationParams(double distacne)
    {
        _distance = distacne;

        // Potentially other params can be added, thus it is not a setter syntactically
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

                if (currentPosition >= _distance) {
                    Result = vehicle;
                    done = true;
                    break; 
                }
            }

            if (done) { break; }

            Thread.Sleep(TICK_TIME_MS);
        }
    }
}
