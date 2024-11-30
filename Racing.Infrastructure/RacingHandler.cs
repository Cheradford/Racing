using Racing.Domain.Abstraction;
using Racing.Domain.Models;

namespace Racing.Infrastructure;

public class RacingHandler
{
    protected RacersFactory RacersFactory = new RacersFactory();
    public Race Race;

    public RacingHandler()
    {
        RacersFactory = new();
        RacerRegistration.RegisterRacers(RacersFactory);
    }
    public Race Create(Configuration config)
    {
        var racers = RacersFactory.Create(config.Racers.ToArray()).ToList();
        IsValid(config.Type, racers);

        Race = new Race
        {
            Racers = racers, Destination = config.Destination,
            Map = GenerateWeightedRandomArray(GenerateMapSize(config.Destination, 4), new[] { 0.7, 0.15, 0.15 })
        };
        return Race;
    }
    public IEnumerable<string> getNames() => RacersFactory.getNames();
    
    public async Task SetTime(int time)
    {
        Race.SetTime(time);
    }

    private int GenerateMapSize(decimal mapSize, int numberOfSize)
    {
        var roundedMapSize = (int) Math.Round(mapSize, 2);
        var rem = roundedMapSize % numberOfSize;
        if (rem == 0) return roundedMapSize;
        var offset = numberOfSize - rem;
        return roundedMapSize + offset;
    }
    private PointType[] GenerateWeightedRandomArray(int size, double[] weights)
    {
        if (weights.Length == 0 || (int) weights.Sum() != 1 )
        {
            throw new ArgumentException("Weights must be non-empty and sum to 1.");
        }

        var array = new PointType[size];
        Random random = new Random();

        // Generate weighted random numbers
        for (int i = 0; i < size; i++)
        {
            double randValue = random.NextDouble();
            double cumulative = 0;

            for (int j = 0; j < weights.Length; j++)
            {
                cumulative += weights[j];
                if (randValue < cumulative)
                {
                    array[i] = (PointType)j;
                    break;
                }
            }
        }

        return array;
    }

    private void IsValid(RaceType type, List<IMoveable> racers)
    {
        if (racers == null || racers.Count < 2) throw new NullReferenceException("Racers are empty or less then 2");
        if (type == RaceType.Mixed) return;
        Func<IMoveable, bool> validator = type == RaceType.Ground
            ? (racer) => racer is not IDriveable
            : (racer) => racer is not IFlyable;
        if (racers.Any(validator))
        {
            throw new InvalidDataException("Selected races are invalid for this type of racing");
        }
            
    }
}