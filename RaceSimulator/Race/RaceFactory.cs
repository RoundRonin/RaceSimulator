using RaceSimulator.Presentation.Interfaces;
using RaceSimulator.Utils.Interfaces;

namespace RaceSimulator.Race;

public class RaceFactory(List<Type> raceTypes, IPrinter printer, int TICK_TIME_MS) : IFactory<RaceLogic>
{
    private readonly List<Type> raceTypes = raceTypes;
    public List<Type> Types {
        get {return raceTypes; } 
    }

    public RaceLogic Create(int index)
    {

        if (index < 1 || index > raceTypes.Count)
        {
            throw new ArgumentException("Unknown vehicle type");
        }

        var raceTypeToCreate = raceTypes[index - 1];
        object[] constructorArgs = { printer, TICK_TIME_MS };

        if (raceTypeToCreate == null) { throw new NotImplementedException("race types are not implemented"); }

        return (RaceLogic)Activator.CreateInstance(raceTypeToCreate, constructorArgs);
    }
}
