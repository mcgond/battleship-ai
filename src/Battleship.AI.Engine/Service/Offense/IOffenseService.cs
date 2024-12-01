using Battleship.AI.Contract;
using Battleship.AI.Engine.Enumeration;

namespace Battleship.AI.Engine.Service.Offense
{
    public interface IOffenseService
    {
        Coordinate GetAttack(Grid grid);

        void HandleAttackResult(Gameboard opponentGameboard, Coordinate attackCoordinate, AttackResult attackResult, Ship hitShip);

    }
}
