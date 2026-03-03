using Xunit;
using ConwaysGameOfLife.Lib.View;

namespace ConwaysGameOfLife.Test.StepDefinitions
{
    [Binding]
    public sealed class ViewStepDefinitions
    {
        private readonly HashSet<(int x, int y)> _liveCells = [];
        private int _originX;
        private int _originY;
        private int _width;
        private int _height;
        private string[][]? _rendered;

        [Given("An initial board state of tuples like")]
        public void GivenAnInitialBoardStateOfTuplesLike(Table tuples)
        {
            _liveCells.Clear();

            foreach (var row in tuples.Rows)
            {
                var x = int.Parse(row["x"]);
                var y = int.Parse(row["y"]);
                _liveCells.Add((x, y));
            }
        }

        [Given(@"the initial view is \((-?\d+),(-?\d+)\), width = (\d+), height = (\d+)")]
        public void GivenTheInitialViewIsWidthHeight(int x, int y, int width, int height)
        {
            SetView(x, y, width, height);
        }

        [When("The board is rendered")]
        public void WhenTheBoardIsRendered()
        {
            _rendered = BoardViewRenderer.Render(_liveCells, _originX, _originY, _width, _height);
        }

        [When(@"The view is set to \((-?\d+),(-?\d+)\), width = (\d+), height = (\d+)")]
        public void WhenTheViewIsSetToWidthHeight(int x, int y, int width, int height)
        {
            SetView(x, y, width, height);
            _rendered = BoardViewRenderer.Render(_liveCells, _originX, _originY, _width, _height);
        }

        [Then("the rendered view becomes")]
        public void ThenTheRenderedViewBecomes(Table renderedView)
        {
            Assert.NotNull(_rendered);

            var expectedHeaders = renderedView.Header.ToArray();
            var expectedHeaderRange = Enumerable
                .Range(_originX, _width)
                .Select(value => value.ToString())
                .ToArray();
            Assert.Equal(expectedHeaderRange, expectedHeaders);

            Assert.Equal(_height, renderedView.Rows.Count);
            for (var rowIndex = 0; rowIndex < renderedView.Rows.Count; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < _width; columnIndex++)
                {
                    var header = expectedHeaders[columnIndex];
                    var expected = renderedView.Rows[rowIndex][header].Trim();
                    var actual = _rendered[rowIndex][columnIndex];
                    Assert.Equal(expected, actual);
                }
            }
        }

        private void SetView(int x, int y, int width, int height)
        {
            _originX = x;
            _originY = y;
            _width = width;
            _height = height;
        }
    }
}
