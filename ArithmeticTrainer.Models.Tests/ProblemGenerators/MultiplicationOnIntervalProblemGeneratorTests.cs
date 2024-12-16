using ArithmeticTrainer.Models.ProblemGenerators;
using ArithmeticTrainer.Models.Problems;

namespace ArithmeticTrainer.Models.Tests.ProblemGenerators;

public sealed class MultiplicationOnIntervalProblemGeneratorTests
{
    [Theory]
    [InlineData(0, 0, 100)]
    [InlineData(1, 1, 100)]
    [InlineData(-2, 2, 100)]
    [InlineData(2, 99, 100)]
    [InlineData(9, 99, 100)]
    [InlineData(-99, 99, 100)]
    public void CanGenerate(int from, int to, int numberOfProblems)
    {
        // Arrange
        Interval interval = new(from, to);
        MultiplicationOnIntervalProblemGenerator problemGenerator = new(interval);
        
        // Act
        Problem[] problems = problemGenerator.Next(numberOfProblems);
        
        // Assert
        problems.Should().AllBeAssignableTo<MultiplicationOnIntervalProblem>();
    }

    [Theory]
    [InlineData(10, 99)]
    [InlineData(-10, -1)]
    public void FailToCreateWhenIntervalHasNoProblems(int from, int to)
    {
        // Arrange
        Interval interval = new(from, to);
        
        // Act
        Action action = () => _ = new MultiplicationOnIntervalProblemGenerator(interval);
        
        // Assert
        action.Should().Throw<ArgumentException>();
    }
}