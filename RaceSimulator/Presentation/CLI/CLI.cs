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
        printer.PrintFormattedLine("Info", $"The winner is {winner.Name}!");
    }

    public void GetParams(ISimulator simulator)
    {
        simulator.SetSimulationParams(GetRaceDistance());
    }

    public RaceLogic GetRace(IFactory<RaceLogic> factory)
    {
        printer.PrintFormattedLine("Info", "Choose the type of race:");

        PrintOptions(factory.Types);
        string input = GetInputInRange(1, factory.Types.Count);

        return factory.Create(int.Parse(input));
    }

    public void GetObject(IFactory<AbstractVehicle> factory, ISimulator simulator)
    {
        printer.PrintFormattedLine("Info", "How many vehicles do you want to register?");

        string input = GetInputInRange(1, factory.Types.Count);
        int remainingVehiclesToAdd = int.Parse(input);

        while (remainingVehiclesToAdd > 0)
        {
            printer.PrintFormattedLine("Info", $"Choose vehicle:");
            PrintOptions(factory.Types);

            input = Console.ReadLine();
            int type = int.Parse(input);
            var vehicle = factory.Create(type);
            try { simulator.RegisterObject(vehicle); }
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
        printer.PrintFormattedLine("Info", "Enter the race distance:");

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
            var attribute = (NameAttribute)Attribute.GetCustomAttribute(type, typeof(NameAttribute));
            string nameValue = attribute != null ? attribute.Name : "Unknown";

            printer.PrintFormattedLine(PrintedIndex.ToString(), nameValue);
            PrintedIndex++;
        }
    }

    private string GetInputInRange(int minVal, int maxVal)
    {
        string? input = Console.ReadLine();
        while (string.IsNullOrEmpty(input) || !int.TryParse(input, out int type) || type < minVal || type > maxVal)
        {
            printer.PrintFormattedLine("Error", "Invalid input.");
            printer.PrintFormattedLine("Info", $"Choose again:");
            input = Console.ReadLine();
        }

        return input;
    }

}
