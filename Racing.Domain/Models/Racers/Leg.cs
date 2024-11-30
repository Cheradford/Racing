using Racing.Domain.Abstraction;


namespace Racing.Domain.Models.Racers;

public class Leg :  IDriveable
{
    public string Name { get; set; }= "Ступа Бабы Яги";
    public float Speed { get; set; }= 6.95f;
    public Status Status { get; set; }
    public int Position { get; set; }= 0;
    public int TimeScore { get; set; } = 0;
    public Race Race { get; set; }
    
    public double MoveFunction(int time)
    {
        return 5 * time * time + 10 * Math.Sin(2 * Math.PI * time); 
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