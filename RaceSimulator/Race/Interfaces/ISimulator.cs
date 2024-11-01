using RaceSimulator.Transportation.Abstractions;

namespace RaceSimulator.Race.Interfaces;

internal interface ISimulator
{
    void RegisterObject(AbstractVehicle abstractVehicle);
    void SetSimulationParams(double distacne);
    void StartSimulation();
}
