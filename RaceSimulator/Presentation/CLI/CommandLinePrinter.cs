using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Presentation.Interfaces;

namespace RaceSimulator.Presentation.CLI;

public class CommandLinePrinter : IPrinter
{
    public void PrintFormattedLine(string key, string value)
    {
        // Ensure the total length is 20 characters, including the word and whitespaces
        string formattedLine = string.Format("{0,-19}:{1}", key, value);
        Console.WriteLine(formattedLine);
    }
}
