using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Race.Transportation;

namespace RaceSimulator.Presentation.Interfaces;

internal interface IInformer
{
    void DisplayWinner(Vehicle winner);
}
