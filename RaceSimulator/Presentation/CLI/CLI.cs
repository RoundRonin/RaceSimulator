using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Presentation.Interfaces;

namespace RaceSimulator.Presentation.CLI;

internal class CLI(IPrinter printer) : IReciever, IInformer
{
    public void DisplayWinner(AbstractVehicle winner)
    {
        printer.PrintFormattedLine("Winner", $"The winner is {winner.Name}!");
    }

    public double GetRaceDistance()
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

    public int GetRaceType()
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
