namespace ArithmeticTrainer.Models.Tests;

public class IntervalTests
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(10, 20)]
    public void CanCreate(int from, int to)
    {
        // Act
        Action action = () => _ = new Interval(from, to);
        
        // Assertion
        action.Should().NotThrow();
    }
    
    [Theory]
    [InlineData(1, 0)]
    [InlineData(-1, -2)]
    public void FailToCreateWhenFromIsGreaterThanTo(int from, int to)
    {
        // Act
        Action action = () => _ = new Interval(from, to);
        
        // Assertion
        action.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(5, 8, "Interval From 5 To 8")]
    public void HasCorrectName(int from, int to, string expectedName)
    {
        // Arrange
        Interval interval = new(from, to);
        
        // Act
        string name = interval.Name;
        
        // Assert
        name.Should().Be(expectedName);
    }
    
    [Theory]
    [InlineData(-2, 2, -3, false)]
    [InlineData(-2, 2, -2, true)]
    [InlineData(-2, 2, 0, true)]
    [InlineData(-2, 2, 2, true)]
    [InlineData(-2, 2, 3, false)]
    public void Contains(int from, int to, int value, bool expected)
    {
        // Arrange
        Interval interval = new(from, to);
        
        // Act
        bool result = interval.Contains(value);

        // Assert
        result.Should().Be(expected);
    }
}