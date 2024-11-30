﻿using Microsoft.Extensions.Logging;

using Battleship.AI.Contract;
using Battleship.AI.Contract.Enumeration;

namespace Battleship.AI.Engine.Strategy.Offense.Hunt
{
    public class HighScoreStrategy : IHuntStrategy
    {
        private readonly ILogger<HighScoreStrategy> _logger;
        private readonly Random _random;

        public HighScoreStrategy(ILogger<HighScoreStrategy> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _random = new Random();
        }

        public Coordinate GetAttack(Grid grid)
        {
            _logger.LogDebug("Using IHuntStrategy: HighScoreStrategy");

            List<Square> possibleAttackSquares = grid.Squares.Where(s => s.State == SquareState.Empty)
                .ToList()
                .OrderByDescending(s => s.Score.Total)
                .Take(7)
                .ToList();

            Coordinate attackCoordinate = possibleAttackSquares[_random.Next(possibleAttackSquares.Count)].Coordinate;

            _logger.LogDebug($"Selected coordinate {attackCoordinate} to attack");

            return attackCoordinate;
        }
    }
}