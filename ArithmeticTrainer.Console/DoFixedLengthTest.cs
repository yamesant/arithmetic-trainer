using System.Diagnostics;
using ArithmeticTrainer.Data;
using ArithmeticTrainer.Models;
using Spectre.Console;

namespace ArithmeticTrainer.Console;

public sealed class DoFixedLengthTest(History history)
{
    private const int IncorrectResponsePenaltyInSeconds = 10;
    
    public void Execute(ProblemCollection problemCollection, LengthLimit lengthLimit)
    {
        AnsiConsole.WriteLine($"Starting {lengthLimit.Label} Test on {problemCollection.Label}.");
        List<Attempt> attempts = [];
        Stopwatch stopwatch = Stopwatch.StartNew();
        for (int i = 1; i <= lengthLimit.Value; i++)
        {
            Problem problem = problemCollection.Next();
            AnsiConsole.WriteLine(problem.Question);
            string response = System.Console.ReadLine() ?? "";
            Attempt attempt = new(problem, response);
            AnsiConsole.WriteLine($"{attempt.Outcome}. Problems Remaining: {lengthLimit.Value-i}");
            attempts.Add(attempt);
        }

        TimeSpan elapsedTime = stopwatch.Elapsed;
        int correctCount = attempts.Count(attempt => attempt.IsCorrect);
        int incorrectCount = attempts.Count - correctCount;
        TimeSpan penaltyTime = TimeSpan.FromSeconds(incorrectCount * IncorrectResponsePenaltyInSeconds);
        TimeSpan finishTime = elapsedTime + penaltyTime;
        AnsiConsole.WriteLine($"Finish Time: {Format(finishTime)} (including {Format(penaltyTime)} penalty time)");

        history.Add(attempts);
    }

    private string Format(TimeSpan timeSpan)
    {
        return timeSpan >= TimeSpan.FromHours(1) ? "Over 1 Hour" : timeSpan.ToString(@"mm\:ss");
    }
}