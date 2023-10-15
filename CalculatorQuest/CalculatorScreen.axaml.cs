using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace CalculatorQuest;

public partial class CalculatorScreen : Window
{
    private Calc _calc = new Calc();
    public CalculatorScreen()
    {
        Height = 320;
        Width = 250;
        
        InitializeComponent();
        Result.Content = "";
        Operation.Content = "";

    }

    private void Click_number(object? sender, RoutedEventArgs routedEventArgs)
    {
        if (_calc.res != "")
        {
            Console.WriteLine("number présent on clean");
            ClearAl(sender, routedEventArgs);
        }
        Button? clickedButton = (sender as Button);
        Result.Content += clickedButton.Content.ToString();
        Console.WriteLine("number add");
    }
    
    private void Click_ope(object? sender, RoutedEventArgs routedEventArgs)
    {
        Button? clickedButton = (sender as Button);
        if (_calc.ope == "")
        {
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
            _calc.res = _calc.Operator();
            Result.Content = "=" + _calc.res;
        }
    }

    private void ClearEnt(object? sender, RoutedEventArgs e)
    {
        Button? clickedButton = (sender as Button);
        Result.Content = "";
        _calc.ope = "";
        _calc.member_1 = "";
        _calc.member_2 = "";
        _calc.res = "";
        Console.WriteLine("Clean entry");
    }
    private void ClearAl(object? sender, RoutedEventArgs e)
    {
        Button? clickedButton = (sender as Button);
        Result.Content = "";
        Operation.Content = "";
        _calc.ope = "";
        _calc.member_1 = "";
        _calc.member_2 = "";
        _calc.res = "";
        Console.WriteLine("Clean all");
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
            Result.Content = Result.Content.ToString().Substring(1,Result.Content.ToString().Length-1);
            Console.WriteLine("Signe retiré");
        }
    }

    private void Square_root(object? sender, RoutedEventArgs e)
    {
        Console.WriteLine(Result.Content.ToString());
        Button? clickedButton = (sender as Button);
        if (string.IsNullOrEmpty(Result.Content.ToString()) || Result.Content.ToString()[Result.Content.ToString().Length -1 ] != '\u221a' )
        {
            Result.Content += "\u221a";
            Console.WriteLine("Racine ajoutée");
        }
        else if (Result.Content.ToString() == "\u221a"){
            Result.Content = "";
            Console.WriteLine("Racine retirée");
        }
        else
        {
            Result.Content = Result.Content.ToString().Substring(1,Result.Content.ToString().Length-2);
            Console.WriteLine("Racine retirée");
        }
    }
    private void Power(object? sender, RoutedEventArgs e)
    {
        Button? clickedButton = (sender as Button);
        if (string.IsNullOrEmpty(Result.Content.ToString()))
        {
            Result.Content = "";
            Console.WriteLine("carré impossible");
        }
        else if (Result.Content.ToString().Substring(Result.Content.ToString().Length -1 ) != "²" )
        {
            Result.Content += "²";
            Console.WriteLine("carré ajoutée");
        }
        else
        {
            Result.Content = Result.Content.ToString().Remove(Result.Content.ToString().Length - 1);;
            Console.WriteLine("carré retirée");
        }
    }
    private void Inv(object? sender, RoutedEventArgs e)
    {
        Button? clickedButton = (sender as Button);
        if (Result.Content.ToString().StartsWith("1/"))
        {
            Result.Content = Result.Content.ToString().Substring(2);
            Console.WriteLine("inverse retiré");
        }
        else
        {
            Result.Content = "1/" + Result.Content;
            Console.WriteLine("inverse ajouté");
        }
    }
}