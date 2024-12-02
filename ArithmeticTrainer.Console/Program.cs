using ArithmeticTrainer.Models;
using ArithmeticTrainer.Models.ProblemGenerators;
using Spectre.Console;

List<Attempt> history = [];
const string startPractice = "Start practice";
const string viewHistory = "View practice history";
const string quit = "Quit";
const string additionPractice = "Addition (+)";
const string subtractionPractice = "Subtraction (-)";
const string multiplicationPractice = "Multiplication (*)";
const string divisionPractice = "Division (/)";
const string mixedPractice = "All Together";
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
            string practiceMode = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Pick practice mode: ")
                    .AddChoices(
                        additionPractice,
                        subtractionPractice,
                        multiplicationPractice,
                        divisionPractice,
                        mixedPractice,
                        cancel));
            switch (practiceMode)
            {
                case additionPractice:
                    DoPractice(new AdditionProblemGenerator());
                    break;
                case subtractionPractice:
                    DoPractice(new SubtractionProblemGenerator());
                    break;
                case multiplicationPractice:
                    DoPractice(new MultiplicationProblemGenerator());
                    break;
                case divisionPractice:
                    DoPractice(new DivisionProblemGenerator());
                    break;
                case mixedPractice:
                    DoPractice(new MixedProblemGenerator(
                        new AdditionProblemGenerator(),
                        new SubtractionProblemGenerator(),
                        new MultiplicationProblemGenerator(),
                        new DivisionProblemGenerator()));
                    break;
                case cancel:
                    continue;
            }
            break;
        case viewHistory:
            ShowHistory();
            break;
        case quit:
            return;
    }
}

void DoPractice(ProblemGenerator problemGenerator)
{
    Console.WriteLine($"Starting practice on {problemGenerator.Description}. Press q to stop.");
    foreach (Problem problem in problemGenerator.Generate())
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