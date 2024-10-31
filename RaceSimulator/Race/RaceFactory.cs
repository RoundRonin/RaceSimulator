﻿using RaceSimulator.Presentation.Interfaces;

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
        return (RaceLogic)Activator.CreateInstance(raceTypeToCreate, constructorArgs);
    }
}
