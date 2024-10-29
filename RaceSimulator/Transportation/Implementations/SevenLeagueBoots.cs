﻿using RaceSimulator.Transportation.Abstractions;

namespace RaceSimulator.Transportation;

public class SevenLeagueBoots : AbstractGroundTransport
{
    public SevenLeagueBoots()
    {
        Name = "Seven-League Boots";
        Speed = 20;
        TravelTimeBeforeRest = 10;
        RestDuration = 5;
        RestDurationCoefficient = 1.1;
    }

    override protected void UpdateParams()
    {
        if (Speed > 10 && timeWithoutRest + 5 > TravelTimeBeforeRest) { Speed--; }
    }
}