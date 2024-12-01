using Battleship.AI.Contract;

namespace Battleship.AI.Engine.Service.Target
{
    public interface ITargetService
    {
        Coordinate GetAttack(Grid grid, Ship shipToSink);
    }
}
