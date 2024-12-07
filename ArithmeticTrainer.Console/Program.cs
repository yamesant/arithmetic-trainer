using System.Diagnostics;
using ArithmeticTrainer.Data;
using ArithmeticTrainer.Models;
using Spectre.Console;

List<Attempt> history = [];
TrainingModeCatalogue trainingModeCatalogue = new();
TimeLimitCatalogue timeLimitCatalogue = new();
LengthLimitCatalogue lengthLimitCatalogue = new();
const string startFixedTimeTest = "Start Fixed Time Test";
const string startFixedLengthTest = "Start Fixed Length Test";
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
            .AddChoices(startFixedTimeTest, startFixedLengthTest, startPractice, viewHistory, quit));
    TrainingMode? trainingMode;
    switch (action)
    {
        case startFixedTimeTest:
            trainingMode = ConfigureTrainingMode();
            if (trainingMode is null) break;
            TimeLimit? timeLimit = ConfigureTimeLimit();
            if (timeLimit is null) break;
            do
            {
                DoFixedTimeTest(trainingMode, timeLimit);
            } while (AnsiConsole.Prompt(new ConfirmationPrompt("Try Again?")));
            break;
        case startFixedLengthTest:
            trainingMode = ConfigureTrainingMode();
            if (trainingMode is null) break;
            LengthLimit? lengthLimit = ConfigureLengthLimit();
            if (lengthLimit is null) break;
            do
            {
                DoFixedLengthTest(trainingMode, lengthLimit);
            } while (AnsiConsole.Prompt(new ConfirmationPrompt("Try Again?")));
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

void DoFixedLengthTest(TrainingMode trainingMode, LengthLimit lengthLimit)
{
    int incorrectResponsePenaltyInSeconds = 10;
    AnsiConsole.WriteLine($"Starting {lengthLimit.Label} test on {trainingMode.Label}.");
    List<Attempt> attempts = [];
    Stopwatch stopwatch = Stopwatch.StartNew();
    for (int i = 1; i <= lengthLimit.Value; i++)
    {
        Problem problem = trainingMode.ProblemGenerator.Next();
        AnsiConsole.WriteLine(problem.Question);
        string response = Console.ReadLine() ?? "";
        Attempt attempt = new(problem, response);
        AnsiConsole.WriteLine($"{attempt.Outcome}. Problems remaining: {lengthLimit.Value-i}");
        attempts.Add(attempt);
    }

    TimeSpan elapsedTime = stopwatch.Elapsed;
    int correctCount = attempts.Count(attempt => attempt.IsCorrect);
    int incorrectCount = attempts.Count - correctCount;
    TimeSpan penaltyTime = TimeSpan.FromSeconds(incorrectCount * incorrectResponsePenaltyInSeconds);
    TimeSpan finishTime = elapsedTime + penaltyTime;
    AnsiConsole.WriteLine($"Finish Time: {Format(finishTime)} (including {Format(penaltyTime)} penalty time)");

    history.AddRange(attempts);
    
    string Format(TimeSpan timeSpan)
    {
        return timeSpan >= TimeSpan.FromHours(1) ? "Over 1 Hour" : timeSpan.ToString(@"mm\:ss");
    }
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

LengthLimit? ConfigureLengthLimit()
{
    List<string> labels = lengthLimitCatalogue.GetLabels();
    string selection = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Pick Length Limit: ")
            .AddChoices(labels)
            .AddChoices(cancel)
    );
    return selection == cancel ? null : lengthLimitCatalogue.GetByLabel(selection);
}