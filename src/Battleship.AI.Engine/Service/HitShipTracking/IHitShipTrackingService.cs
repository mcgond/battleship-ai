using Battleship.AI.Contract;

namespace Battleship.AI.Engine.Service.HitShipTracking
{
    public interface IHitShipTrackingService
    {
        void TryAddHitShip(Ship ship);

        Ship GetFirstHitShip();

        int GetCountOfHitShips();

        void RemoveFirstHitShip();
    }
}
