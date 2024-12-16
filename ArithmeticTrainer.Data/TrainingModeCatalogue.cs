using ArithmeticTrainer.Models;
using ArithmeticTrainer.Models.ProblemGenerators;

namespace ArithmeticTrainer.Data;

public sealed class TrainingModeCatalogue
{
    private readonly IReadOnlyList<TrainingMode> _items =
    [
        new("Mixed (+-/*) On Range 2 to 99", new MixedProblemGenerator(
            new AdditionOnIntervalProblemGenerator(new(from: 2, to: 99)),
            new SubtractionOnIntervalProblemGenerator(new(from: 2, to: 99)),
            new MultiplicationOnIntervalProblemGenerator(),
            new DivisionOnIntervalProblemGenerator())),
        new("Addition (+) On Range 2 to 99", new AdditionOnIntervalProblemGenerator(new(from: 2, to: 99))),
        new("Subtraction (-) On Range 2 to 99", new SubtractionOnIntervalProblemGenerator(new(from: 2, to: 99))),
        new("Division (/) On Range 2 to 99", new DivisionOnIntervalProblemGenerator()),
        new("Multiplication (*) On Range 2 to 99", new MultiplicationOnIntervalProblemGenerator()),
    ];
    public List<string> GetLabels() => _items.Select(m => m.Label).ToList();

    public TrainingMode? GetByLabel(string label) => _items.FirstOrDefault(m => m.Label == label);
}