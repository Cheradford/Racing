using Racing.Domain.Abstraction;


namespace Racing.Domain.Models;

public class Race
{
    public List<IMoveable> Racers { get; set; }
    
    public List<IMoveable> Finished { get; set; }
    public decimal Destination { get; set; }
    public PointType[] Map { get; set; }

    public void Finish(IMoveable moveable)
    {
        if(Finished == null) Finished = new List<IMoveable>();
        //Racers.Remove(moveable);
        Finished.Add(moveable);
    }
    public void SetTime(int time)
    {
        Racers.ForEach(r => 
        {
            r.Race = this;
            r.Move(time);
        });
    }
    
}