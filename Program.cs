using QuizPortfolioApp;
using Spectre.Console;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        AnsiConsole.MarkupLine("[bold red]Welcome to the[/] [italic yellow]Geography Quiz![/]");
        AnsiConsole.MarkupLine("[cyan]Get ready and GOOD LUCK![/]");
        AnsiConsole.MarkupLine("\nPress any key to start...");
        Console.ReadKey(true);

        string jsonFilePath = "geografi.json";
        string json = File.ReadAllText(jsonFilePath);
        QuizData quizData = JsonSerializer.Deserialize<QuizData>(json);

        int correctAnswers = 0;
        int totalQuestions = 0;

        AnsiConsole.MarkupLine("[bold green]Let's begin the quiz![/]");

        foreach (var category in quizData.Categories)
        {
            AnsiConsole.MarkupLine($"\n[underline][bold]Category:[/] {category.CategoryName}[/]");
            totalQuestions += category.Questions.Count;

            foreach (var question in category.Questions)
            {
                AnsiConsole.MarkupLine($"\n[underline]Question:[/] {question.QuestionText}");

                var options = new List<string>(question.Options);
                var selectedOption = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Select an answer")
                        .PageSize(10)
                        .AddChoices(options)
                );

                if (selectedOption == question.CorrectAnswer)
                {
                    AnsiConsole.MarkupLine("[green]Correct answer![/]");
                    correctAnswers++;
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Incorrect answer![/]");
                }

                AnsiConsole.MarkupLine("\nPress any key to continue...");
                Console.ReadKey(true);
            }
        }

        AnsiConsole.MarkupLine($"\n[bold yellow]The quiz is finished![/]");
        AnsiConsole.MarkupLine($"[bold]Correct answers:[/] {correctAnswers} out of {totalQuestions}");
        AnsiConsole.MarkupLine($"[bold]Incorrect answers:[/] {totalQuestions - correctAnswers}");

        string rank = GetRank(correctAnswers);
        AnsiConsole.MarkupLine($"\n[bold green]Your rank: {rank}[/]");

        string resultMessage = GetResultMessage(correctAnswers);
        AnsiConsole.MarkupLine($"\n[bold cyan]{resultMessage}[/]");

        Console.WriteLine("Thank you for playing!");
    }

    static string GetRank(int correctAnswers)
    {
        if (correctAnswers >= 9)
        {
            return "Advanced";
        }
        else if (correctAnswers >= 6)
        {
            return "Intermediate";
        }
        else if (correctAnswers >= 3)
        {
            return "Novice";
        }
        else
        {
            return "Beginner";
        }

    }
    static string GetResultMessage(int correctAnswers)
    {
        if (correctAnswers >= 9)
        {
            return "Excellent work! You're an expert!";
        }
        else if (correctAnswers >= 6)
        {
            return "Good job! You're doing great!";
        }
        else if (correctAnswers >= 3)
        {
            return "Almost there! But you did a good job!";
        }
        else if (correctAnswers == 0)
        {
            return "Unlucky! Better luck next time!";
        }
        else
        {
            return "Nice try! Keep practicing and you'll improve!";
        }
    }

}











