using Racing.Domain.Abstraction;


namespace Racing.Domain.Models.Racers;

public class Coach :IDriveable
{
    public string Name { get; set; } = "Карета-тыква";
    public float Speed { get; set; } = 60f;
    public Status Status { get; set; }

    public int Position { get; set; } = 0;
    public int TimeScore { get; set; } = 0;
    public Race Race { get; set; }
    public double MoveFunction(int time)
    {
        var accelerationAmplitude = 3;
        var frequency = 2;
        double integral = 0;
        double step = 0.01;
        for (double t = 0; t <= time; t += step)
        {
            integral += (Speed + accelerationAmplitude * Math.Cos(frequency * t)) * step;
        }
        return integral;
    }
    
    public bool Cooldown(int currentTime, PointType pointType)
    {
        double restStart = pointType switch
        {
            PointType.Regular => 20.0,
            PointType.Rain => 15.0,
            PointType.Heat => 25.0,
            _ => 20.0
        };

        double restDuration = 5.0; // Время отдыха 5 минут
        return (currentTime % restStart) < restDuration;
    }
}