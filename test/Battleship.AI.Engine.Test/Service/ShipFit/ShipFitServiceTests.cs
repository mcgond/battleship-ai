using Microsoft.Extensions.DependencyInjection;

using Battleship.AI.Contract;
using Battleship.AI.Contract.Constants;
using Battleship.AI.Contract.Enumeration;
using Battleship.AI.Engine.Service.ShipFit;

using Battleship.AI.Engine.Test.Fixture;

namespace Battleship.AI.Engine.Test.Service.ShipFit
{
    [Collection("Engine Collection")]
    public class ShipFitServiceTests
    {
        private EngineFixture _fixture;

        public ShipFitServiceTests(EngineFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void DoesShipFitHorizontally_ShipThatFits_ReturnsTrue()
        {
            IShipFitService shipFitService = _fixture.ServiceProvider.GetRequiredService<IShipFitService>();

            Grid grid = new Grid();
            grid.At(new Coordinate("A4")).State = SquareState.Miss;

            Ship ship = new Ship("TestShip", ShipSize.THREE);
            ship.Hit(new Coordinate("A2"));

            bool result = shipFitService.DoesShipFitHorizontally(grid, ship);

            Assert.True(result);
        }

        [Fact]
        public void DoesShipFitHorizontally_ShipThatDoesNotFit_ReturnsFalse()
        {
            IShipFitService shipFitService = _fixture.ServiceProvider.GetRequiredService<IShipFitService>();

            Grid grid = new Grid();
            grid.At(new Coordinate("A4")).State = SquareState.Miss;

            Ship ship = new Ship("TestShip", ShipSize.FIVE);
            ship.Hit(new Coordinate("A2"));

            bool result = shipFitService.DoesShipFitHorizontally(grid, ship);

            Assert.False(result);
        }

        [Fact]
        public void DoesShipFitVertically_ShipThatFits_ReturnsTrue()
        {
            IShipFitService shipFitService = _fixture.ServiceProvider.GetRequiredService<IShipFitService>();

            Grid grid = new Grid();
            grid.At(new Coordinate("D1")).State = SquareState.Miss;

            Ship ship = new Ship("TestShip", ShipSize.THREE);
            ship.Hit(new Coordinate("B1"));

            bool result = shipFitService.DoesShipFitVertically(grid, ship);

            Assert.True(result);
        }

        [Fact]
        public void DoesShipFitVertically_ShipThatDoesNotFit_ReturnsFalse()
        {
            IShipFitService shipFitService = _fixture.ServiceProvider.GetRequiredService<IShipFitService>();

            Grid grid = new Grid();
            grid.At(new Coordinate("D1")).State = SquareState.Miss;

            Ship ship = new Ship("TestShip", ShipSize.FIVE);
            ship.Hit(new Coordinate("B1"));

            bool result = shipFitService.DoesShipFitVertically(grid, ship);

            Assert.False(result);
        }
    }
}
