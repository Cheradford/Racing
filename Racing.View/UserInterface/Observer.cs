using System.Text;
using Racing.Infrastructure;
using Racing.View.UserInterface.Abstract;
using Racing.View.UserInterface.Screens;
using Racing.View.UserInterface.Screens.Standart;
using Spectre.Console;

namespace Racing.View;

public class Observer : IObserver
{
    public Dictionary<ScreenType, IShowable> Screens { get; set; }
    public RacingHandler RacingHandler { get; set; } = new();
    public StateManager StateManager { get; set; } = new();

    public Observer()
    {
        Screens = new()
        {
            { ScreenType.MainMenu, new MainMenu(this, StateManager) },
            { ScreenType.RaceType, new RaceSelection(this, StateManager) },
            { ScreenType.Error, new Error(this, StateManager) },
            { ScreenType.Test, new RacingProgress(this, StateManager) },
            { ScreenType.RacersPeek, new PeekRacers(this, StateManager) },
            { ScreenType.RaceDistance, new RaceDistance(this, StateManager) },
            { ScreenType.Summary, new Summary(this, StateManager) },
        };
        AnsiConsole.Clear();
        Set(ScreenType.MainMenu);
    }


    public async Task Set(ScreenType type)
    {
        try
        {
            if (Screens.TryGetValue(type, out IShowable screen))
            {
                await screen.Show();
            }
            
        }
        catch (Exception e)
        {
            StateManager.Exception = e;
            await Screens[ScreenType.Error].Show();
        }
    }

    public async Task Close()
    {
        
    }
}