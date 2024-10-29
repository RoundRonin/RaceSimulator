using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceSimulator.Presentation.Interfaces;

internal interface IReciever
{
    double GetRaceDistance();
    int GetRaceType();
}