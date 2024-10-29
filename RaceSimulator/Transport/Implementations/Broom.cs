using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race.Transportation;

public class Broom : AbstractAirTransport
{
    public Broom()
    {
        Name = "Broom";
        Speed = 50;
        AccelerationCoefficient = 1.4;
    }
    override protected void UpdateParams()
    {
        if (Speed < 70) { AccelerationCoefficient += 0.01; }
    }
}