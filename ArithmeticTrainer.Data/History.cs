using ArithmeticTrainer.Models;

namespace ArithmeticTrainer.Data;

public sealed class History
{
    private readonly List<Attempt> _attempts = [];
    public IReadOnlyList<Attempt> Attempts => _attempts;

    public void Add(List<Attempt> attempts)
    {
        _attempts.AddRange(attempts);
    }
}