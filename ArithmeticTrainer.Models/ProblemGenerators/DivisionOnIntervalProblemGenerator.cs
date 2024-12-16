namespace ArithmeticTrainer.Models.ProblemGenerators;

public sealed class DivisionOnIntervalProblemGenerator : ProblemGenerator
{
    public override Problem Next()
    {
        int result = Random.Next(2, 50);
        int y = Random.Next(2, 99 / result + 1);
        int x = result * y;
        return new GenericProblem($"{x} / {y} = ?", result.ToString());
    }
}