using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Battleship.AI.Contract;
using Battleship.AI.Engine.Strategy.Offense.Hunt;

namespace Battleship.AI.Engine.Service.Hunt
{
    public class HuntService : IHuntService
    {
        private readonly ILogger<HuntService> _logger;
        private readonly IServiceProvider _serviceProvider;

        private readonly Random _random;

        public HuntService(ILogger<HuntService> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

            _random = new Random();
        }

        public Coordinate GetAttack(Grid grid)
        {
            return _random.Next(1, 101) switch
            {
                >= 1 and <= 95 => _serviceProvider.GetRequiredService<HighScoreStrategy>().GetAttack(grid),
                > 95 and <= 99 => _serviceProvider.GetRequiredService<LowScoreStrategy>().GetAttack(grid),
                _ => _serviceProvider.GetRequiredService<RandomScoreStrategy>().GetAttack(grid)
            };
        }
    }
}
