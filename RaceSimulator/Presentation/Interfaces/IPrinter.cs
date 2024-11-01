using RaceSimulator.Transportation.Abstractions;

namespace RaceSimulator.Presentation.Interfaces;

public interface IPrinter
{
    public void InitRecuringState();
    public void StopRecuringState();
    public void PrintFormattedLine(string key, string value);
    public void PrintFormattedLines(Dictionary<string, string> lines);
}