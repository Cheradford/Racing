using Racing.View.UserInterface.Screens;

namespace Racing.View.UserInterface.Abstract;

public interface IObserver
{
    public Task Set(ScreenType type);
    public Task Close();
}