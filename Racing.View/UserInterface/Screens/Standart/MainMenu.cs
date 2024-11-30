using Racing.View.UserInterface.Abstract;
using Spectre.Console;

namespace Racing.View.UserInterface.Screens.Standart;

public class MainMenu(IObserver observer, StateManager stateManager) : ScreenBase(observer, stateManager)
{
    public override ScreenType Current { get; set; } = ScreenType.MainMenu;
    public override ScreenType Next { get; set; } = ScreenType.RaceType;

    public override async Task InnerHandler()
    {
        AnsiConsole.Write(new FigletText("National Racing").Centered());
        AnsiConsole.WriteLine();
        var key = AnsiConsole.Prompt(
            new SelectionPrompt<ScreenType>()
                .Title("Добро пожаловать на национальные гонки! Пожалуйста выберите действие из списка ниже:")
                .AddChoices(ScreenType.RaceType, ScreenType.None)
                .UseConverter(sc => sc.GetDescription())
        );
        Next = key;
        
    }
}