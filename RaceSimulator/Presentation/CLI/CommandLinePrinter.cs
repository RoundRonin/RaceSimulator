using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Presentation.Interfaces;

namespace RaceSimulator.Presentation.CLI;

public class CommandLinePrinter : IPrinter
{
    int informationLines = 0;
    bool lastWasMultiple = false;
    KeyValuePair<string, string>? LastMessage;

    public void InitRecuringState()
    {
        lastWasMultiple = false;
        Console.Clear();
        informationLines = 0;
    }

    public void StopRecuringState()
    {
        lastWasMultiple = false;
        informationLines = 0;
    }

    public void PrintFormattedLine(string key, string value)
    {
        if (LastMessage != null)
        {
            Console.SetCursorPosition(0, 0);
            string formattedLine = string.Format("{0,-5}: {1}", LastMessage.Value.Key, LastMessage.Value.Value);
            Console.WriteLine(formattedLine.PadRight(Console.WindowWidth));
            LastMessage = null;
        }
        else if (lastWasMultiple)
        {
            LastMessage = new KeyValuePair<string, string>(key, value);
            return;
        }

        string newLine = string.Format("{0,-5}: {1}", key, value);
        Console.WriteLine(newLine);
        informationLines++;
        lastWasMultiple = false;
    }

    public void PrintFormattedLines(Dictionary<string, string> lines)
    {
        if (LastMessage != null)
        {
            Console.SetCursorPosition(0, 0);
            string formattedLine = string.Format("{0,-5}: {1}", LastMessage.Value.Key, LastMessage.Value.Value);
            Console.WriteLine(formattedLine.PadRight(Console.WindowWidth));
            LastMessage = null;
            informationLines++;
        }

        Console.SetCursorPosition(0, informationLines);
        foreach (var line in lines)
        {
            string formattedLine = string.Format("{0,-5}: {1}", line.Key, line.Value);
            Console.WriteLine(formattedLine.PadRight(Console.WindowWidth));
        }
        informationLines = 0;
        lastWasMultiple = true;
    }
}