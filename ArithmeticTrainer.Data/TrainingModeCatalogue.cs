using ArithmeticTrainer.Models;
using ArithmeticTrainer.Models.ProblemGenerators;

namespace ArithmeticTrainer.Data;

public sealed class TrainingModeCatalogue
{
    private readonly IReadOnlyList<TrainingMode> _items =
    [
        new("Mixed (+-/*) On Range 2 to 99", new MixedProblemGenerator(
            new AdditionProblemGenerator(),
            new SubtractionProblemGenerator(),
            new MultiplicationProblemGenerator(),
            new DivisionProblemGenerator())),
        new("Addition (+) On Range 2 to 99", new AdditionProblemGenerator()),
        new("Subtraction (-) On Range 2 to 99", new SubtractionProblemGenerator()),
        new("Division (/) On Range 2 to 99", new DivisionProblemGenerator()),
        new("Multiplication (*) On Range 2 to 99", new MultiplicationProblemGenerator()),
    ];
    public List<string> GetLabels() => _items.Select(m => m.Label).ToList();

    public TrainingMode? GetByLabel(string label) => _items.FirstOrDefault(m => m.Label == label);
}