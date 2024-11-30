using Racing.Domain.Models.Racers;

namespace Racing.Domain.Abstraction;

public class RacersFactory
{
    private readonly Dictionary<string, Func<IMoveable?>> _moves = new();
    

    public void Register(string name, Func<IMoveable> move)
    {
        if(!_moves.TryAdd(name, move)) throw new ArgumentException($"The name {name} is already registered.");
    }
    public IEnumerable<string> getNames()
    {
        return _moves.Keys;
    }
    public IEnumerable<IMoveable> Create(params string[] keys)
    {
        List<IMoveable> moves = new();
        foreach (var key in keys)
        {
            if (_moves.TryGetValue(key, out var creator))
            {
                var moveable = creator();
                moves.Add(moveable);
            }
        }
        
        return moves;
    }
}