using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Transportation;
using RaceSimulator.Presentation.Interfaces;
using RaceSimulator.Race.Interfaces;
using RaceSimulator.Race;
using RaceSimulator.Utils;

namespace RaceSimulator.Presentation.CLI;

internal class CLI(IPrinter printer) : IReciever, IInformer
{
    public void DisplayWinner(AbstractVehicle winner)
    {
        printer.PrintFormattedLine("Winner", $"The winner is {winner.Name}!");
    }

    public void GetParams(ISimulator simulator)
    {
        simulator.SetSimulationParams(GetRaceDistance());
    }

    public RaceLogic GetRace(IFactory<RaceLogic> factory)
    {
        printer.PrintFormattedLine("Prompt", "Choose the type of race:");

        PrintOptions(factory.Types);

        string? input = Console.ReadLine();
        while (string.IsNullOrEmpty(input) || !int.TryParse(input, out int type) || type < 1 || type > factory.Types.Count)
        {
            printer.PrintFormattedLine("Error", "Invalid input.");
            printer.PrintFormattedLine("Prompt", "Choose the type of race:");
            input = Console.ReadLine();
        }

        return factory.Create(int.Parse(input));
    }

    public void GetObject(IFactory<AbstractVehicle> factory, ISimulator simulator)
    {
        printer.PrintFormattedLine("Prompt", "How many vehicles do you want to register?");

        string? input = Console.ReadLine();
        while (string.IsNullOrEmpty(input) || !int.TryParse(input, out int vehicleCount) || vehicleCount <= 0)
        {
            printer.PrintFormattedLine("Error", "Invalid input. Enter a positive number");
            printer.PrintFormattedLine("Prompt", "How many vehicles do you want to register?");
            input = Console.ReadLine();
        }

        int remainingVehiclesToAdd = int.Parse(input);

        while (remainingVehiclesToAdd > 0)
        {
            printer.PrintFormattedLine("Prompt", $"Choose vehicle:");
            PrintOptions(factory.Types);

            input = Console.ReadLine();
            while (string.IsNullOrEmpty(input) || !int.TryParse(input, out int vehicleType) || vehicleType < 1 || vehicleType > factory.Types.Count)
            {
                printer.PrintFormattedLine("Error", "Invalid input.");
                printer.PrintFormattedLine("Prompt", $"Choose vehicle:");
                input = Console.ReadLine();
            }

            int type = int.Parse(input);
            try { simulator.RegisterObject(factory.Create(type)); }
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

    private void PrintOptions(List<Type> types) {
        int PrintedIndex = 1;
        foreach (var type in types)
        {
            printer.PrintFormattedLine(PrintedIndex.ToString(), type.Name);
            PrintedIndex++;
        }
    }

}
