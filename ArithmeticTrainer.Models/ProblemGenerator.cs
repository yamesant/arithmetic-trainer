using System.Collections;

namespace ArithmeticTrainer.Models;

public abstract class ProblemGenerator
{
    protected readonly Random Random = new();
    public abstract string Description { get; }
    public abstract Problem Next();
    public IEnumerable<Problem> Generate()
    {
        while (true)
        {
            yield return Next();
        }
    }
}