using Microsoft.Extensions.Logging;

using Battleship.AI.Contract;

namespace Battleship.AI.Engine.Service.HitShipTracking
{
    public class HitShipTrackingService : IHitShipTrackingService
    {
        private readonly ILogger<HitShipTrackingService> _logger;

        private List<Ship> _hitShipsBeingWorkedOn;

        public HitShipTrackingService(ILogger<HitShipTrackingService> logger)
        {
            _logger = logger;

            _hitShipsBeingWorkedOn = new List<Ship>();
        }

        public void TryAddHitShip(Ship ship)
        {
            if (!_hitShipsBeingWorkedOn.Contains(ship))
            {
                _hitShipsBeingWorkedOn.Add(ship);
            }
        }

        public Ship GetFirstHitShip()
        {
            return _hitShipsBeingWorkedOn.First();
        }

        public int GetCountOfHitShips()
        {
            return _hitShipsBeingWorkedOn.Count();
        }

        public void RemoveFirstHitShip()
        {
            _hitShipsBeingWorkedOn.RemoveAt(0);
        }
    }
}
