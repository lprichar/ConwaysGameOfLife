namespace ConwaysGameOfLife.Lib.Contracts;

public readonly record struct BoardView
{
    public BoardView(int originX, int originY, int width, int height)
    {
        if (width <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(width), "Width must be greater than zero.");
        }

        if (height <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(height), "Height must be greater than zero.");
        }

        OriginX = originX;
        OriginY = originY;
        Width = width;
        Height = height;
    }

    public int OriginX { get; }

    public int OriginY { get; }

    public int Width { get; }

    public int Height { get; }
}
