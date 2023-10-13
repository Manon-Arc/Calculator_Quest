//https://codes-sources.commentcamarche.net/forum/affich-1370965-faire-une-calculatrice-avec-c-debutant

using System;
using System.Linq;

namespace CalculatorQuest;

public class Calc
{
    private string[] _signs { get; } = { "+", "-", "x", "/", "%" };
    public string member_1 { get; set; }
    public string ope { get; set; } = "";
    public string member_2 { get; set; } = "";
    public double res { get; set; }

    public Calc()
    {
        member_1 = "";
        member_2 = "";
        ope = "";
    }
    public string Operator()
{
    double r1, r2;

    Console.WriteLine("member_1 : " + member_1);
    Console.WriteLine("ope : " + ope);
    Console.WriteLine("member_2 : " + member_2);

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
    return res.ToString();
}

}

