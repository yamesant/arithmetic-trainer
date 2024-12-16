using ArithmeticTrainer.Models.Problems;

namespace ArithmeticTrainer.Models.Tests.Problems;

public sealed class AdditionOnIntervalProblemTests
{
    [Theory]
    [InlineData(-9, 9, 2, 2, 4)]
    public void CanCreate(int from, int to, int x, int y, int result)
    {
        // Arrange
        Interval interval = new(from, to);
        
        // Act
        Action action = () => _ = new AdditionOnIntervalProblem(interval, x, y, result);
        
        // Assert
        action.Should().NotThrow();
    }
    
    [Theory]
    [InlineData(-9, 9, 2, 2, 4, "2 + 2 = ?")]
    [InlineData(-9, 9, -2, -2, -4, "-2 + (-2) = ?")]
    public void HasCorrectQuestionPresentation(int from, int to, int x, int y, int result, string expectedQuestion)
    {
        // Arrange
        Interval interval = new(from, to);
        AdditionOnIntervalProblem problem = new(interval, x, y, result);
        
        // Act
        string question = problem.Question;
        
        // Assert
        question.Should().Be(expectedQuestion);
    }
    
    [Theory]
    [InlineData(2, 99, 1, 2, 3)]
    [InlineData(-99, 99, -50, 100, 50)]
    [InlineData(2, 99, 98, 2, 100)]
    public void FailToCreateIfExistParameterOutsideInterval(int from, int to, int x, int y, int result)
    {
        // Arrange
        Interval interval = new(from, to);
        
        // Act
        Action action = () => _ = new AdditionOnIntervalProblem(interval, x, y, result);
        
        // Assert
        action.Should().Throw<ArgumentException>();
    }
    
    [Theory]
    [InlineData(-9, 9, 0, 0, 1)]
    public void FailToCreateIfResultIsWrong(int from, int to, int x, int y, int result)
    {
        // Arrange
        Interval interval = new(from, to);
        
        // Act
        Action action = () => _ = new AdditionOnIntervalProblem(interval, x, y, result);
        
        // Assert
        action.Should().Throw<ArgumentException>();
    }
}