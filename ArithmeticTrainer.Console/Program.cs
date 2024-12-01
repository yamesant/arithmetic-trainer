Random random = new();

while (true)
{
    Console.WriteLine("Welcome to Arithmetic Trainer");
    Console.WriteLine("Pick operation to practice: +, -, *, /");
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
        Console.WriteLine($"{x} + {y} = ?");
        string input = Console.ReadLine() ?? "";
        if (input == "q")
        {
            break;
        }
        if (input != result.ToString())
        {
            Console.WriteLine($"Wrong, the answer is {result}");
        }
        else
        {
            Console.WriteLine("Correct");
        }
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
        Console.WriteLine($"{x} - {y} = ?");
        string input = Console.ReadLine() ?? "";
        if (input == "q")
        {
            break;
        }
        if (input != result.ToString())
        {
            Console.WriteLine($"Wrong, the answer is {result}");
        }
        else
        {
            Console.WriteLine("Correct");
        }
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
        Console.WriteLine($"{x} * {y} = ?");
        string input = Console.ReadLine() ?? "";
        if (input == "q")
        {
            break;
        }
        if (input != result.ToString())
        {
            Console.WriteLine($"Wrong, the answer is {result}");
        }
        else
        {
            Console.WriteLine("Correct");
        }
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
        Console.WriteLine($"{x} / {y} = ?");
        string input = Console.ReadLine() ?? "";
        if (input == "q")
        {
            break;
        }
        if (input != result.ToString())
        {
            Console.WriteLine($"Wrong, the answer is {result}");
        }
        else
        {
            Console.WriteLine("Correct");
        }
    }
}