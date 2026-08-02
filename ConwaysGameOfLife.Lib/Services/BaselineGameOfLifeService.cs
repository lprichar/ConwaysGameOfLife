using ConwaysGameOfLife.Lib.Contracts;

namespace ConwaysGameOfLife.Lib.Services;

/// <summary>
/// Baseline Phase 0 implementation for stable contract wiring.
/// This is deterministic scaffolding and does not implement full Conway behavior.
/// </summary>
public sealed class BaselineGameOfLifeService : IGameOfLifeService
{
    private static readonly IReadOnlyDictionary<string, Board> BaselineShapes =
        new Dictionary<string, Board>(StringComparer.OrdinalIgnoreCase)
        {
            ["I-heptomino"] = new(
            [
                new CellCoordinate(0, 0),
                new CellCoordinate(1, 0),
                new CellCoordinate(1, 1),
                new CellCoordinate(2, 1)
            ]),
            ["Gosper's glider gun"] = new(
            [
                new CellCoordinate(0, 0),
                new CellCoordinate(1, 0),
                new CellCoordinate(2, 0),
                new CellCoordinate(2, 1),
                new CellCoordinate(1, 2)
            ])
        };

    public Board CreateEmptyBoard() => Board.Empty;

    public Board LoadShape(string shapeName)
    {
        if (string.IsNullOrWhiteSpace(shapeName))
        {
            throw new ArgumentException("Shape name is required.", nameof(shapeName));
        }

        if (!BaselineShapes.TryGetValue(shapeName, out var shapeBoard))
        {
            throw new ArgumentException($"Shape '{shapeName}' is not available in the baseline service.", nameof(shapeName));
        }

        return new Board(shapeBoard.LiveCells);
    }

    public Board ComputeNextGeneration(Board board)
    {
        ArgumentNullException.ThrowIfNull(board);
        return new Board(board.LiveCells);
    }

    public RenderedBoard Render(Board board, BoardView view)
    {
        ArgumentNullException.ThrowIfNull(board);

        var rows = new List<RenderedRow>(view.Height);
        for (var yOffset = 0; yOffset < view.Height; yOffset++)
        {
            var y = view.OriginY + yOffset;
            var cells = new List<RenderedCell>(view.Width);

            for (var xOffset = 0; xOffset < view.Width; xOffset++)
            {
                var x = view.OriginX + xOffset;
                var coordinate = new CellCoordinate(x, y);
                cells.Add(new RenderedCell(x, board.IsAlive(coordinate)));
            }

            rows.Add(new RenderedRow(y, cells));
        }

        return new RenderedBoard(view.OriginX, view.OriginY, view.Width, view.Height, rows);
    }
}
