using Microsoft.Extensions.Logging;

using Battleship.AI.Contract;
using Battleship.AI.Contract.Enumeration;
using Battleship.AI.Engine.Strategy.Offense.Target;

namespace Battleship.AI.Engine.Service.Target
{
    public class TargetService : ITargetService
    {
        private ILogger<TargetService> _logger;
        private readonly DetermineShipDirectionStrategy _determineShipDirectionStrategy;
        private readonly SinkShipStrategy _sinkShipStrategy;

        public TargetService(ILogger<TargetService> logger,
            DetermineShipDirectionStrategy determineShipDirectionStrategy,
            SinkShipStrategy sinkShipStrategy)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _determineShipDirectionStrategy = determineShipDirectionStrategy ?? throw new ArgumentNullException(nameof(determineShipDirectionStrategy));
            _sinkShipStrategy = sinkShipStrategy ?? throw new ArgumentNullException(nameof(sinkShipStrategy));
        }

        public Coordinate GetAttack(Grid grid, Ship shipToSink)
        {
            if (shipToSink.Orientation == Orientation.Unknown)
            {
                return _determineShipDirectionStrategy.GetAttack(grid, shipToSink);
            }
            else
            {
                return _sinkShipStrategy.GetAttack(grid, shipToSink);
            }
        }
    }
}
