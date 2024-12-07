using Battleship.AI.Contract;

namespace Battleship.AI.Engine.Service.ScoreCalculation
{
    public interface IScoreCalculationService
    {
        void Calculate(Score score);
    }
}
