using Microsoft.Extensions.Logging;

using Battleship.AI.Contract;
using Battleship.AI.Contract.Enumeration;

namespace Battleship.AI.Engine.Strategy.Offense.Misc
{
    public class MarkSquaresAsMissStrategy
    {
        private readonly ILogger<MarkSquaresAsMissStrategy> _logger;

        public MarkSquaresAsMissStrategy(ILogger<MarkSquaresAsMissStrategy> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void MarkSquares(Grid grid, int smallestRemainingShipSize)
        {
            List<int> leftRightPossibleMissList = TraverseHorizontally(grid, smallestRemainingShipSize);
            List<int> upDownPossibleMissList = TraverseVertically(grid, smallestRemainingShipSize);

            List<int> squaresToMarkAsMiss = leftRightPossibleMissList.Intersect(upDownPossibleMissList).ToList();

            foreach (int squareToMarkAsMiss in squaresToMarkAsMiss)
            {
                _logger.LogDebug($"Marked {grid.Squares[squareToMarkAsMiss].Coordinate} as miss");

                grid.Squares[squareToMarkAsMiss].State = SquareState.Miss;
                grid.Squares[squareToMarkAsMiss].Score.ZeroOut();
            }
        }

        private List<int> TraverseHorizontally(Grid grid, int smallestRemainingShipSize)
        {
            List<int> leftRightPossibleMissList = new List<int>();

            int emptySquaresCount = 0;
            int pointer = 0;

            Square square;

            // Left to right, top to bottom traversal
            for (int squareIndex = 0; squareIndex <= 99; squareIndex++)
            {
                square = grid.Squares[squareIndex];

                if (square.State == SquareState.Empty)
                {
                    emptySquaresCount++;

                    // We are at an edge so count the empty squares
                    if (square.IsInLastColumn)
                    {
                        if (emptySquaresCount < smallestRemainingShipSize)
                        {
                            for (int i = pointer; i <= squareIndex; i++)
                            {
                                leftRightPossibleMissList.Add(i);
                            }
                        }

                        pointer = squareIndex + 1;
                        emptySquaresCount = 0;
                    }
                }
                // We hit a square with a miss or hit so count the empty squares
                else
                {
                    if (emptySquaresCount < smallestRemainingShipSize)
                    {
                        for (int i = pointer; i < squareIndex; i++)
                        {
                            leftRightPossibleMissList.Add(i);
                        }
                    }

                    pointer = squareIndex + 1;
                    emptySquaresCount = 0;
                }
            }

            return leftRightPossibleMissList;
        }

        private List<int> TraverseVertically(Grid grid, int smallestRemainingShipSize)
        {
            List<int> upDownPossibleMissList = new List<int>();

            int emptySquaresCount = 0;
            int pointer = 0;

            Square square;

            // Top to bottom, left to right traversal
            for (int squareIndex = 0; squareIndex != 109; squareIndex += 10)
            {
                if (squareIndex > 99)
                {
                    squareIndex -= 99;
                }

                square = grid.Squares[squareIndex];

                if (square.State == SquareState.Empty)
                {
                    emptySquaresCount++;

                    // We are at an edge so count the empty squares
                    if (square.IsInLastRow)
                    {
                        if (emptySquaresCount < smallestRemainingShipSize)
                        {
                            for (int i = pointer; i <= squareIndex; i += 10)
                            {
                                upDownPossibleMissList.Add(i);
                            }
                        }

                        pointer = squareIndex - 89;
                        emptySquaresCount = 0;
                    }
                }
                // We hit a square with a miss or hit so count the empty squares
                else
                {
                    if (emptySquaresCount < smallestRemainingShipSize)
                    {
                        for (int i = pointer; i < squareIndex; i += 10)
                        {
                            upDownPossibleMissList.Add(i);
                        }
                    }

                    pointer = squareIndex + 10;
                    if (pointer > 99)
                    {
                        pointer -= 99;
                    }
                    emptySquaresCount = 0;
                }
            }

            return upDownPossibleMissList;
        }
    }
}
