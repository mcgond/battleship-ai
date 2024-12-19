using Microsoft.Extensions.Logging;

using Battleship.AI.Contract;
using Battleship.AI.Contract.Constants;
using Battleship.AI.Engine.Enumeration;
using Battleship.AI.Engine.Service.Defense;
using Battleship.AI.Engine.Service.Offense;
using Battleship.AI.Engine.Service.SquareScoreDetermination;

namespace Battleship.AI.Engine.Service.AI
{
    public class AIService : IAIService
    {
        private readonly ILogger<AIService> _logger;

        private readonly IOffenseService _offenseService;
        private readonly IDefenseService _defenseService;
        private readonly ISquareScoreDeterminationService _squareScoreDeterminationService;

        private Gameboard _opponentGameBoard;
        private Gameboard _myGameBoard;

        public AIService(ILogger<AIService> logger,
            IOffenseService offenseService,
            IDefenseService defenseService,
            ISquareScoreDeterminationService squareScoreDeterminationService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _offenseService = offenseService ?? throw new ArgumentNullException(nameof(offenseService));
            _defenseService = defenseService ?? throw new ArgumentNullException(nameof(defenseService));
            _squareScoreDeterminationService = squareScoreDeterminationService ?? throw new ArgumentNullException(nameof(squareScoreDeterminationService));

            _opponentGameBoard = new Gameboard();
            _myGameBoard = new Gameboard();
        }

        public void StartGame()
        {
            // Place AI's ships
            _defenseService.PlaceShips(_myGameBoard.Fleet.Ships);

            // Calculate initial square scores
            _squareScoreDeterminationService.DetermineSquareScores(_opponentGameBoard.Grid.Squares);
        }

        public void EndGame()
        {
            // Nothing to do now
        }

        public string GetAttack()
        {
            return _offenseService.GetAttack(_opponentGameBoard.Grid).ToString();
        }

        public void HandleAttackResult(string coordinateString, string attackResultString, string hitShipString)
        {
            // Map coordinate
            Coordinate coordinate = new Coordinate(coordinateString);

            // Map attack result
            AttackResult attackResult = AttackResult.Miss;
            if (attackResultString == "H")
            {
                attackResult = AttackResult.Hit;
            }
            else if (attackResultString == "S")
            {
                attackResult = AttackResult.Sunk;
            }

            // Map Hit Ship
            string hitShip = hitShipString switch
            {
                "A" => ShipName.AIRCRAFT_CARRIER,
                "B" => ShipName.BATTLESHIP,
                "D" => ShipName.DESTROYER,
                "S" => ShipName.SUBMARINE,
                "P" => ShipName.PATROL_BOAT,
                _ => string.Empty
            };

            _offenseService.HandleAttackResult(_opponentGameBoard, coordinate, attackResult, hitShip);
            _squareScoreDeterminationService.DetermineSquareScores(_opponentGameBoard.Grid.Squares);
        }

        public List<string> GetAircraftCarrierLocation()
        {
            return getShipLocation(ShipName.AIRCRAFT_CARRIER);
        }

        public List<string> GetBattleshipLocation()
        {
            return getShipLocation(ShipName.BATTLESHIP);
        }

        public List<string> GetSubmarineLocation()
        {
            return getShipLocation(ShipName.SUBMARINE);
        }

        public List<string> GetDestroyerLocation()
        {
            return getShipLocation(ShipName.DESTROYER);
        }

        public List<string> GetPatrolBoatLocation()
        {
            return getShipLocation(ShipName.PATROL_BOAT);
        }

        private List<string> getShipLocation(string shipName)
        {
            List<string> location = new List<string>();

            List<Coordinate> coordinates = _myGameBoard.Fleet.Ships.Where(s => s.Name == shipName)
                .Single()
                .Location;

            foreach (Coordinate coordinate in coordinates)
            {
                location.Add(coordinate.ToString());
            }

            return location;
        }
    }
}
