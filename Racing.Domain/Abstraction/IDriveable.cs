using Racing.Domain.Models;
using Racing.Domain.Models.Racers;

namespace Racing.Domain.Abstraction;

public interface IDriveable : IMoveable
{
    void IMoveable.Move(int time)
    {
        if (Status != Status.Finished)
        {
            Status = Status.Running;
            var type = Race.Map[Position];
            
            if (!Cooldown(time, type))
            {
                Position = (int)MoveFunction(time);
            }

            if (Race.Destination <= Position)
            {
                Position = (int)Race.Destination;
                TimeScore = time;
                Status = Status.Finished;
                Race.Finish(this);
            }
        }
    }
    public bool Cooldown(int currentTime, PointType pointType);
}