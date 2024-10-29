using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Presentation.Interfaces;

namespace RaceSimulator.RaceLogic;

public class RaceLogic(IPrinter printer, int TICK_TIME_MS = 1000)
{
    private double _distance;

    public List<AbstractVehicle> Vehicles { get; set; } = new List<AbstractVehicle>();
    public void RegisterVehicle(AbstractVehicle vehicle)
    {
        Vehicles.Add(vehicle);
        _distance = 0; 
    }

    public void SetRaceParams(double distacne)
    {
        _distance = distacne;

        // Potentially other params can be added, thus it is not a setter syntactically
    }

    public AbstractVehicle StartRace()
    {
        double currentPosition = 0;

        while (true)
        {
            foreach (var vehicle in Vehicles)
            {
                currentPosition = vehicle.CalculatePosition();
                printer.PrintFormattedLine(vehicle.Name, currentPosition.ToString());

                if (currentPosition >= _distance) { return vehicle; }
            }

            Thread.Sleep(TICK_TIME_MS);
        }
    }
}
