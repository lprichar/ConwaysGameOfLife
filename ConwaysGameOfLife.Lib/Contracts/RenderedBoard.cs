namespace ConwaysGameOfLife.Lib.Contracts;

public sealed record RenderedBoard(
    int OriginX,
    int OriginY,
    int Width,
    int Height,
    IReadOnlyList<RenderedRow> Rows);

public sealed record RenderedRow(int Y, IReadOnlyList<RenderedCell> Cells);

public readonly record struct RenderedCell(int X, bool IsAlive);
