using RaceSimulator.Transportation.Abstractions;

namespace RaceSimulator.Presentation.Interfaces;

internal interface IInformer
{
    void DisplayWinner(AbstractVehicle winner);
}
