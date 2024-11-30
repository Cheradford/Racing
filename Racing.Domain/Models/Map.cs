namespace Racing.Domain.Models;

public class Map
{
    public PointType[] Points { get; set; }

    public Map(int destination)
    {
        Points = new PointType[destination];
        
    }
}