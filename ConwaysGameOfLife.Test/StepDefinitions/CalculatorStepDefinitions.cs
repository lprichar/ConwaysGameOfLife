using ConwaysGameOfLife.Lib.Demo;
using Xunit;

namespace ConwaysGameOfLife.Test.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private readonly Calculator _calculator = new();
        private bool _hasResult;
        private int _result;

        [Given("the first number is {int}")]
        public void GivenTheFirstNumberIs(int number)
        {
            _calculator.SetFirstNumber(number);
        }

        [Given("the second number is {int}")]
        public void GivenTheSecondNumberIs(int number)
        {
            _calculator.SetSecondNumber(number);
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            _result = _calculator.Add();
            _hasResult = true;
        }

        [Then("the result should be {int}")]
        public void ThenTheResultShouldBe(int result)
        {
            Assert.True(_hasResult, "Perform addition before asserting the result.");
            Assert.Equal(result, _result);
        }
    }
}
