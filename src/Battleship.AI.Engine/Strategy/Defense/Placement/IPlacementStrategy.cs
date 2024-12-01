using Battleship.AI.Contract;

namespace Battleship.AI.Engine.Strategy.Defense.Placement
{
    public interface IPlacementStrategy
    {
        void PlaceShips(List<Ship> ships);
    }
}
