using Battleship.AI.Contract.Enumeration;

namespace Battleship.AI.Contract.Test
{
    public class SquareTests
    {
        [Fact]
        public void Construct_Square_ReturnsSquare()
        {
            Square square = new Square(0, 0);

            Assert.Equal("A1", square.Coordinate.ToString());
            Assert.Equal(SquareState.Empty, square.State);
            Assert.Equal(0, square.Score.Total);
            Assert.Equal(0, square.XPosition);
            Assert.Equal(0, square.YPosition);
        }

        [Fact]
        public void Set_SquareState_UpdatesSquareState()
        {
            Square square = new Square(0, 0);
            square.State = SquareState.Hit;

            Assert.Equal(SquareState.Hit, square.State);
        }

        [Fact]
        public void IsInFirstRow_SquareInFirstRow_ReturnsTrue()
        {
            Square square = new Square(5, 0);

            Assert.True(square.IsInFirstRow);
        }

        [Fact]
        public void IsInFirstRow_SquareNotInFirstRow_ReturnsFalse()
        {
            Square square = new Square(5, 5);

            Assert.False(square.IsInFirstRow);
        }

        [Fact]
        public void IsInLastRow_SquarInLastRow_ReturnsTrue()
        {
            Square square = new Square(5, 9);

            Assert.True(square.IsInLastRow);
        }

        [Fact]
        public void IsInLastRow_SquareNotInLastRow_ReturnsFalse()
        {
            Square square = new Square(5, 5);

            Assert.False(square.IsInLastRow);
        }

        [Fact]
        public void IsInFirstColumn_SquareInFirstColumn_ReturnsTrue()
        {
            Square square = new Square(0, 5);

            Assert.True(square.IsInFirstColumn);
        }

        [Fact]
        public void IsInFirstColumn_SquareNotInFirstColumn_ReturnsFalse()
        {
            Square square = new Square(5, 5);

            Assert.False(square.IsInFirstColumn);
        }

        [Fact]
        public void IsInLastColumn_SquareInLastColumn_ReturnsTrue()
        {
            Square square = new Square(9, 5);

            Assert.True(square.IsInLastColumn);
        }

        [Fact]
        public void IsInLastColumn_SquareNotInLastColumn_ReturnsFalse()
        {
            Square square = new Square(5, 5);

            Assert.False(square.IsInLastColumn);
        }

        [Theory]
        [InlineData(0, 'A')]
        [InlineData(1, 'B')]
        [InlineData(2, 'C')]
        [InlineData(3, 'D')]
        [InlineData(4, 'E')]
        [InlineData(5, 'F')]
        [InlineData(6, 'G')]
        [InlineData(7, 'H')]
        [InlineData(8, 'I')]
        [InlineData(9, 'J')]
        public void MapYPositionToLetter_YPosition_ReturnsCoordinateLetter(int yPosition, char expected)
        {
            Square square = new Square(0, yPosition);

            Assert.Equal(expected, square.Coordinate.Letter);
        }

        [Fact]
        public void MapYPositionToLetter_InvalidYPosition_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Square(0, 10));
        }
    }
}
