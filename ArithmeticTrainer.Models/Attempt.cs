namespace ArithmeticTrainer.Models;

public record Attempt(Problem Problem, string Response)
{
    public string Outcome => Problem.Answer == Response ? "Correct" : $"Incorrect. The answer is {Problem.Answer}";
}