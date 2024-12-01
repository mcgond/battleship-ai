using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Battleship.AI.Contract;
using Battleship.AI.Contract.Enumeration;
using Battleship.AI.Engine.Strategy.Offense.Target;

namespace Battleship.AI.Engine.Service.Target
{
    public class TargetService : ITargetService
    {
        private ILogger<TargetService> _logger;
        private readonly IServiceProvider _serviceProvider;

        public TargetService(ILogger<TargetService> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public Coordinate GetAttack(Grid grid, Ship shipToSink)
        {
            if (shipToSink.Orientation == Orientation.Unknown)
            {
                return _serviceProvider.GetRequiredService<DetermineShipDirectionStrategy>().GetAttack(grid, shipToSink);
            }
            else
            {
                return _serviceProvider.GetRequiredService<SinkShipStrategy>().GetAttack(grid, shipToSink);
            }
        }
    }
}
