using Battleship.AI.Contract;

namespace Battleship.AI.Engine.Service.ShipFit
{
    public interface IShipFitService
    {
        bool DoesShipFitHorizontally(Grid grid, Ship shipToSink);
        bool DoesShipFitVertically(Grid grid, Ship shipToSink);
    }
}
