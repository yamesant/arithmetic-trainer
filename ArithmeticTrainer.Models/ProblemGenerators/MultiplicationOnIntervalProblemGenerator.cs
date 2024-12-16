using ArithmeticTrainer.Models.Problems;

namespace ArithmeticTrainer.Models.ProblemGenerators;

public sealed class MultiplicationOnIntervalProblemGenerator : ProblemGenerator
{
    private const int MaxIterations = 1000;
    protected override Interval Range { get; }

    public MultiplicationOnIntervalProblemGenerator(Interval interval)
    {
        if (interval.To < 0 ||
            interval.From > 0 && interval.From * interval.From > interval.To)
        {
            throw new ArgumentException("Invalid interval");
        }
        Range = interval;
    }

    public override MultiplicationOnIntervalProblem Next()
    {
        if (Range.From > 0)
        {
            return GenerateOnPositiveRange();
        }

        if (Range.To == 0)
        {
            return GenerateZeroResult();
        }

        // Range.From <= 0 && 1 <= Range.To
        int product = Random.Next(Range.From, Range.To + 1);
        if (product == 0)
        {
            return GenerateZeroResult();
        }

        List<int> divisors = [];
        for (int d = Range.From; d <= Range.To; d++)
        {
            if (d != 0 && product % d == 0)
            {
                divisors.Add(d);
            }
        }

        int x = divisors[Random.Next(0, divisors.Count)];
        int y = product / x;
        return new MultiplicationOnIntervalProblem(Range, x, y, product);
    }

    private MultiplicationOnIntervalProblem GenerateOnPositiveRange()
    {
        for (int i = 0; i < MaxIterations; i++)
        {
            int product = Random.Next(Range.From * Range.From, Range.To + 1);
            List<int> divisors = [];
            for (int d = Range.From; d <= product / Range.From; d++)
            {
                if (product % d == 0)
                {
                    divisors.Add(d);
                }
            }

            if (divisors.Count == 0)
            {
                continue;
            }

            int x = divisors[Random.Next(0, divisors.Count)];
            int y = product / x;
            return new MultiplicationOnIntervalProblem(Range, x, y, product);
        }

        throw new ArithmeticException("Problem generation failed.");
    }

    private MultiplicationOnIntervalProblem GenerateZeroResult()
    {
        int intervalLength = Range.To - Range.From + 1;
        int z = Random.Next(-intervalLength + 1, intervalLength);
        int x = 0;
        int y = 0;
        switch (z)
        {
            case > 0:
            {
                y = Range.From + z - 1;
                if (y >= 0) y++;
                break;
            }
            case < 0:
            {
                x = Range.From - z - 1;
                if (x >= 0) x++;
                break;
            }
        }
        return new MultiplicationOnIntervalProblem(Range, x, y, 0);
    }
}