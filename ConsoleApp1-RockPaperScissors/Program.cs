using ConsoleApp1_RockPaperScissors.Enums;
using ConsoleApp1_RockPaperScissors.Rules;

namespace ConsoleApp1_RockPaperScissors
{
    internal class Program
    {
        private static IRules _rules;
        static void Main(string[] args)
        {
            ConfigureRules();

            DisplayText("Lets play Rock Paper Scissors", ConsoleColor.Green);

            string? playerChoiceAsString;
            Choices playerChoiceAsEnum;

            do
            {
                DisplayText("Player; please enter Rock, Paper, or Scissors:", ConsoleColor.Cyan);
                playerChoiceAsString = Console.ReadLine();
            } while (!PlayerChoiceValid(playerChoiceAsString, out playerChoiceAsEnum));

            var computerChoice = _rules.GetComputerChoice();

            DisplayText($"Computer; chose {computerChoice}", ConsoleColor.Yellow);


            var result = _rules.GetResults(player: playerChoiceAsEnum, computer: computerChoice);

            DisplayText($"Result is: {result}", ConsoleColor.Magenta);
            DisplayText("Press any key to exit", ConsoleColor.Green);
            Console.ReadLine();
            return;
        }

        private static void ConfigureRules()
        {
            _rules = new GameRules();
            _rules.AddRule(choice: Choices.Rock, beats: Choices.Scissor);
            _rules.AddRule(choice: Choices.Scissor, beats: Choices.Paper);
            _rules.AddRule(choice: Choices.Paper, beats: Choices.Rock);

        }

        private static bool PlayerChoiceValid(string? playerChoiceAsString, out Choices playerChoiceAsEnum)
        {
            var isValid = !string.IsNullOrEmpty(playerChoiceAsString);

            playerChoiceAsEnum = Choices.Unknown;

            if (isValid)
            {
                isValid = Enum.TryParse<Choices>(playerChoiceAsString, ignoreCase: true, out playerChoiceAsEnum);
            }

            if (isValid)
            {
                isValid = (playerChoiceAsEnum != Choices.Unknown);
            }

            return isValid;
        }

        private static void DisplayText(string text, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(text);
            Console.ResetColor();

        }
    }
}