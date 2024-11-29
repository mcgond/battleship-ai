namespace Battleship.AI.Contract.Test
{
    public class GameboardTests
    {
        [Fact]
        public void Construct_Gameboard_ReturnsGameboard()
        {
            Gameboard gameboard = new Gameboard();

            Assert.Equal(5, gameboard.Fleet.Ships.Count);
            Assert.Equal(2, gameboard.Fleet.SmallestUnsunkShipSize);

            Assert.Equal(100, gameboard.Grid.Squares.Count);
            Assert.Equal("A1", gameboard.Grid.Squares[0].Coordinate.ToString());
            Assert.Equal("J10", gameboard.Grid.Squares[99].Coordinate.ToString());
        }
    }
}
