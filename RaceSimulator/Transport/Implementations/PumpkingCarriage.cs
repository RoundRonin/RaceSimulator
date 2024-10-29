﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race.Transportation;

public class PumpkingCarriage : AbstractGroundTransport
{
    public PumpkingCarriage()
    {
        Name = "Pumpking carriage";
        Speed = 40;
        TravelTimeBeforeRest = 20;
        RestDuration = 15;
    }
    override protected void UpdateParams()
    {
        if (Speed > 30) Speed -= 0.01;
        if (Speed < 60 && resting) Speed += 0.01;
    }
}