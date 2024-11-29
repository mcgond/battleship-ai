namespace Battleship.AI.Contract.Test
{
    public class GridTests
    {
        [Fact]
        public void Construct_Grid_ReturnsGrid()
        {
            Grid grid = new Grid();

            Assert.Equal(100, grid.Squares.Count);
            Assert.Equal("A1", grid.Squares[0].Coordinate.ToString());
            Assert.Equal("J10", grid.Squares[99].Coordinate.ToString());
        }

        [Fact]
        public void At_Square_ReturnsSquare()
        {
            Grid grid = new Grid();
            Coordinate coordinate = new Coordinate("A1");

            Square expected = new Square(0, 0);
            Square actual = grid.At(coordinate);

            Assert.Equal(expected.Coordinate, actual.Coordinate);
        }

        [Fact]
        public void LeftOf_SquareNotInFirstColumn_ReturnsSquare()
        {
            Grid grid = new Grid();
            Square square = new Square(1, 0);

            Square expected = new Square(0, 0);
            Square actual = grid.LeftOf(square);

            Assert.Equal(expected.Coordinate, actual.Coordinate);
        }

        [Fact]
        public void LeftOf_SquareInFirstColumn_ThrowsArgumentException()
        {
            Grid grid = new Grid();
            Square square = new Square(0, 0);

            Assert.Throws<ArgumentException>(() => grid.LeftOf(square));
        }

        [Fact]
        public void RightOf_SquareNotInLastColumn_ReturnsSquare()
        {
            Grid grid = new Grid();
            Square square = new Square(8, 0);

            Square expected = new Square(9, 0);
            Square actual = grid.RightOf(square);

            Assert.Equal(expected.Coordinate, actual.Coordinate);
        }

        [Fact]
        public void RightOf_SquareInLastColumn_ThrowsArgumentException()
        {
            Grid grid = new Grid();
            Square square = new Square(9, 0);

            Assert.Throws<ArgumentException>(() => grid.RightOf(square));
        }

        [Fact]
        public void Above_SquareNotInFirstRow_ReturnsSquare()
        {
            Grid grid = new Grid();
            Square square = new Square(0, 1);

            Square expected = new Square(0, 0);
            Square actual = grid.Above(square);

            Assert.Equal(expected.Coordinate, actual.Coordinate);
        }

        [Fact]
        public void Above_SquareInFirstRow_ThrowsArgumentException()
        {
            Grid grid = new Grid();
            Square square = new Square(0, 0);

            Assert.Throws<ArgumentException>(() => grid.Above(square));
        }

        [Fact]
        public void Below_SquareNotInLastRow_ReturnsSquare()
        {
            Grid grid = new Grid();
            Square square = new Square(0, 8);

            Square expected = new Square(0, 9);
            Square actual = grid.Below(square);

            Assert.Equal(expected.Coordinate, actual.Coordinate);
        }

        [Fact]
        public void Below_SquareInLastRow_ThrowsArgumentException()
        {
            Grid grid = new Grid();
            Square square = new Square(0, 9);

            Assert.Throws<ArgumentException>(() => grid.Below(square));
        }
    }
}
