using System.Collections.Frozen;
using System.Collections.ObjectModel;

namespace ConwaysGameOfLife.Lib.Contracts;

public sealed record Board
{
    public static Board Empty { get; } = new([]);

    public Board(IEnumerable<CellCoordinate> liveCells)
    {
        ArgumentNullException.ThrowIfNull(liveCells);
        var uniqueCells = liveCells.Distinct().ToList();
        LiveCells = new ReadOnlyCollection<CellCoordinate>(uniqueCells);
        _liveCellLookup = uniqueCells.ToFrozenSet();
    }

    private readonly FrozenSet<CellCoordinate> _liveCellLookup;

    public IList<CellCoordinate> LiveCells { get; }

    public bool IsAlive(CellCoordinate coordinate) => _liveCellLookup.Contains(coordinate);
}
