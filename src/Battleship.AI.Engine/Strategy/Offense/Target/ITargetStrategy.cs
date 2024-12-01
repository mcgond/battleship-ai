using Battleship.AI.Contract;

namespace Battleship.AI.Engine.Strategy.Offense.Target
{
    public interface ITargetStrategy
    {
        Coordinate GetAttack(Grid grid, Ship shipToSink);
    }
}
