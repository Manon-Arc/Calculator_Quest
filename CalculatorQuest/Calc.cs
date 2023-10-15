using System;

namespace CalculatorQuest;

public class Calc
{
    public string member_1 { get; set; }
    public string ope { get; set; } = "";
    public string member_2 { get; set; } = "";
    public string res { get; set; }

    public Calc()
    {
        member_1 = "";
        member_2 = "";
        ope = "";
    }
    public string Operator()
{
    double r1;
    double r2;
    double res;

    Console.WriteLine("member_1 : " + member_1);
    Console.WriteLine("ope : " + ope);
    Console.WriteLine("member_2 : " + member_2);

    if (member_1.Length > 2)
    {
        if (member_1.StartsWith("1/"))
        {
            member_1 = member_1.Replace("1/", "inv");
        }
    }

    if (member_2.Length > 2)
    {
        if (member_2.StartsWith("1/"))
        {
            member_2 = member_2.Replace("1/", "inv");
        }
    }

    if (member_1.Contains("√"))
    {
        string numberString = member_1.Replace("√", "");
        if (double.TryParse(numberString, out double num))
        {
            r1 = Math.Sqrt(num);
        }
        else
        {
            return "Unable to parse the first member as a number";
        }
    }
    else if (member_1.Contains("inv"))
    {
        string invString = member_1.Replace("inv", "");
        if (double.TryParse(invString, out double num))
        {
            r1 = 1 / num;
        }
        else
        {
            return "Unable to parse the first member as a number";
        }
    }
    else if (member_1.Contains("²"))
    {
        string baseString = member_1.Replace("²", "");
        if (double.TryParse(baseString, out double baseNumber))
        {
            r1 = baseNumber * baseNumber;
        }
        else
        {
            return "Unable to parse the first member with square";
        }
    }
    else
    {
        if (!double.TryParse(member_1, out r1))
        {
            return "First member is not a number";
        }
    }

    if (member_2.Contains("√"))
    {
        string numberString = member_2.Replace("√", "");
        if (double.TryParse(numberString, out double num))
        {
            r2 = Math.Sqrt(num);
        }
        else
        {
            return "Unable to parse the second member as a number";
        }
    }
    else if (member_2.Contains("inv"))
    {
        string invString = member_2.Replace("inv", "");
        if (double.TryParse(invString, out double num))
        {
            r2 = 1 / num;
        }
        else
        {
            return "Unable to parse the second member as a number";
        }
    }
    else if (member_2.Contains("²"))
    {
        string baseString = member_2.Replace("²", "");
        if (double.TryParse(baseString, out double baseNumber))
        {
            r2 = baseNumber * baseNumber;
        }
        else
        {
            return "Unable to parse the second member with square";
        }
    }
    else
    {
        if (!double.TryParse(member_2, out r2))
        {
            return "Second member is not a number";
        }
    }
    Console.WriteLine("r1 : " + r1);
    Console.WriteLine("ope : " + ope);
    Console.WriteLine("r2 : " + r2);
    switch (ope)
    {
        case "+":
            res = r1 + r2;
            break;
        case "-":
            res = r1 - r2;
            break;
        case "x":
            res = r1 * r2;
            break;
        case "%":
            res = r1 % r2;
            break;
        case "/":
            if (r2 == 0)
            {
                return "Division by 0 is not possible";
            }
            res = r1 / r2;
            break;
        default:
            return "Invalid operator";
    }
    Console.WriteLine("res : " + res);
    return res.ToString();
    }
}

