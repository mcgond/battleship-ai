using Microsoft.Extensions.Logging;

using Battleship.AI.Contract;
using Battleship.AI.Contract.Enumeration;

namespace Battleship.AI.Engine.Strategy.Offense.Hunt
{
    public class RandomScoreStrategy : IHuntStrategy
    {
        private readonly ILogger<RandomScoreStrategy> _logger;
        private readonly Random _random;

        public RandomScoreStrategy(ILogger<RandomScoreStrategy> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _random = new Random();
        }

        public Coordinate GetAttack(Grid grid)
        {
            _logger.LogDebug("Using IHuntStrategy: RandomScoreStrategy");

            List<Square> possibleAttackSquares = grid.Squares.Where(s => s.State == SquareState.Empty)
                .ToList();

            Coordinate attackCoordinate = possibleAttackSquares[_random.Next(possibleAttackSquares.Count)].Coordinate;

            _logger.LogDebug($"Selected coordinate {attackCoordinate} to attack");

            return attackCoordinate;

        }
    }
}
