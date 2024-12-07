using Microsoft.Extensions.DependencyInjection;

using Battleship.AI.Contract;
using Battleship.AI.Engine.Service.ScoreCalculation;

using Battleship.AI.Engine.Test.Fixture;

namespace Battleship.AI.Engine.Test.Service.ScoreCalculation
{
    [Collection("Engine Collection")]
    public class ScoreCalculationServiceTests
    {
        private EngineFixture _fixture;

        public ScoreCalculationServiceTests(EngineFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Calculate_LowScore_ReturnsScore()
        {
            IScoreCalculationService scoreCalculationService = _fixture.ServiceProvider.GetRequiredService<IScoreCalculationService>();

            Score score = new Score();
            score.Horizontal = 1;
            score.HorizontalReverse = 10;
            score.Vertical = 1;
            score.VerticalReverse = 10;

            scoreCalculationService.Calculate(score);

            Assert.Equal(4, score.Total);
        }

        [Fact]
        public void Calculate_HighScore_ReturnsScore()
        {
            IScoreCalculationService scoreCalculationService = _fixture.ServiceProvider.GetRequiredService<IScoreCalculationService>();

            Score score = new Score();
            score.Horizontal = 5;
            score.HorizontalReverse = 6;
            score.Vertical = 5;
            score.VerticalReverse = 6;

            scoreCalculationService.Calculate(score);

            Assert.True(score.Total == 61 || score.Total == 67);
        }
    }
}
