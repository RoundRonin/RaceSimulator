namespace RaceSimulator.RaceLogic;

internal interface ISimulator<T>
{
    void RegisterObject(T objectToRegister);
    void SetSimulationParams(double distacne);
    void StartSimulation();
}
