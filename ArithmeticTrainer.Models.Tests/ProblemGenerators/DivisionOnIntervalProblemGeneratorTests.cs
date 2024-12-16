using ArithmeticTrainer.Models.ProblemGenerators;
using ArithmeticTrainer.Models.Problems;

namespace ArithmeticTrainer.Models.Tests.ProblemGenerators;

public sealed class DivisionOnIntervalProblemGeneratorTests
{
    [Theory]
    [InlineData(1, 1, 100)]
    [InlineData(0, 1, 100)]
    [InlineData(-1, 0, 100)]
    [InlineData(-2, 2, 100)]
    [InlineData(2, 99, 100)]
    public void CanGenerate(int from, int to, int numberOfProblems)
    {
        // Arrange
        Interval interval = new(from, to);
        DivisionOnIntervalProblemGenerator problemGenerator = new(interval);
        
        // Act
        Problem[] problems = problemGenerator.Next(numberOfProblems);
        
        // Assert
        problems.Should().AllBeAssignableTo<DivisionOnIntervalProblem>();
    }

    [Theory]
    [InlineData(10, 99)]
    [InlineData(-10, -1)]
    [InlineData(0, 0)]
    public void FailToCreateWhenIntervalHasNoProblems(int from, int to)
    {
        // Arrange
        Interval interval = new(from, to);
        
        // Act
        Action action = () => _ = new DivisionOnIntervalProblemGenerator(interval);
        
        // Assert
        action.Should().Throw<ArgumentException>();
    }
}