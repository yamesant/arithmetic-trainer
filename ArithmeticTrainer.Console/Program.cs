using ArithmeticTrainer.Models;
using ArithmeticTrainer.Models.ProblemGenerators;

List<Attempt> history = [];

while (true)
{
    Console.WriteLine("Welcome to Arithmetic Trainer");
    Console.WriteLine("Pick operation: +, -, *, / to start a new practice");
    Console.WriteLine("Press a to start mixed practice");
    Console.WriteLine("Press h to view practice history");
    Console.WriteLine("Press q to quit");
    string input = Console.ReadLine() ?? "";
    switch (input)
    {
        case "+":
            DoPractice(new AdditionProblemGenerator());
            break;
        case "-":
            DoPractice(new SubtractionProblemGenerator());
            break;
        case "*":
            DoPractice(new MultiplicationProblemGenerator());
            break;
        case "/":
            DoPractice(new DivisionProblemGenerator());
            break;
        case "a":
            DoPractice(new MixedProblemGenerator(
                new AdditionProblemGenerator(),
                new SubtractionProblemGenerator(),
                new MultiplicationProblemGenerator(),
                new DivisionProblemGenerator()));
            break;
        case "h":
            ShowHistory();
            break;
        case "q":
            return;
        default:
            Console.WriteLine("Unrecognised command");
            break;
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
        foreach (Attempt attempt in history)
        {
            Console.WriteLine($"{attempt.Problem.Question} Response: {attempt.Response} Outcome: {attempt.Outcome}");
        }
    }
}