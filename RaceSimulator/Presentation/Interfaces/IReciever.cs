using RaceSimulator.Race.Interfaces;
using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Utils.Interfaces;

namespace RaceSimulator.Presentation.Interfaces;

internal interface IReciever
{
    void GetParams(ISimulator simulator);
    void GetObject(IFactory<AbstractVehicle> factory, ISimulator simulator);
}