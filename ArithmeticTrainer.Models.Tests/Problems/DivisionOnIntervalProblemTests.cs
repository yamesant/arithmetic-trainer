using ArithmeticTrainer.Models.Problems;

namespace ArithmeticTrainer.Models.Tests.Problems;

public sealed class DivisionOnIntervalProblemTests
{
    [Theory]
    [InlineData(-9, 9, 6, 3, 2)]
    public void CanCreate(int from, int to, int x, int y, int result)
    {
        // Arrange
        Interval interval = new(from, to);
        
        // Act
        Action action = () => _ = new DivisionOnIntervalProblem(interval, x, y, result);
        
        // Assert
        action.Should().NotThrow();
    }
    
    [Theory]
    [InlineData(-9, 9, 2, 2, 1, "2 / 2 = ?")]
    [InlineData(-9, 9, -2, -2, 1, "-2 / (-2) = ?")]
    public void HasCorrectQuestionPresentation(int from, int to, int x, int y, int result, string expectedQuestion)
    {
        // Arrange
        Interval interval = new(from, to);
        DivisionOnIntervalProblem problem = new(interval, x, y, result);
        
        // Act
        string question = problem.Question;
        
        // Assert
        question.Should().Be(expectedQuestion);
    }
    
    [Theory]
    [InlineData(2, 99, 200, 50, 4)]
    [InlineData(5, 99, 80, 4, 20)]
    [InlineData(5, 99, 80, 20, 4)]
    public void FailToCreateIfExistParameterOutsideInterval(int from, int to, int x, int y, int result)
    {
        // Arrange
        Interval interval = new(from, to);
        
        // Act
        Action action = () => _ = new DivisionOnIntervalProblem(interval, x, y, result);
        
        // Assert
        action.Should().Throw<ArgumentException>();
    }
    
    [Theory]
    [InlineData(-9, 9, 4, 3, 1)]
    [InlineData(-9, 9, -4, -4, -1)]
    public void FailToCreateIfResultIsWrong(int from, int to, int x, int y, int result)
    {
        // Arrange
        Interval interval = new(from, to);
        
        // Act
        Action action = () => _ = new DivisionOnIntervalProblem(interval, x, y, result);
        
        // Assert
        action.Should().Throw<ArgumentException>();
    }
    
    [Theory]
    [InlineData(-9, 9, 0, 0, 1)]
    public void FailToCreateDivisionByZero(int from, int to, int x, int y, int result)
    {
        // Arrange
        Interval interval = new(from, to);
        
        // Act
        Action action = () => _ = new DivisionOnIntervalProblem(interval, x, y, result);
        
        // Assert
        action.Should().Throw<ArgumentException>();
    }
}