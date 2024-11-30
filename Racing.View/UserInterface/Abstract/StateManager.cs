using Racing.Domain.Abstraction;
using Racing.Domain.Models;
using Racing.Infrastructure;
using Racing.View.UserInterface.Screens;
using Spectre.Console;

namespace Racing.View.UserInterface.Abstract;

public class StateManager
{
    public Configuration Config { get; set; } = new Configuration();
    public RacingHandler RacingHandler { get; set; } = new RacingHandler();
    
    public Dictionary<IMoveable, Color> Colors { get; set; } = new Dictionary<IMoveable, Color>();
    public Exception Exception { get; set; }


    public Race GetRace() => RacingHandler.Race;
    public async Task Create()
    {
        RacingHandler.Create(Config);
        foreach (var racer in RacingHandler.Race.Racers)
        {
            Colors.Add(racer, racer.GetRandomHexColor());
        }
    }

    public async Task Clear()
    {
        RacingHandler = new RacingHandler();
        Colors.Clear();
        Exception = null;
        Config = new Configuration();
    }
    public IEnumerable<string> getNames() => RacingHandler.getNames();
    public async Task SetTime(int time) => await RacingHandler.SetTime(time);
}