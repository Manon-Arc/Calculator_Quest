//https://codes-sources.commentcamarche.net/forum/affich-1370965-faire-une-calculatrice-avec-c-debutant

using System;
using System.Linq;

namespace CalculatorQuest;

public class Calc
{
    private static string[] _signs { get; } = { "+", "-", "x", "/", "%" };

    public Calc()
    {
        
    }

    public string Operator(string operation){ ;
        var res = "";
        int indexOfOperateur = GetPositionOperateur(operation);
        Console.WriteLine(indexOfOperateur);
        int count = NbrofOperator(operation);
        if (operation =="") {
            return "Please enter an operation";
        }
        if (count > 1)
        {
            return "Only one operation please";
        }

        if (indexOfOperateur != -1)
        {
            Console.WriteLine("index" + indexOfOperateur);
            Console.WriteLine("operation" + operation);
            res = Calculer(operation, indexOfOperateur);
        }
        else if (indexOfOperateur == -1)
        {
            res = operation;
        }
        return res;
    }
    static private int GetPositionOperateur(string result)
    {
        int index = -1;
        foreach (char s in result)
        {
            Console.WriteLine(_signs);
            if (_signs.Contains(s.ToString()))
            {
                Console.WriteLine("operator");
                index = result.IndexOf(s);
                break;
            }
        }
        return index;
    }


    static private int NbrofOperator(string operation)
    {
        int count = 0;
        foreach (var v in operation)
        {
            if (_signs.Contains(v.ToString())) {
                count++;
            }
        }
        return count;
    }
    static private string Calculer(string result, int indexOfOperateur)
    {
        float computeResult = 0f;
        string[] cal = new string[3];

        cal[0] = result.Substring(0, indexOfOperateur).Trim();
        Console.WriteLine("1:" + cal[0]);
        cal[1] = result[indexOfOperateur].ToString();
        Console.WriteLine("2:" + cal[1]);
        cal[2] = result.Substring(indexOfOperateur + 1).Trim();
        Console.WriteLine("3:" + cal[2]);

        float r1;
        if (!float.TryParse(cal[0], out r1))
        {
            return "First member is not a number";
        }

        float r2;
        if (!float.TryParse(cal[2], out r2))
        {
            return "Second member is not a number";
        }

        switch (cal[1])
        {
            case "+":
                computeResult = r1 + r2;
                break;

            case "-":
                computeResult = r1 - r2;
                break;

            case "*":
                computeResult = r1 * r2;
                break;
            case "%":
                computeResult = r1 % r2;
                break;

            case "/":
                if (r2 == 0)
                {
                    return "division by 0 impossible";
                }
                computeResult = r1 / r2;
                break;

            default:
                return "invalid operator";
        }
        return computeResult.ToString();
    }
}

