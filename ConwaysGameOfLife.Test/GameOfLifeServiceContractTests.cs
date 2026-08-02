using ConwaysGameOfLife.Lib.Contracts;
using ConwaysGameOfLife.Lib.Services;
using Xunit;

namespace ConwaysGameOfLife.Test;

public sealed class GameOfLifeServiceContractTests
{
    [Fact]
    public void Interface_Signature_RemainsStable()
    {
        var methods = typeof(IGameOfLifeService).GetMethods()
            .OrderBy(method => method.Name, StringComparer.Ordinal)
            .ToArray();

        Assert.Collection(
            methods,
            method =>
            {
                Assert.Equal(nameof(IGameOfLifeService.ComputeNextGeneration), method.Name);
                Assert.Equal(typeof(Board), method.ReturnType);
                Assert.Collection(
                    method.GetParameters(),
                    parameter =>
                    {
                        Assert.Equal("board", parameter.Name);
                        Assert.Equal(typeof(Board), parameter.ParameterType);
                    });
            },
            method =>
            {
                Assert.Equal(nameof(IGameOfLifeService.CreateEmptyBoard), method.Name);
                Assert.Equal(typeof(Board), method.ReturnType);
                Assert.Empty(method.GetParameters());
            },
            method =>
            {
                Assert.Equal(nameof(IGameOfLifeService.LoadShape), method.Name);
                Assert.Equal(typeof(Board), method.ReturnType);
                Assert.Collection(
                    method.GetParameters(),
                    parameter =>
                    {
                        Assert.Equal("shapeName", parameter.Name);
                        Assert.Equal(typeof(string), parameter.ParameterType);
                    });
            },
            method =>
            {
                Assert.Equal(nameof(IGameOfLifeService.Render), method.Name);
                Assert.Equal(typeof(RenderedBoard), method.ReturnType);
                Assert.Collection(
                    method.GetParameters(),
                    boardParameter =>
                    {
                        Assert.Equal("board", boardParameter.Name);
                        Assert.Equal(typeof(Board), boardParameter.ParameterType);
                    },
                    viewParameter =>
                    {
                        Assert.Equal("view", viewParameter.Name);
                        Assert.Equal(typeof(BoardView), viewParameter.ParameterType);
                    });
            });
    }

    [Fact]
    public void Board_CopiesInputToImmutableSet()
    {
        var mutableSource = new List<CellCoordinate> { new(0, 0) };

        var board = new Board(mutableSource);
        mutableSource.Add(new CellCoordinate(1, 1));
        var liveCells = board.LiveCells.ToArray();

        Assert.Single(board.LiveCells);
        Assert.Contains(new CellCoordinate(0, 0), liveCells);
        Assert.DoesNotContain(new CellCoordinate(1, 1), liveCells);
    }

    [Fact]
    public void Baseline_Service_IsDeterministic_ForRender()
    {
        IGameOfLifeService service = new BaselineGameOfLifeService();
        var board = service.LoadShape("I-heptomino");
        var view = new BoardView(0, 0, 4, 3);

        var first = service.Render(board, view);
        var second = service.Render(board, view);

        Assert.Equal(first.OriginX, second.OriginX);
        Assert.Equal(first.OriginY, second.OriginY);
        Assert.Equal(first.Width, second.Width);
        Assert.Equal(first.Height, second.Height);
        Assert.Equal(
            first.Rows.SelectMany(row => row.Cells).Select(cell => cell.IsAlive),
            second.Rows.SelectMany(row => row.Cells).Select(cell => cell.IsAlive));
    }
}
