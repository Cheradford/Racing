using Racing.Domain.Abstraction;
using Racing.View.UserInterface.Abstract;
using Spectre.Console;

namespace Racing.View.UserInterface.Screens.Standart;

public class RaceSelection(IObserver observer, StateManager stateManager) : ScreenBase(observer, stateManager)
{
    public override ScreenType Current { get; set; } =  ScreenType.RaceType;
    public override ScreenType Next { get; set; } = ScreenType.RaceDistance;
    public override async Task InnerHandler()
    {
        AnsiConsole.Write(new FigletText("National Racing").Centered());
        AnsiConsole.WriteLine();
        var key = AnsiConsole.Prompt(
            new SelectionPrompt<RaceType>()
                .Title("Выберите тип гонки из списка ниже:")
                .AddChoices(Enum.GetValues<RaceType>())
                .UseConverter(sc => sc.GetDescription())
        );
        StateManager.Config.Type = key;
    }
}