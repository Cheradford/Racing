

using Spectre.Console;

namespace Racing.Domain.Abstraction;

public class EnumColorAttribute : Attribute
{
    public Color Color { get; }

    public EnumColorAttribute(byte red, byte green, byte blue)
    {
        Color = new Color(red, green, blue);
    }

    //Alternatively, use a string representation of the color if you prefer
    public EnumColorAttribute(string color)
     {
         (byte r, byte g, byte b) = HexToRgb(color);
         Color = new Color(r, g, b); // Converts hex string to Color
    }
    
    private (byte r, byte g, byte b) HexToRgb(string hex)
    {
        // Remove the '#' if present
        if (hex.StartsWith("#"))
        {
            hex = hex.Substring(1);
        }

        // Parse the hex values to integers
        byte r = Convert.ToByte(hex.Substring(0, 2), 16);
        byte g = Convert.ToByte(hex.Substring(2, 2), 16);
        byte b = Convert.ToByte(hex.Substring(4, 2), 16);

        return (r, g, b);
    }
}