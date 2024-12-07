using ArithmeticTrainer.Data;
using ArithmeticTrainer.Models;
using Spectre.Console;

List<Attempt> history = [];
TrainingModeCatalogue trainingModeCatalogue = new();
const string startPractice = "Start practice";
const string viewHistory = "View practice history";
const string quit = "Quit";
const string cancel = "Cancel";

while (true)
{
    Console.WriteLine("Welcome to Arithmetic Trainer");
    string action = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Select action: ")
            .AddChoices(startPractice, viewHistory, quit));
    switch (action)
    {
        case startPractice:
            TrainingMode? trainingMode = ConfigureTrainingMode();
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

void DoPractice(TrainingMode trainingMode)
{
    Console.WriteLine($"Starting practice on {trainingMode.Label}. Press q to stop.");
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
        history.Add(attempt);
    }
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