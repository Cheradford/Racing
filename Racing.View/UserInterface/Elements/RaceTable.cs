using Racing.View.UserInterface.Abstract;
using Racing.View.UserInterface.Screens;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Racing.View.Elements;

public class RaceTable(StateManager stateManager):BaseElement<Table>(stateManager)
{

    protected override void Configure(RenderOptions options, int maxWidth)
    {
        Element = new Table()
        .Expand()
        .Border(TableBorder.Rounded)
        .Centered()
        .AddColumns(
            new TableColumn("#"), 
            new TableColumn("Имя"), 
            new TableColumn("Пройденное расстояние")
            );
        
        var sortedRacers = stateManager.RacingHandler.Race.Racers.OrderByDescending(im => im.Position).ToArray();
        
        for (int i = 0; i < sortedRacers.Length; i++)
        {
            var racer = sortedRacers[i];
            var color = stateManager.Colors[racer];
            var index = color.FormatString(i+1);
            var name = color.FormatString(racer.Name);
            var position = color.FormatString(racer.Position);
            
            Element.AddRow(index, name, position);
        }
        
    }


}