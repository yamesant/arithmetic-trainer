namespace ArithmeticTrainer.Models.ProblemGenerators;

public sealed class AdditionOnIntervalProblemGenerator : ProblemGenerator
{
    public AdditionOnIntervalProblemGenerator(Interval interval)
    {
        
    }
    public override Problem Next()
    {
        int result = Random.Next(4, 100);
        int x = Random.Next(2, result - 1);
        int y = result - x;
        return new GenericProblem($"{x} + {y} = ?", result.ToString());
    }
}