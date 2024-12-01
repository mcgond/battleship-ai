using Battleship.AI.Contract;

namespace Battleship.AI.Engine.Service.Defense
{
    public interface IDefenseService
    {
        void PlaceShips(List<Ship> ships);
    }
}
