using ConwaysGameOfLife.Lib;
using ConwaysGameOfLife.Lib.View;

namespace ConwaysGameOfLife.WebUI.Pages;

public partial class Index
{
    private const int ViewWidth = 20;
    private const int ViewHeight = 20;
    private const string CellSizePx = "18px";
    private const string AliveCell = "O";

    private int _originX;
    private int _originY;
    private string[][] _renderedView = [];

    // Minimal seeded pattern (a blinker) so the grid renders with some live cells.
    // Coordinates here are world coordinates.
    private HashSet<(int x, int y)> _liveCells =
        [
            (9, 8),
            (9, 9),
            (9, 10),
        ];

    protected override void OnInitialized() => RenderView();

    private void Next()
    {
        _liveCells = GameOfLifeAlgorithm.NextGeneration(_liveCells);
        RenderView();
    }

    private void PanLeft()
    {
        _originX -= 1;
        RenderView();
    }

    private void PanRight()
    {
        _originX += 1;
        RenderView();
    }

    private void PanUp()
    {
        _originY -= 1;
        RenderView();
    }

    private void PanDown()
    {
        _originY += 1;
        RenderView();
    }

    private void RenderView() => _renderedView = BoardViewRenderer.Render(_liveCells, _originX, _originY, ViewWidth, ViewHeight);

    private bool IsAliveInView(int x, int y) => _renderedView[y][x] == AliveCell;
}
