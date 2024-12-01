using Microsoft.Extensions.Logging;

using Battleship.AI.Contract;
using Battleship.AI.Contract.Enumeration;

namespace Battleship.AI.Engine.Strategy.Offense.Target
{
    public class SinkShipStrategy : ITargetStrategy
    {
        private readonly ILogger<SinkShipStrategy> _logger;

        public SinkShipStrategy(ILogger<SinkShipStrategy> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Coordinate GetAttack(Grid grid, Ship shipToSink)
        {
            _logger.LogDebug("Using ITargetStrategy: SinkShipStrategy");

            List<Square> possibleAttackSquares = new List<Square>();

            if (shipToSink.Orientation == Orientation.Horizontal)
            {
                foreach (Coordinate coordinate in shipToSink.Location)
                {
                    Square coordinateSquare = grid.At(coordinate);

                    // Try adding square to the left
                    if (!coordinateSquare.IsInFirstColumn && grid.LeftOf(coordinateSquare).State == SquareState.Empty)
                    {
                        possibleAttackSquares.Add(grid.LeftOf(coordinateSquare));
                    }

                    // Try adding square to the right
                    if (!coordinateSquare.IsInLastColumn && grid.RightOf(coordinateSquare).State == SquareState.Empty)
                    {
                        possibleAttackSquares.Add(grid.RightOf(coordinateSquare));
                    }
                }
            }
            else
            {
                foreach (Coordinate coordinate in shipToSink.Location)
                {
                    Square coordinateSquare = grid.At(coordinate);

                    // Try adding square above
                    if (!coordinateSquare.IsInFirstRow && grid.Above(coordinateSquare).State == SquareState.Empty)
                    {
                        possibleAttackSquares.Add(grid.Above(coordinateSquare));
                    }

                    // Try adding square below
                    if (!coordinateSquare.IsInLastRow && grid.Below(coordinateSquare).State == SquareState.Empty)
                    {
                        possibleAttackSquares.Add(grid.Below(coordinateSquare));
                    }
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
