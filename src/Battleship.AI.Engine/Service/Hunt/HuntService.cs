using Microsoft.Extensions.Logging;

using Battleship.AI.Contract;
using Battleship.AI.Engine.Strategy.Offense.Hunt;

namespace Battleship.AI.Engine.Service.Hunt
{
    public class HuntService : IHuntService
    {
        private readonly ILogger<HuntService> _logger;
        private readonly HighScoreStrategy _highScoreStrategy;
        private readonly LowScoreStrategy _lowScoreStrategy;
        private readonly RandomScoreStrategy _randomScoreStrategy;

        private readonly Random _random;

        public HuntService(ILogger<HuntService> logger,
            HighScoreStrategy highScoreStrategy,
            LowScoreStrategy lowScoreStrategy,
            RandomScoreStrategy randomScoreStrategy)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _highScoreStrategy = highScoreStrategy ?? throw new ArgumentNullException(nameof(highScoreStrategy));
            _lowScoreStrategy = lowScoreStrategy ?? throw new ArgumentNullException(nameof(lowScoreStrategy));
            _randomScoreStrategy = randomScoreStrategy ?? throw new ArgumentNullException(nameof(randomScoreStrategy));

            _random = new Random();
        }

        public Coordinate GetAttack(Grid grid)
        {
            return _random.Next(1, 101) switch
            {
                >= 1 and <= 95 => _highScoreStrategy.GetAttack(grid),
                > 95 and <= 99 => _lowScoreStrategy.GetAttack(grid),
                _ => _randomScoreStrategy.GetAttack(grid)
            };
        }
    }
}
