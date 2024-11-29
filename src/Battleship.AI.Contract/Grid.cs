namespace Battleship.AI.Contract
{
    public class Grid
    {
        private readonly List<Square> _squares;

        public List<Square> Squares
        {
            get { return _squares; }
        }

        public Grid()
        {
            _squares = new List<Square>();

            for (int yCoordinate = 0; yCoordinate <= 9; yCoordinate++)
            {
                for (int xCoordinate = 0; xCoordinate <= 9; xCoordinate++)
                {
                    _squares.Add(new Square(xCoordinate, yCoordinate));
                }
            }
        }

        /// <summary>
        /// Get the square at the provided coordinate
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        public Square At(Coordinate coordinate)
        {
            return _squares.Where(s => s.Coordinate == coordinate).First();
        }

        /// <summary>
        /// Get the square to the left of the provided square
        /// </summary>
        /// <param name="square"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public Square LeftOf(Square square)
        {
            if (square.IsInFirstColumn)
            {
                throw new ArgumentException($"Square with coordinate {square.Coordinate} is in the first column of the gameboard. Cannot get square to the left of this square.");
            }

            return _squares.Where(s => s.XPosition == square.XPosition - 1 && s.YPosition == square.YPosition).Single();
        }

        /// <summary>
        /// Get the square to the right of the provided square
        /// </summary>
        /// <param name="square"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public Square RightOf(Square square)
        {
            if (square.IsInLastColumn)
            {
                throw new ArgumentException($"Square with coordinate {square.Coordinate} is in the last column of the gameboard. Cannot get square to the right of this square.");

            }

            return _squares.Where(s => s.XPosition == square.XPosition + 1 && s.YPosition == square.YPosition).Single();
        }

        /// <summary>
        /// Get the square above the provided square
        /// </summary>
        /// <param name="square"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public Square Above(Square square)
        {
            if (square.IsInFirstRow)
            {
                throw new ArgumentException($"Square with coordinate {square.Coordinate} is in the first row of the gameboard. Cannot get square above this square.");

            }

            return _squares.Where(s => s.XPosition == square.XPosition && s.YPosition == square.YPosition - 1).Single();
        }

        /// <summary>
        /// Get the square below the provided square
        /// </summary>
        /// <param name="square"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public Square Below(Square square)
        {
            if (square.IsInLastRow)
            {
                throw new ArgumentException($"Square with coordinate {square.Coordinate} is in the last row of the gameboard. Cannot get square below this square.");

            }

            return _squares.Where(s => s.XPosition == square.XPosition && s.YPosition == square.YPosition + 1).Single();
        }
    }
}
