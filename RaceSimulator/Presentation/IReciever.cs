using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race.Presentiation;

internal interface IReciever
{
    double GetRaceDistance();
    int GetRaceType();
}