using System.ComponentModel;
using Racing.Domain.Abstraction;
using Spectre.Console;

namespace Racing.View.UserInterface.Screens;

public static class Extensions
{
    public static Color GetRandomHexColor(this IMoveable moveable)
    {
        Random random = new Random();
        byte red = (byte) random.Next(0, 256);     // Random value between 0 and 255
        byte green = (byte)random.Next(0, 256);
        byte blue = (byte) random.Next(0, 256);

        return new Color(red, green, blue);   // Return the color in hexadecimal format (e.g. #RRGGBB)
    }
    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attribute = field?.GetCustomAttributes(typeof(DescriptionAttribute), false)
            .Cast<DescriptionAttribute>()
            .FirstOrDefault();
        return attribute?.Description ?? value.ToString();
    }

    public static Color GetEnumColor(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attribute = field?.GetCustomAttributes( typeof(EnumColorAttribute), false)
            .Cast<EnumColorAttribute>()
            .FirstOrDefault();;
        return attribute?.Color ?? Color.White;
    }

    public static string FormatString(this Color color, object value)
    {
        return $"[#{color.ToHex()}]{value}[/]";
    }
}