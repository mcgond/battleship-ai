using Microsoft.Extensions.Logging;

using Battleship.AI.Contract;
using Battleship.AI.Contract.Enumeration;
using Battleship.AI.Engine.Enumeration;
using Battleship.AI.Engine.Service.HitShipTracking;
using Battleship.AI.Engine.Service.Hunt;
using Battleship.AI.Engine.Service.Target;
using Battleship.AI.Engine.Strategy.Offense.Misc;

namespace Battleship.AI.Engine.Service.Offense
{
    public class OffenseService : IOffenseService
    {
        private readonly ILogger<OffenseService> _logger;
        private readonly IHuntService _huntService;
        private readonly ITargetService _targetService;
        private readonly IHitShipTrackingService _hitShipTrackingService;
        private readonly MarkSquaresAsMissStrategy _markSquaresAsMissStrategy;

        private AIState _attackMode;

        public OffenseService(ILogger<OffenseService> logger,
            IHuntService huntService,
            ITargetService targetService,
            IHitShipTrackingService hitShipTrackingService,
            MarkSquaresAsMissStrategy markSquaresAsMissStrategy)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _huntService = huntService ?? throw new ArgumentNullException(nameof(huntService));
            _targetService = targetService ?? throw new ArgumentNullException(nameof(targetService));
            _hitShipTrackingService = hitShipTrackingService ?? throw new ArgumentNullException(nameof(hitShipTrackingService));
            _markSquaresAsMissStrategy = markSquaresAsMissStrategy ?? throw new ArgumentNullException(nameof(markSquaresAsMissStrategy));

            _attackMode = AIState.Hunt;
        }

        public Coordinate GetAttack(Grid grid)
        {
            _logger.LogDebug($"In AttackMode: {_attackMode}");

            if (_attackMode == AIState.Hunt)
            {
                return _huntService.GetAttack(grid);
            }
            else
            {
                return _targetService.GetAttack(grid, _hitShipTrackingService.GetFirstHitShip());
            }
        }

        public void HandleAttackResult(Gameboard opponentGameboard, Coordinate attackCoordinate, AttackResult attackResult, Ship hitShip)
        {
            switch (attackResult)
            {
                case AttackResult.Miss:
                    HandleMissResult(opponentGameboard, attackCoordinate);
                    break;

                case AttackResult.Hit:
                    HandleHitResult(opponentGameboard, attackCoordinate, hitShip);
                    break;

                case AttackResult.Sunk:
                    HandleSunkResult(opponentGameboard, attackCoordinate, hitShip);
                    break;
            };

            opponentGameboard.Grid.At(attackCoordinate).Score.ZeroOut();

            if (_attackMode != AIState.Target && opponentGameboard.Fleet.SmallestUnsunkShipSize != 0)
            {
                _markSquaresAsMissStrategy.MarkSquares(opponentGameboard.Grid, opponentGameboard.Fleet.SmallestUnsunkShipSize);
            }
        }

        private void HandleMissResult(Gameboard opponentGameboard, Coordinate attackCoordinate)
        {
            opponentGameboard.Grid.At(attackCoordinate).State = SquareState.Miss;
        }

        private void HandleHitResult(Gameboard opponentGameboard, Coordinate attackCoordinate, Ship hitShip)
        {
            opponentGameboard.Grid.At(attackCoordinate).State = SquareState.Hit;
            hitShip.Hit(attackCoordinate);

            // Switch to "Target" mode to sink hit ship
            _attackMode = AIState.Target;

            // Add the ship to the List of ships in the process of being sunk if it isn't there already
            // This covers the scenario where the opponent has placed their ships in a way where they are adjacent to each other
            _hitShipTrackingService.TryAddHitShip(hitShip);
        }

        private void HandleSunkResult(Gameboard opponentGameboard, Coordinate attackCoordinate, Ship hitShip)
        {
            opponentGameboard.Grid.At(attackCoordinate).State = SquareState.Hit;
            hitShip.Hit(attackCoordinate);

            // Remove the now sunk ship from the List of ships in the process of being sunk
            _hitShipTrackingService.RemoveFirstHitShip();

            // If there are no more hit ships to sink, go back to hunting for others
            if (_hitShipTrackingService.GetCountOfHitShips() == 0)
            {
                _attackMode = AIState.Hunt;
            }
        }
    }
}
