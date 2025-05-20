[System.Serializable]
public class Equation
{
    public int X; // Coefficient of x
    public int Num; // Constant term
    public int Total; // Right-hand side value

    public Equation(int a, int b, int c)
    {
        X = a;
        Num = b;
        Total = c;
    }

    public override string ToString()
    {
        return $"{X}x + {Num} = {Total}";
    }

    public int GetXValue()
    {
        return (Total - Num) / X;
    }
}
