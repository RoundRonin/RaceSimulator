﻿using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Transportation;
using RaceSimulator.Presentation.Interfaces;
using RaceSimulator.Race.Interfaces;
using RaceSimulator.Race;
using RaceSimulator.Utils;
using RaceSimulator.Weather.Interfaces;
using RaceSimulator.Utils.Interfaces;

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
        printer.InitRecuringState();
        printer.PrintFormattedLine("Info", "Choose the type of race:");

        PrintOptions(factory.Types);
        printer.StopRecuringState();
        string input = GetInputInRange(1, factory.Types.Count);

        return factory.Create(int.Parse(input));
    }

    public IWeatherState GetWeatherState(IFactory<IWeatherState> factory)
    {
        printer.InitRecuringState();
        printer.PrintFormattedLine("Info", "Choose the weather:");

        PrintOptions(factory.Types);
        printer.StopRecuringState();
        string input = GetInputInRange(1, factory.Types.Count);

        return factory.Create(int.Parse(input));
    }

    public void GetObject(IFactory<AbstractVehicle> factory, ISimulator simulator)
    {
        printer.PrintFormattedLine("Info", "How many vehicles do you want to register?");

        string input = GetInputInRange(1, factory.Types.Count);
        int remainingVehiclesToAdd = int.Parse(input);

        printer.InitRecuringState();
        while (remainingVehiclesToAdd > 0)
        {
            printer.PrintFormattedLine("Info", $"Choose vehicle:");
            PrintOptions(factory.Types);

            input = Console.ReadLine();
            int type = int.Parse(input);
            try { simulator.RegisterObject(factory.Create(type)); }
            catch (ArgumentException ex)
            {
                printer.PrintFormattedLine("Error", ex.Message);
                continue;
            }
            
            remainingVehiclesToAdd--;
        }
        printer.StopRecuringState();
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
        var lines = new Dictionary<string, string>();
        foreach (var type in types)
        {
            var attribute = (NameAttribute)Attribute.GetCustomAttribute(type, typeof(NameAttribute));
            string nameValue = attribute != null ? attribute.Name : "Unknown";
            lines.Add(PrintedIndex.ToString(), nameValue);

            PrintedIndex++;
        }

        printer.PrintFormattedLines(lines);
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
