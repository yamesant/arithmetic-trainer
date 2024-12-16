namespace ArithmeticTrainer.Models;

public sealed class Interval : Range
{
    public override string Name => $"Interval From {From} To {To}";
    public int From { get; }
    public int To { get; }

    public Interval(int from, int to)
    {
        if (from > to)
        {
            throw new ArgumentException($"{nameof(from)} must be less than or equal to {nameof(to)}");
        }
        From = from;
        To = to;
    }
    
    public override bool Contains(int value)
    {
        return From <= value && value <= To;
    }

    public void EnsureContains(int value, string valueName)
    {
        if (Contains(value))
        {
            return;
        }
        throw new ArgumentOutOfRangeException($"{valueName}={value} must be between {From} and {To}");
    }
}