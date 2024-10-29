using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race.Transportation;

public class HutOnChickenLegs : AbstractGroundTransport
{
    public HutOnChickenLegs()
    {
        Name = "Hut on chicken legs";
        Speed = 30;
        TravelTimeBeforeRest = 5;
        RestDuration = 10;
    }
    override protected void UpdateParams()
    {
        Speed += 0.01;
        RestDuration += 0.01;
    }
}
