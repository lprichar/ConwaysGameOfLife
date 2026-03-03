namespace ConwaysGameOfLife.WebUI.Pages;

public partial class Index
{
    private const int ViewWidth = 20;
    private const int ViewHeight = 20;
    private const string CellSizePx = "18px";

    // Minimal seeded pattern (a blinker) so the grid renders with some live cells.
    // Coordinates here are view-local (0..ViewWidth-1, 0..ViewHeight-1).
    private readonly HashSet<(int x, int y)> _liveCells =
    [
        (9, 8),
        (9, 9),
        (9, 10),
    ];

    private bool IsAlive(int x, int y) => _liveCells.Contains((x, y));
}
