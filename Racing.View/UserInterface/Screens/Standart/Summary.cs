using Racing.View.Elements;
using Racing.View.UserInterface.Abstract;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Racing.View.UserInterface.Screens.Standart;

public class Summary(IObserver observer, StateManager stateManager) : ScreenBase(observer, stateManager)
{
    public override ScreenType Current { get; set; } = ScreenType.Summary;
    public override ScreenType Next { get; set; } = ScreenType.MainMenu;
    public override async Task InnerHandler()
    {

        var racers = StateManager.RacingHandler.Race.Finished;
        var colors = new[] { Color.Gold1, Color.Silver, Color.SandyBrown, Color.White };
        
        AnsiConsole.Write(new FigletText("Racing").Centered());
        AnsiConsole.Write(new Rule("[yellow]Итоги гонки[/]").Centered());
        
        var Element = new Table()
            .Expand()
            .Border(TableBorder.Rounded)
            .Centered()
            .AddColumns(
                new TableColumn("#"), 
                new TableColumn("Имя"), 
                new TableColumn("Время")
            );
        
        for (int i = 0; i < racers.Count; i++)
        {
            var color = colors[Math.Min(i, colors.Length - 1)];
            var racer = racers[i];
            var position = color.FormatString(i + 1);
            var name = color.FormatString(racer.Name);
            var time = color.FormatString(racer.TimeScore);
            
            Element.AddRow(position, name, time);
        }
        
        AnsiConsole.Write(Element);
        
        AnsiConsole.MarkupLine("\n[dim]Нажмите [bold]любую кнопку[/], чтобы продолжить...[/]");
        Console.ReadKey();
        
        StateManager.Clear();

    }
}