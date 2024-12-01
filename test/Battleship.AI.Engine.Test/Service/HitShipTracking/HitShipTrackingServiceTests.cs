using Microsoft.Extensions.DependencyInjection;

using Battleship.AI.Contract;
using Battleship.AI.Contract.Constants;
using Battleship.AI.Engine.Service.HitShipTracking;

using Battleship.AI.Engine.Test.Fixture;

namespace Battleship.AI.Engine.Test.Service.HitShipTracking
{
    [Collection("Engine Collection")]
    public class HitShipTrackingServiceTests : IDisposable
    {
        private EngineFixture _fixture;

        public HitShipTrackingServiceTests(EngineFixture fixture)
        {
            _fixture = fixture;
        }

        public void Dispose()
        {
            IHitShipTrackingService hitShipTrackingService = _fixture.ServiceProvider.GetRequiredService<IHitShipTrackingService>();

            // Since the hit ships is being tracked "globally" using a Singleton, the instance needs to be reset for each test
            while (hitShipTrackingService.GetCountOfHitShips() > 0)
            {
                hitShipTrackingService.RemoveFirstHitShip();
            }
        }

        [Fact]
        public void TryAddHitShip_ShipNotInList_TrackedShipsContainsOneShip()
        {
            IHitShipTrackingService hitShipTrackingService = _fixture.ServiceProvider.GetRequiredService<IHitShipTrackingService>();

            Ship hitShip = new Ship("TestShip", ShipSize.THREE);

            hitShipTrackingService.TryAddHitShip(hitShip);

            Assert.Equal(1, hitShipTrackingService.GetCountOfHitShips());
        }

        [Fact]
        public void TryAddHitShip_ShipAlreadyInList_TrackedShipsContainsOneShip()
        {
            IHitShipTrackingService hitShipTrackingService = _fixture.ServiceProvider.GetRequiredService<IHitShipTrackingService>();

            Ship hitShip = new Ship("TestShip", ShipSize.THREE);

            hitShipTrackingService.TryAddHitShip(hitShip);
            hitShipTrackingService.TryAddHitShip(hitShip);

            Assert.Equal(1, hitShipTrackingService.GetCountOfHitShips());
        }

        [Fact]
        public void GetFirstHitShip_ShipInList_ReturnsFirstHitShip()
        {
            IHitShipTrackingService hitShipTrackingService = _fixture.ServiceProvider.GetRequiredService<IHitShipTrackingService>();

            Ship firstHitShip = new Ship("FirstHitShip", ShipSize.THREE);
            Ship secondHitShip = new Ship("SecondHitShip", ShipSize.THREE);

            hitShipTrackingService.TryAddHitShip(firstHitShip);
            hitShipTrackingService.TryAddHitShip(secondHitShip);

            Ship actualFirstHitShip = hitShipTrackingService.GetFirstHitShip();

            Assert.Equal("FirstHitShip", actualFirstHitShip.Name);
        }

        [Fact]
        public void GetCountOfHitShips_OneShipInList_ReturnsOne()
        {
            IHitShipTrackingService hitShipTrackingService = _fixture.ServiceProvider.GetRequiredService<IHitShipTrackingService>();

            Ship hitShip = new Ship("TestShip", ShipSize.THREE);

            hitShipTrackingService.TryAddHitShip(hitShip);

            int actual = hitShipTrackingService.GetCountOfHitShips();

            Assert.Equal(1, actual);
        }

        [Fact]
        public void RemoveFirstHitShip_TwoShipsInList_FirstHitShipRemoved()
        {
            IHitShipTrackingService hitShipTrackingService = _fixture.ServiceProvider.GetRequiredService<IHitShipTrackingService>();

            Ship firstHitShip = new Ship("FirstHitShip", ShipSize.THREE);
            Ship secondHitShip = new Ship("SecondHitShip", ShipSize.THREE);

            hitShipTrackingService.TryAddHitShip(firstHitShip);
            hitShipTrackingService.TryAddHitShip(secondHitShip);

            hitShipTrackingService.RemoveFirstHitShip();

            Ship actualHitShip = hitShipTrackingService.GetFirstHitShip();

            Assert.Equal("SecondHitShip", actualHitShip.Name);
        }
    }
}
