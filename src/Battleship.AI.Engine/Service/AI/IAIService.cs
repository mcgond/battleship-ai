namespace Battleship.AI.Engine.Service.AI
{
    public interface IAIService
    {
        void StartGame();
        void EndGame();

        string GetAttack();
        void HandleAttackResult(string coordinateString, string attackResultString, string hitShipString);

        List<string> GetAircraftCarrierLocation();
        List<string> GetBattleshipLocation();
        List<string> GetSubmarineLocation();
        List<string> GetDestroyerLocation();
        List<string> GetPatrolBoatLocation();
    }
}
