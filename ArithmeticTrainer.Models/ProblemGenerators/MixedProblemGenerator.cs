namespace ArithmeticTrainer.Models.ProblemGenerators;

public sealed class MixedProblemGenerator(params ProblemGenerator[] problemGenerators) : ProblemGenerator
{
    public override Problem Next()
    {
        return problemGenerators[Random.Next(problemGenerators.Length)].Next();
    }
}