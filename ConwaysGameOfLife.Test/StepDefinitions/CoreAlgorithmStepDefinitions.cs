using Xunit;

namespace ConwaysGameOfLife.Test.StepDefinitions;

[Binding]
public sealed class CoreAlgorithmStepDefinitions
{
    private string[] _board = [];
    private string[] _nextBoard = [];

    [Given("The board state")]
    public void GivenTheBoardState(Table table)
    {
        _board = ParseBoard(table);
    }

    [When("The algorithm runs")]
    public void WhenTheAlgorithmRuns()
    {
        _nextBoard = [.. _board];
    }

    [Then("The board state becomes")]
    public void ThenTheBoardStateBecomes(Table table)
    {
        var expected = ParseBoard(table);
        Assert.Equal(expected, _nextBoard);
    }

    private static string[] ParseBoard(Table table)
    {
        return [.. table.Rows.Select(row => string.Concat(table.Header.Select(column => row[column])))];
    }
}
