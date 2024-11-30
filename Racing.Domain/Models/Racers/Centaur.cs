using Racing.Domain.Abstraction;


namespace Racing.Domain.Models.Racers;

public class Centaur : IDriveable
{
    public string Name { get; set; } = "Кентавр";
    public float Speed { get; set; } = 35f;
    public Status Status { get; set; }
    public int Position { get; set; } = 0;
    public int TimeScore { get; set; } = 0;
    public Race Race { get; set; }

    public double MoveFunction(int time)
    {
        return Speed * time - 0.5 * 0.8 * time * time;
    }

    public bool Cooldown(int currentTime, PointType pointType)
    {
        double restStart = pointType switch
        {
            PointType.Regular => 40.0,
            PointType.Rain => 30.0,
            PointType.Heat => 50.0,
            _ => 40.0
        };

        double restDuration = 15.0; // Время отдыха 15 минут
        return (currentTime % restStart) < restDuration;
    }
}