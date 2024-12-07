namespace ArithmeticTrainer.Models;

public record Attempt(Problem Problem, string Response)
{
    public bool IsCorrect => Problem.Answer == Response;
    public string Outcome => IsCorrect ? "Correct" : $"Incorrect. The answer is {Problem.Answer}";
}