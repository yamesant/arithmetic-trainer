using ArithmeticTrainer.Models.Problems;

namespace ArithmeticTrainer.Models.ProblemGenerators;

public sealed class SubtractionOnIntervalProblemGenerator : ProblemGenerator
{
    protected override Interval Range { get; }

    public SubtractionOnIntervalProblemGenerator(Interval interval)
    {
        if (Math.Max(interval.From, interval.From - interval.To) > Math.Min(interval.To, interval.To - interval.From))
        {
            throw new ArgumentException("Invalid interval");
        }
        Range = interval;
    }

    public override SubtractionOnIntervalProblem Next()
    {
        int result = Random.Next(
            Math.Max(Range.From, Range.From - Range.To),
            Math.Min(Range.To, Range.To - Range.From) + 1);
        int x = Random.Next(
            Math.Max(Range.From, Range.From + result),
            Math.Min(Range.To, Range.To + result));
        int y = x - result;
        
        return new SubtractionOnIntervalProblem(Range, x, y, result);
    }
}