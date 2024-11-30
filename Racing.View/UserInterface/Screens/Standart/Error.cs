using System.Text.Json;
using Racing.View.UserInterface.Abstract;
using Spectre.Console;
using Spectre.Console.Json;

namespace Racing.View.UserInterface.Screens.Standart;

public class Error(IObserver observer, StateManager stateManager) : ScreenBase(observer, stateManager)
{
    public override ScreenType Current { get; set; } = ScreenType.Error;
    public override ScreenType Next { get; set; } = ScreenType.MainMenu;
    public async override Task InnerHandler()
    {
        
        var message = new Panel($"[bold yellow]Внимание ошибка![/]\n" +
                                $"{StateManager.Exception.Source}:{StateManager.Exception.Message}" +
                                $"")
        {
            Border = BoxBorder.Rounded,
            Padding = new Padding(1, 1),
        };
        var data = new JsonText(JsonSerializer.Serialize(StateManager.Exception));

        /*// Рассчитываем количество строк для отступа сверху
        var verticalPadding = (consoleHeight / 2) - 4; // Учитываем высоту сообщения и кнопки

        // Добавляем пустые строки сверху
        for (int i = 0; i < verticalPadding; i++)
        {
            AnsiConsole.WriteLine();
        }*/

        // Выводим сообщение с горизонтальным центрированием
        AnsiConsole.Write(
            new Align
            (
                message,
                HorizontalAlignment.Center,
                VerticalAlignment.Middle
            ));
        AnsiConsole.Write(
            new Panel(data)
                .Collapse()
                .RoundedBorder()
                .BorderColor(Color.Yellow)
            );
        // Оставляем место для кнопки
        AnsiConsole.WriteLine();

        // Кнопка "Ок"
        AnsiConsole.Write(
            new Align
            (
                new Markup("[bold green]Ок[/]"),
                HorizontalAlignment.Center,
                VerticalAlignment.Middle
            ));

        // Ожидание нажатия клавиши Enter
        AnsiConsole.MarkupLine("\n[dim]Нажмите [bold]любую кнопку[/], чтобы продолжить...[/]");
        Console.ReadLine();
    
    }
}