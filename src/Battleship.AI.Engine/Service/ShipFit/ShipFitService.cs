using Microsoft.Extensions.Logging;

using Battleship.AI.Contract;
using Battleship.AI.Contract.Enumeration;

namespace Battleship.AI.Engine.Service.ShipFit
{
    public class ShipFitService : IShipFitService
    {
        private readonly ILogger<ShipFitService> _logger;

        public ShipFitService(ILogger<ShipFitService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public bool DoesShipFitHorizontally(Grid grid, Ship shipToSink)
        {
            Coordinate firstHitCoordinate = shipToSink.Location[0];

            int horizontalCount = 1;

            // Get all squares to the left of the first hit.
            // Stop at the edge of the board or if a non-empty square is reached.
            Square currentSquare = grid.At(firstHitCoordinate);
            while (!currentSquare.IsInFirstColumn && grid.LeftOf(currentSquare).State == SquareState.Empty)
            {
                horizontalCount++;
                currentSquare = grid.LeftOf(currentSquare);
            }

            // Get all squares to the right of the first hit.
            // Stop at the edge of the board or if a non-empty square is reached.
            currentSquare = grid.At(firstHitCoordinate);
            while (!currentSquare.IsInLastColumn && grid.RightOf(currentSquare).State == SquareState.Empty)
            {
                horizontalCount++;
                currentSquare = grid.RightOf(currentSquare);
            }

            return horizontalCount >= shipToSink.Size;
        }

        public bool DoesShipFitVertically(Grid grid, Ship shipToSink)
        {
            Coordinate firstHitCoordinate = shipToSink.Location[0];

            int verticalCount = 1;

            // Get all squares above the first hit.
            // Stop at the edge of the board or if a non-empty square is reached.
            Square currentSquare = grid.At(firstHitCoordinate);
            while (!currentSquare.IsInFirstRow && grid.Above(currentSquare).State == SquareState.Empty)
            {
                verticalCount++;
                currentSquare = grid.Above(currentSquare);
            }

            // Get all squares below the first hit.
            // Stop at the edge of the board or if a non-empty square is reached.
            currentSquare = grid.At(firstHitCoordinate);
            while (!currentSquare.IsInLastRow && grid.Below(currentSquare).State == SquareState.Empty)
            {
                verticalCount++;
                currentSquare = grid.Below(currentSquare);
            }

            return verticalCount >= shipToSink.Size;
        }
    }
}
