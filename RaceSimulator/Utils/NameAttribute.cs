
namespace RaceSimulator.Utils;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class NameAttribute(string name) : Attribute
{
    public string Name { get; } = name;
}
