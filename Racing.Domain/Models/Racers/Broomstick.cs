using Racing.Domain.Abstraction;


namespace Racing.Domain.Models.Racers;

public class Broomstick : IFlyable
{
    public string Name { get; set; } = "Метла";
    public float Speed { get; set; } = 10f;
    public Status Status { get; set; }
    public int Position { get; set; } = 0;
    public int TimeScore { get; set; } = 0;
    public Race Race { get; set; }
    
    public double MoveFunction(int time)
    {
        var point = Race.Map[Position];
        var power = AccelerationRatio(Position, point);
        var result = Speed * (Math.Exp(power/8) * time - 1);
        return result;
    }
    

    public double AccelerationRatio(int passedWay, PointType pointType)
    {
        double baseAcceleration = 10.0; // Базовое ускорение для метлы

        // Коэффициенты для местности
        double pointMultiplier = pointType switch
        {
            PointType.Regular => 1.0,
            PointType.Rain => 0.7, // В дождь скольжение ухудшает ускорение
            PointType.Heat => 0.9, // В жару магия работает хуже
            _ => 1.0
        };

        // Дополнительное замедление при увеличении расстояния
        double distanceEffect = -0.02 * Position;

        return Math.Max(0, baseAcceleration * pointMultiplier + distanceEffect);;
    }
}