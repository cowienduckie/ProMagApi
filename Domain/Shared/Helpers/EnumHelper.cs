using System.ComponentModel;

namespace Domain.Shared.Helpers;

public static class EnumHelper
{
    public static string GetDescription(this Enum value)
    {
        var type = value.GetType();
        var name = Enum.GetName(type, value);

        if (name == null)
        {
            return value.ToString();
        }

        var field = type.GetField(name);

        if (field == null)
        {
            return value.ToString();
        }

        if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
        {
            return attribute.Description;
        }

        return value.ToString();
    }
}