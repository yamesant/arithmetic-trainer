using ArithmeticTrainer.Data;
using ArithmeticTrainer.Models;
using Spectre.Console;

namespace ArithmeticTrainer.Console;

public sealed class ConfigureTimeLimit(TimeLimitCatalogue timeLimitCatalogue)
{
    private const string Cancel = "Cancel";
    public TimeLimit? Execute()
    {
        List<string> labels = timeLimitCatalogue.GetLabels();
        string selection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Pick Time Limit: ")
                .AddChoices(labels)
                .AddChoices(Cancel)
        );
        return selection == Cancel ? null : timeLimitCatalogue.GetByLabel(selection);
    }
}