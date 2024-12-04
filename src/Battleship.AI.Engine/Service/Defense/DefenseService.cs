using Microsoft.Extensions.Logging;

using Battleship.AI.Contract;
using Battleship.AI.Engine.Strategy.Defense.Placement;

namespace Battleship.AI.Engine.Service.Defense
{
    public class DefenseService : IDefenseService
    {
        private readonly ILogger<DefenseService> _logger;
        private readonly RandomPlacementStrategy _randomPlacementStrategy;

        public DefenseService(ILogger<DefenseService> logger,
            RandomPlacementStrategy randomPlacementStrategy)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _randomPlacementStrategy = randomPlacementStrategy ?? throw new ArgumentNullException(nameof(randomPlacementStrategy));
        }

        public void PlaceShips(List<Ship> ships)
        {
            _randomPlacementStrategy.PlaceShips(ships);
        }
    }
}
