using Spectre.Console;

namespace Phi3CsharpTest.Helpers
{
    internal static class ConsoleHelper
    {
        /// <summary>
        ///     Clears the console and creates the header for the application.
        /// </summary>
        public static void ShowHeader()
        {
            AnsiConsole.Clear();

            Grid grid = new();
            grid.AddColumn();
            grid.AddRow(new FigletText("Phi-3 Mini ONNX").Centered().Color(Color.Red));
            grid.AddRow(Align.Center(new Panel("[red]Sample by Dmitriy Borodiy ([link]https://github.com/DmitryBorodiy[/])[/])")));

            AnsiConsole.Write(grid);
            AnsiConsole.WriteLine();
        }

        /// <summary>
        ///     Gets the folder path from the user.
        /// </summary>
        /// <param name="prompt">The prompt message.</param>
        /// <returns>The folder path entered by the user.</returns>
        public static string GetFolderPath(string prompt)
        {
            return AnsiConsole.Prompt(
                new TextPrompt<string>(prompt)
                .PromptStyle("white")
                .ValidationErrorMessage("[red]Invalid path[/]")
                .Validate(prompt =>
                {
                    if (!Directory.Exists(prompt))
                    {
                        return ValidationResult.Error(
                          "[red]Path does not exist[/]");
                    }

                    return ValidationResult.Success();
                }));
        }

        /// <summary>
        ///     Writes the specified text to the console.
        /// </summary>
        /// <param name="text">The text to write.</param>
        public static void WriteToConsole(string text)
            => AnsiConsole.Markup($"[white]{text}[/]");
    }
}
