using Racing.Domain.Models;
using Racing.Domain.Models.Racers;
using Racing.Infrastructure;

namespace Racing.Domain.Abstraction;

public abstract class Moveable : IMoveable
{
    public abstract static string Name { get; }
}