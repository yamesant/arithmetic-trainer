using ArithmeticTrainer.Console;
using ArithmeticTrainer.Data;
using ArithmeticTrainer.Models;
using Spectre.Console;

History history = new();
DoFixedTimeTest doFixedTimeTest = new(history);
DoFixedLengthTest doFixedLengthTest = new(history);
DoPractice doPractice = new(history);
ShowHistory showHistory = new(history);
ProblemCollectionCatalogue problemCollectionCatalogue = new();
TimeLimitCatalogue timeLimitCatalogue = new();
LengthLimitCatalogue lengthLimitCatalogue = new();
ConfigureProblemCollection configureProblemCollection = new(problemCollectionCatalogue);
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
    ProblemCollection? problemCollection;
    switch (action)
    {
        case startFixedTimeTest:
            problemCollection = configureProblemCollection.Execute();
            if (problemCollection is null) break;
            TimeLimit? timeLimit = configureTimeLimit.Execute();
            if (timeLimit is null) break;
            do
            {
                doFixedTimeTest.Execute(problemCollection, timeLimit);
            } while (AnsiConsole.Prompt(new ConfirmationPrompt("Try Again?")));
            break;
        case startFixedLengthTest:
            problemCollection = configureProblemCollection.Execute();
            if (problemCollection is null) break;
            LengthLimit? lengthLimit = configureLengthLimit.Execute();
            if (lengthLimit is null) break;
            do
            {
                doFixedLengthTest.Execute(problemCollection, lengthLimit);
            } while (AnsiConsole.Prompt(new ConfirmationPrompt("Try Again?")));
            break;
        case startPractice:
            problemCollection = configureProblemCollection.Execute();
            if (problemCollection is null) break;
            doPractice.Execute(problemCollection);
            break;
        case viewHistory:
            showHistory.Execute();
            break;
        case quit:
            return;
    }
}