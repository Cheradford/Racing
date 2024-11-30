using Racing.View.UserInterface.Abstract;

namespace Racing.View.UserInterface.Screens;

public abstract class ScreenBase(IObserver observer, StateManager stateManager) : IShowable
{
    public abstract ScreenType Current { get; set; }
    public abstract ScreenType Next { get; set; }
    public IObserver Observer { get; set; } = observer;
    public StateManager StateManager { get; set; } = stateManager;

    public abstract Task InnerHandler();
}