using Battleship.AI.Contract.Enumeration;

namespace Battleship.AI.Contract
{
    public class Square
    {
        private readonly Coordinate _coordinate;
        private SquareState _state;
        private readonly Score _score;
        private readonly int _xPosition;
        private readonly int _yPosition;

        /// <summary>
        /// Gameboard coordinate of the square
        /// </summary>
        public Coordinate Coordinate
        {
            get { return _coordinate; }
        }

        /// <summary>
        /// State of the square
        /// </summary>
        public SquareState State
        {
            get { return _state; }
            set { _state = value; }
        }

        /// <summary>
        /// Score of the square
        /// </summary>
        public Score Score
        {
            get { return _score; }
        }

        /// <summary>
        /// Gameboard X position of the square.
        /// </summary>
        public int XPosition
        {
            get { return _xPosition; }
        }

        /// <summary>
        /// Gameboard Y position of the square.
        /// </summary>
        public int YPosition
        {
            get { return _yPosition; }
        }

        /// <summary>
        /// Indicates if the square is in the first row on the gameboard
        /// </summary>
        public bool IsInFirstRow
        {
            get { return _coordinate.Letter == 'A'; }
        }

        /// <summary>
        /// Indicates if the square is in the last row on the gameboard
        /// </summary>
        public bool IsInLastRow
        {
            get { return _coordinate.Letter == 'J'; }
        }

        /// <summary>
        /// Indicates if the square is in the first column on the gameboard
        /// </summary>
        public bool IsInFirstColumn
        {
            get { return _coordinate.Number == 1; }
        }

        /// <summary>
        /// Indicates if the square is in the last column on the gameboard
        /// </summary>
        public bool IsInLastColumn
        {
            get { return _coordinate.Number == 10; }
        }

        public Square(int xPosition, int yPosition)
        {
            char letter = yPosition switch
            {
                0 => 'A',
                1 => 'B',
                2 => 'C',
                3 => 'D',
                4 => 'E',
                5 => 'F',
                6 => 'G',
                7 => 'H',
                8 => 'I',
                9 => 'J',
                _ => throw new ArgumentException($"yPosition '{yPosition}' is invalid.")
            };

            // Offset the zero-indexed square position by 1 to get the correct respective number for the coordinate
            _coordinate = new Coordinate(letter, xPosition + 1);
            _state = SquareState.Empty;
            _score = new Score();

            _xPosition = xPosition;
            _yPosition = yPosition;
        }
    }
}
