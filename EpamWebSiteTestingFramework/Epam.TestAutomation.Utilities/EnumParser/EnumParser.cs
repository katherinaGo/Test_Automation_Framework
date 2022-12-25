using System.ComponentModel;
using System.Reflection;

namespace Epam.TestAutomation.Utilities.EnumParser;

public static class EnumParser
{
    public static T ParseEnum<T>(string value) where T : IComparable, IFormattable, IConvertible
    {
        return (T)Enum.Parse(typeof(T), value, true);
    }

    public static T GetEnumValueByDescription<T>(string description)
    {
        var type = typeof(T);
        if (!type.IsEnum)
            throw new ArgumentException();
        FieldInfo[] fields = type.GetFields();
        var field = fields
            .SelectMany(f => f.GetCustomAttributes(
                typeof(DescriptionAttribute), false), (
                f, a) => new { Field = f, Att = a }).SingleOrDefault(a => ((DescriptionAttribute)a.Att)
                .Description == description);
        return field == null ? default(T) : (T)field.Field.GetRawConstantValue();
    }
}