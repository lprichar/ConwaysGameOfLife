namespace ConwaysGameOfLife.Lib.Demo;

public sealed class Calculator
{
    private int _firstNumber;
    private int _secondNumber;

    public void SetFirstNumber(int value) => _firstNumber = value;

    public void SetSecondNumber(int value) => _secondNumber = value;

    public int Add() => _firstNumber + _secondNumber;
}
