namespace ArithmeticTrainer.Models.ProblemGenerators;

public sealed class SubtractionProblemGenerator : ProblemGenerator
{
    public override Problem Next()
    {
        int result = Random.Next(2, 98);
        int x = Random.Next(result + 2, 100);
        int y = x - result; 
        return new Problem($"{x} - {y} = ?", result.ToString());
    }
}