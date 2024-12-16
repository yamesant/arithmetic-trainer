namespace ArithmeticTrainer.Models.ProblemGenerators;

public sealed class MultiplicationProblemGenerator : ProblemGenerator
{
    public override Problem Next()
    {
        while (true)
        {
            int product = Random.Next(4, 100);
            List<int> divisors = [];
            for (int d = 2; d <= product / 2; d++)
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
            return new GenericProblem($"{x} * {y} = ?", product.ToString());
        }
    }
}