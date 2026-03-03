using ConwaysGameOfLife.Lib;
using Xunit;

namespace ConwaysGameOfLife.Test.StepDefinitions;

[Binding]
public sealed class CoreAlgorithmStepDefinitions
{
    private HashSet<(int x, int y)> _liveCells = [];
    private HashSet<(int x, int y)> _nextGenerationLiveCells = [];

    [Given("The board state")]
    public void GivenTheBoardState(Table table)
    {
        _liveCells = ParseLiveCells(table);
    }

    [When("The algorithm runs")]
    public void WhenTheAlgorithmRuns()
    {
        _nextGenerationLiveCells = GameOfLifeAlgorithm.NextGeneration(_liveCells);
    }

    [Then("The board state becomes")]
    public void ThenTheBoardStateBecomes(Table table)
    {
        var expectedGrid = ParseGridRows(table);
        var actualGrid = RenderGridRows(_nextGenerationLiveCells, table);
        Assert.Equal(expectedGrid, actualGrid);
    }

    private static HashSet<(int x, int y)> ParseLiveCells(Table table)
    {
        var columnNames = table.Header.ToArray();
        var xCoordinates = columnNames.Select(int.Parse).ToArray();
        var liveCells = new HashSet<(int x, int y)>();

        for (var y = 0; y < table.Rows.Count; y++)
        {
            var row = table.Rows[y];

            for (var xIndex = 0; xIndex < xCoordinates.Length; xIndex++)
            {
                var x = xCoordinates[xIndex];
                var columnName = columnNames[xIndex];
                if (row[columnName] == "O")
                {
                    liveCells.Add((x, y));
                }
            }
        }

        return liveCells;
    }

    private static string[] ParseGridRows(Table table)
    {
        return [.. table.Rows.Select(row => string.Concat(table.Header.Select(column => row[column])))];
    }

    private static string[] RenderGridRows(HashSet<(int x, int y)> liveCells, Table table)
    {
        var xCoordinates = table.Header.Select(int.Parse).ToArray();
        var renderedRows = new string[table.Rows.Count];

        for (var y = 0; y < table.Rows.Count; y++)
        {
            var row = new char[xCoordinates.Length];
            for (var xIndex = 0; xIndex < xCoordinates.Length; xIndex++)
            {
                row[xIndex] = liveCells.Contains((xCoordinates[xIndex], y)) ? 'O' : '.';
            }

            renderedRows[y] = new string(row);
        }

        return renderedRows;
    }
}
