using Racing.View.UserInterface.Abstract;
using Spectre.Console.Rendering;

namespace Racing.View.Elements;

public abstract class BaseElement<T>(StateManager stateManager) : Renderable where T : IRenderable
{
    public T Element { get; set; }
    public StateManager StateManager { get; set; } = stateManager;

    protected abstract void Configure(RenderOptions options, int maxWidth);
    protected override IEnumerable<Segment> Render(RenderOptions options, int maxWidth)
    {
        Configure(options, maxWidth);
        return Element.Render(options, maxWidth);
    }
}