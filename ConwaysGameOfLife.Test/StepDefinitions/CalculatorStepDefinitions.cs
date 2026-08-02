using ConwaysGameOfLife.Lib.Contracts;
using ConwaysGameOfLife.Lib.Services;
using Xunit;

namespace ConwaysGameOfLife.Test.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private IGameOfLifeService? _service;
        private Board? _board;
        private Board? _loadedBoardOne;
        private Board? _loadedBoardTwo;
        private Board? _nextGenerationOne;
        private Board? _nextGenerationTwo;
        private RenderedBoard? _renderedBoard;

        [Given("a baseline game of life service")]
        public void GivenABaselineGameOfLifeService()
        {
            _service = new BaselineGameOfLifeService();
        }

        [Given("the shape {string} is loaded as the current board")]
        public void GivenTheShapeIsLoadedAsTheCurrentBoard(string shapeName)
        {
            Assert.NotNull(_service);
            _board = _service.LoadShape(shapeName);
        }

        [When("an empty board is created")]
        public void WhenAnEmptyBoardIsCreated()
        {
            Assert.NotNull(_service);
            _board = _service.CreateEmptyBoard();
        }

        [When("the board is rendered at origin {int},{int} with width {int} and height {int}")]
        public void WhenTheBoardIsRenderedAtOriginWithWidthAndHeight(int originX, int originY, int width, int height)
        {
            Assert.NotNull(_service);
            Assert.NotNull(_board);
            _renderedBoard = _service.Render(_board, new BoardView(originX, originY, width, height));
        }

        [When("the shape {string} is loaded twice")]
        public void WhenTheShapeIsLoadedTwice(string shapeName)
        {
            Assert.NotNull(_service);
            _loadedBoardOne = _service.LoadShape(shapeName);
            _loadedBoardTwo = _service.LoadShape(shapeName);
        }

        [When("next generation is computed twice from the current board")]
        public void WhenNextGenerationIsComputedTwiceFromTheCurrentBoard()
        {
            Assert.NotNull(_service);
            Assert.NotNull(_board);
            _nextGenerationOne = _service.ComputeNextGeneration(_board);
            _nextGenerationTwo = _service.ComputeNextGeneration(_board);
        }

        [Then("the rendered board has {int} rows and each row has {int} cells")]
        public void ThenTheRenderedBoardHasRowsAndEachRowHasCells(int expectedRows, int expectedColumns)
        {
            Assert.NotNull(_renderedBoard);
            Assert.Equal(expectedRows, _renderedBoard.Rows.Count);
            Assert.All(_renderedBoard.Rows, row => Assert.Equal(expectedColumns, row.Cells.Count));
        }

        [Then("all rendered cells are dead")]
        public void ThenAllRenderedCellsAreDead()
        {
            Assert.NotNull(_renderedBoard);
            Assert.All(_renderedBoard.Rows, row =>
                Assert.All(row.Cells, cell => Assert.False(cell.IsAlive)));
        }

        [Then("both loaded boards have the same live-cell set")]
        public void ThenBothLoadedBoardsHaveTheSameLiveCellSet()
        {
            Assert.NotNull(_loadedBoardOne);
            Assert.NotNull(_loadedBoardTwo);
            Assert.Equal(_loadedBoardOne.LiveCells, _loadedBoardTwo.LiveCells);
        }

        [Then("both next-generation boards have the same live-cell set")]
        public void ThenBothNextGenerationBoardsHaveTheSameLiveCellSet()
        {
            Assert.NotNull(_nextGenerationOne);
            Assert.NotNull(_nextGenerationTwo);
            Assert.Equal(_nextGenerationOne.LiveCells, _nextGenerationTwo.LiveCells);
        }
    }
}
