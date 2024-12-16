using ArithmeticTrainer.Models.Problems;

namespace ArithmeticTrainer.Models.ProblemGenerators;

public sealed class AdditionOnIntervalProblemGenerator: ProblemGenerator
{
    protected override Interval Range { get; }
    public AdditionOnIntervalProblemGenerator(Interval interval)
    {
        if (Math.Max(interval.From + interval.From, interval.From) > Math.Min(interval.To + interval.To, interval.To))
        {
            throw new ArgumentException("Invalid interval");
        }
        Range = interval;
    }
    public override AdditionOnIntervalProblem Next()
    {
        int result = Random.Next(
            Math.Max(Range.From + Range.From, Range.From),
            Math.Min(Range.To + Range.To, Range.To) + 1);
        int x = Random.Next(
            Math.Max(result - Range.To, Range.From),
            Math.Min(result - Range.From, Range.To) + 1);
        int y = result - x;
        return new AdditionOnIntervalProblem(Range, x, y, result);
    }
}