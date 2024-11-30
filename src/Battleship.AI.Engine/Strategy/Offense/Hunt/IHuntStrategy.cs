using Battleship.AI.Contract;

namespace Battleship.AI.Engine.Strategy.Offense.Hunt
{
    public interface IHuntStrategy
    {
        Coordinate GetAttack(Grid grid);
    }
}
