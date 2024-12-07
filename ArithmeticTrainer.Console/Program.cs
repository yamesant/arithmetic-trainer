using ArithmeticTrainer.Console;
using ArithmeticTrainer.Data;
using ArithmeticTrainer.Models;
using Spectre.Console;

History history = new();
DoFixedTimeTest doFixedTimeTest = new(history);
DoFixedLengthTest doFixedLengthTest = new(history);
DoPractice doPractice = new(history);
ShowHistory showHistory = new(history);
TrainingModeCatalogue trainingModeCatalogue = new();
TimeLimitCatalogue timeLimitCatalogue = new();
LengthLimitCatalogue lengthLimitCatalogue = new();
ConfigureTrainingMode configureTrainingMode = new(trainingModeCatalogue);
ConfigureTimeLimit configureTimeLimit = new(timeLimitCatalogue);
ConfigureLengthLimit configureLengthLimit = new(lengthLimitCatalogue);

const string startFixedTimeTest = "Start Fixed Time Test";
const string startFixedLengthTest = "Start Fixed Length Test";
const string startPractice = "Start Practice";
const string viewHistory = "View Training History";
const string quit = "Quit";

while (true)
{
    Console.WriteLine("Welcome to Arithmetic Trainer");
    string action = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Select Action: ")
            .AddChoices(startFixedTimeTest, startFixedLengthTest, startPractice, viewHistory, quit));
    TrainingMode? trainingMode;
    switch (action)
    {
        case startFixedTimeTest:
            trainingMode = configureTrainingMode.Execute();
            if (trainingMode is null) break;
            TimeLimit? timeLimit = configureTimeLimit.Execute();
            if (timeLimit is null) break;
            do
            {
                doFixedTimeTest.Execute(trainingMode, timeLimit);
            } while (AnsiConsole.Prompt(new ConfirmationPrompt("Try Again?")));
            break;
        case startFixedLengthTest:
            trainingMode = configureTrainingMode.Execute();
            if (trainingMode is null) break;
            LengthLimit? lengthLimit = configureLengthLimit.Execute();
            if (lengthLimit is null) break;
            do
            {
                doFixedLengthTest.Execute(trainingMode, lengthLimit);
            } while (AnsiConsole.Prompt(new ConfirmationPrompt("Try Again?")));
            break;
        case startPractice:
            trainingMode = configureTrainingMode.Execute();
            if (trainingMode is null) break;
            doPractice.Execute(trainingMode);
            break;
        case viewHistory:
            showHistory.Execute();
            break;
        case quit:
            return;
    }
}