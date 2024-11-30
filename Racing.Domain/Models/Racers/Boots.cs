using Racing.Domain.Abstraction;


namespace Racing.Domain.Models.Racers;

public class Boots : IDriveable
{
    public string Name { get; set; } = "Сапоги-скороходы";
    public float Speed { get; set; } = 13f;
    public Status Status { get; set; }
    public int Position { get; set; } = 0;
    public int TimeScore { get; set; } = 0;
    public Race Race { get; set; }

    public double MoveFunction(int time)
    {
        return Speed * time;
    }

    public bool Cooldown(int currentTime, PointType pointType)
    {
        double restStart = pointType switch
        {
            PointType.Regular => 15.0,
            PointType.Rain => 12.0,
            PointType.Heat => 18.0,
            _ => 15.0
        };

        double restDuration = 2.0; // Время отдыха 2 минуты
        return (currentTime % restStart) < restDuration;
    }
}