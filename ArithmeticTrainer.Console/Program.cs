using ArithmeticTrainer.Models;

List<Attempt> history = [];
Random random = new();

while (true)
{
    Console.WriteLine("Welcome to Arithmetic Trainer");
    Console.WriteLine("Pick operation: +, -, *, / to start a new practice");
    Console.WriteLine("Press h to view practice history");
    Console.WriteLine("Press q to quit");
    string input = Console.ReadLine() ?? "";
    switch (input)
    {
        case "+":
            DoAddition();
            break;
        case "-":
            DoSubtraction();
            break;
        case "*":
            DoMultiplication();
            break;
        case "/":
            DoDivision();
            break;
        case "h":
            ShowHistory();
            break;
        case "q":
            return;
        default:
            Console.WriteLine("Unrecognised operation");
            break;
    }
}

void DoAddition()
{
    Console.WriteLine("Starting addition practice. Press q to stop.");
    while (true)
    {
        int result = random.Next(4, 100);
        int x = random.Next(2, result - 1);
        int y = result - x;
        Problem problem = new($"{x} + {y} = ?", result.ToString());
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

void DoSubtraction()
{
    Console.WriteLine("Starting subtraction practice. Press q to stop.");
    while (true)
    {
        int result = random.Next(2, 98);
        int x = random.Next(result + 2, 100);
        int y = x - result;
        Problem problem = new($"{x} - {y} = ?", result.ToString());
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

(int, int, int) GenerateMultiplicationTriple()
{
    while (true)
    {
        int product = random.Next(4, 100);
        List<int> divisors = [];
        for (int d = 2; d <= product / 2; d++)
        {
            if (product % d == 0)
            {
                divisors.Add(d);
            }
        }
        if (divisors.Count == 0)
        {
            continue;
        }
        int x = divisors[random.Next(0, divisors.Count)];
        int y = product / x;
        return (x, y, product);
    }
}

void DoMultiplication()
{
    Console.WriteLine("Starting multiplication practice. Press q to stop.");
    while (true)
    {
        (int x, int y, int result) = GenerateMultiplicationTriple();
        Problem problem = new($"{x} * {y} = ?", result.ToString());
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

void DoDivision()
{
    Console.WriteLine("Starting division practice. Press q to stop.");
    while (true)
    {
        int result = random.Next(2, 50);
        int y = random.Next(2, 99 / result + 1);
        int x = result * y;
        Problem problem = new($"{x} / {y} = ?", result.ToString());
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