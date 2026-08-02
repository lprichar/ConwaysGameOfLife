using System.Collections.Frozen;

namespace ConwaysGameOfLife.Lib.Contracts;

public sealed record Board
{
    public static Board Empty { get; } = new([]);

    public Board(IEnumerable<CellCoordinate> liveCells)
    {
        ArgumentNullException.ThrowIfNull(liveCells);
        LiveCells = liveCells.ToFrozenSet();
    }

    public FrozenSet<CellCoordinate> LiveCells { get; }

    public bool IsAlive(CellCoordinate coordinate) => LiveCells.Contains(coordinate);
}
