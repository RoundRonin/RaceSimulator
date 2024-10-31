using RaceSimulator.Race.Interfaces;
using RaceSimulator.Transportation.Abstractions;

namespace RaceSimulator.Presentation.Interfaces;

internal interface IReciever
{
    void GetParams(ISimulator simulator);
    void GetObject(IFactory<AbstractVehicle> factory, ISimulator simulator);
}