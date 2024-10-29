using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race.Transportation;

public class MagicCarpet : AbstractAirTransport
{
    public MagicCarpet()
    {
        Name = "Magic Carpet";
        Speed = 20;
        AccelerationCoefficient = 1.2;
    }
    override protected void UpdateParams() { }
}
