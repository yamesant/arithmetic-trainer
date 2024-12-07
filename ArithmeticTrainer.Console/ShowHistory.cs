using ArithmeticTrainer.Data;
using ArithmeticTrainer.Models;
using Spectre.Console;

namespace ArithmeticTrainer.Console;

public sealed class ShowHistory(History history)
{
    public void Execute()
    {
        if (history.Attempts.Count == 0)
        {
            AnsiConsole.WriteLine("No Training Recorded Yet");
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
            foreach (Attempt attempt in history.Attempts)
            {
                table.AddRow(attempt.Problem.Question, attempt.Response, attempt.Outcome);
            }

            AnsiConsole.Write(table);
        }
    }
}