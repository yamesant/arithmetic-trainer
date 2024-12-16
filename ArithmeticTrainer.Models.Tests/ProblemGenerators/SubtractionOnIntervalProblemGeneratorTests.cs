using ArithmeticTrainer.Models.ProblemGenerators;
using ArithmeticTrainer.Models.Problems;

namespace ArithmeticTrainer.Models.Tests.ProblemGenerators;

public sealed class SubtractionOnIntervalProblemGeneratorTests
{
    [Theory]
    [InlineData(0, 0, 100)]
    [InlineData(-1, 1, 100)]
    [InlineData(2, 99, 100)]
    [InlineData(-99, -2, 100)]
    public void CanGenerate(int from, int to, int numberOfProblems)
    {
        // Arrange
        Interval interval = new(from, to);
        SubtractionOnIntervalProblemGenerator problemGenerator = new(interval);
        
        // Act
        Problem[] problems = problemGenerator.Next(numberOfProblems);
        
        // Assert
        problems.Should().AllBeAssignableTo<SubtractionOnIntervalProblem>();
    }

    [Theory]
    [InlineData(10, 19)]
    [InlineData(-19, -10)]
    public void FailToCreateWhenIntervalHasNoProblems(int from, int to)
    {
        // Arrange
        Interval interval = new(from, to);
        
        // Act
        Action action = () => _ = new SubtractionOnIntervalProblemGenerator(interval);
        
        // Assert
        action.Should().Throw<ArgumentException>();
    }
}