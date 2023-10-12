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
        double r1;
        Console.WriteLine("member_1 : " + member_1);
        Console.WriteLine("ope : " + ope);
        Console.WriteLine("member_2 : " + member_2);
        if (!double.TryParse(member_1, out r1))
        {
            return "First member is not a number";
        }
        
        double r2;
        if (!double.TryParse(member_2, out r2))
        {
            Console.WriteLine("ça me soule -" + member_2);
            return "Second member is not a number";
        }

        switch (ope)
        {
            case "+":
                res = (r1) + (r2);
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
                    return "division by 0 impossible";
                }
                res = r1 / r2;
                break;

            default:
                return "invalid operator";
        }
        return res.ToString();
    }
}

