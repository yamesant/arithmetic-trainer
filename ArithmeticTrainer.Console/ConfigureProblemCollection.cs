using ArithmeticTrainer.Data;
using ArithmeticTrainer.Models;
using Spectre.Console;

namespace ArithmeticTrainer.Console;

public sealed class ConfigureProblemCollection(ProblemCollectionCatalogue problemCollectionCatalogue)
{
    private const string Cancel = "Cancel";
    public ProblemCollection? Execute()
    {
        List<string> labels = problemCollectionCatalogue.GetLabels();
        string selection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose Problem Collection: ")
                .AddChoices(labels)
                .AddChoices(Cancel)
        );
        return selection == Cancel ? null : problemCollectionCatalogue.GetByLabel(selection);
    }
}