namespace ConwaysGameOfLife.WebUI.Pages;

public partial class Index
{
    private static int NumberOne => 40;
    private static int NumberTwo => 2;
    private int Sum { get; set; }

    protected override void OnInitialized()
    {
        var calculator = new Lib.Demo.Calculator();
        calculator.SetFirstNumber(NumberOne);
        calculator.SetSecondNumber(NumberTwo);
        Sum = calculator.Add();

        base.OnInitialized();
    }
}
