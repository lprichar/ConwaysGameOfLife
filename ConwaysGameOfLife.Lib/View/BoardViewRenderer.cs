namespace ConwaysGameOfLife.Lib.View;

public static class BoardViewRenderer
{
    public static string[][] Render(
        IReadOnlySet<(int x, int y)> liveCells,
        int originX,
        int originY,
        int width,
        int height)
    {
        var rows = new string[height][];

        for (var y = 0; y < height; y++)
        {
            rows[y] = new string[width];

            for (var x = 0; x < width; x++)
            {
                var worldX = originX + x;
                var worldY = originY + y;
                rows[y][x] = liveCells.Contains((worldX, worldY)) ? "O" : ".";
            }
        }

        return rows;
    }
}
