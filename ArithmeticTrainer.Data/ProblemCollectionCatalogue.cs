using ArithmeticTrainer.Models;
using ArithmeticTrainer.Models.ProblemGenerators;

namespace ArithmeticTrainer.Data;

public sealed class ProblemCollectionCatalogue
{
    private readonly IReadOnlyList<ProblemCollection> _items =
    [
        new("Mixed (+-/*) On Interval From 2 To 99", [
            new AdditionOnIntervalProblemGenerator(new(from: 2, to: 99)),
            new SubtractionOnIntervalProblemGenerator(new(from: 2, to: 99)),
            new MultiplicationOnIntervalProblemGenerator(new(from: 2, to: 99)),
            new DivisionOnIntervalProblemGenerator(new(from: 2, to: 99))]),
        new("Mixed (+-/*) On Interval From -20 To 20", [
            new AdditionOnIntervalProblemGenerator(new(from: -20, to: 20)),
            new SubtractionOnIntervalProblemGenerator(new(from: -20, to: 20)),
            new MultiplicationOnIntervalProblemGenerator(new(from: -20, to: 20)),
            new DivisionOnIntervalProblemGenerator(new(from: -20, to: 20))]),
        new("Addition & Subtraction On Interval From -999 To 999", [
            new AdditionOnIntervalProblemGenerator(new(from: -999, to: 999)),
            new SubtractionOnIntervalProblemGenerator(new(from: -999, to: 999))]),
    ];
    public List<string> GetLabels() => _items.Select(m => m.Label).ToList();

    public ProblemCollection? GetByLabel(string label) => _items.FirstOrDefault(m => m.Label == label);
}