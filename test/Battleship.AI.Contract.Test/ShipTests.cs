using Battleship.AI.Contract.Enumeration;

namespace Battleship.AI.Contract.Test
{
    public class ShipTests
    {
        [Fact]
        public void Construct_Ship_ReturnsShip()
        {
            Ship ship = new Ship("ShipName", 3);

            Assert.Equal("ShipName", ship.Name);
            Assert.Equal(3, ship.Size);
            Assert.False(ship.Sunk);
            Assert.Empty(ship.Location);
            Assert.Equal(Orientation.None, ship.Orientation);
        }

        [Fact]
        public void NoOrientation_Ship_ReturnsNoOrientation()
        {
            Ship ship = new Ship("ShipName", 3);

            Assert.Equal(Orientation.None, ship.Orientation);
        }

        [Fact]
        public void UnknownOrientation_Ship_ReturnsUnknownOrientation()
        {
            Ship ship = new Ship("ShipName", 3);
            ship.Hit(new Coordinate("A1"));

            Assert.Equal(Orientation.Unknown, ship.Orientation);
        }

        [Fact]
        public void HorizontalOrientation_Ship_ReturnsHorizontalOrientation()
        {
            Ship ship = new Ship("ShipName", 3);
            ship.Hit(new Coordinate("A1"));
            ship.Hit(new Coordinate("A2"));

            Assert.Equal(Orientation.Horizontal, ship.Orientation);
        }

        [Fact]
        public void VerticalOrientation_Ship_ReturnsVertictalOrientation()
        {
            Ship ship = new Ship("ShipName", 3);
            ship.Hit(new Coordinate("A1"));
            ship.Hit(new Coordinate("B1"));

            Assert.Equal(Orientation.Vertical, ship.Orientation);
        }

        [Fact]
        public void InvalidOrientation_Ship_ThrowsException()
        {
            Ship ship = new Ship("ShipName", 3);
            ship.Hit(new Coordinate("A1"));
            ship.Hit(new Coordinate("B2"));

            Assert.Throws<InvalidOperationException>(() => ship.Orientation);
        }

        [Fact]
        public void Hit_ShipUntilSunk_ReturnsShipIsSunk()
        {
            Ship ship = new Ship("ShipName", 1);
            Coordinate firstHit = new Coordinate("C1");

            Assert.False(ship.Sunk);

            ship.Hit(firstHit);

            Assert.True(ship.Sunk);
        }

        [Fact]
        public void Sink_Ship_ReturnsShipIsSunk()
        {
            Ship ship = new Ship("ShipName", 1);

            ship.Sink();

            Assert.True(ship.Sunk);
        }

        [Fact]
        public void Place_Ship_PlacesShip()
        {
            Ship ship = new Ship("ShipName", 1);

            List<Coordinate> coordinates = new List<Coordinate>();
            coordinates.Add(new Coordinate("A1"));
            ship.Place(coordinates);

            Assert.Single(ship.Location);
            Assert.Equal(new Coordinate("A1"), ship.Location[0]);
        }

        [Fact]
        public void Place_ShipWithInvalidLocation_ThrowsException()
        {
            Ship ship = new Ship("ShipName", 3);

            List<Coordinate> coordinates = new List<Coordinate>();
            coordinates.Add(new Coordinate("A1"));
            coordinates.Add(new Coordinate("A2"));

            Assert.Throws<ArgumentException>(() => ship.Place(coordinates));
        }
    }
}
