using Microsoft.Extensions.Logging;

using Battleship.AI.Engine.Service.ScoreCalculation;
using Battleship.AI.Contract;
using Battleship.AI.Contract.Enumeration;

namespace Battleship.AI.Engine.Service.SquareScoreDetermination
{
    public class SquareScoreDeterminationService : ISquareScoreDeterminationService
    {
        private readonly ILogger<SquareScoreDeterminationService> _logger;
        private readonly IScoreCalculationService _scoreCalculationService;

        public SquareScoreDeterminationService(ILogger<SquareScoreDeterminationService> logger,
            IScoreCalculationService scoreCalculationService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _scoreCalculationService = scoreCalculationService ?? throw new ArgumentNullException(nameof(_scoreCalculationService));
        }

        public void DetermineSquareScores(List<Square> squares)
        {
            DetermineHorizontalSquareScores(squares);
            DetermineHorizontalReverseSquareScores(squares);
            DetermineVerticalSquareScores(squares);
            DetermineVerticalReverseSquareScores(squares);

            for (int i = 0; i < squares.Count; i++)
            {
                _scoreCalculationService.Calculate(squares[i].Score);
            }
        }

        private void DetermineHorizontalSquareScores(List<Square> squares)
        {
            int score = 1;
            for (int i = 0; i <= 99; i++)
            {
                // Reset score when starting a new row
                if (squares[i].IsInFirstColumn)
                {
                    score = 1;
                }

                // Assign current score if square is empty and increment
                if (squares[i].State == SquareState.Empty)
                {
                    squares[i].Score.Horizontal = score;
                    score++;
                }
                // Reset score if square has a hit or miss in it
                else
                {
                    score = 1;
                }
            }
        }

        private void DetermineHorizontalReverseSquareScores(List<Square> squares)
        {
            int score = 1;
            for (int i = 99; i >= 0; i--)
            {
                // Reset score when starting a new row (going backwards)
                if (squares[i].IsInLastColumn)
                {
                    score = 1;
                }

                // Assign current score if square is empty and increment
                if (squares[i].State == SquareState.Empty)
                {
                    squares[i].Score.HorizontalReverse = score;
                    score++;
                }
                // Reset score if square has a hit or miss in it
                else
                {
                    score = 1;
                }
            }
        }

        private void DetermineVerticalSquareScores(List<Square> squares)
        {
            int score = 1;
            for (int i = 0; i != 109; i += 10)
            {
                // Reset score when starting a new column
                // The iterator also needs to be adjusted so the next column is started
                if (i > 99)
                {
                    score = 1;
                    i -= 99;
                }

                // Assign current score if square is empty and increment
                if (squares[i].State == SquareState.Empty)
                {
                    squares[i].Score.Vertical = score;
                    score++;
                }
                // Reset score if square has a hit or miss in it
                else
                {
                    score = 1;
                }
            }
        }

        private void DetermineVerticalReverseSquareScores(List<Square> squares)
        {
            int score = 1;
            for (int i = 99; i != -10; i -= 10)
            {
                // Reset score when starting a new column (going backwards)
                // The iterator also needs to be adjusted so the next column is started
                if (i < 0)
                {
                    score = 1;
                    i += 99;
                }

                // Assign current score if square is empty and increment
                if (squares[i].State == SquareState.Empty)
                {
                    squares[i].Score.VerticalReverse = score;
                    score++;
                }
                // Reset score if square has a hit or miss in it
                else
                {
                    score = 1;
                }
            }
        }
    }
}
