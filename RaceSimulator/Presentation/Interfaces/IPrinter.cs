using RaceSimulator.Transportation.Abstractions;

namespace RaceSimulator.Presentation.Interfaces;

public interface IPrinter
{
    public void PrintFormattedLine(string key, string value);
}