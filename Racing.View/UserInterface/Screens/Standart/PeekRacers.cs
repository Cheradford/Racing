using Racing.Domain.Abstraction;
using Racing.View.UserInterface.Abstract;
using Spectre.Console;

namespace Racing.View.UserInterface.Screens.Standart;

public class PeekRacers(IObserver observer, StateManager stateManager) : ScreenBase(observer, stateManager)
{
    public override ScreenType Current { get; set; } = ScreenType.RacersPeek;
    public override ScreenType Next { get; set; } = ScreenType.Test;
    public override async Task InnerHandler()
    {
        AnsiConsole.WriteLine();
        var racers = AnsiConsole.Prompt(
            new MultiSelectionPrompt<string>()
                .Title("Выберите персонажей для гонки. Пожалуйста учитывайте, что не все персонажи подходят для всех типов гонки. " +
                       "В случае если персонаж не подходит, то произойдет ошибка с возвратом в главное меню.")
                .InstructionsText("Для выбора персонажа нажмите кнопку пробел. \n" +
                                  "Для подтверждения выбранных персонажей нажмите кнопки enter.")
                .AddChoices(stateManager.getNames())
        );
        StateManager.Config.Racers = racers;
        await StateManager.Create();
    }
}