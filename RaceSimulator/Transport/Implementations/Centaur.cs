using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race.Transportation;

public class Centaur : AbstractGroundTransport
{
    public Centaur()
    {
        Name = "Centaur";
        Speed = 40;
        TravelTimeBeforeRest = 12;
        RestDuration = 7;
    }
    override protected void UpdateParams()
    {
        if (RestDuration > 5 && resting) RestDuration -= 0.01;
    }
}
