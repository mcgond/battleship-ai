using Microsoft.Extensions.DependencyInjection;

using Battleship.AI.Contract;
using Battleship.AI.Contract.Constants;
using Battleship.AI.Contract.Enumeration;
using Battleship.AI.Engine.Service.Target;

using Battleship.AI.Engine.Test.Fixture;

namespace Battleship.AI.Engine.Test.Service.Target
{
    [Collection("Engine Collection")]
    public class TargetServiceTests
    {
        private EngineFixture _fixture;

        public TargetServiceTests(EngineFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void GetAttack_ShipWithOneHit_ReturnsAttack()
        {
            ITargetService targetService = _fixture.ServiceProvider.GetRequiredService<ITargetService>();

            Ship hitShip = new Ship("ShipName", ShipSize.THREE);
            hitShip.Hit(new Coordinate("A1"));

            Grid grid = new Grid();
            grid.At(new Coordinate("A1")).State = SquareState.Hit;

            Coordinate attackCoordinate = targetService.GetAttack(grid, hitShip);

            Assert.True(attackCoordinate.ToString() == "A2" || attackCoordinate.ToString() == "B1");
        }

        [Fact]
        public void GetAttack_ShipWithTwoHits_ReturnsAttack()
        {
            ITargetService targetService = _fixture.ServiceProvider.GetRequiredService<ITargetService>();

            Ship hitShip = new Ship("ShipName", ShipSize.THREE);
            hitShip.Hit(new Coordinate("A2"));
            hitShip.Hit(new Coordinate("A3"));

            Grid grid = new Grid();
            grid.At(new Coordinate("A2")).State = SquareState.Hit;
            grid.At(new Coordinate("A3")).State = SquareState.Hit;

            Coordinate attackCoordinate = targetService.GetAttack(grid, hitShip);

            Assert.True(attackCoordinate.ToString() == "A1" || attackCoordinate.ToString() == "A4");
        }
    }
}
