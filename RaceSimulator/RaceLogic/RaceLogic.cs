using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Presentation.Interfaces;

namespace RaceSimulator.RaceLogic;

public class RaceLogic(double distance, IPrinter printer)
{
    public double Distance { get; set; } = distance;
    public IPrinter printer { get; set; } = printer;
    public List<AbstractVehicle> Vehicles { get; set; } = new List<AbstractVehicle>();

    public void RegisterVehicle(AbstractVehicle vehicle)
    {
        Vehicles.Add(vehicle);
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

                if (currentPosition >= Distance) { return vehicle; }
            }

            Thread.Sleep(1000);
        }
    }
}
