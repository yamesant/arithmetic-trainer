using ArithmeticTrainer.Data;
using ArithmeticTrainer.Models;
using Spectre.Console;

namespace ArithmeticTrainer.Console;

public sealed class ConfigureTrainingMode(TrainingModeCatalogue trainingModeCatalogue)
{
    private const string Cancel = "Cancel";
    public TrainingMode? Execute()
    {
        List<string> labels = trainingModeCatalogue.GetLabels();
        string selection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Pick Training Mode: ")
                .AddChoices(labels)
                .AddChoices(Cancel)
        );
        return selection == Cancel ? null : trainingModeCatalogue.GetByLabel(selection);
    }
}