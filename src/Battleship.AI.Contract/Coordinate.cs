namespace Battleship.AI.Contract
{
    public readonly struct Coordinate : IEquatable<Coordinate>
    {
        /// <summary>
        /// Letter component of a coordinate
        /// </summary>
        public char Letter { get; }

        /// <summary>
        /// Number component of a coordinate
        /// </summary>
        public int Number { get; }

        public Coordinate(char letter, int number)
        {
            Letter = letter;
            Number = number;
        }

        public Coordinate(string coordinateString)
        {
            Letter = coordinateString[0];
            Number = Convert.ToInt32(coordinateString[1..]);
        }

        public override string ToString()
        {
            return $"{Letter}{Number}".ToUpper();
        }

        public override bool Equals(object? obj) =>
            (obj is Coordinate coordinate) && Equals(coordinate);

        public bool Equals(Coordinate other) =>
            (Letter, Number) == (other.Letter, other.Number);

        public override int GetHashCode() =>
            HashCode.Combine(Letter, Number);

        public static bool operator ==(Coordinate left, Coordinate right) =>
            Equals(left, right);

        public static bool operator !=(Coordinate left, Coordinate right) =>
            !Equals(left, right);
    }
}
