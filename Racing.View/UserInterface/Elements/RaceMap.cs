using Racing.Domain.Models;
using Racing.View.UserInterface.Abstract;
using Racing.View.UserInterface.Screens;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Racing.View.Elements;



public class RaceMap(StateManager stateManager) : BaseElement<Canvas>(stateManager)
{
    private Dictionary<Direction, Coordinates> Vectors = new()
    {
        { Direction.Forward, new(1, 0) },
        { Direction.Up, new(0, 1) },
        { Direction.Back, new(-1, 0) },
        { Direction.Down, new(0, -1) },
    };
    
    protected override void Configure(RenderOptions options, int maxWidth)
    {
        int windowHeight = options.Height ?? maxWidth;
        int windowWidth = maxWidth;
        PointType[] road = stateManager.RacingHandler.Race.Map;
        var sizeRatio = GetSizesLength(windowHeight, windowWidth, road.Length);
        var scale = (int) Math.Round((decimal)sizeRatio.width / windowWidth );
        
        Element = new Canvas(windowWidth, windowHeight);
        Element.PixelWidth = 1;
        
        var racers = stateManager.RacingHandler.Race.Racers;

        int pointIndex = 0;
        Coordinates position = new(0, 0);
        Color color;
        foreach (var direction in Enum.GetValues(typeof(Direction)).Cast<Direction>())
        {
            var vector = Vectors[direction];
            int sizeEnd;
            if (direction == Direction.Forward || direction == Direction.Back) sizeEnd = sizeRatio.width; 
            else sizeEnd = sizeRatio.height;

            for (int i = 0; i < sizeEnd - scale; i += scale)
            {
                
                var racer = racers.FirstOrDefault(r => pointIndex <= r.Position && r.Position <= pointIndex + scale);
                if (racer != null)
                {
                    color = stateManager.Colors[racer];
                }
                else
                {
                    var point = road.Skip(i).Take(scale).Max();
                    color = point.GetEnumColor();
                }

                if (direction == Direction.Up || direction == Direction.Down)
                {
                    for (int inPixel = 0; inPixel < Element.PixelWidth; inPixel++)
                    {
                        Element.SetPixel(position.X - vector.Y * inPixel, position.Y, color);
                    }
                }
                else
                {
                    Element.SetPixel(position.X, position.Y, color);
                }
                
                position += (vector);
                pointIndex++;
            }
        }
        
    }

    protected (int width, int height) GetSizesLength(int height, int width, int Perimeter)
    {
        var gcd = GCD(width, height);
        int kx = width / gcd;
        int ky= height / gcd;

        int avgPerSize = Perimeter / (2 * (kx + ky));
        return (avgPerSize * kx, avgPerSize * ky);
    }

    protected int GCD(int a, int b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        return a | b;
    }
}