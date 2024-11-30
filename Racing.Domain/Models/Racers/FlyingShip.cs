using Racing.Domain.Abstraction;

namespace Racing.Domain.Models.Racers;

public class FlyingShip : IFlyable
{
    public string Name { get; set; } = "Летучий корабль";
    public float Speed { get; set; } = 40f;
    public Status Status { get; set; }
    public int Position { get; set; } = 0;
    public int TimeScore { get; set; } = 0;
    public Race Race { get; set; }

    public double MoveFunction(int time)
    {
        var airResistanceCoefficient = 1.3;
        var modifier = ( Math.Sqrt(AccelerationRatio(Position,Race.Map[Position]) * time));
        return (Speed / airResistanceCoefficient) * modifier;
    }

    public double AccelerationRatio(int passedWay, PointType pointType)
    {
        double baseAcceleration = 6.0; 


        double pointMultiplier = pointType switch
        {
            PointType.Regular => 1.0,
            PointType.Rain => 0.9, 
            PointType.Heat => 0.85, 
            _ => 1.0
        };

        // Учет накопленного магического импульса
        double impulseEffect = 0.02 * Math.Sqrt(Position);

        return Math.Max(1, baseAcceleration * pointMultiplier + impulseEffect);
    }
}