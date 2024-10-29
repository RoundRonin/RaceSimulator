using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceSimulator.Presentation.Interfaces;

public interface IPrinter
{
    public void PrintFormattedLine(string key, string value);
}