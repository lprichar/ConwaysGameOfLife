namespace ConwaysGameOfLife.Lib;

public static class GameOfLifeAlgorithm
{
    public static string[] NextGeneration(string[] board)
    {
        var height = board.Length;
        var width = board[0].Length;
        var next = new string[height];

        for (var y = 0; y < height; y++)
        {
            var row = new char[width];

            for (var x = 0; x < width; x++)
            {
                var liveNeighbors = CountLiveNeighbors(board, x, y, width, height);
                var isAlive = board[y][x] == 'O';

                row[x] = isAlive
                    ? (liveNeighbors is 2 or 3 ? 'O' : '.')
                    : (liveNeighbors == 3 ? 'O' : '.');
            }

            next[y] = new string(row);
        }

        return next;
    }

    private static int CountLiveNeighbors(string[] board, int x, int y, int width, int height)
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

                var nx = x + dx;
                var ny = y + dy;

                if (nx < 0 || ny < 0 || nx >= width || ny >= height)
                {
                    continue;
                }

                if (board[ny][nx] == 'O')
                {
                    liveNeighbors++;
                }
            }
        }

        return liveNeighbors;
    }
}
