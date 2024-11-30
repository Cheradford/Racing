using Racing.View.UserInterface.Abstract;
using Spectre.Console;

namespace Racing.View.UserInterface.Screens.Standart;

public class RaceDistance(IObserver observer, StateManager stateManager) : ScreenBase(observer, stateManager)
{
    public override ScreenType Current { get; set; } = ScreenType.RaceDistance;
    public override ScreenType Next { get; set; } = ScreenType.RacersPeek;
    public override async Task InnerHandler()
    {
        var distance = AnsiConsole.Prompt(
            new TextPrompt<decimal>("Введите дистанцию для участников гонки в метрах")
                .DefaultValue(500));
        stateManager.Config.Destination = distance;
    }
}