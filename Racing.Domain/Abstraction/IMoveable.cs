using Racing.Domain.Models;
using Racing.Domain.Models.Racers;

namespace Racing.Domain.Abstraction;

public interface IMoveable
{ 
    public string Name { get; set; }
    public float Speed { get; set; }
    public Status Status { get; set; }
    public int Position { get; set; }
    public int TimeScore { get; set; }
    public Race Race { get; set; }
    public double MoveFunction(int time);
    public void Move(int time);
}