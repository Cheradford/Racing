using Racing.View.UserInterface.Abstract;
using Spectre.Console;

namespace Racing.View.UserInterface.Screens;

public interface IShowable
{
    public ScreenType Current { get; }
    public ScreenType Next { get; }
    public IObserver Observer { get; set; }
    
    public async Task Show()
    {
        AnsiConsole.Clear();
        await InnerHandler();
        await Observer.Set(Next);
    }
    public Task InnerHandler();
}