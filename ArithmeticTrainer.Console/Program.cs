Random random = new();

while (true)
{
    Console.WriteLine("Welcome to Arithmetic Trainer");
    Console.WriteLine("Pick operation to practice: +, -, /");
    string input = Console.ReadLine() ?? "";
    switch (input)
    {
        case "+":
            DoAddition();
            break;
        case "-":
            DoSubtraction();
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