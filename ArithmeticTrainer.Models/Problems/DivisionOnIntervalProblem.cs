namespace ArithmeticTrainer.Models.Problems;

public sealed class DivisionOnIntervalProblem : Problem
{
    public override string Question => Y >= 0 ? $"{X} / {Y} = ?" : $"{X} / ({Y}) = ?";
    public override string Answer => Result.ToString();
    private int X { get; }
    private int Y { get; }
    private int Result { get; }

    public DivisionOnIntervalProblem(Interval interval, int x, int y, int result)
    {
        interval.EnsureContains(x, nameof(x));
        interval.EnsureContains(y, nameof(y));
        interval.EnsureContains(result, nameof(result));
        if (x != y * result)
        {
            throw new ArgumentException("Invalid result");
        }
        if (y == 0)
        {
            throw new ArgumentException("Cannot divide by zero");
        }
        X = x;
        Y = y;
        Result = result;
    }
}