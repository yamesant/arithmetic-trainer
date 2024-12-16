namespace ArithmeticTrainer.Models;

public abstract class Problem
{
    public abstract string Question { get; }
    public abstract string Answer { get; }
}

public sealed class GenericProblem(string question, string answer) : Problem
{
    public override string Question => question;
    public override string Answer => answer;
}