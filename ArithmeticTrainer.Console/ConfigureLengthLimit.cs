using ArithmeticTrainer.Data;
using ArithmeticTrainer.Models;
using Spectre.Console;

namespace ArithmeticTrainer.Console;

public sealed class ConfigureLengthLimit(LengthLimitCatalogue lengthLimitCatalogue)
{
    private const string Cancel = "Cancel";

    public LengthLimit? Execute()
    {
        List<string> labels = lengthLimitCatalogue.GetLabels();
        string selection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Pick Length Limit: ")
                .AddChoices(labels)
                .AddChoices(Cancel)
        );
        return selection == Cancel ? null : lengthLimitCatalogue.GetByLabel(selection);
    }
}