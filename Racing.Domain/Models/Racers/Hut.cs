using Racing.Domain.Abstraction;


namespace Racing.Domain.Models.Racers;

public class Hut :  IDriveable
{
    public string Name { get; set; } = "Избушка на курьих ножках";
    public float Speed { get; set; } = 70f;
    public Status Status { get; set; }

    public int Position { get; set; } = 0;
    public int TimeScore { get; set; } = 0;

    public Race Race { get; set; }

    public double MoveFunction(int time)
    {
        return 3 * time * time + 7 * Math.Cos(Math.PI * time / 2);
    }

    public bool Cooldown(int currentTime, PointType pointType)
    {
        double restStart = pointType switch
        {
            PointType.Regular => 30.0,
            PointType.Rain => 25.0,
            PointType.Heat => 35.0,
            _ => 30.0
        };

        double restDuration = 10.0; // Время отдыха 10 минут
        return (currentTime % restStart) < restDuration;
    }
}