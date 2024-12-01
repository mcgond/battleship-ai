using Microsoft.Extensions.DependencyInjection;

using Battleship.AI.Contract;
using Battleship.AI.Engine.Strategy.Defense.Placement;

using Battleship.AI.Engine.Test.Fixture;

namespace Battleship.AI.Engine.Test.Strategy.Defense.Placement
{
    [Collection("Engine Collection")]
    public class RandomPlacementStrategyTests
    {
        private EngineFixture _fixture;

        public RandomPlacementStrategyTests(EngineFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Place_Ships_ReturnsPlacedShips()
        {
            RandomPlacementStrategy randomPlacementStrategy = _fixture.ServiceProvider.GetRequiredService<RandomPlacementStrategy>();

            Fleet fleet = new Fleet();

            randomPlacementStrategy.PlaceShips(fleet.Ships);

            Assert.Equal(5, fleet.Ships.Count);
            Assert.NotEmpty(fleet.Ships[0].Location);
            Assert.NotEmpty(fleet.Ships[1].Location);
            Assert.NotEmpty(fleet.Ships[2].Location);
            Assert.NotEmpty(fleet.Ships[3].Location);
            Assert.NotEmpty(fleet.Ships[4].Location);
        }
    }
}
