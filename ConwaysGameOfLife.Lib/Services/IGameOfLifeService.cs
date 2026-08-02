using ConwaysGameOfLife.Lib.Contracts;

namespace ConwaysGameOfLife.Lib.Services;

public interface IGameOfLifeService
{
    Board CreateEmptyBoard();

    Board LoadShape(string shapeName);

    Board ComputeNextGeneration(Board board);

    RenderedBoard Render(Board board, BoardView view);
}
