using Racing.Domain.Models;
using Racing.Domain.Models.Racers;

namespace Racing.Domain.Abstraction;

public interface IFlyable : IMoveable
{
    void IMoveable.Move(int time)
    {
        if (Status != Status.Finished)
        {
            Status = Status.Running;


            Position = (int)MoveFunction(time);


            if (Race.Destination <= Position)
            {
                Position = (int)Race.Destination;
                TimeScore = time;
                Status = Status.Finished;
                Race.Finish(this);
            }
        }
    }

    public double AccelerationRatio(int passedWay, PointType pointType);
}