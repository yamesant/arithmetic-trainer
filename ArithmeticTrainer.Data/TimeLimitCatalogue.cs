using ArithmeticTrainer.Models;

namespace ArithmeticTrainer.Data;

public sealed class TimeLimitCatalogue
{
    private readonly IReadOnlyList<TimeLimit> _items =
    [
        new("15 seconds", 15),
        new("30 seconds", 30),
        new("1 minute", 60),
        new("2 minutes", 120),
    ];
    public List<string> GetLabels() => _items.Select(m => m.Label).ToList();

    public TimeLimit? GetByLabel(string label) => _items.FirstOrDefault(m => m.Label == label);
}