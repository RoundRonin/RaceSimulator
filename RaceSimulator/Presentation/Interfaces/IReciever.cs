using RaceSimulator.RaceLogic;
using RaceSimulator.Transportation.Abstractions;

namespace RaceSimulator.Presentation.Interfaces;

internal interface IReciever<T>
{
    void GetParams(ISimulator<T> simulator);
    void GetObject(ISimulator<T> simulator);
}