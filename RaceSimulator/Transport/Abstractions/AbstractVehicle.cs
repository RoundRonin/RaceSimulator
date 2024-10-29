using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race.Transportation;

public abstract class AbstractVehicle
{
    protected double CoordinateX;

    public string Name { get; set; }
    public double Speed { get; set; }
    public abstract double CalculatePosition();

    protected abstract void UpdateParams();
}