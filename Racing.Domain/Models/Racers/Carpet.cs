using Racing.Domain.Abstraction;


namespace Racing.Domain.Models.Racers;

public class Carpet : IFlyable
{
    public string Name { get; set; } = "Ковер-самолет";
    public float Speed { get; set; }
    public Status Status { get; set; }

    public int Position { get; set; } = 0;
    public int TimeScore { get; set; } = 0;
    public Race Race { get; set; }

    public double MoveFunction(int time)
    {
        var point = Race.Map[Position];
        return Speed * time + 0.5 * AccelerationRatio(Position, point) * time * time;
    }


    public double AccelerationRatio(int passedWay, PointType pointType)
    {
        double baseAcceleration = 8.0; // Базовое ускорение для ковра-самолета

        // Коэффициенты для местности
        double pointMultiplier = pointType switch
        {
            PointType.Regular => 1.0,
            PointType.Rain => 0.8, // Дождь снижает устойчивость
            PointType.Heat => 1.1, // В жару ковер ускоряется из-за меньшего сопротивления воздуха
            _ => 1.0
        };

        // Учет магического запаса ковра, снижающегося с расстоянием
        double magicDepletion = -0.015 * Position;

        return Math.Max(0, baseAcceleration * pointMultiplier + magicDepletion);
    }
}