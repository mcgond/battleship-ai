using Microsoft.Extensions.Logging;

using Battleship.AI.Contract;

namespace Battleship.AI.Engine.Strategy.Defense.Placement
{
    public class RandomPlacementStrategy : IPlacementStrategy
    {
        private readonly ILogger<RandomPlacementStrategy> _logger;
        private readonly Random _random;

        public RandomPlacementStrategy(ILogger<RandomPlacementStrategy> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _random = new Random();
        }

        public void PlaceShips(List<Ship> ships)
        {
            _logger.LogDebug("Using IPlacementStrategy: RandomPlacementStrategy");

            List<Coordinate> usedCoordinates = new List<Coordinate>();

            foreach (Ship ship in ships)
            {
                List<Coordinate> proposedShipCoordinates = new List<Coordinate>();

                do
                {
                    proposedShipCoordinates.Clear();

                    // Determine orientation using a random number
                    // Even: horizontal orientation
                    if ((_random.Next(1, 101) % 2) == 0)
                    {
                        // Starting X coordinate needs to be {{ship.Size}} away from right edge
                        // Otherwise it would go off the board and not be legal
                        int startingXCoordinate = _random.Next(0, 10 - ship.Size);
                        int startingYCoordinate = _random.Next(0, 10);

                        // Once the starting coordinate is determined, fill in the rest to the right
                        for (int i = 0; i < ship.Size; i++)
                        {
                            Square square = new Square(startingXCoordinate + i, startingYCoordinate);
                            proposedShipCoordinates.Add(square.Coordinate);
                        }
                    }
                    // Odd: vertical orientation
                    else
                    {
                        // Starting Y coordinate needs to be {{ship.Size}} away from bottom edge
                        // Otherwise it would go off the board and not be legal
                        int startingXCoordinate = _random.Next(0, 10);
                        int startingYCoordinate = _random.Next(0, 10 - ship.Size);

                        // Once the starting coordinate is determined, fill in the rest below
                        for (int i = 0; i < ship.Size; i++)
                        {
                            Square square = new Square(startingXCoordinate, startingYCoordinate + i);
                            proposedShipCoordinates.Add(square.Coordinate);
                        }
                    }
                } while (!IsValidPlacement(proposedShipCoordinates, usedCoordinates));

                usedCoordinates.AddRange(proposedShipCoordinates);
                ship.Place(proposedShipCoordinates);
            }
        }

        /// <summary>
        /// Determines if the proposed location for the ship is valid
        /// Since placement start logic handles the ship not being placed off the board, simply
        /// check if the proposedShipCoordinates intersects with an already placed ship
        /// </summary>
        /// <param name="placedShipCoordinates"></param>
        /// <param name="usedCoordinates"></param>
        /// <returns></returns>
        private bool IsValidPlacement(List<Coordinate> proposedShipCoordinates, List<Coordinate> usedCoordinates)
        {
            return !usedCoordinates.Any(proposedShipCoordinates.Contains);
        }
    }
}
