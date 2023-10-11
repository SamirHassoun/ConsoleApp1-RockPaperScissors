using ConsoleApp1_RockPaperScissors.Enums;

namespace ConsoleApp1_RockPaperScissors.Rules
{
    internal interface IRules
    {
        void AddRule(Choices choice, Choices beats);
        Choices GetComputerChoice();
        Results GetResults(Choices player, Choices computer);
        bool PlayerChoiceValid(Choices playerChoice);
    }
}