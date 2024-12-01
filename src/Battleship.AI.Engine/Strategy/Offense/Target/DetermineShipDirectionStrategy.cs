using Microsoft.Extensions.Logging;

using Battleship.AI.Contract;
using Battleship.AI.Contract.Enumeration;
using Battleship.AI.Engine.Service.ShipFit;

namespace Battleship.AI.Engine.Strategy.Offense.Target
{
    public class DetermineShipDirectionStrategy : ITargetStrategy
    {
        private readonly ILogger<DetermineShipDirectionStrategy> _logger;
        private readonly IShipFitService _shipFitService;

        public DetermineShipDirectionStrategy(ILogger<DetermineShipDirectionStrategy> logger,
            IShipFitService shipFitService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _shipFitService = shipFitService ?? throw new ArgumentNullException(nameof(shipFitService));
        }

        public Coordinate GetAttack(Grid grid, Ship shipToSink)
        {
            _logger.LogDebug("Using ITargetStrategy: DetermineShipDirectionStrategy");

            List<Square> possibleAttackSquares = new List<Square>();
            Square firstHitSquare = grid.At(shipToSink.Location[0]);

            if (_shipFitService.DoesShipFitHorizontally(grid, shipToSink))
            {
                if (!firstHitSquare.IsInFirstColumn && grid.LeftOf(firstHitSquare).State == SquareState.Empty)
                {
                    possibleAttackSquares.Add(grid.LeftOf(firstHitSquare));
                }

                if (!firstHitSquare.IsInLastColumn && grid.RightOf(firstHitSquare).State == SquareState.Empty)
                {
                    possibleAttackSquares.Add(grid.RightOf(firstHitSquare));
                }
            }

            if (_shipFitService.DoesShipFitVertically(grid, shipToSink))
            {
                if (!firstHitSquare.IsInFirstRow && grid.Above(firstHitSquare).State == SquareState.Empty)
                {
                    possibleAttackSquares.Add(grid.Above(firstHitSquare));
                }

                if (!firstHitSquare.IsInLastRow && grid.Below(firstHitSquare).State == SquareState.Empty)
                {
                    possibleAttackSquares.Add(grid.Below(firstHitSquare));
                }
            }

            // Pick the square with the highest score
            possibleAttackSquares = possibleAttackSquares.OrderByDescending(s => s.Score.Total).ToList();
            Coordinate attackCoordinate = possibleAttackSquares[0].Coordinate;

            _logger.LogDebug($"Selected coordinate {attackCoordinate} to attack");

            return attackCoordinate;
        }
    }
}
