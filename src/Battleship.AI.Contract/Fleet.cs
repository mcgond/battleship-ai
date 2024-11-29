using Battleship.AI.Contract.Constants;

namespace Battleship.AI.Contract
{
    public class Fleet
    {
        private readonly List<Ship> _ships;

        public List<Ship> Ships
        {
            get { return _ships; }
        }

        /// <summary>
        /// Get the ship size of the smallest unsunk ship, or 0 if all ships are sunk
        /// </summary>
        public int SmallestUnsunkShipSize
        {
            get
            {
                int smallestUnsunkShipSize = int.MaxValue;

                foreach (Ship ship in _ships)
                {
                    if (!ship.Sunk && ship.Size < smallestUnsunkShipSize)
                    {
                        smallestUnsunkShipSize = ship.Size;
                    }
                }

                return smallestUnsunkShipSize != int.MaxValue ? smallestUnsunkShipSize : 0;
            }
        }

        public Fleet()
        {
            _ships = new List<Ship>();

            _ships.Add(new Ship(ShipName.AIRCRAFT_CARRIER, ShipSize.FIVE));
            _ships.Add(new Ship(ShipName.BATTLESHIP, ShipSize.FOUR));
            _ships.Add(new Ship(ShipName.SUBMARINE, ShipSize.THREE));
            _ships.Add(new Ship(ShipName.DESTROYER, ShipSize.THREE));
            _ships.Add(new Ship(ShipName.PATROL_BOAT, ShipSize.TWO));
        }
    }
}
