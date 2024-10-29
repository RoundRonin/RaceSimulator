using RaceSimulator.Transportation.Abstractions;

namespace RaceSimulator.Presentation.Interfaces;

internal interface IReciever
{
    double GetRaceDistance();
    int GetRaceType();
}