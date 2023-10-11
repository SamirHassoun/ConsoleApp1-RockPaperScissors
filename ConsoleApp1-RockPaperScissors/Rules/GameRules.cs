using ConsoleApp1_RockPaperScissors.Enums;
using ConsoleApp1_RockPaperScissors.Models;

namespace ConsoleApp1_RockPaperScissors.Rules
{
    internal class GameRules : IRules
    {
        private readonly Dictionary<Choices, RulesModel> _rules;

        public GameRules()
        {
            _rules = new Dictionary<Choices, RulesModel>();
        }

        public void AddRule(Choices choice, Choices beats)
        {
            if (_rules.ContainsKey(choice))
                throw new InvalidOperationException($"{choice} already exists in Rules");

            if (choice == beats)
                throw new InvalidOperationException($"{nameof(choice)} must not be the same as {nameof(beats)}");

            _rules.Add(choice, new RulesModel { Choice = choice, Beats = beats });
        }

        public Results GetResults(Choices player, Choices computer)
        {
            if (player == computer)
                return Results.Tie;

            var rule = _rules[player];

            if (rule.Beats == computer)
                return Results.Player_Won;

            return Results.Computer_Won;
        }

        public Choices GetComputerChoice()
        {
            var random = new Random();
            var index = random.Next(0, _rules.Count);

            return _rules.Keys.ElementAt(index);
        }

        public bool PlayerChoiceValid(Choices playerChoice) => _rules.ContainsKey(playerChoice);
    }
}
