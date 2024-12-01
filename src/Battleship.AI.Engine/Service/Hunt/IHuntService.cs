using Battleship.AI.Contract;

namespace Battleship.AI.Engine.Service.Hunt
{
    public interface IHuntService
    {
        Coordinate GetAttack(Grid grid);
    }
}
