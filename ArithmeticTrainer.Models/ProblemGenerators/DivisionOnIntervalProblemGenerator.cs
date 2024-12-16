using ArithmeticTrainer.Models.Problems;

namespace ArithmeticTrainer.Models.ProblemGenerators;

public sealed class DivisionOnIntervalProblemGenerator : ProblemGenerator
{
    protected override Interval Range { get; }

    public DivisionOnIntervalProblemGenerator(Interval interval)
    {
        if (interval is { From: 0, To: 0 } ||
            interval.To < 0 ||
            interval.From > 0 && interval.From * interval.From > interval.To)
        {
            throw new ArgumentException("Invalid interval");
        }
        Range = interval;
    }

    public override DivisionOnIntervalProblem Next()
    {
        int y, result;
        if (Range.From > 0)
        {
            result = Random.Next(Range.From, Range.To / Range.From + 1);
            y = Random.Next(Range.From, Range.To / result + 1);
        }
        else if (Range.To == 0)
        {
            result = 0;
            y = Random.Next(Range.From, 0);
        }
        else // Range.From <= 0 && 1 <= Range.To
        {
            result = Random.Next(Range.From, Range.To + 1);
            switch (result)
            {
                case > 0:
                {
                    do
                    {
                        y = Random.Next(Range.From / result, Range.To / result + 1);
                    } while (y == 0);

                    break;
                }
                case < 0:
                {
                    do
                    {
                        y = Random.Next(Range.To / result, Range.From / result + 1);
                    } while (y == 0);

                    break;
                }
                case 0:
                {
                    do
                    {
                        y = Random.Next(Range.From, Range.To + 1);
                    } while (y == 0);

                    break;
                }
            }
        }
        return new DivisionOnIntervalProblem(Range, y*result, y, result);
    }
}