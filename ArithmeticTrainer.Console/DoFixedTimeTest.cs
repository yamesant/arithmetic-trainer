using System.Diagnostics;
using ArithmeticTrainer.Data;
using ArithmeticTrainer.Models;
using Spectre.Console;

namespace ArithmeticTrainer.Console;

public sealed class DoFixedTimeTest(History history)
{
    public void Execute(ProblemCollection problemCollection, TimeLimit timeLimit)
    {
        AnsiConsole.WriteLine($"Starting {timeLimit.Label} Test on {problemCollection.Label}.");
        List<Attempt> attempts = [];
        Stopwatch stopwatch = Stopwatch.StartNew();
        foreach (Problem problem in problemCollection.Generate())
        {
            AnsiConsole.WriteLine(problem.Question);
            string response = System.Console.ReadLine() ?? "";
            Attempt attempt = new(problem, response);
            long timeRemainingInSeconds = timeLimit.ValueInSeconds - stopwatch.ElapsedMilliseconds / 1000;
            if (timeRemainingInSeconds > 0)
            {
                AnsiConsole.WriteLine($"{attempt.Outcome}. Time Remaining: {timeRemainingInSeconds} seconds");
                attempts.Add(attempt);
            }
            else
            {
                AnsiConsole.WriteLine("Time's up");
                int correctCount = attempts.Count(attempt => attempt.IsCorrect);
                int incorrectCount = attempts.Count - correctCount;
                AnsiConsole.WriteLine($"Correct Count: {correctCount} Incorrect Count: {incorrectCount}");
                break;
            }
        }

        history.Add(attempts);
    }
}