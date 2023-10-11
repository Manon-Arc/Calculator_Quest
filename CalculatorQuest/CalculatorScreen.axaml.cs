using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace CalculatorQuest;

public partial class CalculatorScreen : Window
{
    public CalculatorScreen()
    {
        this.Height = 350;
        this.Width = 200;
        
        InitializeComponent();
    }
    
    private void Add(object? sender, RoutedEventArgs routedEventArgs)
    {
        if (Result.Content != "=")
        {
            ClearAl(sender, routedEventArgs);
        }
        Button? clickedButton = (sender as Button);
        Operation.Content += clickedButton.Content.ToString();
    }

    private void Operator(object? sender, RoutedEventArgs e)
    {
        Calc c = new Calc(); 
        Result.Content = "=" + c.Operator(Operation.Content.ToString());
    }

    private void ClearEnt(object? sender, RoutedEventArgs e)
    {
        Button? clickedButton = (sender as Button);
        Result.Content = "";
    }
    private void ClearAl(object? sender, RoutedEventArgs e)
    {
        Button? clickedButton = (sender as Button);
        Result.Content = "=";
        Operation.Content = "";
    }
    private void Delete(object? sender, RoutedEventArgs e)
    {
        Button? clickedButton = (sender as Button);
        Operation.Content = Operation.Content.ToString()?.Substring(0, Operation.Content.ToString().Length - 1);
    }
}