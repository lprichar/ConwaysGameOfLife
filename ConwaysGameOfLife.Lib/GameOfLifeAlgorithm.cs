namespace ConwaysGameOfLife.Lib;

public static class GameOfLifeAlgorithm
{
    public static HashSet<(int x, int y)> NextGeneration(IEnumerable<(int x, int y)> liveCells)
    {
        var liveCellSet = liveCells.ToHashSet();
        var candidateCells = new HashSet<(int x, int y)>();

        foreach (var cell in liveCellSet)
        {
            candidateCells.Add(cell);
            AddNeighbors(candidateCells, cell.x, cell.y);
        }

        var nextGeneration = new HashSet<(int x, int y)>();

        foreach (var (x, y) in candidateCells)
        {
            var liveNeighbors = CountLiveNeighbors(liveCellSet, x, y);
            var isAlive = liveCellSet.Contains((x, y));

            if ((isAlive && (liveNeighbors == 2 || liveNeighbors == 3)) || (!isAlive && liveNeighbors == 3))
            {
                nextGeneration.Add((x, y));
            }
        }

        return nextGeneration;
    }

    private static void AddNeighbors(HashSet<(int x, int y)> candidateCells, int x, int y)
    {
        for (var dy = -1; dy <= 1; dy++)
        {
            for (var dx = -1; dx <= 1; dx++)
            {
                if (dx == 0 && dy == 0)
                {
                    continue;
                }

                candidateCells.Add((x + dx, y + dy));
            }
        }
    }

    private static int CountLiveNeighbors(HashSet<(int x, int y)> liveCells, int x, int y)
    {
        var liveNeighbors = 0;

        for (var dy = -1; dy <= 1; dy++)
        {
            for (var dx = -1; dx <= 1; dx++)
            {
                if (dx == 0 && dy == 0)
                {
                    continue;
                }

                if (liveCells.Contains((x + dx, y + dy)))
                {
                    liveNeighbors++;
                }
            }
        }

        return liveNeighbors;
    }
}
