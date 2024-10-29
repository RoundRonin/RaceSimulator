using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Race.Transportation;

namespace Race.Presentiation;

internal interface IInformer
{
    void DisplayWinner(Vehicle winner);
}
