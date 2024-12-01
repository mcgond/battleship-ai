using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Battleship.AI.Contract;
using Battleship.AI.Engine.Strategy.Defense.Placement;

namespace Battleship.AI.Engine.Service.Defense
{
    public class DefenseService : IDefenseService
    {
        private readonly ILogger<DefenseService> _logger;
        private readonly IServiceProvider _serviceProvider;

        public DefenseService(ILogger<DefenseService> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public void PlaceShips(List<Ship> ships)
        {
            _serviceProvider.GetRequiredService<RandomPlacementStrategy>().PlaceShips(ships);
        }
    }
}
