using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Presentation.Interfaces;

namespace RaceSimulator.RaceLogic;

public class RaceLogic(IPrinter printer, int tickTimeMs = 1000) : ISimulator<AbstractVehicle>
{
    private readonly IPrinter _printer = printer;
    private readonly int _tickTimeMs = tickTimeMs;
    private double _distance = 0;
    private readonly List<AbstractVehicle> _vehicles = new();
    private Func<AbstractVehicle, bool> _vehicleValidator = _ => true;

    public AbstractVehicle? Result { get; private set; }

    public void RegisterObject(AbstractVehicle objectToRegister)
    {
        if (_vehicleValidator(objectToRegister))
        {
            _vehicles.Add(objectToRegister);
            _printer.PrintFormattedLine("Vehicles", "Registered vehicle:");
            _printer.PrintFormattedLine("Vehicles", objectToRegister.Name.ToString());
        }
        else
        {
            throw new ArgumentException("Vehicle type not allowed for this race");
        }
    }

    public void SetSimulationParams(double distance, int type)
    {
        _distance = distance;
        _vehicleValidator = type switch
        {
            1 => vehicle => vehicle is AbstractGroundTransport,
            2 => vehicle => vehicle is AbstractAirTransport,
            3 => vehicle => true,
            _ => throw new ArgumentException("There is no such race type")
        };
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
                _printer.PrintFormattedLine(vehicle.Name, currentPosition.ToString());
                if (currentPosition >= _distance)
                {
                    Result = vehicle;
                    done = true;
                    break;
                }
            }
            if (done) break;
            Thread.Sleep(_tickTimeMs);
        }
    }
}
