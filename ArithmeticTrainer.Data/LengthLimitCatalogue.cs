using ArithmeticTrainer.Models;

namespace ArithmeticTrainer.Data;

public sealed class LengthLimitCatalogue
{
    private readonly IReadOnlyList<LengthLimit> _items =
    [
        new("10 Problems", 10),
        new("25 Problems", 25),
        new("50 Problems", 50),
        new("100 Problems", 100),
    ];
    public List<string> GetLabels() => _items.Select(m => m.Label).ToList();

    public LengthLimit? GetByLabel(string label) => _items.FirstOrDefault(m => m.Label == label);
}