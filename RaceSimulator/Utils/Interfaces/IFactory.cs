namespace RaceSimulator.Utils.Interfaces;

interface IFactory<T>
{
    public List<Type> Types {get;}
    public T Create(int Index);
}