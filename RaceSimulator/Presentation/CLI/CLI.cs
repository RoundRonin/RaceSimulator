using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Transportation;
using RaceSimulator.Presentation.Interfaces;
using RaceSimulator.RaceLogic;

namespace RaceSimulator.Presentation.CLI;

internal class CLI(IPrinter printer) : IReciever<AbstractVehicle>, IInformer
{
    public void DisplayWinner(AbstractVehicle winner)
    {
        printer.PrintFormattedLine("Winner", $"The winner is {winner.Name}!");
    }

    public void GetParams(ISimulator<AbstractVehicle> simulator)
    {
        simulator.SetSimulationParams(GetRaceDistance(), GetRaceType());
    }

    public void GetObject(ISimulator<AbstractVehicle> simulator)
    {
        printer.PrintFormattedLine("Prompt", "How many vehicles do you want to register?");
        string? input = Console.ReadLine();
        while (string.IsNullOrEmpty(input) || !int.TryParse(input, out int vehicleCount) || vehicleCount <= 0)
        {
            printer.PrintFormattedLine("Error", "Invalid input. Enter a positive number:");
            input = Console.ReadLine();
        }

        int remainingVehiclesToAdd = int.Parse(input);

        while (remainingVehiclesToAdd > 0)
        {
            printer.PrintFormattedLine("Prompt", $"Choose vehicle:");
            printer.PrintFormattedLine("1", "Centaur");
            printer.PrintFormattedLine("2", "SevenLeagueBoots");
            printer.PrintFormattedLine("3", "MagicCarpet");
            printer.PrintFormattedLine("4", "BabaYagasStupa");
            input = Console.ReadLine();
            while (string.IsNullOrEmpty(input) || !int.TryParse(input, out int vehicleType) || vehicleType < 1 || vehicleType > 4)
            {
                printer.PrintFormattedLine("Error", "Invalid input. Choose a vehicle:");
                input = Console.ReadLine();
            }

            int type = int.Parse(input);
            try
            {
                simulator.RegisterObject(VehicleFactory.CreateVehicle(type));
            }
            catch (ArgumentException ex)
            {
                printer.PrintFormattedLine("Error", ex.Message);
                continue;
            }
            
            remainingVehiclesToAdd--;
        }
    }

    private double GetRaceDistance()
    {
        printer.PrintFormattedLine("Prompt", "Enter the race distance:");

        string? input = Console.ReadLine();
        while (string.IsNullOrEmpty(input) || !double.TryParse(input, out double distance))
        {
            printer.PrintFormattedLine("Error", "Invalid input. Enter the race distance:");
            input = Console.ReadLine();
        }
        return double.Parse(input);
    }

    private int GetRaceType()
    {
        printer.PrintFormattedLine("Prompt", "Choose the type of race:");
        printer.PrintFormattedLine("1", "Ground Transport Only");
        printer.PrintFormattedLine("2", "Air Transport Only");
        printer.PrintFormattedLine("3", "All Types of Vehicles");

        string? input = Console.ReadLine();
        while (string.IsNullOrEmpty(input) || !int.TryParse(input, out int type) || type < 1 || type > 3)
        {
            printer.PrintFormattedLine("Error", "Invalid input. Choose the type of race:");
            input = Console.ReadLine();
        }
        return int.Parse(input);
    }

}
