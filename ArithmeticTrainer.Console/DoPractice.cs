using ArithmeticTrainer.Data;
using ArithmeticTrainer.Models;
using Spectre.Console;

namespace ArithmeticTrainer.Console;

public sealed class DoPractice(History history)
{
    public void Execute(TrainingMode trainingMode)
    {
        AnsiConsole.WriteLine($"Starting Practice on {trainingMode.Label}. Press q to stop.");
        List<Attempt> attempts = [];
        foreach (Problem problem in trainingMode.ProblemGenerator.Generate())
        {
            AnsiConsole.WriteLine(problem.Question);
            string response = System.Console.ReadLine() ?? "";
            if (response == "q")
            {
                break;
            }
            Attempt attempt = new(problem, response);
            AnsiConsole.WriteLine(attempt.Outcome);
            attempts.Add(attempt);
        }
        history.Add(attempts);
    }
}