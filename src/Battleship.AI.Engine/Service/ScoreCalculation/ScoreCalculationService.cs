using Microsoft.Extensions.Logging;

using Battleship.AI.Contract;

namespace Battleship.AI.Engine.Service.ScoreCalculation
{
    public class ScoreCalculationService : IScoreCalculationService
    {
        private readonly ILogger<ScoreCalculationService> _logger;
        private readonly Random _random;

        public ScoreCalculationService(ILogger<ScoreCalculationService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _random = new Random();
        }

        public void Calculate(Score score)
        {
            score.HorizontalTotal = (score.Horizontal + score.HorizontalReverse) - Math.Abs(score.Horizontal - score.HorizontalReverse);
            score.VerticalTotal = (score.Vertical + score.VerticalReverse) - Math.Abs(score.Vertical - score.VerticalReverse);
            score.Total = score.HorizontalTotal * score.VerticalTotal;

            // The center of the board can get a little biased at the start. Reduce the bias.
            if (score.Total >= 80)
            {
                if (_random.Next(1, 101) < 64)
                {
                    score.Total = 61;
                }
                else
                {
                    score.Total = 67;
                }
            }
        }
    }
}
