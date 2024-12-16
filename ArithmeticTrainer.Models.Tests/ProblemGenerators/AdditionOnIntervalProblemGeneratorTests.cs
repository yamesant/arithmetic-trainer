using ArithmeticTrainer.Models.ProblemGenerators;
using ArithmeticTrainer.Models.Problems;

namespace ArithmeticTrainer.Models.Tests.ProblemGenerators;

public sealed class AdditionOnIntervalProblemGeneratorTests
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
        AdditionOnIntervalProblemGenerator problemGenerator = new(interval);
        
        // Act
        Problem[] problems = problemGenerator.Next(numberOfProblems);
        
        // Assert
        problems.Should().AllBeAssignableTo<AdditionOnIntervalProblem>();
    }

    [Theory]
    [InlineData(10, 15)]
    [InlineData(-15, -10)]
    public void FailToCreateWhenIntervalHasNoProblems(int from, int to)
    {
        // Arrange
        Interval interval = new(from, to);
        
        // Act
        Action action = () => _ = new AdditionOnIntervalProblemGenerator(interval);
        
        // Assert
        action.Should().Throw<ArgumentException>();
    }
}