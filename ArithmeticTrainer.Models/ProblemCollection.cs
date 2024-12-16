namespace ArithmeticTrainer.Models;

public sealed class ProblemCollection
{
    private readonly Random _random = new();
    private readonly ProblemGenerator[] _problemGenerators;
    public string Label { get; }

    public ProblemCollection(string label, ProblemGenerator[] problemGenerators)
    {
        Label = label;
        _problemGenerators = problemGenerators;
    }
    public Problem Next()
    {
        return _problemGenerators[_random.Next(_problemGenerators.Length)].Next();
    }
    public IEnumerable<Problem> Generate()
    {
        while (true)
        {
            yield return Next();
        }
        // ReSharper disable once IteratorNeverReturns
    }
}