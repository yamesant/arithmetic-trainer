using System.Diagnostics;
using ArithmeticTrainer.Data;
using ArithmeticTrainer.Models;
using Spectre.Console;

List<Attempt> history = [];
TrainingModeCatalogue trainingModeCatalogue = new();
TimeLimitCatalogue timeLimitCatalogue = new();
const string startFixedTimeTest = "Start Fixed Time Test";
const string startPractice = "Start Practice";
const string viewHistory = "View Training History";
const string quit = "Quit";
const string cancel = "Cancel";

while (true)
{
    Console.WriteLine("Welcome to Arithmetic Trainer");
    string action = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Select action: ")
            .AddChoices(startFixedTimeTest, startPractice, viewHistory, quit));
    TrainingMode? trainingMode;
    switch (action)
    {
        case startFixedTimeTest:
            trainingMode = ConfigureTrainingMode();
            if (trainingMode is null) break;
            TimeLimit? timeLimit = ConfigureTimeLimit();
            if (timeLimit is null) break;
            DoFixedTimeTest(trainingMode, timeLimit);
            break;
        case startPractice:
            trainingMode = ConfigureTrainingMode();
            if (trainingMode is null) break;
            DoPractice(trainingMode);
            break;
        case viewHistory:
            ShowHistory();
            break;
        case quit:
            return;
    }
}

void DoFixedTimeTest(TrainingMode trainingMode, TimeLimit timeLimit)
{
    AnsiConsole.WriteLine($"Starting {timeLimit.Label} test on {trainingMode.Label}.");
    List<Attempt> attempts = [];
    Stopwatch stopwatch = Stopwatch.StartNew();
    foreach (Problem problem in trainingMode.ProblemGenerator.Generate())
    {
        AnsiConsole.WriteLine(problem.Question);
        string response = Console.ReadLine() ?? "";
        Attempt attempt = new(problem, response);
        long timeRemainingInSeconds = timeLimit.ValueInSeconds - stopwatch.ElapsedMilliseconds / 1000;
        if (timeRemainingInSeconds > 0)
        {
            AnsiConsole.WriteLine($"{attempt.Outcome}. Time remaining: {timeRemainingInSeconds} seconds");
            attempts.Add(attempt);
        }
        else
        {
            AnsiConsole.WriteLine("Time's up");
            int correctCount = attempts.Count(attempt => attempt.IsCorrect);
            int incorrectCount = attempts.Count - correctCount;
            AnsiConsole.WriteLine($"Correct count: {correctCount} Incorrect count: {incorrectCount}");
            break;
        }
    }

    history.AddRange(attempts);
}

void DoPractice(TrainingMode trainingMode)
{
    Console.WriteLine($"Starting practice on {trainingMode.Label}. Press q to stop.");
    List<Attempt> attempts = [];
    foreach (Problem problem in trainingMode.ProblemGenerator.Generate())
    {
        Console.WriteLine(problem.Question);
        string response = Console.ReadLine() ?? "";
        if (response == "q")
        {
            break;
        }
        Attempt attempt = new(problem, response);
        Console.WriteLine(attempt.Outcome);
        attempts.Add(attempt);
    }
    history.AddRange(attempts);
}

void ShowHistory()
{
    if (history.Count == 0)
    {
        Console.WriteLine("No practice recorded yet");
    }
    else
    {
        Table table = new()
        {
            Border = TableBorder.Square
        };
        table.AddColumn("Question");
        table.AddColumn("Response");
        table.AddColumn("Outcome");
        foreach (Attempt attempt in history)
        {
            table.AddRow(attempt.Problem.Question, attempt.Response, attempt.Outcome);
        }

        AnsiConsole.Write(table);
    }
}

TrainingMode? ConfigureTrainingMode()
{
    {
        List<string> labels = trainingModeCatalogue.GetLabels();
        string selection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Pick Training Mode: ")
                .AddChoices(labels)
                .AddChoices(cancel)
        );
        return selection == cancel ? null : trainingModeCatalogue.GetByLabel(selection);
    }
}

TimeLimit? ConfigureTimeLimit()
{
    List<string> labels = timeLimitCatalogue.GetLabels();
    string selection = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Pick Time Limit: ")
            .AddChoices(labels)
            .AddChoices(cancel)
    );
    return selection == cancel ? null : timeLimitCatalogue.GetByLabel(selection);
}