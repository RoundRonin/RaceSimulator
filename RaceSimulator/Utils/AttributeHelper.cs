namespace RaceSimulator.Utils;

public static class AttributeHelper
{
    public static string GetNameAttribute<T>(Type type) where T : Attribute
    {
        var attribute = (T)Attribute.GetCustomAttribute(type, typeof(T));
        return attribute != null ? ((NameAttribute)(object)attribute).Name : type.Name;
    }
}
