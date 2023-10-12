using System;
using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace CalculatorQuest;

public partial class CalculatorScreen : Window
{
    private Calc _calc = new Calc();
    public CalculatorScreen()
    {
        this.Height = 320;
        this.Width = 250;
        
        InitializeComponent();
        Result.Content = "";
        Operation.Content = "";

    }

    private void Click_number(object? sender, RoutedEventArgs routedEventArgs)
    {
        if (_calc.res != 0f)
        {
            ClearAl(sender, routedEventArgs);
        }
        Button? clickedButton = (sender as Button);
        Result.Content += clickedButton.Content.ToString();
        
    }
    
    private void Click_ope(object? sender, RoutedEventArgs routedEventArgs)
    {
        Button? clickedButton = (sender as Button);
        if (_calc.ope == "")
        {
            Console.WriteLine("on add");
            Operation.Content += Result.Content + clickedButton.Content.ToString();
            _calc.member_1 = Result.Content.ToString();
            Result.Content = "";
            _calc.ope = clickedButton.Content.ToString();
        }
        else
        {
            _calc.ope = clickedButton.Content.ToString();
            Operation.Content = Operation.Content.ToString().Substring(0, Operation.Content.ToString().Length - 1);
            Operation.Content += clickedButton.Content.ToString();
        }
    }

    private void Operator(object? sender, RoutedEventArgs e)
    {
        _calc.member_2 = Result.Content.ToString();
        Operation.Content += Result.Content.ToString();
        if (!((_calc.member_2 == "" && _calc.ope == "") || (_calc.member_1 == "")))
        {
            Result.Content = "=" + _calc.Operator();
        }
    }

    private void ClearEnt(object? sender, RoutedEventArgs e)
    {
        Button? clickedButton = (sender as Button);
        Result.Content = "";
        _calc.ope = "";
        _calc.member_1 = "";
        _calc.member_2 = "";
        _calc.res = 0f;
    }
    private void ClearAl(object? sender, RoutedEventArgs e)
    {
        Button? clickedButton = (sender as Button);
        Result.Content = "";
        Operation.Content = "";
        _calc.ope = "";
        _calc.member_1 = "";
        _calc.member_2 = "";
        _calc.res = 0f;
    }
    private void Delete(object? sender, RoutedEventArgs e)
    {
        Button? clickedButton = (sender as Button);
        if (Result.Content.ToString().Length > 0)
        {
            Result.Content = Result.Content.ToString()?.Substring(0, Result.Content.ToString().Length - 1);
        }
    }

    private void Sign_(object? sender, RoutedEventArgs e)
    {
        Button? clickedButton = (sender as Button);
        if (string.IsNullOrEmpty(Result.Content.ToString()) || Result.Content.ToString()[0] != '-' )
        {
            Result.Content = "-" + Result.Content;
            Console.WriteLine("Signe ajouté");
        }
        else {
            Console.WriteLine("t");
            Result.Content = Result.Content.ToString().Substring(1,Result.Content.ToString().Length-1);
            Console.WriteLine("Signe retiré");
        }
    }
}