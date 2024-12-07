using Battleship.AI.Contract;

namespace Battleship.AI.Engine.Service.SquareScoreDetermination
{
    public interface ISquareScoreDeterminationService
    {
        void DetermineSquareScores(List<Square> squares);
    }
}
