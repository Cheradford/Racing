using Racing.Domain.Abstraction;
using Racing.Domain.Models.Racers;

namespace Racing.Infrastructure;

public static class RacerRegistration
{
    public static void RegisterRacers(RacersFactory factory)
    {
        factory.Register("Сапоги-скороходы", () => new Boots());
        factory.Register("Метла", () => new Broomstick());
        factory.Register("Ковер-самолет", () => new Carpet());
        factory.Register("Кентавр", () => new Centaur());
        factory.Register("Карета-тыква", () => new Coach());
        factory.Register("Летучий корабль", () => new FlyingShip());
        factory.Register("Избушка на курьих ножках", () => new Hut());
        factory.Register("Ступа Бабы Яги", () => new Leg());
    }
}