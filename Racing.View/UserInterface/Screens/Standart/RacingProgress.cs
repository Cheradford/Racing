using Racing.View.Elements;
using Racing.View.UserInterface.Abstract;
using Spectre.Console;
using Status = Racing.Domain.Models.Racers.Status;

namespace Racing.View.UserInterface.Screens.Standart;

public class RacingProgress : ScreenBase
{
    public override ScreenType Current { get; set; } = ScreenType.Racing;
    public override ScreenType Next { get; set; } = ScreenType.Summary;
    

    private Layout Root;
    private RaceMap Progress;
    private RaceTable Table;

    public async override Task InnerHandler()
    {
        await AnsiConsole.Live(Root).Start(async ctx =>
        {
            int time = 1;
            while (StateManager.Colors.Keys.Any(mov => mov.Status != Status.Finished))
            {
                await StateManager.SetTime(time);
                Update();
                ctx.Refresh();
                Thread.Sleep(1000);
                time++;
            }
        });
        
    }

    public RacingProgress(IObserver observer, StateManager stateManager) : base(observer, stateManager)
    {
        Root = new Layout("Root").SplitRows(
            new Layout("Racing"),
            new Layout("Table"));
        
        Update();
    }

    private void Update()
    {
        Progress = new RaceMap(StateManager);
        Table = new RaceTable(StateManager);
        
        Root["Racing"].Update(new Panel(Progress).Header("Racing", Justify.Center).Border(BoxBorder.Rounded).Expand());
        Root["Table"].Update(Table);
    }
}