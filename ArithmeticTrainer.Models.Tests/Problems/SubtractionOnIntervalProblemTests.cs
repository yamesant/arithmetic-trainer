using ArithmeticTrainer.Models.Problems;

namespace ArithmeticTrainer.Models.Tests.Problems;

public sealed class SubtractionOnIntervalProblemTests
{
    [Theory]
    [InlineData(-9, 9, 1, 1, 0)]
    public void CanCreate(int from, int to, int x, int y, int result)
    {
        // Arrange
        Interval interval = new(from, to);
        
        // Act
        Action action = () => _ = new SubtractionOnIntervalProblem(interval, x, y, result);
        
        // Assert
        action.Should().NotThrow();
    }
    
    [Theory]
    [InlineData(-9, 9, 2, 2, 0, "2 - 2 = ?")]
    [InlineData(-9, 9, -2, -2, 0, "-2 - (-2) = ?")]
    public void HasCorrectQuestionPresentation(int from, int to, int x, int y, int result, string expectedQuestion)
    {
        // Arrange
        Interval interval = new(from, to);
        SubtractionOnIntervalProblem problem = new(interval, x, y, result);
        
        // Act
        string question = problem.Question;
        
        // Assert
        question.Should().Be(expectedQuestion);
    }
    
    [Theory]
    [InlineData(2, 99, 100, 50, 50)]
    [InlineData(20, 99, 59, 19, 40)]
    [InlineData(2, 99, 3, 2, 1)]
    public void FailToCreateIfExistParameterOutsideInterval(int from, int to, int x, int y, int result)
    {
        // Arrange
        Interval interval = new(from, to);
        
        // Act
        Action action = () => _ = new SubtractionOnIntervalProblem(interval, x, y, result);
        
        // Assert
        action.Should().Throw<ArgumentException>();
    }
    
    [Theory]
    [InlineData(-9, 9, 0, 1, 0)]
    public void FailToCreateIfResultIsWrong(int from, int to, int x, int y, int result)
    {
        // Arrange
        Interval interval = new(from, to);
        
        // Act
        Action action = () => _ = new SubtractionOnIntervalProblem(interval, x, y, result);
        
        // Assert
        action.Should().Throw<ArgumentException>();
    }
}