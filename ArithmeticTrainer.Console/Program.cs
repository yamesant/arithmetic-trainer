Random random = new();

while (true)
{
    int result = random.Next(4, 100);
    int x = random.Next(2, result - 1);
    int y = result - x;
    Console.WriteLine($"{x} + {y} = ?");
    string input = Console.ReadLine() ?? "";
    if (input != result.ToString())
    {
        Console.WriteLine($"Wrong, the answer is {result}");
    }
    else
    {
        Console.WriteLine("Correct");
    }
}
