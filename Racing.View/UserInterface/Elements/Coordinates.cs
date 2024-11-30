namespace Racing.View.Elements;

class Coordinates
{
    public int X { get; set; }
    public int Y { get; set; }

    public static Coordinates operator +(Coordinates a, Coordinates b)
    {
        a.X += b.X;
        a.Y += b.Y;
        return a;
    }

    public static Coordinates operator *(Coordinates a, int k)
    {
        return new Coordinates(a.X * k, a.Y * k);
    }
    public Coordinates(int x, int y)
    {
        X = x;
        Y = y;
    }
}