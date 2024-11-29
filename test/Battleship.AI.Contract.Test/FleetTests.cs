using Battleship.AI.Contract.Constants;

namespace Battleship.AI.Contract.Test
{
    public class FleetTests
    {
        [Fact]
        public void Construct_Fleet_ReturnsFleet()
        {
            Fleet fleet = new Fleet();

            Assert.Equal(5, fleet.Ships.Count);
            Assert.Equal(2, fleet.SmallestUnsunkShipSize);
        }

        [Fact]
        public void SmallestUnsunkShipSize_Fleet_UpdatedAfterSinkingSmallestShip()
        {
            Fleet fleet = new Fleet();
            Coordinate firstHit = new Coordinate("C1");
            Coordinate secondHit = new Coordinate("C2");

            Assert.Equal(2, fleet.SmallestUnsunkShipSize);


            Ship ship = fleet.Ships.Where(s => s.Name == ShipName.PATROL_BOAT).First();

            ship.Hit(firstHit);
            ship.Hit(secondHit);

            Assert.Equal(3, fleet.SmallestUnsunkShipSize);
        }

        [Fact]
        public void SmallestUnsunkShipSize_Fleet_ZeroWhenAllShipsSunk()
        {
            Fleet fleet = new Fleet();

            fleet.Ships.Where(s => s.Name == ShipName.PATROL_BOAT).First().Sink();
            fleet.Ships.Where(s => s.Name == ShipName.DESTROYER).First().Sink();
            fleet.Ships.Where(s => s.Name == ShipName.SUBMARINE).First().Sink();
            fleet.Ships.Where(s => s.Name == ShipName.BATTLESHIP).First().Sink();
            fleet.Ships.Where(s => s.Name == ShipName.AIRCRAFT_CARRIER).First().Sink();

            Assert.Equal(0, fleet.SmallestUnsunkShipSize);
        }
    }
}
