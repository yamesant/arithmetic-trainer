namespace ArithmeticTrainer.Models;

public abstract class ProblemGenerator
{
    protected readonly Random Random = new();
    protected abstract Range Range { get; }
    public abstract Problem Next();
    public Problem[] Next(int count)
    {
        Problem[] problems = new Problem[count];
        for (int i = 0; i < count; i++)
        {
            problems[i] = Next();
        }
        return problems;
    }
    public IEnumerable<Problem> Generate()
    {
        while (true)
        {
            yield return Next();
        }
    }
}