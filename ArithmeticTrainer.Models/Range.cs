namespace ArithmeticTrainer.Models;

public abstract class Range
{
    public abstract string Name { get; }
    public abstract bool Contains(int value);
}