using RaceSimulator.Utils.Interface;

namespace RaceSimulator.Utils;

internal static class RepeatedNamesHelper
{
    public static void NormalizeNames(List<INamedObject> list)
    {
        var nameCount = new Dictionary<string, int>();

        for (int i = 0; i < list.Count; i++)
        {
            var obj = list[i];
            if (nameCount.ContainsKey(obj.Name))
            {
                nameCount[obj.Name]++;
                obj.Name = $"{obj.Name} {nameCount[obj.Name]+1}";
            }
            else
            {
                nameCount[obj.Name] = 0;
            }
        }
    }
}
